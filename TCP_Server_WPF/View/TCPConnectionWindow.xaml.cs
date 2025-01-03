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
using System.Security.Cryptography;
using TCP_Server_WPF.View;

namespace TCP_Server_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy TCPConnectionWindow.xaml
    /// </summary>
    public partial class TCPConnectionWindow : Window
    {
        TCPConnectionController NewConnection = new TCPConnectionController();
        TCPConnectionWindowView ShowWindow;
        public TCPConnectionWindow(int number)
        {
            InitializeComponent();
            BtnEnd.Click += BtnEnd_Click;
            ShowWindow = new TCPConnectionWindowView(this);
            var Thread_1 = new Thread(TCPConnection);
            Thread_1.IsBackground = true;
            Thread_1.Start();
        }

        private void BtnEnd_Click(object sender, RoutedEventArgs e)
        {
            //NewConnection.EndWhile = true;
            Close();    
        }
        public void TCPConnection()
        {
            ShowWindow.ConnectionStatusMark(0, this);
            Socket handler1 = NewConnection.GetTCPConnection(this, SignalDataList.ReturnCount());
            try
            {
                ShowWindow.ConnectionStatusMark(2, this);
                NewConnection.message(handler1, this, ShowWindow);
            }
            catch (Exception ex)
            {
                ShowWindow.ConnectionStatusMark(1,this);
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                NewConnection.CloseTCPConnection(handler1);
            }
        }
    }
}
