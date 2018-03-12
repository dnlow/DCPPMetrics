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
        private bool addX = false;
        private bool addY = false;

        public Measurement()
        {
            
        }

        /**
         *  Holy shit I had to do trig for the first time in like 6 years my math teachers are screaming "told you so"
         */
        internal PointF GetArrowEnd()
        {
            DetermineHeading();
            float baseX = mLocation.X;
            float baseY = mLocation.Y;
            float hypotenuse = WindSpeed * 50f;
            float endX = baseX + hypotenuse * (addX ? Math.Abs((float)Math.Cos(WindDirection)) : (float)Math.Cos(WindDirection));
            float endY = baseY + hypotenuse * (addY ? Math.Abs((float)Math.Sin(WindDirection)) : (float)Math.Sin(WindDirection));
            Debug.Print("Add X: {0}         Add Y: {1}", addX, addY);
            Debug.Print("Angle: {0}         Andjusted Angle: {1}", WindDirection, WindDirection - 270.0);
            Debug.Print("Calulated Values: ({0}, {1})", endX - baseX, endY - baseY);
            Debug.Print("Base: ({0}, {1})      Tip: ({2}, {3})", baseX, baseY, endX, endY);

            return new PointF(endX, endY);
        }

        internal void DetermineHeading()
        {
            if (WindDirection >= 180)
            {
                addX = true;
                if (WindDirection >= 270.0 || WindDirection <= 90.0)
                {
                    addY = true;
                }
            }
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
