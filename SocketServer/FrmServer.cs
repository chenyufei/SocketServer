﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class FrmServer : Form
    {
        //定义回调:解决跨线程访问问题
        private delegate void SetTextValueCallBack(string strValue);

        //定义接收客户端发送消息的回调
        private delegate void ReceiveMsgCallBack(string strReceive);

        //声明回调
        private SetTextValueCallBack setCallBack;

        //声明
        private ReceiveMsgCallBack receiveCallBack;

        //定义回调：给ComboBox控件添加元素
        private delegate void SetCmbCallBack(string strItem);

        //声明
        private SetCmbCallBack setCmbCallBack;

        //定义发送文件的回调
        private delegate void SendFileCallBack(byte[] bf);

        //声明
        private SendFileCallBack sendCallBack;

        //用于通信的Socket
        Socket socketSend;

        //用于监听的SOCKET
        Socket socketWatch;

        //将远程连接的客户端的IP地址和Socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();



        //创建监听连接的线程
        Thread AcceptSocketThread;

        //接收客户端发送消息的线程
        Thread threadReceive;

        public FrmServer()
        {
            InitializeComponent();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            //当点击开始监听的时候 在服务器端创建一个负责监听IP地址和端口号的Socket
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //获取ip地址
            IPAddress ip = IPAddress.Parse(this.textBox_IP.Text.Trim());

            //创建端口号
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(this.textBox_Port.Text.Trim()));

            //绑定IP地址和端口号
            socketWatch.Bind(point);
            this.richTextBox_Log.AppendText("监听成功" + " \r \n");

            //开始监听:设置最大可以同时连接多少个请求
            socketWatch.Listen(10);

            //实例化回调
            setCallBack = new SetTextValueCallBack(SetTextValue);
            receiveCallBack = new ReceiveMsgCallBack(ReceiveMsg);
            setCmbCallBack = new SetCmbCallBack(AddCmbItem);
            sendCallBack = new SendFileCallBack(SendFile);


            //创建线程
            AcceptSocketThread = new Thread(new ParameterizedThreadStart(StartListen));
            AcceptSocketThread.IsBackground = true;
            AcceptSocketThread.Start(socketWatch);
        }

        /// <summary>
        /// 等待客户端的连接，并且创建与之通信用的Socket
        /// </summary>
        /// <param name="obj"></param>
        private void StartListen(object obj)
        {
            Socket socketWatch = obj as Socket;
            while (true)
            {
               //等待客户端的连接，并且创建一个用于通信的Socket
                socketSend = socketWatch.Accept();

                //获取远程主机的ip地址和端口号
                string strIp = socketSend.RemoteEndPoint.ToString();
                dicSocket.Add(strIp, socketSend);
                this.comboBox_Socket.Invoke(setCmbCallBack, strIp);
                string strMsg = "远程主机：" + socketSend.RemoteEndPoint + "连接成功";

                //使用回调
                richTextBox_Log.Invoke(setCallBack, strMsg);

                //定义接收客户端消息的线程
                threadReceive = new Thread(new ParameterizedThreadStart(Receive));
                threadReceive.IsBackground = true;
                threadReceive.Start(socketSend);
            }

        }

        /// <summary>
        /// 服务器端不停的接收客户端发送的消息
        /// </summary>
        /// <param name="obj"></param>
        private void Receive(object obj)
        {
            Socket socketSend = obj as Socket;
            while (true)
            {
                //客户端连接成功后，服务器接收客户端发送的消息
                byte[] buffer = new byte[2048];

                //实际接收到的有效字节数
                int count = socketSend.Receive(buffer);
                if (count == 0)//count 表示客户端关闭，要退出循环
                {
                    break;
                }
                else
                {
                    string str = Encoding.Default.GetString(buffer, 0, count);
                    string strReceiveMsg = "接收：" + socketSend.RemoteEndPoint + "发送的消息:" + str;
                    richTextBox_Log.Invoke(receiveCallBack, strReceiveMsg);
                }
            }
        }

        /// <summary>
        /// 回调委托需要执行的方法
        /// </summary>
        /// <param name="strValue"></param>
        private void SetTextValue(string strValue)
        {
            this.richTextBox_Log.AppendText(strValue + " \r \n");
        }

        private void ReceiveMsg(string strMsg)
        {
            this.richTextBox_Log.AppendText(strMsg + " \r \n");
        }

        private void AddCmbItem(string strItem)
        {
            this.comboBox_Socket.Text = strItem;
            this.comboBox_Socket.Items.Add(strItem);
        }
        private void SendFile(byte[] sendBuffer)

        {
            try
            {
                dicSocket[comboBox_Socket.SelectedItem.ToString()].Send(sendBuffer, SocketFlags.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送文件出错:" + ex.Message);
            }
        }
        private void button_Stop_Listen_Click(object sender, EventArgs e)
        {
            socketWatch.Close();
            socketSend.Close();
            //终止线程
            AcceptSocketThread.Abort();
            threadReceive.Abort();
        }


        private void btn_Shock_Click(object sender, EventArgs e)

        {
            byte[] buffer = new byte[1] { 2 };
            dicSocket[comboBox_Socket.SelectedItem.ToString()].Send(buffer);
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            try
            {
                string strMsg = this.richTextBox_Msg.Text.Trim();
                byte[] buffer = Encoding.Default.GetBytes(strMsg);
                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);
                //将泛型集合转换为数组
                byte[] newBuffer = list.ToArray();
                //获得用户选择的IP地址
                string ip = this.comboBox_Socket.Text.ToString();
                dicSocket[ip].Send(newBuffer);
            }

            catch (Exception ex)
            {
                MessageBox.Show("给客户端发送消息出错:" + ex.Message);
            }
            //socketSend.Send(buffer);
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();

            //设置初始目录
            dia.InitialDirectory = @"";
            dia.Title = "请选择要发送的文件";

            //过滤文件类型
            dia.Filter = "所有文件|*.*";
            dia.ShowDialog();

            //将选择的文件的全路径赋值给文本框
            this.textBox_FilePath.Text = dia.FileName;
        }

        private void button_SendFile_Click(object sender, EventArgs e)
        {
            List<byte> list = new List<byte>();

            //获取要发送的文件的路径
            string strPath = this.textBox_FilePath.Text.Trim();
            using (FileStream sw = new FileStream(strPath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[2048];
                int r = sw.Read(buffer, 0, buffer.Length);
                list.Add(1);
                list.AddRange(buffer);

                byte[] newBuffer = list.ToArray();

                //发送
                //dicSocket[cmb_Socket.SelectedItem.ToString()].Send(newBuffer, 0, r+1, SocketFlags.None);
                button_SendFile.Invoke(sendCallBack, newBuffer);
            }
        }
    }
}
