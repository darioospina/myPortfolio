
namespace A2_DarioOspina
{
    partial class NHLForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.Label();
            this.filter1 = new System.Windows.Forms.TextBox();
            this.filter2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGo1 = new System.Windows.Forms.Button();
            this.buttonGo2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(156, 264);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1056, 303);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Title.Location = new System.Drawing.Point(156, 33);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(1056, 71);
            this.Title.TabIndex = 1;
            this.Title.Text = "NHL Player Stats 2017 - 2018";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // filter1
            // 
            this.filter1.Location = new System.Drawing.Point(279, 162);
            this.filter1.Multiline = true;
            this.filter1.Name = "filter1";
            this.filter1.Size = new System.Drawing.Size(340, 35);
            this.filter1.TabIndex = 2;
            this.filter1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filter1_KeyPress);
            // 
            // filter2
            // 
            this.filter2.Location = new System.Drawing.Point(766, 162);
            this.filter2.Multiline = true;
            this.filter2.Name = "filter2";
            this.filter2.Size = new System.Drawing.Size(340, 35);
            this.filter2.TabIndex = 3;
            this.filter2.TextChanged += new System.EventHandler(this.filter2_TextChanged);
            this.filter2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filter2_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter the information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(843, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sort the information";
            // 
            // buttonGo1
            // 
            this.buttonGo1.Location = new System.Drawing.Point(416, 203);
            this.buttonGo1.Name = "buttonGo1";
            this.buttonGo1.Size = new System.Drawing.Size(60, 43);
            this.buttonGo1.TabIndex = 6;
            this.buttonGo1.Text = "Go";
            this.buttonGo1.UseVisualStyleBackColor = true;
            this.buttonGo1.Click += new System.EventHandler(this.buttonGo1_Click);
            // 
            // buttonGo2
            // 
            this.buttonGo2.Location = new System.Drawing.Point(907, 203);
            this.buttonGo2.Name = "buttonGo2";
            this.buttonGo2.Size = new System.Drawing.Size(60, 43);
            this.buttonGo2.TabIndex = 7;
            this.buttonGo2.Text = "Go";
            this.buttonGo2.UseVisualStyleBackColor = true;
            this.buttonGo2.Click += new System.EventHandler(this.buttonGo2_Click);
            // 
            // NHLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 600);
            this.Controls.Add(this.buttonGo2);
            this.Controls.Add(this.buttonGo1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filter2);
            this.Controls.Add(this.filter1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.dataGridView1);
            this.Name = "NHLForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox filter1;
        private System.Windows.Forms.TextBox filter2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonGo1;
        private System.Windows.Forms.Button buttonGo2;
    }
}

