using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TCP_Server_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy TCPConnectionWindow.xaml
    /// </summary>
    public partial class TCPConnectionWindow : Window
    {
        public TCPConnectionWindow()
        {
            InitializeComponent();
            StartTCP.Click += StartTCP_Click;
        }
        private void StartTCP_Click(object sender, RoutedEventArgs e)
        {
            var Thread_1 = new Thread(TCPConnection);
            Thread_1.IsBackground = true;
            Thread_1.Start();
        }

        public void TCPConnection()
        {

            ConnectionStatusMark(0);
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress Ip = host.AddressList[0];
            IPEndPoint LocalEndPoint = new IPEndPoint(Ip, 11001);

            Socket Listener = new Socket(Ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(LocalEndPoint);
            Listener.Listen(10);
            Socket handler1 = Listener.Accept();
            ConnectionStatusMark(2);
            SignalType test = new SignalType(1, "wind", 0, 10, 10);
            //ConnectionStatus.Background = Brushes.Green;
            //Console.WriteLine("TCP Server");
            try
            {
                message(handler1);

                handler1.Shutdown(SocketShutdown.Both);
                handler1.Close();
                //Console.WriteLine("Polaczenie zakonczone");
                System.Windows.MessageBox.Show("Polacenie zakonczone");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                System.Windows.MessageBox.Show(ex.ToString());
            }

        }


        public void message(Socket handler)
        {
            //await Task.Run(() =>
            //{

            //});

            int i = 0;
            int endValue = 50;
            while (true)
            {
                string data = null;
                byte[] bytes = null;
                bytes = new byte[1024];
                int bytesRead = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRead);

                WriteMessage(data);
                Thread.Sleep(5000);
                //StatusColor(modbusStatus, tr);

                byte[] msg = Encoding.ASCII.GetBytes(data);
                handler.Send(msg);
                i += 1;
                if (i == endValue)
                {
                    break;
                }
            }

        }
        public void ConnectionStatusMark(int NumStatus)
        {
            this.Dispatcher.Invoke(() =>
            {
                switch (NumStatus)
                {
                    case 0:
                        ConnectionStatus.Background = Brushes.Blue;
                        break;
                    case 1:
                        ConnectionStatus.Background = Brushes.Red;
                        break;
                    case 2:
                        ConnectionStatus.Background = Brushes.Green;
                        break;

                }

            });
        }
        public void WriteMessage(string Message)
        {
            this.Dispatcher.Invoke(() =>
            {
                TextRange tr = new TextRange(MessageTCP.Document.ContentEnd, MessageTCP.Document.ContentEnd)
                {
                    Text = Message + "\n"
                };
            });
        }
    }
}
