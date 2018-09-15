using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Szachy.Pieces
{
    class Tower : Piece
    {
        public Tower(byte id, Bitmap image, byte[] board) : base(id, image, board)
        {
        } //moze pozostac pusty

        public override bool move(byte moveFrom, byte moveTo)
        {
            int moveFromX = moveFrom / 8;
            int moveFromY = moveFrom % 8;
            int moveToX = moveTo / 8;
            int moveToY = moveTo % 8;
            if (overlaping(moveFromX, moveFromY, moveToX, moveToY)) return false;
            if (Math.Abs(moveFromX - moveToX) == 0 || Math.Abs(moveFromY - moveToY) == 0) return true;
            return false;
        }

        // returns true if there is another piece on moving piece's way
        private bool overlaping(int moveFromX, int moveFromY, int moveToX, int moveToY)
        {
            bool ascending = false;

            // check along which axis is piece moving
            if (moveFromX - moveToX == 0)
            {
                // along y axis
                // check if parameter is ascending or not
                if (moveFromY - moveToY < 0) ascending = true;

                if (ascending)
                {
                    for (int y = moveFromY + 1; y < moveToY; ++y)
                    {
                        if (board[convertToOneDimension(moveFromX, y)] != 32) return true;
                    }
                }
                else
                {
                    for (int y = moveFromY - 1; y > moveToY; --y)
                    {
                        if (board[convertToOneDimension(moveFromX, y)] != 32) return true;
                    }
                }
            }
            else
            {
                // along x axis
                if (moveFromX - moveToX < 0) ascending = true;
                if (ascending)
                {
                    for (int x = moveFromX + 1; x < moveToX; ++x)
                    {
                        if (board[convertToOneDimension(x, moveFromY)] != 32) return true;
                    }
                }
                else
                {
                    for (int x = moveFromX - 1; x > moveToX; --x)
                    {
                        if (board[convertToOneDimension(x, moveFromY)] != 32) return true;
                    }
                }
            }

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