using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int AltınDegeri { get; set; }
        public bool gizliMi { get; set; }
        public override string ToString()
        {
            return "X:" + X.ToString() + " Y:" + Y.ToString(); 
        }
    }
}
   
