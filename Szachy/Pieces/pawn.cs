using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Szachy.Pieces
{
    class Pawn: Piece
    {
        public Pawn(byte id, Bitmap image, byte [] board) : base(id, image, board) { } //moze pozostac pusty

        public override bool move(byte x, byte y)
        {
            board[y] = board[x];
            board[x] = 32;
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
