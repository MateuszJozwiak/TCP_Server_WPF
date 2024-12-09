//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace ZadanieNaJunior.JSON
{
    class ReadJSON
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
                    int number= i;
                    var NewSettings = new ModbusSettings(Jsonlist.Sensors[i].Id, Jsonlist.Sensors[i].Type, Jsonlist.Sensors[i].MinValue, Jsonlist.Sensors[i].MaxValue, Jsonlist.Sensors[i].Frequency);
                    var NewWin = new ModbusSimulator(NewSettings);
                    NewWin.Show();
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }

}
        */