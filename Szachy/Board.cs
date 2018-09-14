using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using Szachy.Pieces;
using System.ComponentModel;

namespace Szachy
{
    
    class Board
    {
        BackgroundWorker workerThread;
        byte[] board = new byte[64];
        Piece[] pieces = new Piece[32];
        Bitmap pieceBitmap;
        bool pieceSelected = false;
        byte selectedPiecePosition;
        bool whiteMove;
        public Connection connectionReference;
        Player playerYou;
        Player playerEnemy;
        Window windowReference;
        public Board(Connection connectionReference, Player playerYou, Player playerEnemy, bool whiteMove)
        {
            workerThread = new BackgroundWorker();
            this.playerYou = playerYou;
            this.playerEnemy = playerEnemy;
            this.whiteMove = whiteMove;
            this.connectionReference = connectionReference;
            pieceBitmap = global::Szachy.Properties.Resources.pieces;
            //czarne wieze
            pieces[0] = new Tower(0, pieceBitmap.Clone(new Rectangle(0, 0, 70, 70), pieceBitmap.PixelFormat), board);
            pieces[7] = new Tower(7, pieceBitmap.Clone(new Rectangle(0, 0, 70, 70), pieceBitmap.PixelFormat), board);
            //czarne konie
            pieces[1] = new Horse(1, pieceBitmap.Clone(new Rectangle(70, 0, 70, 70), pieceBitmap.PixelFormat), board);
            pieces[6] = new Horse(6, pieceBitmap.Clone(new Rectangle(70, 0, 70, 70), pieceBitmap.PixelFormat), board);
            //czarne gonce
            pieces[2] = new Runner(2, pieceBitmap.Clone(new Rectangle(140, 0, 70, 70), pieceBitmap.PixelFormat), board);
            pieces[5] = new Runner(5, pieceBitmap.Clone(new Rectangle(140, 0, 70, 70), pieceBitmap.PixelFormat), board);
            //czarna krolowa
            pieces[3] = new Queen(3, pieceBitmap.Clone(new Rectangle(210, 0, 70, 70), pieceBitmap.PixelFormat), board);
            //czarny krol
            pieces[4] = new King(4, pieceBitmap.Clone(new Rectangle(280, 0, 70, 70), pieceBitmap.PixelFormat), board);

            for (byte i = 8; i < 16; i++)
            { //pionki czarne
                pieces[i] = new Pawn(i, pieceBitmap.Clone(new Rectangle(350, 0, 70, 70), pieceBitmap.PixelFormat), board);
            }

            for (byte i = 16; i < 24; i++)
            { //pionki biale
                pieces[i] = new Pawn(i, pieceBitmap.Clone(new Rectangle(350, 70, 70, 70), pieceBitmap.PixelFormat), board);
            }

            //biale wieze
            pieces[24] = new Tower(24, pieceBitmap.Clone(new Rectangle(0, 70, 70, 70), pieceBitmap.PixelFormat), board);
            pieces[31] = new Tower(31, pieceBitmap.Clone(new Rectangle(0, 70, 70, 70), pieceBitmap.PixelFormat), board);
            //czarne konie
            pieces[25] = new Horse(25, pieceBitmap.Clone(new Rectangle(70, 70, 70, 70), pieceBitmap.PixelFormat), board);
            pieces[30] = new Horse(30, pieceBitmap.Clone(new Rectangle(70, 70, 70, 70), pieceBitmap.PixelFormat), board);
            //czarne gonce
            pieces[26] = new Runner(26, pieceBitmap.Clone(new Rectangle(140, 70, 70, 70), pieceBitmap.PixelFormat), board);
            pieces[29] = new Runner(29, pieceBitmap.Clone(new Rectangle(140, 70, 70, 70), pieceBitmap.PixelFormat), board);
            //czarna krolowa
            pieces[27] = new Queen(27, pieceBitmap.Clone(new Rectangle(210, 70, 70, 70), pieceBitmap.PixelFormat), board);
            //czarny krol
            pieces[28] = new King(28, pieceBitmap.Clone(new Rectangle(280, 70, 70, 70), pieceBitmap.PixelFormat), board);

            setupBoard();
            //pieces[18].move(12, 20); ACHTUNG TESTEN
            if (!whiteMove)
            {
                enemyTurn(128, 128);
            }
        }

        public void addWindowReference(Window window)
        {
            this.windowReference = window;
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

        public byte getSelectedTile()
        {
            if (pieceSelected)
            {
                return selectedPiecePosition;
            }
            else
            {
                return 64;
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

        public byte[] get_board()
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

        public void onClick(byte i)
        {
            //NIC JESZCE NIE ZAZNACZYLEM
            if (playerYou.getToken())
            {
                if (!pieceSelected)
                {
                    bool goodColorSelected = false;
                    if (whiteMove)
                    {
                        if (board[i] > 15 && board[i] != 32) //selected white; not empty
                        {
                            goodColorSelected = true;
                        }
                    }
                    else //blackMove
                    {
                        if (board[i] <= 15) //selected black; not empty
                        {
                            goodColorSelected = true;
                        }
                    }

                    if (goodColorSelected)
                    {
                        selectedPiecePosition = i; //zapamietaj pozycje
                        pieceSelected = true; //pamietaj, ze masz cos zaznaczone
                    }
                }
                else //JEZELI JUZ COS ZAZNACZYLEM
                {
                    if (i != selectedPiecePosition) // jesli cokolwiek przesunal
                    {
                        bool anotherColorSelected = false;
                        if (whiteMove)
                        {
                            if (board[i] <= 15 || board[i] == 32) // jezeli czarne lub puste
                            {
                                anotherColorSelected = true;
                            }
                        }
                        else //black move
                        {
                            if (board[i] > 15) // jezeli biale lub puste
                            {
                                anotherColorSelected = true;
                            }
                        }

                        if (anotherColorSelected)
                        {
                            if (pieces[board[selectedPiecePosition]].move(selectedPiecePosition, i)) // can move
                            {
                                board[i] = board[selectedPiecePosition]; //przesun
                                board[selectedPiecePosition] = 32; //posprzataj
                                enemyTurn(selectedPiecePosition, i);  //przekazanie ruchu
                                pieceSelected = false; //usun zaznaczenie
                                whiteMove = !whiteMove; // zmien ruch
                                                        //powiadomienie do serwera
                            }
                        }
                        else
                        {
                            selectedPiecePosition = i;
                        }
                    }
                }
            }
        }

        public void enemyTurn(byte from, byte to) //Skończyłem ruch, wysyłam dane
        {
                //SET TOKEN
                playerYou.setToken(false);
          
                //DO CONNECTION STUFF
                workerThread.DoWork += doThreadWork;
                workerThread.RunWorkerCompleted += threadWorkCompleted;
                workerThread.RunWorkerAsync(from * 64 + to);
        }

        public void enemyMoved(byte from, byte to) //Zaczynam nowy ruch, dostaje dane
        {

            //MOVE
            board[to] = board[from];
            board[from] = 32; 
            //SET TOKEN
            playerYou.setToken(true);
            windowReference.board.Invalidate();
        }

        private void doThreadWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if ((int)e.Argument != 128 * 64 + 128) //not black's first move
            {
                connectionReference.send(e.Argument.ToString());
            }
            string info = connectionReference.receive();
            e.Result = Convert.ToInt32(info);
        }

        private void threadWorkCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            int from = (int)e.Result / 64;
            int to = (int)e.Result % 64;
            enemyMoved(Convert.ToByte(from),Convert.ToByte(to));
        }
    }
}
