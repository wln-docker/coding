using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
namespace ConsoleApplication
{
    public class Program
    {
        /// <summary>
        /// 代理端Socket
        /// </summary>
        private static Socket proxySocket;
        public static void Main(string[] args)
        {
            var serverPort = 5001;
            proxySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            proxySocket.Bind(new IPEndPoint(IPAddress.Any, serverPort));  //监听所有网络接口
            proxySocket.Listen(30);//设定最多30个排队连接请求
            System.Console.WriteLine("Listen port:"+serverPort);
            NewConnect();
        }

        /// <summary>  
        /// 新连接事件处理  
        /// </summary>  
        private static void NewConnect()
        {
            while (true)
            {
                Socket clientSocket = proxySocket.Accept(); //挂起并继续等待下一个链接
                new Thread(ReceiveMessage).Start(clientSocket);
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private static void ReceiveMessage(object socket)
        {
            System.Console.WriteLine("NewConnect Start.");
            var clientSocket = (Socket)socket;
            try
            {
                var request = new byte[1024 * 64];
                var response = new byte[1024 * 64];
                while(true)
                {
                    var receiveNumber = clientSocket.Receive(request);
                    if (receiveNumber > 0)
                    {
                        var msgRequest = Encoding.ASCII.GetString(request, 0, receiveNumber);
                        var msgResponse="Response:"+msgRequest;
                        System.Console.WriteLine("Request:"+msgRequest);
                        response = Encoding.ASCII.GetBytes(msgResponse);
                        clientSocket.Send(response);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Client Socket Closed.");
            }
            finally
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Dispose();
            }
        }
    }
}
