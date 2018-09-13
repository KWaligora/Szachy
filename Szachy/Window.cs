using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Szachy
{
    class Window : Form
    {
        private Panel board;

        public Window()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.board = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(600, 600);
            this.board.TabIndex = 0;
            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.board);
            this.Name = "Window";
            this.ResumeLayout(false);

        }
    }
}
