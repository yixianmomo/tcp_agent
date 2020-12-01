using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpAgent
{
    class TcpServer
    {
        private static TcpServer tcpServer = null;
        private static object objlock = new object();
        private Socket server = null;
        private static string address;
        private static int port;
        private static int agentPort;
        private static int maxListen;
        private Thread listenThread = null;
        private List<AgentObj> users = new List<AgentObj>();
        private static object addLock = new object();//创建锁
        private static object removeLock = new object();//创建锁
        Form1.UserListDelegate userListDelegate = null;
       

        private TcpServer()
        {           
            run();
        }

        public static TcpServer getInstance(string mAddress,int mPort,int mAgentPort,int mMaxListen)
        {
            address = mAddress;
            port = mPort;
            agentPort = mAgentPort;
            maxListen = mMaxListen;
            if (null == tcpServer) {
                lock (objlock)
                {
                    if (null == tcpServer)
                    {
                        tcpServer = new TcpServer();

                    }
                }
            }
            return tcpServer;
        }

        public void setDelegate(Form1.UserListDelegate mDelegate)
        {
            this.userListDelegate = mDelegate;
        }


        private void run()
        {
            try
            {
                if (null == server)
                {
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint point = new IPEndPoint(IPAddress.Any, port);
                    server.Bind(point);                   
                    listenThread = new Thread(listen);
                    listenThread.IsBackground = true;
                    listenThread.Start();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("启动服务错误");
            }
            
           
        }



        private void listen()
        {
            try
            {
                server.Listen(maxListen);
                while (true)
                {
                    Socket cs = server.Accept();
                    IPEndPoint clientipe = (IPEndPoint)cs.RemoteEndPoint;
                    Console.Write(clientipe.Address.ToString() + ":" + clientipe.Port.ToString());
                    userListDelegate.Invoke("add|" + clientipe.Address.ToString() + ":" + clientipe.Port.ToString());
                    Socket agentSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    agentSocket.Connect(new IPEndPoint(IPAddress.Parse(address), agentPort));
                    AgentObj agent = new AgentObj();
                    agent.socket = cs;
                    agent.agnetSocket = agentSocket;
                    addAgent(agent);
                    new Thread(receive).Start(agent);
                    new Thread(response).Start(agent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("服务异常");
            }
            finally {
                if (null != server) {
                    server.Close();
                }
            }
    
        }


        public void stop()
        {
            try
            {
                foreach (AgentObj item in users)
                {
                    closeAgent(item);
                    Thread.Sleep(100);

                }

                if (null != server)
                {
                    server.Close();
                    Console.WriteLine("服务关闭成功");
                }
                tcpServer = null;
            }
            catch (Exception e) {

                Console.WriteLine("stop错误");
            }
        }





        private void addAgent(AgentObj obj)
        {

            lock (addLock) {

                users.Add(obj);
            }
        }




        private void  closeAgent(AgentObj obj)
        {
            try
            {
                lock (removeLock)
                {
                    if (null != obj)
                    {
                        if (null != obj.socket)
                        {
                            IPEndPoint clientipe = (IPEndPoint)obj.socket.RemoteEndPoint;                          
                            userListDelegate.Invoke("remove|" + clientipe.Address.ToString() + ":" + clientipe.Port.ToString());
                            obj.socket.Close();
                        }
                        if (null != obj.agnetSocket)
                        {
                            obj.agnetSocket.Close();
                        }
                        if (users.Contains(obj))
                        {
                            users.Remove(obj);
                        }
                    }
                }
            }
            catch (Exception e) {
            }
           
        }

        private void response(object o)
        {
            AgentObj agent = (AgentObj)o;
            byte[] buffer = new byte[1024];
            int temp = -1;
            while (true)
            {
                try
                {
                    temp = agent.agnetSocket.Receive(buffer);
                    if (temp <= 0)
                    {
                        throw new IOException("连接已关闭");
                    }
                    agent.socket.Send(buffer, 0, temp, SocketFlags.None);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    closeAgent(agent);
                    break;
                }
            }

        }


        private void receive(object o)
        {
            AgentObj agent = (AgentObj) o;
            byte[] buffer = new byte[1024];
            int temp = -1;
            while (true)
            {
                try
                {
                   temp = agent.socket.Receive(buffer);
                    if (temp <= 0)
                    {
                        throw new IOException("连接已关闭");
                    }
                    agent.agnetSocket.Send(buffer, 0, temp,SocketFlags.None);
                }
                catch (Exception e) {
                    Console.WriteLine(e.ToString());
                    closeAgent(agent);
                    break;
                }
            }

        }





    }
}
