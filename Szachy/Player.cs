using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    class Player
    {
        bool token;

        public Player(bool token)
        {
            this.token = token;
        }

        public void setToken( bool token)
        {
            this.token = token;
        }

        public bool getToken()
        {
            return token;
        }
    }
}
