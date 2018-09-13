﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szachy
{
    class Board
    {
        byte[] board = new byte[64];

        public Board()
        {
            for (int i = 0; i < 16; i++)
            {
                board[i] = Convert.ToByte(i + 1);
            }

            for (int i = 48; i < 64; i++)
            {
                board[i] = Convert.ToByte(i - 31);
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
    }
}
