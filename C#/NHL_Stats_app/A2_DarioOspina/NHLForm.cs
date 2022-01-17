using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Windows.Forms;
using A2_DarioOspina;
using System.Collections;
using System.Text.RegularExpressions;


namespace A2_DarioOspina
{
    public partial class NHLForm : Form
    {
        public List<NHLStats> records; // Contains and displays the records of the NHL cvs file
        public ArrayList listOfExpressions = new ArrayList(); // Contains the list of expressions from the filter textbox
        public List<Operation> singleExp = new List<Operation>();

        public NHLForm()
        {
            InitializeComponent();
            using (var reader = new StreamReader(@"C:\Users\da_os\Documents\Personal\BVC\03Fall2021\SODV2202 - Object Oriented Programming\Assignments\Assignment 2\A2_DarioOspina\NHL Player Stats 2017-18.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<NHLStats>().ToList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = records;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = records;
        }


        // This receives the input from the user and returns the table filtered
        private void infoToFilter(string input)
        {
            string[] expression = input.ToLower().Trim().Split(',');
            for(int i = 0; i<=expression.Length -1; i++)
            {
                listOfExpressions.Add(expression[i].Trim().Replace(" ", ""));
            }

            for (int i = 0; i <= listOfExpressions.Count - 1; i++)
            {
                for (int j = 0; j <= listOfExpressions[i].ToString().Length - 1; j++)
                {
                    Stack<string> finalExp = new Stack<string>(); // This stack will store each of the three parts of the expression
                    string str = listOfExpressions[i].ToString(); // str = Complete expression (eg. 'P >= 100')
                    char ch = str[j]; // Represents each character of the str
                    int pos = 0; // Initial position of the str

                    if (ch == '<' || ch == '=' || ch == '>')
                    {
                        string firstExp = str.Substring(pos, j);
                        string secondExp = null;
                        string thirdExp = null;
                        finalExp.Push(firstExp);
                        pos = j;
                        ch = str[pos + 1];
                        if (ch == '<' || ch == '=' || ch == '>')
                        {
                            secondExp = str.Substring(pos, 2);
                            finalExp.Push(secondExp);
                            pos = pos + 2;
                            thirdExp = str.Substring(pos);
                            finalExp.Push(thirdExp);
                        }
                        else
                        {
                            secondExp = str.Substring(pos, 1);
                            pos = pos + 1;
                            thirdExp = str.Substring(pos);
                            finalExp.Push(thirdExp);
                        }
                        j = listOfExpressions[i].ToString().Length - 1;
                        singleExp.Add(new Operation { part1 = firstExp, part2 = secondExp, part3 = thirdExp });
                    }
                }
            }
            foreach(var item in singleExp)
            {
                item.part1 = getColumn(item.part1);
            }

            string query = null;
            
            for (int i=0; i<= singleExp.Count -1; i++)
            {
                if (singleExp.Count > 0)
                {
                    if(i == singleExp.Count-1)
                    {
                        query += singleExp[i].part1 + " " + singleExp[i].part2 + " " + singleExp[i].part3 + " ";
                    } else
                    {
                        query += singleExp[i].part1 + " " + singleExp[i].part2 + " " + singleExp[i].part3 + " AND ";
                    }
                }
                if (singleExp.Count == 0)
                {
                    query = singleExp[i].part1 + " " + singleExp[i].part2 + " " + singleExp[i].part3;
                }
            }

            var recordsFiltered = records.AsQueryable().Where(query).ToList();
            dataGridView1.DataSource = recordsFiltered;

            filter1.Clear();
            query = null;
        }
        

    // This method gets the input from the user and returns the table sorted 
    private void infoToSort(string input)
        {
            string[] expression = input.ToLower().Trim().Split(' ');
            string part1 = expression[0];
            string part2 = expression[expression.Length - 1];
            string columnToBeSorted = getColumn(part1);
            
            var recordsSorted = records;

            if(part2 == "asc")
            {
                recordsSorted = records.AsQueryable().OrderBy(columnToBeSorted + " ascending").ToList();
                filter1.Text = "";
            }
            if (part2 == "desc")
            {
                recordsSorted = records.AsQueryable().OrderBy(columnToBeSorted + " descending").ToList();
                filter1.Text = "";
            }

            dataGridView1.DataSource = recordsSorted;
            filter2.Clear();
        }


        // This method takes the name of the column from the user and returns the Column name as appears on the CSV file
        public static string getColumn(string input)
        {
            string[] columns = { "Name", "Team", "Pos", "GP", "G", "A", "P", "Plus_minus", "PIM", "P_GP", "PPG", "PPP", "SHG", "SHP", "GWG", "OTG", "S", "S_percent", "TOI_GP", "Shifts_GP", "FOW_percent" };
            foreach (var column in columns)
            {
                if (input == column.ToLower())
                    return column;
            }
            return null;
        }

        // These two methods receive the input from the user and call the method infoToFilter
        private void buttonGo1_Click(object sender, EventArgs e)
        {
            var input = filter1.Text;
            infoToFilter(input);
        }

        private void filter1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var input = filter1.Text;
            if (e.KeyChar == (char)Keys.Enter)
            {
                infoToFilter(input);
            }
        }

        // These two method receive the input from the user and calls the method infoToSort
        private void filter2_KeyPress(object sender, KeyPressEventArgs e)
        {
            var input = filter2.Text;
            if (e.KeyChar == (char)Keys.Enter)
            {
                infoToSort(input);
            }
        }

        private void buttonGo2_Click(object sender, EventArgs e)
        {
            var input = filter2.Text;
            infoToSort(input);

        }

        private void filter2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
