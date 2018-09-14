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
        protected byte[] board;
        public Piece(byte id, Bitmap image, byte [] board)
        {
            this.image = image;
            this.id = id;
            this.board = board;
        }

        protected byte id;

        public abstract bool move(byte moveFrom, byte moveTo);

        public Bitmap getImage()
        {
            return image;
        }

        public abstract bool special();

        public abstract byte getPieceID();
    }
}
