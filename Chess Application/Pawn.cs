using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Pawn : Piece
    {
        public Pawn(Player player) : base(player, Type.Pawn)
        {
            base.shift = 1;
            base.xaxis = new int[] { 0, 0, -1, 1 };
            base.yaxis = new int[] { 1, 2, 1, 1 };
        }
    }
}
