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
        private List<string> adreses = new List<string>();

        public void Start(string Code)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);

                byte[] ReadData = new byte[2048];
                byte[] WriteData = new byte[1024];
                NetworkStream stream = client.GetStream();

                int Hibytes = stream.Read(ReadData, 0, ReadData.Length);
                MessageBox.Show(Encoding.UTF8.GetString(ReadData, 0, Hibytes));
                ReadData = new byte[2048];


                WriteData = Encoding.UTF8.GetBytes(Code);

                stream.Write(WriteData, 0, WriteData.Length);

                StringBuilder response = new StringBuilder();

                do
                {
                    int BLenght = stream.Read(ReadData, 0, ReadData.Length);
                    response.Append(Encoding.UTF8.GetString(ReadData, 0, BLenght));
                    adreses.Add(response.ToString());
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
