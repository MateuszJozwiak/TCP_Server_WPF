using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server_WPF
{
    /// <summary>
    /// Kontener na dane
    /// </summary>
    public class SignalType
    {

        /// <summary>
        /// Data contener for simulation settings
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Type"></param>
        /// <param name="MinValue"></param>
        /// <param name="MaxValue"></param>
        /// <param name="Frequency"></param>

        public int Id { get; }
        public double MinValue { get; }
        public double MaxValue { get; }
        public double Frequency { get; }
        public string Type { get; }

        public SignalType(int id, string type, double minValue, double maxValue, double frequency)
        {
            Id = id;
            Type = type;
            MinValue = minValue;
            MaxValue = maxValue;
            Frequency = frequency;
        }
    }
}
