/*
 *  FILENAME:  Form1.cs
 *  PROJECT: ACS_A01
 *  PROGRAMMER: Jody Markic and Leveson Cocarell
 *  FIRST VERSION: 3/27/2017
 *  DESCRIPTION: This file holds a simple chat program that sends messages over the network
 *               via a TCP/IP socket protocol. This chat program has additionally functionality
 *               of encrypting and decrypting send and recieved messages.
 */
using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ACS_A01
{
    //
    //  METHOD: Form1 : Form
    //  DESCRIPTION: This Class holds all logic associated with the ACS_A01 project's UI
    //               including Event handlers, User Input and Validation.
    //
    public partial class Form1 : Form
    {
        //blow fish encryption key
        static string EKey = "6dc80611-8713-4417-be68-dcc7c8ce5a23";
        //Blowfish object
        BlowFish BFish;
        const int IPv4 = 3;
        private string serverIP;
        //Server listener socket
        Socket serverSocket = null;
        //Server Sender Reciever Socket
        Socket serverAcceptSocket = null;
        Socket clientSocket = null;
        Thread readerThread = null;
        IPAddress ipAddress = null;
        IPEndPoint EndPoint = null;


        //
        //  METHOD: Form1()
        //  DESCRIPTION: Constructor
        //  PARAMETERS: na
        //  RETURNS: na
        //
        public Form1()
        {
            //initialize window form
            InitializeComponent();
            //create blowfish object with a key
            BFish = new BlowFish(EKey);
        }

        //
        //  METHOD: ServerSetIP()
        //  DESCRIPTION: This method gets a local machines IP
        //  PARAMETERS: na
        //  RETURNS: void
        //
        private void ServerSetIP()
        {
            //gather the local machine host name
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            //use to convert into an ipEntry
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            //gather the local machines ip address
            IPAddress[] addr = ipEntry.AddressList;
            serverIP = addr[IPv4].ToString();
        }

        //
        //  METHOD: ReaderLoop()
        //  DESCRIPTION: main listener loop to recieve incoming messages
        //  PARAMETERS: na
        //  RETURNS: void
        //
        private void ReaderLoop()
        {
            //create a byte array buffer
            byte[] byteMessageBuffer = new byte[1024];
            string RecievedMessage = "";
            int bytesRead = 0;

            //main listening loop
            while (true)
            {
                //check if were a client
                if (ClientRadioButton.Enabled)
                {
                    //recieve message on the client socket
                    bytesRead = clientSocket.Receive(byteMessageBuffer);
                }
                //check if were a server
                else if (ServerRadioButton.Enabled)
                {
                    //recieve messages on the server socket
                    bytesRead = serverAcceptSocket.Receive(byteMessageBuffer);
                }

                //convert the recieved message from a byte array into a string
                RecievedMessage = Encoding.ASCII.GetString(byteMessageBuffer, 0, bytesRead);

                //check if the recieved message has our delimiter
                //if no delimiter the message has been encrypted
                if (!(RecievedMessage.Contains("|")))
                {
                    //display the encrypted message
                    displayMessage(RecievedMessage);
                    //decrypt the message
                    RecievedMessage = BFish.Decrypt_CBC(RecievedMessage);
                    //split the payload into flag | username | message
                    string[] messagePart = RecievedMessage.Split('|');
                    //display the sender username
                    displayUsername(messagePart[1]);
                    //display the recieved message
                    displayMessage(messagePart[2]);

                }
                //otherwise the message isn't encrypted
                else
                {
                    //split the payload into flag | username | message
                    string[] messagePart = RecievedMessage.Split('|');
                    //display the sender username
                    displayUsername(messagePart[1]);
                    //display the recieved message
                    displayMessage(messagePart[2]);
                }

                //ADD ADDITIONAL DISCONNECT FUNCTIONALITY
            }
        }

        //
        //  METHOD: displayUsername()
        //  DESCRIPTION: Allows a thread to access the UI's MessageRecievedTextbox object and write to it
        //  PARAMETERS: string username
        //  RETURNS: void
        //
        private void displayUsername(string username)
        {
            //check if this thread needs to access UI elements safely
            if (this.InvokeRequired)
            {
                //write the username to the MessageRecievedTextbox
                this.Invoke(new Action<string>(displayMessage), new object[] { username + " Says :" });

            }
            else //if the thread is accesses UI elements safely already
            {
                //write the username to the MessageRecievedTextbox
                MessageRecievedTextbox.AppendText(username + " Says : ");
            }
        }

        //
        //  METHOD: displayMessage()
        //  DESCRIPTION:  Allows a thread to access the UI's MessageRecievedTextbox object and write to it
        //  PARAMETERS: string recievedMessage
        //  RETURNS: void
        //
        private void displayMessage(string recievedMessage)
        {

            //check if this thread needs to access UI elements safely
            if (this.InvokeRequired)
            {
                //write the messafe to the MessageRecievedTextbox
                this.Invoke(new Action<string>(displayMessage), new object[] { recievedMessage });
            }
            else //if the thread is accesses UI elements safely already
            {
                //write the message to the MessageRecievedTextbox
                MessageRecievedTextbox.AppendText(recievedMessage + Environment.NewLine);
            }
        }

        //
        //  METHOD: ClientRadioButton_CheckedChanged()
        //  DESCRIPTION: Event handle for the UI ClientRadioButton object
        //  PARAMETERS: (object sender, EventArgs e
        //  RETURNS: void
        //
        private void ClientRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //disable and enable aspects of the UI
            ServerRadioButton.Enabled = false;
            IPAddressTextbox.Enabled = true;
            PortNumberTextbox.Enabled = true;
            ConfirmConnectionButton.Enabled = true;
        }

        //
        //  METHOD: ServerRadioButton_CheckedChanged()
        //  DESCRIPTION: Event handle for the UI ServerRadioButton object
        //  PARAMETERS: object sender, EventArgs e
        //  RETURNS: void
        //
        private void ServerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //disable and enable aspects of the UI
            ClientRadioButton.Enabled = false;
            PortNumberTextbox.Enabled = true;
            ConfirmConnectionButton.Enabled = true;
        }


        //
        //  METHOD: ConfirmConnectionButton_Click()
        //  DESCRIPTION: Event handle for the UI  ConfirmConnectionButton object
        //  PARAMETERS: object sender, EventArgs e
        //  RETURNS: void
        //
        private void ConfirmConnectionButton_Click(object sender, EventArgs e)
        {
            //check if the were a Server
            if (ServerRadioButton.Checked)
            {
                //Gather and set he ServerIP to a string
                ServerSetIP();

                int port = 0;
                //check that the user has written something within the portNumber and that it's of integer format
                if ((PortNumberTextbox.Text.Length != 0) && (int.TryParse(PortNumberTextbox.Text, out port)))
                {
                    //Convert the serverIP string into an IPAddress object
                    ipAddress = IPAddress.Parse(serverIP);
                    //create an IPEndPoint object with the IPAddress object and the port number
                    EndPoint = new IPEndPoint(ipAddress, port);

                    //create a server Socket
                    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //bind the server socket to the endpoint
                    serverSocket.Bind(EndPoint);
                    //set that socket to listen on that endpoint
                    serverSocket.Listen(1);
                    //create another server socket that accepts incoming and outgoing messages
                    serverAcceptSocket = serverSocket.Accept();

                    //start a listening thread to actively accept incoming message
                    readerThread = new Thread(ReaderLoop);
                    //start the thread
                    readerThread.Start();

                    //disable and enable aspects of the UI
                    UsernameTextbox.Enabled = true;
                    PortNumberTextbox.Enabled = false;
                    ConfirmConnectionButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please Ensure You've entered a Valid Port Number!");
                }
            }
            //check if the were a Client
            else if (ClientRadioButton.Checked)
            {
                int port = 0;
                //check that the user has written something within the portNumber and that it's of integer format
                if ((IPAddressTextbox.Text.Length != 0) && (int.TryParse(PortNumberTextbox.Text, out port)))
                {
                    IPAddress ipAddress;
                    //try and parse user input for the IPAddressTextbox into a IPAddress object
                    if (IPAddress.TryParse(IPAddressTextbox.Text, out ipAddress))
                    {
                        //create a client socket
                        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        //connect the client socket to an enpoint at that address
                        clientSocket.Connect(ipAddress, port);

                        //start a listening thread to actively accept incoming message
                        readerThread = new Thread(ReaderLoop);
                        //start the thread
                        readerThread.Start();

                        //disable and enable aspects of the UI
                        UsernameTextbox.Enabled = true;
                        IPAddressTextbox.Enabled = false;
                        PortNumberTextbox.Enabled = false;
                        ConfirmConnectionButton.Enabled = false;
                    }
                    else
                    {
                        //Let user know if we setup an endpoint corrected
                        //enable the username stuff
                    }
                }
                else
                {
                    //Display message if user inputs are incorrect for IP or Port
                    MessageBox.Show("Please Ensure You've entered a valid IP and Port Number!");
                }
            }
        }

        //
        //  METHOD: UsernameTextbox_TextChanged()
        //  DESCRIPTION: Event handle for the UI  UsernameTextbox object
        //  PARAMETERS: object sender, EventArgs e
        //  RETURNS: void
        //
        private void UsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            //Check if user has entered a username
            if (UsernameTextbox.Text.Length != 0)
            {
                //disable and enable aspects of the UI
                MessageRecievedTextbox.Enabled = true;
                MessageSendTextbox.Enabled = true;
                SendButton.Enabled = true;
                SendEncryptedButton.Enabled = true;
            }
            else //if not user name is selected
            {
                //disable and enable aspects of the UI
                MessageRecievedTextbox.Enabled = false;
                MessageSendTextbox.Enabled = false;
                SendButton.Enabled = true;
                SendEncryptedButton.Enabled = true;
            }
        }

        //
        //  METHOD: SendButton_Click()
        //  DESCRIPTION: Event handle for the UI SendButton object
        //  PARAMETERS: object sender, EventArgs e
        //  RETURNS: void
        //
        private void SendButton_Click(object sender, EventArgs e)
        {
            //check if user has entered in text in the MessageSendTextbox
            if (MessageSendTextbox.Text.Length != 0)
            {
                //enable aspects of the UI
                SendButton.Enabled = true;
                SendEncryptedButton.Enabled = true;

                //append our flag and sender username to message
                string message = "0|" + UsernameTextbox.Text + "|" + MessageSendTextbox.Text;

                //convert string to a byte array
                byte[] SendMessage = Encoding.ASCII.GetBytes(message);
                //check if were a client
                if (ClientRadioButton.Enabled)
                {
                    //use the client socket to send the message
                    clientSocket.Send(SendMessage);

                    //display message being sent
                    displayUsername(UsernameTextbox.Text);
                    displayMessage(MessageSendTextbox.Text);

                }
                //check if were a server
                else if (ServerRadioButton.Enabled)
                {
                    //user the server socket to send the message
                    serverAcceptSocket.Send(SendMessage);

                    //display message being sent
                    displayUsername(UsernameTextbox.Text);
                    displayMessage(MessageSendTextbox.Text);
                }
            }
            else
            {
                //if user doesn't write a message down display this error message
                MessageBox.Show("Please enter some text to send!");
            }
        }

        //
        //  METHOD: SendEncryptedButton_Click()
        //  DESCRIPTION: Event handle for the UI SendEncryptedButton object
        //  PARAMETERS: object sender, EventArgs e
        //  RETURNS: void
        //
        private void SendEncryptedButton_Click(object sender, EventArgs e)
        {
            //check if user has entered in text in the MessageSendTextbox
            if (MessageSendTextbox.Text.Length != 0)
            {
                //enable aspects of the UI
                SendButton.Enabled = true;
                SendEncryptedButton.Enabled = true;

                //append our flag and sender username to message
                string message = "1|" + UsernameTextbox.Text + "|" + MessageSendTextbox.Text;
                //encrypt message
                message = BFish.Encrypt_CBC(message);
                //convert string to a byte array
                byte[] SendMessage = Encoding.ASCII.GetBytes(message);
                //check if were a client
                if (ClientRadioButton.Enabled)
                {
                    //use the client socket to send the encrypted message
                    clientSocket.Send(SendMessage);
                    //display the encrypted message
                    displayMessage(message);
                    //display the decrypted version of the sent
                    displayUsername(UsernameTextbox.Text);
                    displayMessage(MessageSendTextbox.Text);

                }
                //check if were a server
                else if (ServerRadioButton.Enabled)
                {
                    //use the server socket to send the encrypted message
                    serverAcceptSocket.Send(SendMessage);

                    //display the encrypted message sent
                    displayMessage(message);
                    //display the decrypted version of the sent
                    displayUsername(UsernameTextbox.Text);
                    displayMessage(MessageSendTextbox.Text);
                }
            }
            else
            {
                //if user doesn't write a message down display this error message
                MessageBox.Show("Please enter some text to send!");
            }
        }
    }
}
