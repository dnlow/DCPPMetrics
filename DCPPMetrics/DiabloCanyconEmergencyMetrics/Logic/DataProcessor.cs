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

        /* Location (Dictionary<string, Dictionary<string, Dictionary<string, float>>>)
         *     Time Stamp
         *             Wind Speed, Wind Direction
         * 
         * MT1 = Primary
         * MT2 = Seconday
         * MT3 = Point Buchon
         * MT4 = Los Osos Cemetery
         * MT5 = Foot Hill
         * MT6 = Service Center
         * MT7 = Energy Edu. Center
         * MT8 = Davis Peak
         * MT9 = Grover Beach
         * 
         */
        private Dictionary<string, Dictionary<string, Dictionary<string, float>>> ReadCSVFile()
        {
            Dictionary<string, Dictionary<string, Dictionary<string, float>>> metrics = 
                new Dictionary<string, Dictionary<string, Dictionary<string, float>>>();

            using (var reader = new StreamReader(fileName))
            {
               /* 
                * Read header row & assign column #s for each location's measurements
                * 
                * MT(1-2)_1 = Wind Direction
                * MT(1-2)_3 = Wind Speed
                *
                * MT(3-9)_4 = Wind Speed
                * MT(3-9)_5 = Wind Direction
                */

                int MT1_1 = 0;
                int MT1_3 = 0;
                int MT2_1 = 0;
                int MT2_2 = 0;
                int MT3_4 = 0;
                int MT3_5 = 0;
                int MT4_4 = 0;
                int MT4_5 = 0;
                int MT5_4 = 0;
                int MT5_5 = 0;
                int MT6_4 = 0;
                int MT6_5 = 0;
                int MT7_4 = 0;
                int MT7_5 = 0;
                int MT8_4 = 0;
                int MT8_5 = 0;
                int MT9_4 = 0;
                int MT9_5 = 0;

                // read header row
                var headerRow = reader.ReadLine();
                // split commas
                var headerValues = headerRow.Split(',');
                // Find the column number for each measurement

                for (int i = 0; i < headerValues.Length; i++)
                {
                    if (headerValues[i].Equals("MT1_1")) MT1_1 = i;
                    else if (headerValues[i].Equals("MT1_3")) MT1_3 = i;
                    else if (headerValues[i].Equals("MT2_1")) MT2_1 = i;
                    else if (headerValues[i].Equals("MT2_2")) MT2_2 = i;
                    else if (headerValues[i].Equals("MT3_4")) MT3_4 = i;
                    else if (headerValues[i].Equals("MT3_5")) MT3_5 = i;
                    else if (headerValues[i].Equals("MT4_4")) MT4_4 = i;
                    else if (headerValues[i].Equals("MT4_5")) MT4_5 = i;
                    else if (headerValues[i].Equals("MT5_4")) MT5_4 = i;
                    else if (headerValues[i].Equals("MT5_5")) MT5_5 = i;
                    else if (headerValues[i].Equals("MT6_4")) MT6_4 = i;
                    else if (headerValues[i].Equals("MT6_5")) MT6_5 = i;
                    else if (headerValues[i].Equals("MT7_4")) MT7_4 = i;
                    else if (headerValues[i].Equals("MT7_5")) MT7_5 = i;
                    else if (headerValues[i].Equals("MT8_4")) MT8_4 = i;
                    else if (headerValues[i].Equals("MT8_5")) MT8_5 = i;
                    else if (headerValues[i].Equals("MT9_4")) MT9_4 = i;
                    else if (headerValues[i].Equals("MT9_5")) MT9_5 = i;
                }

                // read data lines           
                while (!reader.EndOfStream)
                {
                    Dictionary<string, Dictionary<string, float>> measurements = new Dictionary<string, Dictionary<string, float>>();
                    string stationName = "";

                    var line = reader.ReadLine();
                    var values = line.Split(',');



                    metrics.Add(stationName, measurements);
                }
            }
            return metrics;
        }




    }
}
