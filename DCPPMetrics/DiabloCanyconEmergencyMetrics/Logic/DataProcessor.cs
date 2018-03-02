using DiabloCanyonEmergencyMetrics.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabloCanyonEmergencyMetrics.Logic
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

        /* 
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

        public List<Measurement> ReadCSVFile()
        {
            List<Measurement> measurements = new List<Measurement>();
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
                    DateTime ts;
               
                    if (!DateTime.TryParseExact(values[0], "H:mm", CultureInfo.InvariantCulture,
                                                                    DateTimeStyles.AssumeLocal, out ts))
                    {
                        Debug.Print("Invalid Time Stamp {0}", values[0]);
                    }

                    // Add MT1 Data
                    measurements.Add(GetMeasurementData(values, 
                                                        MT1_3, 
                                                        MT1_1, 
                                                        ts, 
                                                        Measurement.MeasurementLocation.MT1));

                    // Add MT2 Data
                    measurements.Add(GetMeasurementData(values, 
                                                        MT2_3,
                                                        MT2_1, 
                                                        ts, 
                                                        Measurement.MeasurementLocation.MT2));

                    // Add MT3 Data
                    measurements.Add(GetMeasurementData(values, 
                                                        MT3_4, 
                                                        MT3_5, 
                                                        ts, 
                                                        Measurement.MeasurementLocation.MT3));

                    // Add MT4 Data
                    measurements.Add(GetMeasurementData(values, 
                                                        MT4_4, 
                                                        MT4_5, 
                                                        ts, 
                                                        Measurement.MeasurementLocation.MT4));

                    // Add MT5 Data
                    measurements.Add(GetMeasurementData(values, 
                                                        MT5_4, 
                                                        MT5_5, 
                                                        ts, 
                                                        Measurement.MeasurementLocation.MT5));

                    // Add MT6 Data
                    measurements.Add(GetMeasurementData(values, 
                                                        MT6_4, 
                                                        MT6_5, 
                                                        ts, 
                                                        Measurement.MeasurementLocation.MT6));

                    // Add MT7 Data
                    measurements.Add(GetMeasurementData(values, 
                                                        MT7_4, 
                                                        MT7_5, 
                                                        ts, 
                                                        Measurement.MeasurementLocation.MT7));

                    // Add MT8 Data
                    measurements.Add(GetMeasurementData(values, 
                                                        MT8_4, 
                                                        MT8_5, 
                                                        ts, 
                                                        Measurement.MeasurementLocation.MT8));

                    // Add MT9 Data
                    measurements.Add(GetMeasurementData(values, 
                                                        MT9_4, 
                                                        MT9_5, 
                                                        ts, 
                                                        Measurement.MeasurementLocation.MT9));
                }
                #endregion
            }
            //PrintMeasurements(measurements);

            return measurements;
        }

        private int GetDataColumns(string[] headerValues, string columnName)
        {
            for (int i = 0; i < headerValues.Length; i++)
            {
                if (headerValues[i].Equals(columnName)) return i;
            }
            return 0;
        }

        private Measurement GetMeasurementData(string[] values, int windSpeed, int windDirection, DateTime ts, Measurement.MeasurementLocation location)
        {
            Measurement measurements = new Measurement()
            { 
               WindSpeed = float.Parse(values[windSpeed]),
               WindDirection = float.Parse(values[windDirection]),
               TimeStamp = ts.TimeOfDay.ToString(),
               TimeStampDT = ts,
               Location = location
            };

            return measurements;
        }

        private void PrintMeasurements(ICollection<Measurement> measurements)
        {
            foreach (Measurement measurement in measurements)
            {
                Debug.Print("{0}, {1}, {2}, {3}", measurement.Location.ToString(),
                                                  measurement.TimeStamp.ToString(),
                                                  measurement.WindDirection.ToString(),
                                                  measurement.WindSpeed.ToString());                
            }
        }

        public static List<Measurement> CurrentMeasurements(List<Measurement> allMeasurements)
        {
            return allMeasurements.Where(x => x.TimeStampDT.Hour == DateTime.Now.Hour 
                                               && x.TimeStampDT.Minute == DateTime.Now.Minute)
                                        .ToList();
        }

    }
}
