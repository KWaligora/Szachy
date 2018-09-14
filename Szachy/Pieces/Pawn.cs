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
        private bool moved = false;

        public Pawn(byte id, Bitmap image, byte[] board) : base(id, image, board)
        {
        }

        public override bool move(byte x, byte y)
        {
            int xp = x / 8;
            int xq = x % 8;
            int yp = y / 8;
            int yq = y % 8;
            Console.WriteLine("---------"+board[x]+"----------");
            Console.WriteLine("xp: "+xp);
            Console.WriteLine("xq: "+xq);
            Console.WriteLine("yp: "+yp);
            Console.WriteLine("yq: "+yq);
            Console.WriteLine("--------"+id+"--------");
            if (board[x] < 16 && board[y] < 16) return false;
            if (board[x] > 16 && board[x] < 32 && board[y] > 16 && board[y] < 32) return false;
            if (board[x] < 16)
            {
                if (IsMoved() && xq - yq == 0 && xp - yp == -1) return true;
                if (!IsMoved() && xq - yq == 0 && xp - yp >= -2)
                {
                    moved = true;
                    return true;
                }
            }
            else
            {
                if (IsMoved() && xq - yq == 0 && xp - yp == 1) return true;
                if (!IsMoved() && xq - yq == 0 && xp - yp <= 2)
                {
                    moved = true;
                    return true;
                }
            }

            return false;
        }

        private bool IsMoved()
        {
            return moved;
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