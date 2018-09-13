using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

using System.Windows.Forms;

namespace Szachy
{
    class Entry
    {
       
        public static int Main(String[] args)
        {
            /* Connection connection;

             switch (args[0].ToUpper()) {
                 case "SERVER":
                 connection = new Connection(true, args[1], short.Parse(args[2]));
                     break;
                 case "CLIENT":
                 connection = new Connection(false, args[1], short.Parse(args[2]));
                     break;
                 default:
                     Console.WriteLine("CRITICAL ERROR: args[0] is invalid; press any key to exit...");
                     Console.ReadKey();
                     Environment.Exit(1);
                     connection = null; //otherwise you get using uninitialized variable error lol
                     break;
             }

             if (connection.isHost)
             {
                 connection.send("Hello there!");
                 connection.receive();
             }
             else
             {
                 connection.receive();
                 connection.send("Hello too!");
             }
             */
            Application.Run(new Window());
            //Console.ReadKey();
            return 0;
        }
    }
}