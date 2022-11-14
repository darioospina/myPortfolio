
namespace A2_PieGraph
{
    partial class Form1
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
            this.btnCreateChart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblDarioWebsite = new System.Windows.Forms.Label();
            this.pieChart1 = new A2_PieGraph.PieChart();
            this.dataForm1 = new A2_PieGraph.DataForm();
            this.SuspendLayout();
            // 
            // btnCreateChart
            // 
            this.btnCreateChart.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnCreateChart.Location = new System.Drawing.Point(864, 665);
            this.btnCreateChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateChart.Name = "btnCreateChart";
            this.btnCreateChart.Size = new System.Drawing.Size(180, 56);
            this.btnCreateChart.TabIndex = 2;
            this.btnCreateChart.Text = "Create Chart";
            this.btnCreateChart.UseVisualStyleBackColor = false;
            this.btnCreateChart.Click += new System.EventHandler(this.btnCreateChart_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnClear.Location = new System.Drawing.Point(1068, 665);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(180, 56);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAuthor.Location = new System.Drawing.Point(348, 735);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(387, 25);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "Developed by Dario Ospina. Visit me at";
            // 
            // lblDarioWebsite
            // 
            this.lblDarioWebsite.AutoSize = true;
            this.lblDarioWebsite.ForeColor = System.Drawing.Color.Cyan;
            this.lblDarioWebsite.Location = new System.Drawing.Point(726, 735);
            this.lblDarioWebsite.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDarioWebsite.Name = "lblDarioWebsite";
            this.lblDarioWebsite.Size = new System.Drawing.Size(177, 25);
            this.lblDarioWebsite.TabIndex = 5;
            this.lblDarioWebsite.Text = "dario-ospina.com";
            this.lblDarioWebsite.Click += new System.EventHandler(this.lblDarioWebsite_Click);
            // 
            // pieChart1
            // 
            this.pieChart1.BackColor = System.Drawing.Color.White;
            this.pieChart1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieChart1.chartTitle = null;
            this.pieChart1.Location = new System.Drawing.Point(752, 15);
            this.pieChart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(598, 633);
            this.pieChart1.TabIndex = 1;
            // 
            // dataForm1
            // 
            this.dataForm1.BackColor = System.Drawing.Color.Lavender;
            this.dataForm1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataForm1.LabelName1 = "";
            this.dataForm1.LabelName10 = "";
            this.dataForm1.LabelName2 = "";
            this.dataForm1.LabelName3 = "";
            this.dataForm1.LabelName4 = "";
            this.dataForm1.LabelName5 = "";
            this.dataForm1.LabelName6 = "";
            this.dataForm1.LabelName7 = "";
            this.dataForm1.LabelName8 = "";
            this.dataForm1.LabelName9 = "";
            this.dataForm1.Location = new System.Drawing.Point(16, 15);
            this.dataForm1.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.dataForm1.Name = "dataForm1";
            this.dataForm1.Size = new System.Drawing.Size(714, 704);
            this.dataForm1.TabIndex = 0;
            this.dataForm1.Title = "";
            this.dataForm1.Value1 = "";
            this.dataForm1.Value10 = "";
            this.dataForm1.Value2 = "";
            this.dataForm1.Value3 = "";
            this.dataForm1.Value4 = "";
            this.dataForm1.Value5 = "";
            this.dataForm1.Value6 = "";
            this.dataForm1.Value7 = "";
            this.dataForm1.Value8 = "";
            this.dataForm1.Value9 = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1380, 779);
            this.Controls.Add(this.lblDarioWebsite);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreateChart);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.dataForm1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataForm dataForm1;
        private PieChart pieChart1;
        private System.Windows.Forms.Button btnCreateChart;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblDarioWebsite;
    }
}

