using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_MemoryMatch
{
    public class Player
    {
        public int Moves { get; set; } = 0;
        public int Pairs { get; set; } = 0;

        public Boolean PlayerTurn { get; set; } = false;
    }
}
