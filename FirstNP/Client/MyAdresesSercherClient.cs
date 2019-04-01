using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace FirstNP.Client
{
    public class MyAdresesSercherClient
    {
        private const int port = 8888;
        private const string server = "127.0.0.1";
        private List<string> Adreses = new List<string>();

        public void Start(int Code)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);

                byte[] ReadData = new byte[2048];
                byte[] WriteData = new byte[1024];
                NetworkStream stream = client.GetStream();

                stream.Read(ReadData, 0, ReadData.Length);
                ReadData = null;


                WriteData = BitConverter.GetBytes(port);
                stream.Write(WriteData, 0, WriteData.Length);

                StringBuilder response = new StringBuilder();
                
                do
                {
                    int bytes = stream.Read(ReadData, 0, ReadData.Length);
                    response.Append(Encoding.UTF8.GetString(ReadData, 0, bytes));
                    Adreses.Add(response.ToString());
                }
                while (stream.DataAvailable);



                stream.Close();
                client.Close();
            }
            catch (SocketException)
            {
                MessageBox.Show("SocketException");
            }
        }
    }
}
