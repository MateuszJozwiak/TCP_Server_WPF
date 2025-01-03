using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using TCP_Server_WPF.XML;

namespace TCP_Server_WPF.Controller
{
    internal struct MainWindowController
    {
        public void StartNewWindow(MainWindow mainWindow)
        {
            if (mainWindow.txbType.Text == "")
            {
                MessageBox.Show("Wprowadz nazwe telegramu");
            }
            else if (mainWindow.txbId.Text == "")
            {
                MessageBox.Show("Wprowadz numer ID");
            }
            else if(!int.TryParse(mainWindow.txbId.Text, out int _idnumber))
            {
                MessageBox.Show("id nie jest numerem");
            }
            else
            {
                try
                {
                    SignalType okno = new SignalType(Convert.ToInt32(mainWindow.txbId.Text), mainWindow.txbType.Text, Convert.ToDouble(mainWindow.txtMin.Text), Convert.ToDouble(mainWindow.txtMax.Text), mainWindow._frequencyValue);
                    SignalDataList.AddSignalSettings(okno);
                    TCPConnectionWindow NewWin = new TCPConnectionWindow(SignalDataList.ReturnCount()-1); // brak okna gdzie wprowaadzac dane???
                    NewWin.Show();
                }
                catch 
                {
                    MessageBox.Show("Sprawdz wszystkie wartosci");
                }

            }

        }

        public void UploadConfigurationFromFile(MainWindow mainWindow)
        {
            
            try
            {
                var newFile = new OpenFileDialog
                {
                    Filter = "JSON file (*.json)|*.json|XML file (*.xml)|*.xml",
                    FilterIndex = 2
                };
                newFile.ShowDialog();
                string FileName = System.IO.Path.GetExtension(newFile.FileName);
                switch (FileName)
                {
                    case ".json":
                        ReadJSON ReadJFile = new ReadJSON(newFile.FileName);
                        break;

                    case ".xml":
                        ReadXML ReadXFile = new ReadXML(newFile.FileName);
                        break;
                    default:
                        MessageBox.Show("Wrong Data format");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
        }
    }
}
