using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiabloCanyonEmergencyMetrics
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            DrillButton.Click += new EventHandler(Drill_Clicked);
            LiveButton.Click += new EventHandler(Live_Clicked);
        }

        private void Drill_Clicked(object sender, EventArgs e)
        {
            DrillForm drill = new DrillForm
            {
                Icon = this.Icon,
                Tag = this
            };
            drill.Show();
            Hide();
        }

        private void Live_Clicked(object sender, EventArgs e)
        {
            LiveEmergency live = new LiveEmergency()
            {
                Icon = this.Icon,
                Tag = this
            };
            live.Show();
            Hide();
        }
    }
}
