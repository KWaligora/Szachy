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
        Bitmap selectBitmap;
        int selectX, selectY;
        private TextBox chatLog;
        private TextBox chatField;
        Board boardModel;

        public Window(Board boardModel)
        {
            this.boardModel = boardModel;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.board = new System.Windows.Forms.Panel();
            this.chatLog = new System.Windows.Forms.TextBox();
            this.chatField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackgroundImage = global::Szachy.Properties.Resources.board;
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(600, 600);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.board_Paint);
            this.board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.board_MouseClick);
            // 
            // chatLog
            // 
            this.chatLog.Location = new System.Drawing.Point(610, 300);
            this.chatLog.Multiline = true;
            this.chatLog.Name = "chatLog";
            this.chatLog.ReadOnly = true;
            this.chatLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatLog.Size = new System.Drawing.Size(180, 250);
            this.chatLog.TabIndex = 1;
            // 
            // textBox1
            // 
            this.chatField.Location = new System.Drawing.Point(610, 560);
            this.chatField.Name = "textBox1";
            this.chatField.Size = new System.Drawing.Size(180, 20);
            this.chatField.TabIndex = 2;
            // 
            // Window
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.chatField);
            this.Controls.Add(this.chatLog);
            this.Controls.Add(this.board);
            this.Name = "Window";
            this.ResumeLayout(false);
            this.PerformLayout();

            initFields();
        }

        private void initFields()
        {
            this.selectBitmap = global::Szachy.Properties.Resources.select;
            this.selectX = 0;
            this.selectY = 0;
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(selectBitmap, new Point(19 + selectX * 70, 19 + selectY * 70));
            for(int i = 0; i<64; i++)
            {
                byte pieceID = boardModel.getPieceID(i);
                if (pieceID < 32)
                {
                    Piece piece = boardModel.getPiece(pieceID);
                    int y = i / 8;
                    int x = i % 8;
                    e.Graphics.DrawImage(piece.getImage(), 19 + x * 70, 19 + y * 70, 70, 70);
                }
            }
        }

        private void board_MouseClick(object sender, MouseEventArgs e)
        {
            this.selectX = (e.X - 20) / 70;
            this.selectY = (e.Y - 20) / 70;
            boardModel.onClick(Convert.ToByte(selectY * 8 + selectX));
            this.board.Invalidate();
        }
    }
}
