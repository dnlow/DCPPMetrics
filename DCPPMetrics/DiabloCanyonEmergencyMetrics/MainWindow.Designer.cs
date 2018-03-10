namespace DiabloCanyonEmergencyMetrics
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DrillButton = new System.Windows.Forms.Button();
            this.LiveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrillButton
            // 
            this.DrillButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DrillButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DrillButton.Location = new System.Drawing.Point(696, 292);
            this.DrillButton.Name = "DrillButton";
            this.DrillButton.Size = new System.Drawing.Size(435, 100);
            this.DrillButton.TabIndex = 0;
            this.DrillButton.Text = "Simulated Emergency";
            this.DrillButton.UseVisualStyleBackColor = true;
            // 
            // LiveButton
            // 
            this.LiveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LiveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LiveButton.Location = new System.Drawing.Point(696, 489);
            this.LiveButton.Name = "LiveButton";
            this.LiveButton.Size = new System.Drawing.Size(435, 100);
            this.LiveButton.TabIndex = 1;
            this.LiveButton.Text = "Live Emergency";
            this.LiveButton.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 1000);
            this.Controls.Add(this.LiveButton);
            this.Controls.Add(this.DrillButton);
            this.Name = "MainWindow";
            this.Text = "DCPP Emergency Metrics";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DrillButton;
        private System.Windows.Forms.Button LiveButton;
    }
}

