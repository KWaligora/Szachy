using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Szachy.Pieces
{
    class Runner : Piece
    {
        public Runner(byte id, Bitmap image, byte[] board) : base(id, image, board)
        {
        } //moze pozostac pusty

        public override bool move(byte x, byte y)
        {
            int xp = x / 8;
            int xq = x % 8;
            int yp = y / 8;
            int yq = y % 8;
            if (Math.Abs(xp - yp) == Math.Abs(xq - yq)) return true;

            return false;
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