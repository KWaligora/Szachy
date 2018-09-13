using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using Szachy.Pieces;

namespace Szachy
{
    class Board
    {
        byte[] board = new byte[64];
        Piece[] pieces = new Piece[32];
        
        public Board()
        {
            for (int i = 0; i < 16; i++)
            {
                board[i] = Convert.ToByte(i); // oryginalnie board[i] = Convert.ToByte(i + 1); // out of bounds
            }

            for (int i = 16; i<48; i++)
            {
                board[i] = 32; // -1 nie wchodzi do byte :(
            }

            for (int i = 48; i < 64; i++)
            {
                board[i] = Convert.ToByte(i - 32); // oryginalnie board[i] = Convert.ToByte(i - 31); // out of bounds
            }

            for (int i = 0; i < 32; i++) {
                pieces[i] = new Pawn(0, global::Szachy.Properties.Resources.select);
            }
            
        }

        public int get_piece(int x)
        {
            for (int i = 0; i < 64; i++)
            {
                if (board[i] == x) return i;
            }
            return -1;
        }

        public byte [] get_board()
        {
            return board;
        }

        public byte getPieceID(int x)
        {
            return board[x];
            //return pieces[x].getPieceID(); // WTF po co mi to ;p
        }

        public Piece getPiece(int x)
        {
            return pieces[x];
        }
    }
}
