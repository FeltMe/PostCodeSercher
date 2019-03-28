﻿using FirstNP.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        const int port = 8888;
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);

                server.Start();

                while (true)
                {
                    Console.WriteLine("Start... ");


                    TcpClient client = server.AcceptTcpClient();

                    Console.WriteLine("Connect client...");


                    NetworkStream stream = client.GetStream();

                    

                    using(MyDataBase myData = new MyDataBase())
                    {
                        foreach (var item in myData.Mies)
                        {
                            if(item.PostCode == client)
                            {
                                string response = item.AdressName;

                                byte[] data = Encoding.UTF8.GetBytes(response);


                                stream.Write(data, 0, data.Length);
                                Console.WriteLine($"Send message: n ", response);
                            }
                            
                        }
                    }
                    


                    stream.Close();

                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }
    }
}
