﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
   abstract class Piece
    {
        Bitmap obrazek;

        protected byte id;

        public abstract bool move();

        public abstract void draw();

        public abstract bool special();

        public abstract byte getPieceID();
    }
}
