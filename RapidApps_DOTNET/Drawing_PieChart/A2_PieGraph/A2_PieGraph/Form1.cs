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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Data> dataList = new List<Data>();

        private void btnCreateChart_Click(object sender, EventArgs e)
        {
            pieChart1.clearPanel();
            pieChart1.clearTitle();
            dataList.Clear();

            if (dataForm1.LabelName1 != String.Empty)
            { 
                dataList.Add(new Data(dataForm1.LabelName1, float.Parse(dataForm1.Value1), "DeepPink")); 
            }

            if(dataForm1.LabelName2 != String.Empty)
            {
                dataList.Add(new Data(dataForm1.LabelName2, float.Parse(dataForm1.Value2), "DarkBlue"));
            }

            if (dataForm1.LabelName3 != String.Empty)
            {
                dataList.Add(new Data(dataForm1.LabelName3, float.Parse(dataForm1.Value3), "LimeGreen"));
            }

            if (dataForm1.LabelName4 != String.Empty)
            {
                dataList.Add(new Data(dataForm1.LabelName4, float.Parse(dataForm1.Value4), "Purple"));
            }

            if (dataForm1.LabelName5 != String.Empty)
            {
                dataList.Add(new Data(dataForm1.LabelName5, float.Parse(dataForm1.Value5), "CornflowerBlue"));
            }

            if (dataForm1.LabelName6 != String.Empty)
            {
                dataList.Add(new Data(dataForm1.LabelName6, float.Parse(dataForm1.Value6), "BlueViolet"));
            }

            if (dataForm1.LabelName7 != String.Empty)
            {
                dataList.Add(new Data(dataForm1.LabelName7, float.Parse(dataForm1.Value7), "Teal"));
            }

            if (dataForm1.LabelName8 != String.Empty)
            {
                dataList.Add(new Data(dataForm1.LabelName8, float.Parse(dataForm1.Value8), "LightCoral"));
            }

            if (dataForm1.LabelName9 != String.Empty)
            {
                dataList.Add(new Data(dataForm1.LabelName9, float.Parse(dataForm1.Value9), "Yellow"));
            }

            if (dataForm1.LabelName10 != String.Empty)
            {
                dataList.Add(new Data(dataForm1.LabelName10, float.Parse(dataForm1.Value10), "MediumVioletRed"));
            }

            pieChart1.setDataSource(dataForm1.Title, dataList);
            pieChart1.Refresh();
               
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataList.Clear();
            pieChart1.clearPanel();
            pieChart1.clearTitle();
            pieChart1.Refresh();

            dataForm1.Title = string.Empty;
            dataForm1.LabelName1 = string.Empty;
            dataForm1.LabelName2 = string.Empty;
            dataForm1.LabelName3 = string.Empty;
            dataForm1.LabelName4 = string.Empty;
            dataForm1.LabelName5 = string.Empty;
            dataForm1.LabelName6 = string.Empty;
            dataForm1.LabelName7 = string.Empty;
            dataForm1.LabelName8 = string.Empty;
            dataForm1.LabelName9 = string.Empty;
            dataForm1.LabelName10 = string.Empty;
            dataForm1.Value1 = string.Empty;
            dataForm1.Value2 = string.Empty;
            dataForm1.Value3 = string.Empty;
            dataForm1.Value4 = string.Empty;
            dataForm1.Value5 = string.Empty;
            dataForm1.Value6 = string.Empty;
            dataForm1.Value7 = string.Empty;
            dataForm1.Value8 = string.Empty;
            dataForm1.Value9 = string.Empty;
            dataForm1.Value10 = string.Empty;
        }

        private void lblDarioWebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dario-ospina.com");
        }
    }
}
