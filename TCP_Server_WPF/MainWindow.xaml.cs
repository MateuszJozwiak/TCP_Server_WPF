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
using System.Security.Cryptography.X509Certificates;
using TCP_Server_WPF.Controller;

namespace TCP_Server_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int _frequencyValue=1;
        
        public MainWindow()
        {
            InitializeComponent();
            btnStart.Click += btnStart_Click;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MainWindowController CreateNewWindow = new MainWindowController();
            CreateNewWindow.StartNewWindow(this);
        }

        private void BtnUpload(object sender, RoutedEventArgs e)
        {
            MainWindowController CreateNewWindow = new MainWindowController();
            CreateNewWindow.UploadConfigurationFromFile(this);
        }

        private void BtnNew(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnVersion(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wersja 2.0" ,"Wersja aplikacji",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void Set_Hz(object sender, RoutedEventArgs e)
        {
            if (Radio_Btn_1.IsChecked == true) { _frequencyValue = 1; }
            if (Radio_Btn_2.IsChecked == true) { _frequencyValue = 2; }
            if (Radio_Btn_5.IsChecked == true) { _frequencyValue = 5; }
            if (Radio_Btn_10.IsChecked == true) { _frequencyValue = 10; }
        }
    }
}