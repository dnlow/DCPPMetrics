using DiabloCanyonEmergencyMetrics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiabloCanyconEmergencyMetrics.Logic
{
    class GraphicsProcessing
    {
        public static String baseMapPath = "";

        public static Bitmap DrawMap(PictureBox pictureBox, List<Measurement> measurements)
        {
            Bitmap bmp = new Bitmap(baseMapPath);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (Measurement m in measurements)
                {
                    g.DrawLine(m.GetArrow(), m.GetArrowBeginning(), m.GetArrowEnd());
                }
            }
            return bmp;
        }
    }
}
