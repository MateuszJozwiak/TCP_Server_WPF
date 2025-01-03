using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP_Server_WPF;

namespace TCP_Server_WPF
{
    /// <summary>
    /// Lista z danymi o parametrach rowniez metody do zwrotu poszczegolnych zmiennych
    /// </summary>

    public static class SignalDataList
    {
        private static IList<SignalType> _windowsList = new List<SignalType>();

        public static void AddSignalSettings(SignalType input)
        {
            _windowsList.Add(input);
        }

        // funkcje z ktorych mozesz otrzymac wartosci ale nie mozesz zmieniac.
        public static int ReturnId(int listNumber)
        {
            return _windowsList[listNumber].Id;
        }

        public static double ReturnMinValue(int listNumber)
        {
            return _windowsList[listNumber].MinValue;
        }

        public static double ReturnMaxValue(int listNumber)
        {
            return _windowsList[listNumber].MaxValue;
        }

        public static int ReturnFrequency(int listNumber)
        {
            return _windowsList[listNumber].Frequency;
        }

        public static string ReturnType(int listNumber)
        {
            return _windowsList[listNumber].Type;
        }

        public static int ReturnCount()
        {
            return _windowsList.Count();
        }
    }
}
