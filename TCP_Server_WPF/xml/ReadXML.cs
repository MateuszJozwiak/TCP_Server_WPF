using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TCP_Server_WPF.XML
{
    class ReadXML
    {
        public ReadXML(string input)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                Stream readData = new FileStream(input, FileMode.Open);
                xmlDoc.Load(readData);
                var MinList = xmlDoc.GetElementsByTagName("MinValue");
                for (int i = 0; i < xmlDoc.GetElementsByTagName("ID").Count; i++)
                {
                    var Id = Convert.ToInt32(xmlDoc.GetElementsByTagName("ID")[i].InnerText.ToString());
                    var Type = xmlDoc.GetElementsByTagName("Type")[i].InnerText.ToString();
                    var MinValue = Convert.ToDouble(xmlDoc.GetElementsByTagName("MinValue")[i].InnerText.ToString());
                    var MaxValue = Convert.ToDouble(xmlDoc.GetElementsByTagName("MaxValue")[i].InnerText.ToString());
                    var Frequency = Convert.ToInt32(xmlDoc.GetElementsByTagName("Frequency")[i].InnerText.ToString());
                    var ModbusSetting = new SignalType(Id, Type, MinValue, MaxValue, Frequency);
                    //var NewWin = new ModbusSimulator(ModbusSetting);

                    //NewWin.Show();
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
