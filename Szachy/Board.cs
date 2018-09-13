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
        Bitmap pieceBitmap;
        public Board()
        {
            pieceBitmap = global::Szachy.Properties.Resources.pieces;
            //czarne wieze
            pieces[0] = new Tower(0, pieceBitmap.Clone(new Rectangle(0,0,70,70), pieceBitmap.PixelFormat), pieces);
            pieces[7] = new Tower(7, pieceBitmap.Clone(new Rectangle(0,0,70,70), pieceBitmap.PixelFormat), pieces);
            //czarne konie
            pieces[1] = new Horse(1, pieceBitmap.Clone(new Rectangle(70,0,70,70), pieceBitmap.PixelFormat), pieces);
            pieces[6] = new Horse(6, pieceBitmap.Clone(new Rectangle(70,0,70,70), pieceBitmap.PixelFormat), pieces);
            //czarne gonce
            pieces[2] = new Runner(2, pieceBitmap.Clone(new Rectangle(140,0,70,70), pieceBitmap.PixelFormat), pieces);
            pieces[5] = new Runner(5, pieceBitmap.Clone(new Rectangle(140,0,70,70), pieceBitmap.PixelFormat), pieces);
            //czarna krolowa
            pieces[3] = new Queen(3, pieceBitmap.Clone(new Rectangle(210,0,70,70), pieceBitmap.PixelFormat), pieces);
            //czarny krol
            pieces[4] = new King(4, pieceBitmap.Clone(new Rectangle(280,0,70,70), pieceBitmap.PixelFormat), pieces);

            for (byte i = 8; i < 16; i++) { //pionki czarne
                pieces[i] = new Pawn(i, pieceBitmap.Clone(new Rectangle(350,0,70,70), pieceBitmap.PixelFormat), pieces);
            }

            for (byte i = 16; i < 24; i++) { //pionki biale
                pieces[i] = new Pawn(i, pieceBitmap.Clone(new Rectangle(350,70,70,70), pieceBitmap.PixelFormat), pieces);
            }

            //biale wieze
            pieces[24] = new Tower(24, pieceBitmap.Clone(new Rectangle(0,70,70,70), pieceBitmap.PixelFormat), pieces);
            pieces[31] = new Tower(31, pieceBitmap.Clone(new Rectangle(0, 70, 70, 70), pieceBitmap.PixelFormat), pieces);
            //czarne konie
            pieces[25] = new Horse(25, pieceBitmap.Clone(new Rectangle(70, 70, 70, 70), pieceBitmap.PixelFormat), pieces);
            pieces[30] = new Horse(30, pieceBitmap.Clone(new Rectangle(70, 70, 70, 70), pieceBitmap.PixelFormat), pieces);
            //czarne gonce
            pieces[26] = new Runner(26, pieceBitmap.Clone(new Rectangle(140, 70, 70, 70), pieceBitmap.PixelFormat), pieces);
            pieces[29] = new Runner(29, pieceBitmap.Clone(new Rectangle(140, 70, 70, 70), pieceBitmap.PixelFormat), pieces);
            //czarna krolowa
            pieces[27] = new Queen(27, pieceBitmap.Clone(new Rectangle(210, 70, 70, 70), pieceBitmap.PixelFormat), pieces);
            //czarny krol
            pieces[28] = new King(28, pieceBitmap.Clone(new Rectangle(280, 70, 70, 70), pieceBitmap.PixelFormat), pieces);

            setupBoard();
        }

        void setupBoard()
        {
            for (int i = 0; i < 16; i++)
            {
                board[i] = Convert.ToByte(i); // oryginalnie board[i] = Convert.ToByte(i + 1); // out of bounds
            }

            for (int i = 16; i < 48; i++)
            {
                board[i] = 32; // -1 nie wchodzi do byte :(
            }

            for (int i = 48; i < 64; i++)
            {
                board[i] = Convert.ToByte(i - 32); // oryginalnie board[i] = Convert.ToByte(i - 31); // out of bounds
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
