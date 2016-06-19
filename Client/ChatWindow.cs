using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Common;
using ServerSide;
using System.Net;

namespace ClientSide
{
    public partial class ChatWindow : Form
    {
        LoginClient loginC= new LoginClient();
        ChatMessage MyInfo = null;

        public ChatWindow()
        {
            InitializeComponent();
            
            loginC.Activate();
            richTxtbxChat.Font = new Font("Arial", 10);
            ClientMethods.EventMsgDialog += new Action<string>(text => MessageBox.Show(text));
            ClientMethods.EventServer += new Action<ChatMessage>(Write2Chat);
            ClientMethods.EventSetButtons += new Action(SetButtons);
            ClientMethods.EventRegisterQuestion += new Func<bool>(RegisterBox);
        }
        private void ChatWindow_Load(object sender, EventArgs e)
        {
            //tests
            //MessageBox.Show(loginC.IPAddress.ToString());
            //MessageBox.Show(loginC.Port.ToString());
            //MessageBox.Show(loginC.Username.ToString());
            //MessageBox.Show(loginC.Nickname.ToString());
            //MessageBox.Show(loginC.color.ToString());

            this.txtbxMessage.Focus();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //tests
            MessageBox.Show("ip ="+ loginC.IPAddress+", port ="+ loginC.Port+", username =" +loginC.Username+", color ="+ loginC.color+", fullname =" +loginC.Nickname);

            MyInfo = new ChatMessage { ip = loginC.IPAddress, port = loginC.Port, username = loginC.Username, color = loginC.color, fullname = loginC.Nickname};
            //MyInfo = new ChatMessage { ip = loginC.IPAddress, port = loginC.Port, username = loginC.Username, color = Color.FromName("Black"), fullname = loginC.Nickname };
            //MyInfo = new ChatMessage { ip = loginC.IPAddress, port = loginC.Port, username = loginC.Username, fullname = loginC.Nickname };

            try
            {
                ClientMethods.Connect(MyInfo);
            }
            //test
            catch (Exception)
            {
                MessageBox.Show("Client failed to connect");
            }
            this.txtbxMessage.Focus();
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                ClientMethods.Disconnect();
                MyInfo = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Client failed to disconnect");
            }
            
        }
        public void SetButtons()
        {
            this.Invoke(new Action(() =>
            {
                if (btnConnect.Enabled)
                {
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                }
                else 
                { 
                    btnConnect.Enabled = true; 
                    btnDisconnect.Enabled = false;
                }
            }
               ));
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if ((txtbxMessage.TextLength > 0) && (MyInfo != null))
            {
                MyInfo.message = txtbxMessage.Text;
                try
                {
                    ClientMethods.SendMessage(MyInfo);
                }
                //test
                catch (Exception)
                {
                    MessageBox.Show("Serialization failed");
                }
                txtbxMessage.ResetText();
            }
        }

        public bool RegisterBox()
        {
            DialogResult result = MessageBox.Show(MyInfo.fullname + " is not registerd, you must register to connect", "Register User", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK) { return true; }
            else { return false; }
        }

        public void Write2Chat(ChatMessage ServerInfo)
        {
            //test
            //MessageBox.Show(ServerInfo.sender);

            if (ServerInfo.sender == "ServerSide")
            {
                this.Invoke(new Action(() =>
                {
                    richTxtbxChat.SelectionStart = richTxtbxChat.Text.Length;
                    richTxtbxChat.SelectionColor = Color.DarkSlateGray;
                    richTxtbxChat.SelectedText = "       >>> Server: " + ServerInfo.message + "\n";
                }
                ));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    richTxtbxChat.SelectionStart = richTxtbxChat.Text.Length;
                    //richTxtbxChat.SelectionColor = ServerInfo.color;
                    //richTxtbxChat.SelectedText = ServerInfo.fullname + " said:\n   " + ServerInfo.message + "\n";
                    richTxtbxChat.SelectedText = ServerInfo.fullname + " said:\n   " + ServerInfo.message + "\n";
                }
                        ));
            }
        }

        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
