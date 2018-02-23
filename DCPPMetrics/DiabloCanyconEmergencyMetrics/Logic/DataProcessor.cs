using System;
using System.Collections.Generic;
using System.Diagnostics;
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
         * { 
         *      "MT1" : 
         *              {
         *                  "0:00" : {
         *                                  "WindSpeed" : 4,
         *                                  "WindDirection" : 123.5
         *              }
         *      }
         * }
         * 
         * 
         * 
         */

        public Dictionary<string, Dictionary<string, Dictionary<string, string>>> ReadCSVFile()
        {
            Dictionary<string, Dictionary<string, Dictionary<string, string>>> metrics =
                new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

            #region Measurements
            // Primary Measurements
            Dictionary<string, Dictionary<string, string>> MT1Measurements =
                            new Dictionary<string, Dictionary<string, string>>();

            // Seconday Measurements
            Dictionary<string, Dictionary<string, string>> MT2Measurements =
                            new Dictionary<string, Dictionary<string, string>>();

            // Point Buchon Measurements
            Dictionary<string, Dictionary<string, string>> MT3Measurements =
                            new Dictionary<string, Dictionary<string, string>>();

            // Los Osos Cemetery Measurements
            Dictionary<string, Dictionary<string, string>> MT4Measurements =
                            new Dictionary<string, Dictionary<string, string>>();

            // Foot Hill Measurements
            Dictionary<string, Dictionary<string, string>> MT5Measurements =
                            new Dictionary<string, Dictionary<string, string>>();

            // Service Center Measurements
            Dictionary<string, Dictionary<string, string>> MT6Measurements =
                            new Dictionary<string, Dictionary<string, string>>();

            // Energy Edu.Center Measurements
            Dictionary<string, Dictionary<string, string>> MT7Measurements =
                            new Dictionary<string, Dictionary<string, string>>();

            // Davis Peak Measurements
            Dictionary<string, Dictionary<string, string>> MT8Measurements =
                            new Dictionary<string, Dictionary<string, string>>();

            // Grover Beach Measurements
            Dictionary<string, Dictionary<string, string>> MT9Measurements =
                            new Dictionary<string, Dictionary<string, string>>();
            #endregion

            Debug.Print("Assigning Column Rows");

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

                // read header row
                var headerRow = reader.ReadLine();
                // split commas
                var headerValues = headerRow.Split(',');
                // Find the column number for each measurement

                int MT1_1 = GetDataColumns(headerValues, "MT1_1");
                int MT1_3 = GetDataColumns(headerValues, "MT1_3");
                int MT2_1 = GetDataColumns(headerValues, "MT2_1");
                int MT2_3 = GetDataColumns(headerValues, "MT2_3");
                int MT3_4 = GetDataColumns(headerValues, "MT3_4");
                int MT3_5 = GetDataColumns(headerValues, "MT3_5");
                int MT4_4 = GetDataColumns(headerValues, "MT4_4");
                int MT4_5 = GetDataColumns(headerValues, "MT4_5");
                int MT5_4 = GetDataColumns(headerValues, "MT5_4");
                int MT5_5 = GetDataColumns(headerValues, "MT5_5");
                int MT6_4 = GetDataColumns(headerValues, "MT6_4");
                int MT6_5 = GetDataColumns(headerValues, "MT6_5");
                int MT7_4 = GetDataColumns(headerValues, "MT7_4");
                int MT7_5 = GetDataColumns(headerValues, "MT7_5");
                int MT8_4 = GetDataColumns(headerValues, "MT8_4");
                int MT8_5 = GetDataColumns(headerValues, "MT8_5");
                int MT9_4 = GetDataColumns(headerValues, "MT9_4");
                int MT9_5 = GetDataColumns(headerValues, "MT9_5");

                #region Measurement Populating
                // read data lines           
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    // Get Time Stamp
                    string timeStamp = values[0];

                    // Add MT1 Data
                    MT1Measurements.Add(timeStamp, GetMeasurementData(values, MT1_3, MT1_1));

                    // Add MT2 Data
                    MT2Measurements.Add(timeStamp, GetMeasurementData(values, MT2_3, MT2_1));

                    // Add MT3 Data
                    MT3Measurements.Add(timeStamp, GetMeasurementData(values, MT3_4, MT3_5));

                    // Add MT4 Data
                    MT4Measurements.Add(timeStamp, GetMeasurementData(values, MT4_4, MT4_5));

                    // Add MT5 Data
                    MT5Measurements.Add(timeStamp, GetMeasurementData(values, MT5_4, MT5_5));

                    // Add MT6 Data
                    MT6Measurements.Add(timeStamp, GetMeasurementData(values, MT6_4, MT6_5));

                    // Add MT7 Data
                    MT7Measurements.Add(timeStamp, GetMeasurementData(values, MT7_4, MT7_5));

                    // Add MT8 Data
                    MT8Measurements.Add(timeStamp, GetMeasurementData(values, MT8_4, MT8_5));

                    // Add MT9 Data
                    MT9Measurements.Add(timeStamp, GetMeasurementData(values, MT9_4, MT9_5));
                }

                metrics.Add("MT1", MT1Measurements);
                metrics.Add("MT2", MT2Measurements);
                metrics.Add("MT3", MT3Measurements);
                metrics.Add("MT4", MT4Measurements);
                metrics.Add("MT5", MT5Measurements);
                metrics.Add("MT6", MT6Measurements);
                metrics.Add("MT7", MT7Measurements);
                metrics.Add("MT8", MT8Measurements);
                metrics.Add("MT9", MT9Measurements);
                #endregion
            }
            return metrics;
        }

        private int GetDataColumns(string[] headerValues, string columnName)
        {
            for (int i = 0; i < headerValues.Length; i++)
            {
                if (headerValues[i].Equals(columnName)) return i;
            }
            return 0;
        }

        private Dictionary<string, string> GetMeasurementData(string[] values, int windSpeed, int windDirection)
        {
            Dictionary<string, string> measurements = new Dictionary<string, string>()
            {
                { "WS", values[windSpeed] },
                { "WD", values[windDirection] }
            };

            return measurements;
        }

        private void PrintMeasurements(Dictionary<string, Dictionary<string, string>> measurements)
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> pair in measurements)
            {
                Debug.Print(pair.Key);
                foreach (KeyValuePair<string, string> measurement in pair.Value)
                {
                    Debug.Print(measurement.Key);
                    Debug.Print(measurement.Value);
                }
            }
        }

    }
}
