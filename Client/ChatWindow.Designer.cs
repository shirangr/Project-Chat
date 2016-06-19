namespace ClientSide
{
    partial class ChatWindow
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtbxMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.grpbxMessages = new System.Windows.Forms.GroupBox();
            this.richTxtbxChat = new System.Windows.Forms.RichTextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.grpbxMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(16, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(124, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtbxMessage
            // 
            this.txtbxMessage.Location = new System.Drawing.Point(16, 283);
            this.txtbxMessage.Name = "txtbxMessage";
            this.txtbxMessage.Size = new System.Drawing.Size(319, 20);
            this.txtbxMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(360, 280);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // grpbxMessages
            // 
            this.grpbxMessages.Controls.Add(this.richTxtbxChat);
            this.grpbxMessages.Controls.Add(this.btnDisconnect);
            this.grpbxMessages.Controls.Add(this.btnConnect);
            this.grpbxMessages.Controls.Add(this.txtbxMessage);
            this.grpbxMessages.Controls.Add(this.btnSend);
            this.grpbxMessages.Location = new System.Drawing.Point(12, 12);
            this.grpbxMessages.Name = "grpbxMessages";
            this.grpbxMessages.Size = new System.Drawing.Size(464, 322);
            this.grpbxMessages.TabIndex = 4;
            this.grpbxMessages.TabStop = false;
            this.grpbxMessages.Text = "Messages";
            // 
            // richTxtbxChat
            // 
            this.richTxtbxChat.Location = new System.Drawing.Point(16, 48);
            this.richTxtbxChat.Name = "richTxtbxChat";
            this.richTxtbxChat.ReadOnly = true;
            this.richTxtbxChat.Size = new System.Drawing.Size(419, 226);
            this.richTxtbxChat.TabIndex = 4;
            this.richTxtbxChat.TabStop = false;
            this.richTxtbxChat.Text = "";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(146, 19);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(124, 23);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 347);
            this.Controls.Add(this.grpbxMessages);
            this.Name = "ChatWindow";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.grpbxMessages.ResumeLayout(false);
            this.grpbxMessages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtbxMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox grpbxMessages;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.RichTextBox richTxtbxChat;
    }
}

