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
             Connection connection;

            switch (args[0].ToUpper())
            {
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

            /*
            if (connection.isHost)
            {
                connection.send("Hello there!");
                connection.receive();
            }
            else
            {
                connection.receive();
                connection.send("Hello too!");
            }*/
            Player gracz1;
            Player gracz2;
            if (connection != null && connection.isHost) //host zazczyna
            {
                gracz1 = new Player(true);
                gracz2 = new Player(false);
                Board board = new Board(connection, gracz1, gracz2, true);
                Window window = new Window(board);
                board.addWindowReference(window);
                Application.Run(window);
            }
            else
            {
                gracz1 = new Player(false);
                gracz2 = new Player(true);
                Board board = new Board(connection, gracz2, gracz1, false);
                Window window = new Window(board);
                board.addWindowReference(window);
                Application.Run(window);
            }
            
            //Console.ReadKey();
            return 0;
        }
    }
}