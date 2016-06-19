using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Common
{
    [Serializable]
    public class ChatMessage
    {
        /// <summary>
        /// class for serialization 
        /// </summary>
        
        public string ip { get; set; } //כתובת
        public int port { get; set; } //פורט
        public Color color { get; set; } //צבע גופן
        public string username { get; set; } //שם המשתמש
        public string fullname { get; set; } //שם משתמש שנבחר
        public string message { get; set; } //תוכן הודעה
        public string sender { get; set; } //שם התוכנית 
    }

    public class Connection : IDisposable
    {
        /// <summary>
        /// class for Connections
        /// </summary>

        static public event Action<string> EventListAdd;
        static public event Action<int> EventListRemove;
        static public event Action<string> EventAdd2History;
        BinaryFormatter tcpBF = new BinaryFormatter();
        TcpClient tcpclient;
        NetworkStream netstream;
        ChatMessage info;
        Thread thrMsg;

        /// <summary>
        /// Connects to the server
        /// </summary>
        public Connection(TcpClient tcpCon)
        {
            tcpclient = tcpCon;
            netstream = tcpclient.GetStream();

            if (Verify())
            {
                ServerMethods.tcpclientArray.Add(tcpclient);
                EventListAdd(info.fullname);
                //sql.UserStatus(true, info.fullname);
                // The thread that accepts the client and awaits messages
                thrMsg = new Thread(Listen4Msg);
                // The thread calls the AcceptClient() method
                thrMsg.Start();
            }
            else CloseConnection();
        }

        /// <summary>
        /// Verifys if the user is registerd or not
        /// </summary>
        /// <returns></returns>
        public bool Verify()
        {
            info = (ChatMessage)tcpBF.Deserialize(netstream);

            // checks if user is registerd
            //bool registerd = sql.Look4User(info.fullname);
            bool registered=true;
            if (!registered)
            {
                try
                {
                    // 3. send the client that the user is not registerd
                    tcpBF.Serialize(netstream, false);

                    // 4. get a response wheter to register or not
                    string respond = (string)tcpBF.Deserialize(netstream);

                    switch (respond)
                    {
                        case "YES":
                            // create a client object + add to clients array + add to database + add to the listview
                            //sql.RegisterUser(info);
                            break;
                        case "NO":
                            return false;
                    }
                }
                // user has disconnected
                catch (SerializationException)
                {
                    return false;
                }
            }
             //3. send the client that the user is registerd
            else
            {
                tcpBF.Serialize(netstream, true);
            }
            return true;
        }

        /// <summary>
        /// A Thread - used for geetting messages from a user and forwarding it all other users
        /// </summary>
        public void Listen4Msg()
        {
            // notifys all clients that a user has connected the chat
            ServerMethods.SendMsgAll("connected", info);

            while (true)
            {
                try
                {
                    ServerMethods.SendMsgAll("msg", (ChatMessage)tcpBF.Deserialize(netstream));
                }
                // server has disconnected
                catch (IOException)
                {
                    ServerMethods.CloseServer();
                    return;
                }
                // client has disconnected
                catch (SerializationException)
                {
                    if (ServerMethods.tcpclientArray.Count > 0)
                    {
                        int tempindex = ServerMethods.tcpclientArray.IndexOf(tcpclient);
                        ServerMethods.tcpclientArray.RemoveAt(tempindex);
                        ServerMethods.SendMsgAll("disconnected", info);

                        EventListRemove(tempindex);
                        EventAdd2History(info.fullname);
                        //sql.UserStatus(false, info.fullname);
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// Closes the connection and disposes the object
        /// </summary>
        private void CloseConnection()
        {
            // Close the currently open objects
            tcpclient.GetStream().Close();
            tcpclient.Close();
            this.Dispose();
        }

        public void Dispose()
        {
            if (netstream != null)
                netstream.Dispose();
        }

    }

    public abstract class ServerMethods
    {
        /// <summary>
        /// class for server use
        /// </summary>

        static public event Action<string> EventMsgDialog;
        static public event Action EventListClear;

        public static BinaryFormatter tcpBF = new BinaryFormatter();
        public static TcpListener tcpListener = null;
        public static TcpClient tcpclient = null;
        public static List<TcpClient> tcpclientArray = new List<TcpClient>();

        /// <summary>
        /// creats the server and opens the listening thread
        /// </summary>
        public static void CreateServer(IPAddress ip, int port)
        {
            try
            {
                tcpListener = new TcpListener(ip, port);
                tcpListener.Start();

                Thread thread_firststep = new Thread(AcceptConnection);
                thread_firststep.Start();
            }

            //port is already in use
            catch (SocketException e)
            {
                EventMsgDialog(e.Message);
                return;
            }
        }

        /// <summary>
        /// gets all user connections and creates an object with the users data
        /// </summary>
        public static void AcceptConnection()
        {
            while (true)
            {
                try
                {
                    tcpclient = tcpListener.AcceptTcpClient();
                }
                // server was disconnected while waiting for a connection
                catch (SocketException)
                {
                    return;
                }
                Connection newconnection = new Connection(tcpclient);
            }
        }

        /// <summary>
        /// Gets a message from the user and sends it to all
        /// </summary>
        /// <value> 
        /// connected- notify a user has connected
        /// disconnected- notify a user has disconnected
        /// msg - forwwrd the users msg
        /// </value>
        public static void SendMsgAll(string value, ChatMessage info)
        {
            if (tcpclientArray.Count > 0)
            {
                foreach (var i in tcpclientArray)
                {
                    switch (value)
                    {
                        case "connected":
                            info.message = info.fullname + " has entered the chat.";
                            info.sender = "ServerSide";
                            tcpBF.Serialize(i.GetStream(), info);
                            break;
                        case "disconnected":
                            info.message = info.fullname + " has left the chat.";
                            info.sender = "ServerSide";
                            tcpBF.Serialize(i.GetStream(), info);
                            break;
                        case "msg":
                            tcpBF.Serialize(i.GetStream(), info);
                            //sql.Write2DataBase(info);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// closes the server
        /// </summary>
        public static void CloseServer()
        {
            tcpListener.Stop();
            EventListClear();
            foreach (var i in tcpclientArray)
            {
                i.Client.Disconnect(true);

            }
            tcpclientArray.Clear();
            //sql.ServerOffline();
        }
    }

    public abstract class ClientMethods
    {
        /// <summary>
        /// class for client use
        /// </summary>
        public static event Action<string> EventMsgDialog;
        public static Action<ChatMessage> EventServer;
        public static Action EventSetButtons;
        public static Func<bool> EventRegisterQuestion;

        static BinaryFormatter tcpBF = new BinaryFormatter();
        static NetworkStream tcpStream = null;
        public static ChatMessage ClientInfo = null;

        /// <summary>
        /// Creates a connection to the server 
        /// </summary>
        public static void Connect(ChatMessage x)
        {
            TcpClient tcpClient = new TcpClient();
            ClientInfo = x;
            EventSetButtons();

            try
            {
                // connect to server and get the stream
                tcpClient.Connect(IPAddress.Parse(ClientInfo.ip), ClientInfo.port);
                tcpStream = tcpClient.GetStream();

                // send the server all the users information
                tcpBF.Serialize(tcpStream, ClientInfo);

                // run the registertaion method
                if (Registeration())
                {
                    Thread thread_step1 = new Thread(Listen4Server);
                    thread_step1.Start();
                }
                else Disconnect();
            }
            // unable to connect to the server
            catch (SocketException e)
            {
                EventMsgDialog(e.Message);
                Disconnect();
            }
        }

        /// <summary>
        /// checks with the server whether user is register or not,
        /// if not gives the option to register using an event, 
        /// yes- continues no-disconnects
        /// </summary>
        public static bool Registeration()
        {

            // 2. receive a resopnse if registed or not (true-yes, false-no)
            bool answer = (bool)tcpBF.Deserialize(tcpStream);

            // user is registerd
            if (answer)
            {
                return true;
            }
            else
            {
                //ask user if he want to register or not
                switch (EventRegisterQuestion())
                {
                    // user responded YES
                    case true:
                        // ask the server to register
                        tcpBF.Serialize(tcpStream, "YES");
                        return true;

                    // user responded NO
                    case false:
                        tcpBF.Serialize(tcpStream, "NO");
                        return false;

                    default:
                        return false;
                }
            }
        }

        /// <summary>
        /// listen for incoming messages from the server
        /// </summary>
        static public void Listen4Server()
        {
            while (true)
            {
                try
                {
                    ChatMessage ServerInfo = (ChatMessage)tcpBF.Deserialize(tcpStream);
                    EventServer(ServerInfo);
                }
                catch (IOException) // client has disconnected
                {
                    return;
                }
                catch (SerializationException) //server has disconnected
                {
                    EventMsgDialog("server has been disconnected");
                    Disconnect();
                    return;
                }
            }
        }

        public static void Disconnect()
        {
            if (tcpStream != null) { tcpStream.Close(); }
            EventSetButtons();
        }

        /// <summary>
        /// sends messages to the server
        /// </summary>
        public static void SendMessage(ChatMessage ClientInfo)
        {
            tcpBF.Serialize(tcpStream, ClientInfo);
        }
    }
}
       