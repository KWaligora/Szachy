using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Szachy.Pieces
{
    class King : Piece
    {
        public King(byte id, Bitmap image, byte[] board) : base(id, image, board)
        {
        } //moze pozostac pusty

        public override bool move(byte moveFrom, byte moveTo)
        {
            int moveFromX = moveFrom / 8;
            int moveFromY = moveFrom % 8;
            int moveToX = moveTo / 8;
            int moveToY = moveTo % 8;

            if ((Math.Abs(moveFromX - moveToX) <= 1 && Math.Abs(moveFromY - moveToY) <= 1)) return true;

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