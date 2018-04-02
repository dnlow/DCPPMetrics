using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        public double WindDirection { get; set; }
        public string TimeStamp { get; set; }
        public DateTime TimeStampDT;
        private PointF mLocation;

        public Measurement()
        {

        }

        /**
         *  Holy shit I had to do trig for the first time in like 6 years my math teachers are screaming "told you so"
         */
        internal PointF GetArrowEnd()
        {
            float baseX = mLocation.X;
            float baseY = mLocation.Y;

            float hypotenuse = WindSpeed * 75f;

            double theta = WindDirection;
            double radians = theta * Math.PI / 180.0;
            float newTheta = (float)Math.Atan(Math.Cos(radians) / Math.Sin(radians));

            float endX = baseX + hypotenuse * -1 * (float)Math.Sin(radians);
            float endY = baseY + hypotenuse * -1 * (float)Math.Cos(radians);

            return new PointF(endX, endY);
        }


        internal PointF GetArrowBeginning()
        {
            if (Location == MeasurementLocation.MT1) mLocation = new PointF(1500, 2500);
            if (Location == MeasurementLocation.MT2) mLocation = new PointF(1750, 2500);
            if (Location == MeasurementLocation.MT3) mLocation = new PointF(2000, 2500);
            if (Location == MeasurementLocation.MT4) mLocation = new PointF(2250, 2500);
            if (Location == MeasurementLocation.MT5) mLocation = new PointF(2500, 2500);
            if (Location == MeasurementLocation.MT6) mLocation = new PointF(2750, 2500);
            if (Location == MeasurementLocation.MT7) mLocation = new PointF(3000, 2500);
            if (Location == MeasurementLocation.MT8) mLocation = new PointF(3250, 2500);
            if (Location == MeasurementLocation.MT9) mLocation = new PointF(3500, 2500);
            return mLocation;
        }

        internal Pen GetArrow()
        {
            Pen pen = new Pen(Color.Red, 50)
            {
                EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor,
                StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor
            };

            return pen;
        }
    }
}
