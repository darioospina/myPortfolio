using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_MemoryMatch
{
    public class Card
    {
        public char Front = '?';
        public int Back { get; set; }
        public Boolean paired { get; set; } = false;
        public Card(int back)
        {
            this.Back = back;
        }
    }
}
