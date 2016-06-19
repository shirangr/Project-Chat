using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSide
{
    public partial class LoginServer : Form
    {
        #region ServerVals:
        public string IPAddress
        {
            get { return txtbxIP2.Text; }
        }

        public int Port
        {
            get { return (int)numericPort2.Value; }
        }
        #endregion

        public LoginServer()
        {
            InitializeComponent();
        }

        private bool ValidateIpAddress()
        {
            //This function checks validation of IP Address
            bool no_error = true;
            epIP.Clear(); // Clear all Error Messages
            if (string.IsNullOrWhiteSpace(this.IPAddress))
            {
                epIP.SetError(txtbxIP2, "Please Enter ip address");
                no_error = false;
            }
            else
            {
                Regex numberchk = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                if (numberchk.IsMatch(this.IPAddress))
                {
                    epIP.SetError(txtbxIP2, "");
                }

                else
                {
                    epIP.Clear(); // Clear all Error Messages
                    epIP.SetError(txtbxIP2, "Please Enter a valid ip address");
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
            if (string.IsNullOrWhiteSpace(this.numericPort2.Text))
            {
                epPort.SetError(numericPort2, "Please Enter Port");
                no_error = false;
            }
            else
            {
                        epPort.SetError(numericPort2, "");
            }
            return no_error;
        }
        private void txtbxIP2_Validating(object sender, CancelEventArgs e)
        {
            ValidateIpAddress();
        }
        private void numericPort2_Validating(object sender, CancelEventArgs e)
        {
            ValidatePort();
        }
        private void btnOK2_Click(object sender, EventArgs e)
        {
            try
            {
                //validation
                if (ValidateIpAddress() && ValidatePort())
                {
                    this.Hide();
                    TableStatusUsers tableStatus = new TableStatusUsers();
                    tableStatus.Show();
                }
            }
            catch (Exception)
            {
                //tests
                MessageBox.Show("Validation of server failed");
            }
        }
        private void btnCancel2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }
        private void LoginServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
