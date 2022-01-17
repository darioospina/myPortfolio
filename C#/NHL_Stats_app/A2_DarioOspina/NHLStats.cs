using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_DarioOspina
{
    public class NHLStats
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public string Pos { get; set; }
        public int GP { get; set; }
        public int G { get; set; }
        public int A { get; set; }
        public int P { get; set; }
        public int Plus_minus { get; set; }
        public int PIM { get; set; }
        public double P_GP { get; set; }
        public int PPG { get; set; }
        public int PPP { get; set; }
        public int SHG { get; set; }
        public int SHP { get; set; }
        public int GWG { get; set; }
        public int OTG { get; set; }
        public int S { get; set; }
        public double S_percent { get; set; }
        public string TOI_GP { get; set; }
        public double Shifts_GP { get; set; }
        public double FOW_percent { get; set; }

        public string getColumn (string input)
        {
            string[] columns = { "Name", "Team", "Pos", "GP", "G", "A", "P", "Plus_minus", "PIM", "P_GP", "PPG", "PPP", "SHG", "SHP", "GWG", "OTG", "S", "S_percent", "TOI_GP", "Shifts_GP", "FOW_percent" };
            foreach(var column in columns)
            {
                if (input == column.ToLower())
                    return column;
            }
            return null;
        }
    }
}
