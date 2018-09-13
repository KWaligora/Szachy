using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Szachy.Pieces
{
    class King: Piece
    {
        public King(byte id, Bitmap image, byte [] board) : base(id, image, board) { } //moze pozostac pusty

        public override bool move(byte x, byte y)
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

