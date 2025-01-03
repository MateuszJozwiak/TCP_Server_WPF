using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Media3D;
using TCP_Server_WPF.View;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TCP_Server_WPF
{
    /// <summary>
    /// 
    /// </summary>
    public struct TCPConnectionController
    {
        //public bool EndWhile = false;
        public TCPConnectionController()
        {
            
        }
        public Socket? GetTCPConnection(TCPConnectionWindow TCPwindow, int number)
        {
            IPAddress Ip;
            IPEndPoint LocalEndPoint;
            try
            {
                int _listCount = number-1;
                int signalCount = SignalDataList.ReturnCount();
                IPHostEntry host = Dns.GetHostEntry("localhost");
                Ip = host.AddressList[1];
                LocalEndPoint = new IPEndPoint(Ip, 11000 + SignalDataList.ReturnId(_listCount));

                Socket Listener = new Socket(Ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Listener.Bind(LocalEndPoint);
                Listener.Listen(10);
                Socket handler = Listener.Accept();
                return handler;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        public void CloseTCPConnection(Socket handler)
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            System.Windows.MessageBox.Show("Polaczenie zakonczone");
        }

        public void message(Socket handler,TCPConnectionWindow window,TCPConnectionWindowView Obrazy)
        {
            string test1 = "0";
            string test2 = "0";
            while (true)
            {
                string data = null;
                byte[] bytes = null;
                bytes = new byte[1024];
                int bytesRead = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRead);

                Obrazy.WriteMessage(data, window, Convert.ToInt32(SignalDataList.ReturnCount()) - 1);
                Thread.Sleep(SignalDataList.ReturnFrequency(Convert.ToInt32(SignalDataList.ReturnCount()) - 1));

                byte[] msg = Encoding.ASCII.GetBytes(data);
                handler.Send(msg);
                test1 = data;

                if (test1 == test2)
                {
                    break;
                }
                test2 = test1;
            }
        }
    }
}
