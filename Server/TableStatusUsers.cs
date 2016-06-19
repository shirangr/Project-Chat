using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Net;

namespace ServerSide
{
    public partial class TableStatusUsers : Form
    {
        LoginServer loginS = new LoginServer();
        //DataSet ds = new DataSet();
        //DataTable SearchResults = new DataTable();
        //SqlCeConnection connection = new SqlCeConnection(@"Data Source=Serverdb.sdf");
        //SqlCeDataAdapter adapter;


        public TableStatusUsers()
        {
            InitializeComponent();

            loginS.Activate();
            ServerMethods.EventMsgDialog += new Action<string>(text => MessageBox.Show(text));
            Common.Connection.EventListAdd += new Action<string>(ListAdd);
            Common.Connection.EventListRemove += new Action<int>(ListRemove);
            Common.Connection.EventAdd2History += new Action<string>(Add2History);
            ServerMethods.EventListClear += new Action(ListClear);
            
            //sql.EventUpdateData += new Action<string>(GridUpdate);
            //GridFillStartup("select * from users", "users");
            //GridFillStartup("select * from messages", "messages");
            //SearchResults = ds.Tables.Add("SearchResults");
        }

        private void TableStatusUsers_Load(object sender, EventArgs e)
        {
            ServerMethods.CreateServer(IPAddress.Parse(loginS.IPAddress), loginS.Port);
            SetButtons();
            listViewUsers.Enabled = false;
            listViewHistory.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMethods.CreateServer(IPAddress.Parse(loginS.IPAddress), loginS.Port);
            }
            catch (Exception)
            {
                MessageBox.Show("Server failed to connect");
            }
            SetButtons();
            listViewUsers.Enabled = false;
            listViewHistory.Enabled = false;

            //לתקן
            //counting number of connected clients
            //int count = 0;
            //foreach (var client in )
            //{
            //    count++;
            //}  
            //this.Text = count + " Connected Users";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMethods.CloseServer();
            }
            catch (Exception)
            {
                MessageBox.Show("Server failed to disconnect");
            }
            SetButtons();
        }

        /// <summary>
        /// Sets the button status to enabled/disabled
        /// </summary>
        public void SetButtons()
        {
            this.Invoke(new Action(() =>
            {
                if (btnConnect.Enabled)
                {
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                }
                else { btnConnect.Enabled = true; btnDisconnect.Enabled = false; }
            }
               ));
        }

        /// <summary>
        /// add users to the ListView
        /// </summary>
        public void ListAdd(string username)
        {
            this.Invoke(new Action(() =>
            {
                ListViewItem item = new ListViewItem(username, 0);
                item.SubItems.Add("Connected");
                item.SubItems.Add(DateTime.Now.ToString("HH:mm:ss"));
                listViewUsers.Items.AddRange(new ListViewItem[] { item });
                item.ForeColor = Color.Green;
                listViewHistory.Items.AddRange(new ListViewItem[] { (ListViewItem)item.Clone() });
            }));
        }



        /// <summary>
        /// removes a user from the ListView
        /// </summary>
        public void ListRemove(int index)
        {
            this.Invoke(new Action(() =>
            {
                listViewUsers.Items.RemoveAt(index);
            }));
        }

        /// <summary>
        /// adds a user to the History ListView
        /// </summary>
        /// <param name="username"></param>
        public void Add2History(string username)
        {
            this.Invoke(new Action(() =>
            {
                ListViewItem item = new ListViewItem(username, 0);
                item.ForeColor = Color.Red;
                item.SubItems.Add("Disconnected");
                item.SubItems.Add(DateTime.Now.ToString("HH:mm:ss"));
                listViewHistory.Items.AddRange(new ListViewItem[] { item });
            }));
        }

        /// <summary>
        /// clears the Online ListView
        /// </summary>
        public void ListClear() 
        { 
            this.Invoke(new Action(() => listViewUsers.Items.Clear())); 
        }

        private void TableStatusUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
