using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabloCanyonEmergencyMetrics.Models
{
    public class Measurement
    {
        public enum MeasurementLocation
        {
            MT1, MT2, MT3, MT4, MT5, MT6, MT7, MT8, MT9
        };

        public MeasurementLocation Location { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public string TimeStamp { get; set; }
        public DateTime TimeStampDT;

        public Measurement()
        {

        }
    }
}
