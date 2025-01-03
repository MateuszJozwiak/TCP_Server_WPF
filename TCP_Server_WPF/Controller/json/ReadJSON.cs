//using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TCP_Server_WPF.Controller;
using TCP_Server_WPF.Model;

namespace TCP_Server_WPF
{
    struct ReadJSON
    {
        /// <summary>
        /// JSON file read function
        /// </summary>
        /// <param name="adress"></param>
        public ReadJSON(string adress)
        {
            try
            {
                string FileJSON = System.IO.File.ReadAllText(adress);
                var Jsonlist = JsonConvert.DeserializeObject<ListJSONSensors>(FileJSON);
                for (int i = 0; i < Jsonlist.Sensors.Count; i++)
                {
                    int number = i;
                    SignalType NewSettings = new SignalType(Jsonlist.Sensors[i].Id, Jsonlist.Sensors[i].Type, Jsonlist.Sensors[i].MinValue, Jsonlist.Sensors[i].MaxValue, Jsonlist.Sensors[i].Frequency);
                    SignalDataList.AddSignalSettings(NewSettings);
                    TCPConnectionWindow NewWin1 = new TCPConnectionWindow(i);
                    NewWin1.Show();
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

    }

}
        