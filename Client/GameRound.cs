using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class GameRound
    {
        public int HumanIndexMove { get; set; }
        public int ServerIndexMove { get; set; }
        public string Winner { get; set; }

        public List<int> unreachedCells { get; set; }
    }
}
