using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Szachy.Pieces
{
    class Runner : Piece
    {
        public Runner(byte id, Bitmap image, byte[] board) : base(id, image, board)
        {
        } //moze pozostac pusty

        public override bool move(byte moveFrom, byte moveTo)
        {
            int moveFromX = moveFrom / 8;
            int moveFromY = moveFrom % 8;
            int moveToX = moveTo / 8;
            int moveToY = moveTo % 8;
            bool Xascending = false;
            bool Yascending = false;
            int tmpX = moveFromX;
            int tmpY = moveFromY;

            if (moveFromX - moveToX < 0) Xascending = true;
            if (moveFromY - moveToY < 0) Yascending = true;

            do
            {
                if (Xascending && Yascending)
                {
                    ++tmpX;
                    ++tmpY;
                }
                else if (Xascending && !Yascending)
                {
                    ++tmpX;
                    --tmpY;
                }
                else if (!Xascending && !Yascending)
                {
                    --tmpX;
                    --tmpY;
                }
                else if (!Xascending && Yascending)
                {
                    --tmpX;
                    ++tmpY;
                }

                if (board[convertToOneDimension(tmpX, tmpY)] != 32) return false;
            } while (tmpX != moveToX);

            if (Math.Abs(moveFromX - moveToX) == Math.Abs(moveFromY - moveToY)) return true;

            return false;
        }

        private int convertToOneDimension(int x, int y)
        {
            return (x * 8) + y;
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