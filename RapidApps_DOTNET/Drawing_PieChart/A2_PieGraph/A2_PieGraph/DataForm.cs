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
    public partial class DataForm : UserControl
    {
        public DataForm()
        {
            InitializeComponent();
        }

        // Chart Title
        public String Title { get { return txtBoxTitle.Text; } set { txtBoxTitle.Text = value; } }

        // Labels
        public String LabelName1 { get { return txtBoxLbl1.Text; } set { txtBoxLbl1.Text = value; } }
        public String LabelName2 { get { return txtBoxLbl2.Text; } set { txtBoxLbl2.Text = value; } }
        public String LabelName3 { get { return txtBoxLbl3.Text; } set { txtBoxLbl3.Text = value; } }
        public String LabelName4 { get { return txtBoxLbl4.Text; } set { txtBoxLbl4.Text = value; } }
        public String LabelName5 { get { return txtBoxLbl5.Text; } set { txtBoxLbl5.Text = value; } }
        public String LabelName6 { get { return txtBoxLbl6.Text; } set { txtBoxLbl6.Text = value; } }
        public String LabelName7 { get { return txtBoxLbl7.Text; } set { txtBoxLbl7.Text = value; } }
        public String LabelName8 { get { return txtBoxLbl8.Text; } set { txtBoxLbl8.Text = value; } }
        public String LabelName9 { get { return txtBoxLbl9.Text; } set { txtBoxLbl9.Text = value; } }
        public String LabelName10 { get { return txtBoxLbl10.Text; } set { txtBoxLbl10.Text = value; } }

        // Values
        public String Value1 { get { return txtBoxVal1.Text; } set { txtBoxVal1.Text = value; } }
        public String Value2 { get { return txtBoxVal2.Text; } set { txtBoxVal2.Text = value; } }
        public String Value3 { get { return txtBoxVal3.Text; } set { txtBoxVal3.Text = value; } }
        public String Value4 { get { return txtBoxVal4.Text; } set { txtBoxVal4.Text = value; } }
        public String Value5 { get { return txtBoxVal5.Text; } set { txtBoxVal5.Text = value; } }
        public String Value6 { get { return txtBoxVal6.Text; } set { txtBoxVal6.Text = value; } }
        public String Value7 { get { return txtBoxVal7.Text; } set { txtBoxVal7.Text = value; } }
        public String Value8 { get { return txtBoxVal8.Text; } set { txtBoxVal8.Text = value; } }
        public String Value9 { get { return txtBoxVal9.Text; } set { txtBoxVal9.Text = value; } }
        public String Value10 { get { return txtBoxVal10.Text; } set { txtBoxVal10.Text = value; } }

    }
}
