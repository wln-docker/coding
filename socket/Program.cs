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
        public static void Main(string[] args)
        {
            Console.WriteLine("Socket Test!");
	        try
	        {
	        	var serverIP = "127.0.0.1";
                serverIP = "120.25.218.227";
                var serverPort = 5000;
                try
                {
                    Console.WriteLine("Input Remote Port(Default 5000):");
                    serverPort = Convert.ToInt32(Console.ReadLine());
                }
                catch { serverPort = 5000; }
	            var response = new byte[1024 * 64];
	            System.Net.Sockets.Socket socket = null;
            	while(true)
            	{
            		Console.WriteLine("Request Content(Input):");
            		var input = Console.ReadLine();
            		if(input == "close")
            		{
            			if(socket!=null){
	                		socket.Shutdown(SocketShutdown.Both);
	                		socket.Dispose();
	                		socket = null;
	                		System.Console.WriteLine("Client Socket Closed.");
            			}
            			else
            			{
	                		System.Console.WriteLine("Socket IsNot Connected.");
            			}
            		}
            		else
            		{
	            		while(socket == null || !socket.Connected)
	            		{
	            			try{
	            				Console.WriteLine("Begin Connect To "+serverIP+":"+serverPort);
	            				socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		            			socket.Connect(System.Net.IPAddress.Parse(serverIP), serverPort);
	            				Console.WriteLine("Connect Success!");
	            			}catch{
	            				Console.WriteLine("Connect Feild!");
	            				socket = null;
	            			}
	            		}
			            socket.Send(Encoding.ASCII.GetBytes(input));
			            var revLength = socket.Receive(response);
			            if (revLength > 0)
			            {
			                var msg = Encoding.ASCII.GetString(response, 0, revLength);
			                System.Console.WriteLine(msg);
			            }
            		}
            	}
	        }
	        catch (Exception ex)
	        {
	            System.Console.WriteLine(ex.Message);
	        }
        }
    }
}
