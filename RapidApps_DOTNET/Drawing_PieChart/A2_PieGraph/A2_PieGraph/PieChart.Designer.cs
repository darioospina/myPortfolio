
namespace A2_PieGraph
{
    partial class PieChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPieTitle = new System.Windows.Forms.Label();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblPieTitle
            // 
            this.lblPieTitle.AutoSize = true;
            this.lblPieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPieTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblPieTitle.Location = new System.Drawing.Point(139, 0);
            this.lblPieTitle.Name = "lblPieTitle";
            this.lblPieTitle.Size = new System.Drawing.Size(0, 20);
            this.lblPieTitle.TabIndex = 0;
            // 
            // panelLabels
            // 
            this.panelLabels.Location = new System.Drawing.Point(17, 228);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(267, 99);
            this.panelLabels.TabIndex = 1;
            // 
            // PieChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelLabels);
            this.Controls.Add(this.lblPieTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PieChart";
            this.Size = new System.Drawing.Size(300, 330);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PieChart_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPieTitle;
        private System.Windows.Forms.Panel panelLabels;
    }
}
