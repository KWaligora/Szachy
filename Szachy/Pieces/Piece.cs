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

        public Piece(byte id, Bitmap image)
        {
            this.image = image;
            this.id = id;
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
