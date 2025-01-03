using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace TCP_Server_WPF.View
{
    /// <summary>
    /// Klasa do trzymania funkcji zwiazanych z wyswietlaniem lub zmiana elementow na widoku WPF
    /// </summary>
    public struct TCPConnectionWindowView
    {
        
        public TCPConnectionWindowView(TCPConnectionWindow window)
        {
            int _listCount = Convert.ToInt32(SignalDataList.ReturnCount()) - 1;
            window.TxtBox_SignalInformation.Text = $"id= {SignalDataList.ReturnId(_listCount)} \n" +
                                            $"Type= {SignalDataList.ReturnType(_listCount)} \n" +
                                            $"Minimum value= {SignalDataList.ReturnMinValue(_listCount)} \n" +
                                            $"Max value= {SignalDataList.ReturnMaxValue(_listCount)} \n" +
                                            $"Frequency= {SignalDataList.ReturnFrequency(_listCount)}";
        }
        
        public void ConnectionStatusMark(int NumStatus, TCPConnectionWindow window)
        {
            window.Dispatcher.Invoke(() =>
            {
                switch (NumStatus)
                {
                    case 0:
                        window.ConnectionStatus.Background = Brushes.Blue;
                        break;
                    case 1:
                        window.ConnectionStatus.Background = Brushes.Red;
                        break;
                    case 2:
                        window.ConnectionStatus.Background = Brushes.Green;
                        break;
                }

            });
        }
        
        public void WriteMessage(string Message, TCPConnectionWindow window, int idNumber)
        {
            int inputMessage=0;
            int.TryParse(Message, out inputMessage);
            int _listCount = Convert.ToInt32(SignalDataList.ReturnCount()) - 1;
            string[] message = MessageOutput(inputMessage, SignalDataList.ReturnId(idNumber), SignalDataList.ReturnType(idNumber), SignalDataList.ReturnMinValue(idNumber), SignalDataList.ReturnMaxValue(idNumber));
            window.Dispatcher.Invoke(() =>
            {
                TextRange tr = new TextRange(window.MessageTCP.Document.ContentEnd, window.MessageTCP.Document.ContentEnd)
                {
                    Text = message[0]
                };
                window.MessageTCP.ScrollToEnd();
            });
        }

        private void StatusColor(string status, TextRange tr)
        {
            if (status == "abnormal")
            {
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Yellow);
            }
            else if (status == "alarm")
            {
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
            }
        }


        public string[] MessageOutput(int input,int id,string type,  double minLimit, double maxLimit)
        {
            var limitRange = maxLimit - minLimit;
            string messageStatus;

            if (input >= ((limitRange * 0.9) + minLimit) || input <= (minLimit + (limitRange * 0.1)))
            {
                messageStatus = "alarm";
            }
            else if (input >= ((limitRange * 0.75) + minLimit) || input <= (minLimit + (limitRange * 0.25)))
            {
                messageStatus = "abnormal";
            }
            else
            {
                messageStatus = "normal";
            }
            return [$"$FIX,{id},{type},{messageStatus},{input}*\n",messageStatus];
        }
    }
}
