using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace FirstNP.Client
{
    public class MyAdresesSercherClient
    {
        private const int port = 8888;
        private const string server = "127.0.0.1";

        public void Start()
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);

                byte[] data = new byte[256];
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);
                MessageBox.Show(response.ToString());

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
