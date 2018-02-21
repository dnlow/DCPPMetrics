using DiabloCanyconEmergencyMetrics.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiabloCanyconEmergencyMetrics
{
    public partial class DrillForm : Form
    {
        public DrillForm()
        {
            InitializeComponent();
            BackButton.Click += new EventHandler(BackButton_Click);

            OpenFileDialog dataFile = new OpenFileDialog
            {
                Filter = "Comma Separated Files|*.csv",
                Title = "Select an CSV Data File",
                Multiselect = false
            };

            if (dataFile.ShowDialog() == DialogResult.OK)
            {
                new DataProcessor(dataFile.FileName, this);
            }
            else
            {
                String errorMessage = "Please select a .csv file containing data for the test. " +
                    "Press the 'Back' button and then hit the 'Simulated Emergency' " +
                    "button on the home page.";
                MessageBox.Show(errorMessage);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
