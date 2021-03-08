using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpAgent
{
  
    public partial class Form1 : Form
    {
        TcpServer tcpserver = null;
        public delegate void UserListDelegate(string s);

        public Form1()
        {
            InitializeComponent();          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        //public void newThreadAddUser(object arg)
        //{
        //    string s = (string)arg;
        //    this.addUser(s);
        //}

        public void operationUser(string s)
        {           
            Console.WriteLine("sssssssssssss:" + userListBox.InvokeRequired);
            if (userListBox.InvokeRequired)
            {
                Console.WriteLine("InvokeRequired:" + s);
                UserListDelegate user = new UserListDelegate(operationUser);
                userListBox.Invoke(user, new object[] { s });
                return;
            }
            else
            {
                Console.WriteLine("Add:" + s);
                if (s.StartsWith("add|"))
                {
                    string ipe = s.Replace("add|", "").Trim();
                    userListBox.Items.Add(ipe);
                }
                else if (s.StartsWith("remove|")) {
                    string ipe = s.Replace("remove|", "").Trim();
                    userListBox.Items.Remove(ipe);
                }
                
            }
        }





        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar >= 57))
            {
                e.Handled = true;
            }
               
        }

        private void port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar >= 57))
            {
                e.Handled = true;
            }
        }

        private void agentPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar >= 57))
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startBtn.Enabled = true;
            portText.Text = ConfigurationUtil.GetConfigValue("port");
            agentAddress.Text = ConfigurationUtil.GetConfigValue("agentAddress");
            agentPortText.Text = ConfigurationUtil.GetConfigValue("agentPort");

          
            //debugText.Enabled = false;

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(agentAddress.Text.Trim()) || string.IsNullOrEmpty(portText.Text.Trim()) || string.IsNullOrEmpty(agentPortText.Text.Trim())) {
                debugText.Text = "Error:端口配置不完整!";
                return;
            }
            string address = agentAddress.Text.Trim();
            int port = Convert.ToInt32(portText.Text);
            int agentPort = Convert.ToInt32(agentPortText.Text);
            int maxListen = Convert.ToInt32(maxListenText.Text);
            // check
            Socket testServer = null;
            try
            {
                debugText.Text = "连接目标服务器.....";
                testServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);                
                testServer.Connect(new IPEndPoint(IPAddress.Parse(address), agentPort));
            }
            catch (Exception ex)
            {
                debugText.Text = "Error:连接目标服务器错误!";
                return;
            }
            finally {
                if (testServer != null) {
                    testServer.Close();
                }
            }

            ConfigurationUtil.SetConfigValue("prot", portText.Text.Trim());
            ConfigurationUtil.SetConfigValue("agentAddress", agentAddress.Text.Trim());
            ConfigurationUtil.SetConfigValue("agentPort", agentPortText.Text.Trim());

            tcpserver =  TcpServer.getInstance(address,port,agentPort,maxListen);
            tcpserver.setDelegate(new UserListDelegate(operationUser));
            startBtn.Enabled = false;
            progressBar1.Value = 100;
            Thread.Sleep(1000);
            stopBtn.Enabled = true;
            debugText.Text = "服务启动完成!";
        }

        private void portText_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            stopBtn.Enabled = false;
            tcpserver.stop();
            progressBar1.Value = 0;
            Thread.Sleep(1000);
            startBtn.Enabled = true;
            debugText.Text = "服务已停止!";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
