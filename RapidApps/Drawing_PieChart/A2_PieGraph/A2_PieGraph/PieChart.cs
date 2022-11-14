using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2_PieGraph
{
    public partial class PieChart : UserControl
    {
        public PieChart()
        {
            InitializeComponent();
            panelLabels.AutoScroll = true;
        }

        public List<Data> dataSource = new List<Data>();
        public String chartTitle { get; set; }

        public void clearPanel()
        {
            panelLabels.Controls.Clear();
        }

        public void clearTitle()
        {
            lblPieTitle.Text = String.Empty;
        }
        public void setDataSource(String title, List<Data> myData)
        {
            this.chartTitle = title;
            this.dataSource = myData;

            lblPieTitle.Text = title;
            lblPieTitle.Location = new Point((this.Size.Width - lblPieTitle.Size.Width) / 2,5);
        }

        private void PieChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle((this.Size.Width - 200) / 2, 30, 200, 200);

            float total = 0;

            foreach (var item in dataSource)
            {
                total += item.Value;
            }
            for(int i=0;i < dataSource.Count; i++)
            {
                dataSource[i].Percentage = dataSource[i].Value / total;
                dataSource[i].SweepAngle = 360 * dataSource[i].Percentage;
                if(i == 0)
                {
                    dataSource[i].StartAngle = 0;
                } 
                else
                {
                    dataSource[i].StartAngle = dataSource[i - 1].StartAngle + dataSource[i - 1].SweepAngle;
                }
            }
            
            foreach(var item in dataSource)
            {
                g.FillPie(new SolidBrush(Color.FromName(item.Color)),rect,item.StartAngle,item.SweepAngle);
            }

            int varY = 0;

            for(int i=0;i< dataSource.Count;i++)
            {
                var newLabelName = new Label();
                
                varY += newLabelName.Size.Height;
                
                newLabelName.Text = dataSource[i].Name;
                newLabelName.Location = new Point(15, varY);
                panelLabels.Controls.Add(newLabelName);

                var newLabelColor = new Label();

                newLabelColor.Width = 10;
                newLabelColor.BackColor = Color.FromName(dataSource[i].Color);
                newLabelColor.Location = new Point(0, varY);
                panelLabels.Controls.Add(newLabelColor);
            }

        }

    }
}
