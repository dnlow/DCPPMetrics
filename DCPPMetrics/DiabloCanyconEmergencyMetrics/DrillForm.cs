using DiabloCanyonEmergencyMetrics.Logic;
using DiabloCanyonEmergencyMetrics.Models;
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

namespace DiabloCanyonEmergencyMetrics
{
    public partial class DrillForm : Form
    {
        List<Measurement> measurements;
        DateTime previous;

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
                DataProcessor dp = new DataProcessor(dataFile.FileName, this);
                measurements = dp.ReadCSVFile();
                dataGridView1.DataSource = DataProcessor.CurrentMeasurements(measurements);
                previous = DateTime.Now;
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute - 1 == previous.Minute || DateTime.Now.Hour > previous.Hour)
            {
                dataGridView1.DataSource = DataProcessor.CurrentMeasurements(measurements);
                previous = DateTime.Now;
            }    
        }
    }
}
