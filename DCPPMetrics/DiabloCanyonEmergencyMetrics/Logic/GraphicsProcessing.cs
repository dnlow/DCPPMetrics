using DiabloCanyonEmergencyMetrics.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiabloCanyonEmergencyMetrics.Logic
{
    public static class GraphicsProcessing
    {
        public static String baseMapPath = Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\eoc_tvmap_archd.jpg";

        public static Bitmap DrawMap(List<Measurement> measurements, float clientRectangleHeight)
        {
            Bitmap bmp = new Bitmap(baseMapPath);
            Bitmap tempBMP = new Bitmap(bmp.Width, bmp.Height);

            Debug.Print("Width: {0}, Height: {1}", tempBMP.Width, tempBMP.Height);
            tempBMP.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
            using (Graphics g = Graphics.FromImage(tempBMP))
            {
                g.DrawImage(bmp, 0, 0);
                g.ScaleTransform(1.0F, -1.0F);
                g.TranslateTransform(0, -tempBMP.Height);
                foreach (Measurement m in measurements)
                {
                    g.DrawLine(m.GetArrow(), m.GetArrowBeginning(), m.GetArrowEnd());
                }
            }

            return tempBMP;
        }
    }
}
