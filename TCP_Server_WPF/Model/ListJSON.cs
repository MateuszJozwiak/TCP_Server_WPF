using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server_WPF.Model
{
    struct ListJSONSensors
    {
        /// <summary>
        ///  Sprobuj zamiast tego moze uzyc List w SimulatorDataList moze to jest niepotrzebne
        /// </summary>
        public IList<SignalType> Sensors { get; set; }
    }
}
