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

        public MeasurementLocation Location;
        public float WindSpeed;
        public float WindDirection;
        public DateTime TimeStamp;

        public Measurement()
        {

        }
    }
}
