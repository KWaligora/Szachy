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
        Bitmap obrazek;

        public Piece(byte id, Bitmap image)
        {
            this.obrazek = image;
            this.id = id;
        }

        protected byte id;

        public abstract bool move();

        public abstract void draw();

        public Bitmap getImage()
        {
            return obrazek;
        }

        public abstract bool special();

        public abstract byte getPieceID();
    }
}
