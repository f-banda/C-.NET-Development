using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Knight : Piece
    {
        public Knight(Player player) : base(player, Type.Knight)
        {
            base.shift = 8;
            base.yaxis = new int[] { 1, 2, -2, -1, -2, -1, 1, 2 };
            base.xaxis = new int[] { 2, 1, 1, 2, -1, -2, -2, -1 };
        }
    }
}
