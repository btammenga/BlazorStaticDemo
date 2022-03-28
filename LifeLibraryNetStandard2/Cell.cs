using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLibraryNetStandard2

{
    public class Cell
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public bool IsAlive { get; set; }

        public int LivingNeigbours { get; set; }
        public List<Cell> Neighbours { get; set; }

    }
}
