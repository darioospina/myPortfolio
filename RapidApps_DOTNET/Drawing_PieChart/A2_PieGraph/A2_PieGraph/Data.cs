using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_PieGraph
{
    public class Data
    {
        public String Name { get; set; }
        public float Value { get; set; }
        public String Color { get; set; }
        public float Percentage { get; set; }
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }

        public Data(String name, float value, String color)
        {
            this.Name = name;
            this.Value = value;
            this.Color = color;
        }

        public Data(String name, float value, String color, float startAngle, float sweepAngle)
        {
            this.Name = name;
            this.Value = value;
            this.Color = color;
            this.StartAngle = startAngle;
            this.SweepAngle = sweepAngle;
        }
    }
}
