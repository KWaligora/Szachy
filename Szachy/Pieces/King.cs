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
            int xp = x / 8;
            int xq = x % 8;
            int yp = y / 8;
            int yq = y % 8;

            if (board[x] < 16 && board[y] < 16) return false;
            if (board[x] > 16 && board[x] < 32 && board[y] > 16 && board[y] < 32) return false;
            if ((Math.Abs(xp - yp) == 1 && Math.Abs(xq - yq) == 0) || (Math.Abs(xp - yp) == 0 && Math.Abs(xq - yq) == 1)) return true;
            
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

