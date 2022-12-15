using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class King : Piece
    {
        public King(Player player) : base(player, Type.King)
        {
            base.shift = 8;
            base.xaxis = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            base.yaxis = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        }
    }
}
