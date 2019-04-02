using FirstNP;
using FirstNP.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        const int port = 8888;

        public static object MessageBox { get; private set; }

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
                    Console.WriteLine("Start");

                    TcpClient client = server.AcceptTcpClient();

                    Console.WriteLine("Go");

                    NetworkStream stream = client.GetStream();


                    string hims = "Hi";
                    byte[] data = new byte[2048];
                    byte[] code = new byte[256];
                    byte[] Temp = Encoding.UTF8.GetBytes(hims);


                    stream.Write(Temp, 0, hims.Length);

                    int bytes = stream.Read(code, 0, code.Length);
                    var MyPostCode = Int32.Parse(Encoding.UTF8.GetString(code, 0, bytes));

                    Sercher(MyPostCode, stream, data);

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

        private static void Sercher(int MyPostCode, NetworkStream stream, byte[] data)
        {
            try
            {
                using (MyDataBase myData = new MyDataBase())
                {
                    foreach (var item in myData.Mies)
                    {
                        if (item.PostCode == MyPostCode)
                        {
                            string response = item.AdressName;

                            byte[] SendingData = Encoding.UTF8.GetBytes(response);

                            stream.Write(data, 0, data.Length);
                            Console.WriteLine($"Send message: n ", response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + " Eto ya!");
            }
        }
    }
}
