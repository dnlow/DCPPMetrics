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
            float hypotenuse = WindSpeed * 50f;
            float endX = baseX + hypotenuse * (float)Math.Cos(WindDirection - 180.0);
            float endY = baseY + hypotenuse * (float)Math.Sin(WindDirection - 180.0);
            Debug.Print("Angle: {0}", WindDirection);
            Debug.Print("Calulated Values: ({0}, {1})", endX - baseX, endY - baseY);
            Debug.Print("Base: ({0}, {1})      Tip: ({2}, {3})", baseX, baseY, endX, endY);

            return new PointF(endX, endY);
        }

        internal PointF GetArrowBeginning()
        {
            if (Location == MeasurementLocation.MT1) mLocation = new PointF(2500, 2500);
            if (Location == MeasurementLocation.MT2) mLocation = new PointF();
            if (Location == MeasurementLocation.MT3) mLocation = new PointF();
            if (Location == MeasurementLocation.MT4) mLocation = new PointF();
            if (Location == MeasurementLocation.MT5) mLocation = new PointF();
            if (Location == MeasurementLocation.MT6) mLocation = new PointF();
            if (Location == MeasurementLocation.MT7) mLocation = new PointF();
            if (Location == MeasurementLocation.MT8) mLocation = new PointF();
            if (Location == MeasurementLocation.MT9) mLocation = new PointF();
            return mLocation;
        }

        internal Pen GetArrow()
        {
            Pen pen = new Pen(Color.Red, 50)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor,
                EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor
            };

            return pen;
        }
    }
}
