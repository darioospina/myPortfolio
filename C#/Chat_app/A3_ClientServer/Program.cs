using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;

namespace A3_ClientServer
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();

        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(8888);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            serverSocket.Start();
            Console.WriteLine("Server Started");
            counter = 0;
            while ((true))
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();

                byte[] message = new byte[1024];
                string user = null;

                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(message, 0, message.Length);
                user = System.Text.Encoding.ASCII.GetString(message);
                user = user.Substring(0, user.IndexOf("$"));
                clientsList.Add(user, clientSocket);

                broadcast(user + " joined ", user, false);

                Console.WriteLine(user + " joined chat room ");
                handleClient client = new handleClient();
                client.startClient(clientSocket, user, clientsList);
            }

            clientSocket.Close();
            serverSocket.Stop();

            Console.ReadLine();
        }

    public static void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;

                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + ": " + msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }  
    }


    public class handleClient
    {
        TcpClient clientSocket;
        string userName;
        Hashtable clientsList;

        public void startClient(TcpClient inClientSocket, string clientN, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.userName = clientN;
            this.clientsList = cList;
            Thread ctThread = new Thread(Chat);
            ctThread.Start();
        }

        private void Chat()
        {
            int requestCount = 0;
            byte[] chatMsg = new byte[1024];
            string MessageFromClient = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(chatMsg, 0, chatMsg.Length);
                    MessageFromClient = System.Text.Encoding.ASCII.GetString(chatMsg);
                    MessageFromClient = MessageFromClient.Substring(0, MessageFromClient.IndexOf("$"));
                    Console.WriteLine("From user - " + userName + ": " + MessageFromClient);
                    rCount = Convert.ToString(requestCount);

                    Program.broadcast(MessageFromClient, userName, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    } 
}
