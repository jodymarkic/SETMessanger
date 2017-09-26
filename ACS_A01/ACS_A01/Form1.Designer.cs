namespace ACS_A01
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClientRadioButton = new System.Windows.Forms.RadioButton();
            this.ServerRadioButton = new System.Windows.Forms.RadioButton();
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.PortNumberLabel = new System.Windows.Forms.Label();
            this.IPAddressTextbox = new System.Windows.Forms.TextBox();
            this.PortNumberTextbox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.SendEncryptedButton = new System.Windows.Forms.Button();
            this.MessageSendTextbox = new System.Windows.Forms.TextBox();
            this.MessageRecievedTextbox = new System.Windows.Forms.TextBox();
            this.ConfirmConnectionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClientRadioButton
            // 
            this.ClientRadioButton.AutoSize = true;
            this.ClientRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientRadioButton.Location = new System.Drawing.Point(13, 13);
            this.ClientRadioButton.Name = "ClientRadioButton";
            this.ClientRadioButton.Size = new System.Drawing.Size(65, 20);
            this.ClientRadioButton.TabIndex = 1;
            this.ClientRadioButton.Text = "Client";
            this.ClientRadioButton.UseVisualStyleBackColor = true;
            this.ClientRadioButton.CheckedChanged += new System.EventHandler(this.ClientRadioButton_CheckedChanged);
            // 
            // ServerRadioButton
            // 
            this.ServerRadioButton.AutoSize = true;
            this.ServerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerRadioButton.Location = new System.Drawing.Point(13, 37);
            this.ServerRadioButton.Name = "ServerRadioButton";
            this.ServerRadioButton.Size = new System.Drawing.Size(72, 20);
            this.ServerRadioButton.TabIndex = 2;
            this.ServerRadioButton.Text = "Server";
            this.ServerRadioButton.UseVisualStyleBackColor = true;
            this.ServerRadioButton.CheckedChanged += new System.EventHandler(this.ServerRadioButton_CheckedChanged);
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.AutoSize = true;
            this.IPAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPAddressLabel.Location = new System.Drawing.Point(94, 17);
            this.IPAddressLabel.Name = "IPAddressLabel";
            this.IPAddressLabel.Size = new System.Drawing.Size(84, 16);
            this.IPAddressLabel.TabIndex = 3;
            this.IPAddressLabel.Text = "IP Address";
            // 
            // PortNumberLabel
            // 
            this.PortNumberLabel.AutoSize = true;
            this.PortNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortNumberLabel.Location = new System.Drawing.Point(94, 41);
            this.PortNumberLabel.Name = "PortNumberLabel";
            this.PortNumberLabel.Size = new System.Drawing.Size(36, 16);
            this.PortNumberLabel.TabIndex = 4;
            this.PortNumberLabel.Text = "Port";
            // 
            // IPAddressTextbox
            // 
            this.IPAddressTextbox.Enabled = false;
            this.IPAddressTextbox.Location = new System.Drawing.Point(184, 14);
            this.IPAddressTextbox.Name = "IPAddressTextbox";
            this.IPAddressTextbox.Size = new System.Drawing.Size(100, 20);
            this.IPAddressTextbox.TabIndex = 5;
            // 
            // PortNumberTextbox
            // 
            this.PortNumberTextbox.Enabled = false;
            this.PortNumberTextbox.Location = new System.Drawing.Point(184, 41);
            this.PortNumberTextbox.Name = "PortNumberTextbox";
            this.PortNumberTextbox.Size = new System.Drawing.Size(100, 20);
            this.PortNumberTextbox.TabIndex = 6;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.Location = new System.Drawing.Point(516, 26);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(118, 25);
            this.UserNameLabel.TabIndex = 7;
            this.UserNameLabel.Text = "Username";
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Enabled = false;
            this.UsernameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextbox.Location = new System.Drawing.Point(640, 23);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(199, 31);
            this.UsernameTextbox.TabIndex = 8;
            this.UsernameTextbox.TextChanged += new System.EventHandler(this.UsernameTextbox_TextChanged);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButton.Location = new System.Drawing.Point(689, 356);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(150, 76);
            this.SendButton.TabIndex = 9;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // SendEncryptedButton
            // 
            this.SendEncryptedButton.Enabled = false;
            this.SendEncryptedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendEncryptedButton.Location = new System.Drawing.Point(689, 438);
            this.SendEncryptedButton.Name = "SendEncryptedButton";
            this.SendEncryptedButton.Size = new System.Drawing.Size(150, 76);
            this.SendEncryptedButton.TabIndex = 10;
            this.SendEncryptedButton.Text = "Send Encrypted";
            this.SendEncryptedButton.UseVisualStyleBackColor = true;
            this.SendEncryptedButton.Click += new System.EventHandler(this.SendEncryptedButton_Click);
            // 
            // MessageSendTextbox
            // 
            this.MessageSendTextbox.Enabled = false;
            this.MessageSendTextbox.Location = new System.Drawing.Point(13, 356);
            this.MessageSendTextbox.Multiline = true;
            this.MessageSendTextbox.Name = "MessageSendTextbox";
            this.MessageSendTextbox.Size = new System.Drawing.Size(655, 159);
            this.MessageSendTextbox.TabIndex = 11;
            // 
            // MessageRecievedTextbox
            // 
            this.MessageRecievedTextbox.Enabled = false;
            this.MessageRecievedTextbox.Location = new System.Drawing.Point(13, 74);
            this.MessageRecievedTextbox.Multiline = true;
            this.MessageRecievedTextbox.Name = "MessageRecievedTextbox";
            this.MessageRecievedTextbox.ReadOnly = true;
            this.MessageRecievedTextbox.Size = new System.Drawing.Size(826, 260);
            this.MessageRecievedTextbox.TabIndex = 12;
            // 
            // ConfirmConnectionButton
            // 
            this.ConfirmConnectionButton.Enabled = false;
            this.ConfirmConnectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmConnectionButton.Location = new System.Drawing.Point(290, 12);
            this.ConfirmConnectionButton.Name = "ConfirmConnectionButton";
            this.ConfirmConnectionButton.Size = new System.Drawing.Size(100, 49);
            this.ConfirmConnectionButton.TabIndex = 13;
            this.ConfirmConnectionButton.Text = "Confirm";
            this.ConfirmConnectionButton.UseVisualStyleBackColor = true;
            this.ConfirmConnectionButton.Click += new System.EventHandler(this.ConfirmConnectionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(859, 527);
            this.Controls.Add(this.ConfirmConnectionButton);
            this.Controls.Add(this.MessageRecievedTextbox);
            this.Controls.Add(this.MessageSendTextbox);
            this.Controls.Add(this.SendEncryptedButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.PortNumberTextbox);
            this.Controls.Add(this.IPAddressTextbox);
            this.Controls.Add(this.PortNumberLabel);
            this.Controls.Add(this.IPAddressLabel);
            this.Controls.Add(this.ServerRadioButton);
            this.Controls.Add(this.ClientRadioButton);
            this.Name = "Form1";
            this.Text = "Encrypted Chat Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ClientRadioButton;
        private System.Windows.Forms.RadioButton ServerRadioButton;
        private System.Windows.Forms.Label IPAddressLabel;
        private System.Windows.Forms.Label PortNumberLabel;
        private System.Windows.Forms.TextBox IPAddressTextbox;
        private System.Windows.Forms.TextBox PortNumberTextbox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button SendEncryptedButton;
        private System.Windows.Forms.TextBox MessageSendTextbox;
        private System.Windows.Forms.TextBox MessageRecievedTextbox;
        private System.Windows.Forms.Button ConfirmConnectionButton;
    }
}

