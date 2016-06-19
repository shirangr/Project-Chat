using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace ClientSide
{
    public partial class LoginClient : Form
    {
        #region ClientVals:
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Nickname
        {
            get { return this.txtbxNickName.Text; }
        }
        public Color color { get; set; }
        #endregion

        public LoginClient()
        {
            InitializeComponent();

            this.IPAddress = txtbxIP.Text;
            this.Port = (int)numericPort.Value;
            //this.Nickname = this.txtbxNickName.Text;
            this.Username = System.Environment.MachineName;
            this.color = Color.FromName(cbxColor.Text);
            
            //tests
            //MessageBox.Show(this.IPAddress + " " + this.Port + " " + this.Nickname + " " + this.Username + " " + this.color);
        }

        private bool ValidateIpAddress()
        {
            //This function checks validation of IP Address
            bool no_error = true;

            epIP.Clear(); // Clear all Error Messages
            if (string.IsNullOrWhiteSpace(this.IPAddress))
            {
                epIP.SetError(txtbxIP, "Please Enter ip address");
                no_error = false;
            }
            else
            {
                Regex numberchk = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                if (numberchk.IsMatch(this.IPAddress))
                {
                    epIP.SetError(txtbxIP, "");
                }

                else
                {
                    epIP.Clear(); // Clear all Error Messages
                    epIP.SetError(txtbxIP, "Please Enter a valid ip address");
                    no_error = false;
                }
            }
            return no_error;
        }

        private bool ValidatePort()
        {
            //This function checks validation of Port
            bool no_error = true;

            epPort.Clear(); // Clear all Error Messages
            if (string.IsNullOrWhiteSpace(this.numericPort.Text))
            {
                epPort.SetError(numericPort, "Please Enter Port");
                no_error = false;
            }
            else
            {
                epPort.SetError(numericPort, "");
            }
            return no_error;
        }

        private bool ValidateNickname()
        {
            //This function checks validation of Nickname
            bool no_error = true;

            epNickname.Clear(); // Clear all Error Messages
            if (string.IsNullOrWhiteSpace(this.Nickname))
            {
                epNickname.SetError(txtbxNickName, "Please Enter NickName");
                no_error = false;
            }
            else
            {
                epNickname.SetError(txtbxNickName, "");
            }
            return no_error;
        }

        private bool ValidateColor()
        {
            //This function checks validation of Color
            bool no_error = true;
            epColor.Clear(); // Clear all Error Messages
            if (string.IsNullOrWhiteSpace(this.cbxColor.Text))
            {
                epColor.SetError(cbxColor, "Please Choose color");
                no_error = false;
            }
            else
            {
                epColor.SetError(cbxColor, "");
            }
            return no_error;
        }

        private void cbxColor_DropDown(object sender, EventArgs e)
        {
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                    this.cbxColor.Items.Add(prop.Name);
            }
        }

        private void txtbxIP_Validating(object sender, CancelEventArgs e)
        {
            ValidateIpAddress();
        }

        private void numericPort_Validating(object sender, CancelEventArgs e)
        {
            ValidatePort();
        }

        private void txtbxNickName_Validating(object sender, CancelEventArgs e)
        {
            ValidateNickname();
        }

        private void cbxColor_Validating(object sender, CancelEventArgs e)
        {
            ValidateColor();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //validation
                if (ValidateIpAddress() && ValidatePort() && ValidateNickname() && ValidateColor())
                {
                    this.IPAddress = txtbxIP.Text;
                    this.Port = (int)numericPort.Value;
                    //this.Nickname = this.txtbxNickName.Text;
                    this.color = Color.FromName(cbxColor.Text);

                    //tests
                    MessageBox.Show(this.IPAddress + " " + this.Port + " " + this.Nickname + " " + this.Username + " " + this.color);

                    this.Hide();
                    //opening chat window
                    ChatWindow Chat = new ChatWindow();
                    Chat.Show();
                }
            }
            //tests
            catch (Exception)
            {
                
                MessageBox.Show("Validation of client failed");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void LoginClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

    }
}
