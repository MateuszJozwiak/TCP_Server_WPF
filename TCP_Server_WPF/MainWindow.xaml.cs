using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace TCP_Server_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnStart.Click += btnStart_Click;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            SignalType okno = new SignalType(Convert.ToInt32(txbId),txbType.ToString(),Convert.ToDouble(txtMin),Convert.ToDouble(txtMax),1);
        }

        private void BtnUpload(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNew(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose(object sender, RoutedEventArgs e)
        {

        }

        private void BtnVersion(object sender, RoutedEventArgs e)
        {

        }

        private void Set_1Hz(object sender, RoutedEventArgs e)
        {

        }

        private void Set_2Hz(object sender, RoutedEventArgs e)
        {

        }

        private void Set_5Hz(object sender, RoutedEventArgs e)
        {

        }

        private void Set_10Hz(object sender, RoutedEventArgs e)
        {

        }
    }
}