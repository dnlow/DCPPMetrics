using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabloCanyconEmergencyMetrics.Logic
{
    class DataProcessor
    {
        private string fileName;
        private DrillForm drillForm;

        public DataProcessor(string fileName, DrillForm drillForm)
        {
            this.fileName = fileName;
            this.drillForm = drillForm;
        }

        private Dictionary<string, Dictionary<string, string>> ReadCSVFile()
        {
            Dictionary<string, Dictionary<string, string>> metrics = new Dictionary<string, Dictionary<string, string>>();

            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {

                }
            }
            return metrics;
        }




    }
}
