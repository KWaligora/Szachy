using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Szachy.Pieces
{
    class Runner: Piece
    {
        public Runner(byte id, Bitmap image) : base(id, image) { } //moze pozostac pusty

        public override bool move()
        {
            return true;
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
