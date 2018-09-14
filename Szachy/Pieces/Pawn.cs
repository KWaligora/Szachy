using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Szachy.Pieces
{
    class Pawn : Piece
    {
        private bool _moved = false;

        public Pawn(byte id, Bitmap image, byte[] board) : base(id, image, board)
        {
        }

        public override bool move(byte moveFrom, byte moveTo)
        {
            int movefromX = moveFrom / 8;
            int movefromY = moveFrom % 8;
            int moveToX = moveTo / 8;
            int moveToY = moveTo % 8;

            if (board[moveFrom] < 16)
            {
                if (IsMoved() &&  movefromY - moveToY  == 0 && movefromX - moveToX  == -1) return true;
                if (!IsMoved() &&  movefromY - moveToY  == 0 && movefromX - moveToX  >= -2)
                {
                    _moved = true;
                    return true;
                }
            }
            else
            {
                if (IsMoved() &&  movefromY - moveToY  == 0 && movefromX - moveToX  == 1) return true;
                if (!IsMoved() &&  movefromY - moveToY  == 0 && movefromX - moveToX  <= 2)
                {
                    _moved = true;
                    return true;
                }
            }

            return false;
        }

        private bool IsMoved()
        {
            return _moved;
        }

        public override bool special()
        {
            return false;
        }

        public override byte getPieceID()
        {
            return id;
        }
    }
}