using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
   abstract class Piece
    {
        Bitmap image;
        Piece[] Pieces;
        public Piece(byte id, Bitmap image, Piece [] pieces)
        {
            this.image = image;
            this.id = id;
            this.Pieces = pieces;
        }

        protected byte id;

        public abstract bool move();

        public Bitmap getImage()
        {
            return image;
        }

        public abstract bool special();

        public abstract byte getPieceID();
    }
}
