using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy.Pieces
{
    class Tower: Piece
    {
        protected byte id;

        public override bool move()
        {
            return true;
        }

        public override void draw()
        {

        }

        public override bool special()
        {
            return true;
        }

        public override byte getPieceID()
        {
            return id;
        }
    }
}

