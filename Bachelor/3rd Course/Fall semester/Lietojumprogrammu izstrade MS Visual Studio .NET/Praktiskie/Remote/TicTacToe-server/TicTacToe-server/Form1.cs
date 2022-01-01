using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Services;

namespace TicTacToe_server
{
    public partial class Form1 : Form
    {
        private Bitmap drawBitmap;
        private Graphics drawGraphics;
        private PictureBox drawPicture = new PictureBox();

        private Pen crossPen = new Pen(Color.Red, 4);
        private Pen circlePen = new Pen(Color.Blue, 4);

        private string cross = "X";
        private string nought = "0";

        bool isCross, isCrossPlayer, won;
        bool isDraw, isNoted, choosenPlayer;
        string[,] board = new string[3, 3];
        char draw;

        private Coordinator.Remote gameCoordinator = null;
        bool isConnected = false;
        private string host, port = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Click += new EventHandler(this.pictureClick);
            this.pictureBox2.Click += new EventHandler(this.pictureClick);
            this.pictureBox3.Click += new EventHandler(this.pictureClick);
            this.pictureBox4.Click += new EventHandler(this.pictureClick);
            this.pictureBox5.Click += new EventHandler(this.pictureClick);
            this.pictureBox6.Click += new EventHandler(this.pictureClick);
            this.pictureBox7.Click += new EventHandler(this.pictureClick);
            this.pictureBox8.Click += new EventHandler(this.pictureClick);
            this.pictureBox9.Click += new EventHandler(this.pictureClick);

            newGameToolStripMenuItem.PerformClick();
        }

        private void pictureClick(object sender, System.EventArgs e)
        {
            if (!won && !isDraw)
            {
                PictureBox picBox = (PictureBox)sender;
                getPiece(picBox.Name);

                //if player click in allready used pictureBox, we won't do nothing 
                if (!isNoted)
                {
                    if ((!checkWon(cross)) && (!checkWon(nought)))
                        checkDraw();
                    if (isConnected)
                        Broadcast(picBox.Name);
                }
            }
            else
            {
                MessageBox.Show("Game is over", "Tic-Tac-Toe Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void getPiece(string picBox)
        {
            switch (picBox)
            {
                case "pictureBox1":
                    setPiece(0, 0, this.pictureBox1);
                    break;
                case "pictureBox2":
                    setPiece(0, 1, this.pictureBox2);
                    break;
                case "pictureBox3":
                    setPiece(0, 2, this.pictureBox3);
                    break;
                case "pictureBox4":
                    setPiece(1, 0, this.pictureBox4);
                    break;
                case "pictureBox5":
                    setPiece(1, 1, this.pictureBox5);
                    break;
                case "pictureBox6":
                    setPiece(1, 2, this.pictureBox6);
                    break;
                case "pictureBox7":
                    setPiece(2, 0, this.pictureBox7);
                    break;
                case "pictureBox8":
                    setPiece(2, 1, this.pictureBox8);
                    break;
                case "pictureBox9":
                    setPiece(2, 2, this.pictureBox9);
                    break;
            }
        }

        private void setPiece(int row, int column, PictureBox pic)
        {
            if (board[row, column] != cross && board[row, column] != nought)
            {
                drawPicture = pic;
                drawBitmap = new Bitmap(drawPicture.Width, drawPicture.Height);
                drawGraphics = Graphics.FromImage(drawBitmap);
                drawPicture.Image = drawBitmap;

                if (isCross)
                {
                    drawX();
                    board[row, column] = cross;
                    if (!isConnected)
                        this.label1.Text = "      Nought player, ur turn to go!";
                }
                else
                {
                    draw0();
                    board[row, column] = nought;
                    if (!isConnected)
                        this.label1.Text = "       Cross player, ur turn to go!";
                }

                //For isCross we'ld give value that is different from this current value.
                isCross = !isCross;
                isNoted = false;
            }
            else
            {
                isNoted = true;
            }
        }
         
        private void drawX()
        {
            drawGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            drawGraphics.DrawLine(crossPen, 10, 10, 50, 50);
            drawGraphics.DrawLine(crossPen, 50, 10, 10, 50);
        }

        private void draw0()
        {
            drawGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            drawGraphics.DrawEllipse(circlePen, 8, 8, 40, 40);
        }

        private bool checkWon(string player)
        {
            //Rows check 
            if (!Check(player, '1', 0, 0, 0, 1, 0, 2))
                if (!Check(player, '2', 1, 0, 1, 1, 1, 2))
                    if (!Check(player, '3', 2, 0, 2, 1, 2, 2))
                        //Column check
                        if (!Check(player, '4', 0, 0, 1, 0, 2, 0))
                            if (!Check(player, '5', 0, 1, 1, 1, 2, 1))
                                if (!Check(player, '6', 0, 2, 1, 2, 2, 2))
                                    // Diagonals check
                                    if (!Check(player, '7', 0, 0, 1, 1, 2, 2))
                                        Check(player, '8', 0, 2, 1, 1, 2, 0);
            return won;
        }

        private bool Check(string player, char ch, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            if (board[x1, y1] == player && board[x2, y2] == player && board[x3, y3] == player)
            {
                won = true;
                draw = ch;

                if (player == "X")
                {
                    if(!isConnected)
                        label1.Text = " Congratulation! Cross player won.";

                    isCrossPlayer = true;
                }
                else
                {
                    if(!isConnected)
                        label1.Text = "Congratulation! Nought player won.";

                    isCrossPlayer = false;
                }

                if (isConnected && isCrossPlayer != choosenPlayer)
                {
                    System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                    label1.Text = "       Sorry, you loose! Try again?";
                    System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = true;
                }

                if (isConnected && isCrossPlayer == choosenPlayer)
                {
                    System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                    label1.Text = "      Congratulation! You is winner.";
                    System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = true;
                }

                newGameToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = true;

                switch (ch)
                {
                    case '1':
                        drawRowLine(ref pictureBox1);
                        drawRowLine(ref pictureBox2);
                        drawRowLine(ref pictureBox3);
                        break;
                    case '2':
                        drawRowLine(ref pictureBox4);
                        drawRowLine(ref pictureBox5);
                        drawRowLine(ref pictureBox6);
                        break;
                    case '3':
                        drawRowLine(ref pictureBox7);
                        drawRowLine(ref pictureBox8);
                        drawRowLine(ref pictureBox9);
                        break;
                    case '4':
                        drawColumnLine(ref pictureBox1);
                        drawColumnLine(ref pictureBox4);
                        drawColumnLine(ref pictureBox7);
                        break;
                    case '5':
                        drawColumnLine(ref pictureBox2);
                        drawColumnLine(ref pictureBox5);
                        drawColumnLine(ref pictureBox8);
                        break;
                    case '6':
                        drawColumnLine(ref pictureBox3);
                        drawColumnLine(ref pictureBox6);
                        drawColumnLine(ref pictureBox9);
                        break;
                    case '7':
                        drawCrossLine(ref pictureBox1);
                        drawCrossLine(ref pictureBox5);
                        drawCrossLine(ref pictureBox9);
                        break;
                    case '8':
                        drawCross(ref pictureBox3);
                        drawCross(ref pictureBox5);
                        drawCross(ref pictureBox7);
                        break;
                }
            }
            return won;
        }

        private void checkDraw()
        {
            if (board[0, 0] != "" && board[0, 1] != "" && board[0, 2] != "")
            {
                if (board[1, 0] != "" && board[1, 1] != "" && board[1, 2] != "")
                {
                    if (board[2, 0] != "" && board[2, 1] != "" && board[2, 2] != "")
                    {
                        label1.Text = "             It's draw! Play again.";
                        newGameToolStripMenuItem.Enabled = true;
                        disconnectToolStripMenuItem.Enabled = true;
                        isDraw = true;
                    }
                }
            }
        }

        private void drawRowLine(ref PictureBox pic)
        {
            drawBitmap = new Bitmap(pic.Image);
            Graphics grf = Graphics.FromImage(drawBitmap);
            grf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (isCrossPlayer)
                grf.DrawLine(crossPen, 0, 30, 59, 30);
            else
                grf.DrawLine(circlePen, 0, 30, 59, 30);

            pic.Image = drawBitmap;
            this.Invalidate();
            grf.Dispose();
        }

        private void drawColumnLine(ref PictureBox pic)
        {
            drawBitmap = new Bitmap(pic.Image);
            Graphics grf = Graphics.FromImage(drawBitmap);
            grf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (isCrossPlayer)
                grf.DrawLine(crossPen, 30, 0, 30, 59);
            else
                grf.DrawLine(circlePen, 30, 0, 30, 59);

            pic.Image = drawBitmap;
            this.Invalidate();
            grf.Dispose();
        }

        private void drawCrossLine(ref PictureBox pic)
        {
            drawBitmap = new Bitmap(pic.Image);
            Graphics grf = Graphics.FromImage(drawBitmap);
            grf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (isCrossPlayer)
                grf.DrawLine(crossPen, 0, 0, 59, 59);
            else
                grf.DrawLine(circlePen, 0, 0, 59, 59);

            pic.Image = drawBitmap;
            this.Invalidate();
            grf.Dispose();
        }

        private void drawCross(ref PictureBox pic)
        {
            drawBitmap = new Bitmap(pic.Image);
            Graphics grf = Graphics.FromImage(drawBitmap);
            grf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (isCrossPlayer)
                grf.DrawLine(crossPen, 59, 0, 0, 59);
            else
                grf.DrawLine(circlePen, 59, 0, 0, 59);

            pic.Image = drawBitmap;
            this.Invalidate();
            grf.Dispose();
        }

        protected override void OnPaint(PaintEventArgs paintEvnt)
        {
            Graphics g = paintEvnt.Graphics;
            Pen myPen = new Pen(Color.DarkGray, 4);

            g.DrawLine(myPen, 121, 62, 121, 253);
            g.DrawLine(myPen, 187, 62, 187, 253);
            g.DrawLine(myPen, 59, 124, 250, 124);
            g.DrawLine(myPen, 59, 190, 250, 190);

            if (won)
            {
                if (isCrossPlayer)
                    myPen.Color = Color.Red;
                else
                    myPen.Color = Color.Blue;

                switch (draw)
                {
                    case '1':
                            g.DrawLine(myPen, 59, 92, 250, 92);
                        break;
                    case '2':
                            g.DrawLine(myPen, 59, 157, 250, 157);
                        break;
                    case '3':
                            g.DrawLine(myPen, 59, 223, 250, 223);
                        break;
                    case '4':
                            g.DrawLine(myPen, 89, 62, 89, 253);
                        break;
                    case '5':
                            g.DrawLine(myPen, 154, 62, 154, 253);
                        break;
                    case '6':
                            g.DrawLine(myPen, 221, 62, 221, 253);
                        break;
                    case '7':
                            g.DrawLine(myPen, 70, 72, 239, 241);
                        break;
                    case '8':
                            g.DrawLine(myPen, 239, 72, 70, 241);
                        break;
                }
            }
            myPen.Dispose();
            g.Dispose();
        }

        private void resetGame()
        {
            int i = 0;
            if (won)
                this.Invalidate();
            won = false;
            isDraw = false;

            for (int y = 0; y < 3; y++)
            {
                board[i, y] = "";
            }
            i++;

            for (int y = 0; y < 3; y++)
            {
                board[i, y] = "";
            }
            i++;

            for (int y = 0; y < 3; y++)
            {
                board[i, y] = "";
            }

            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
        }

        private void Broadcast(string pic)
        {
            Coordinator.ServerMsg Msg = new Coordinator.ServerMsg();
            Msg.ChoosenCross = !isCross;
            Msg.ControlName = pic;

            this.Cursor = Cursors.WaitCursor;
            string URL = "tcp://" + host + ":" + port + "/TestService";

            try
            {
                gameCoordinator = (Coordinator.Remote)Activator.GetObject(typeof(Coordinator.Remote), URL);

                if (!won && !isDraw)
                {
                    Coordinator.ClientMsg cMsg = gameCoordinator.callCln(Msg);
                    isCross = cMsg._ChoosenCross;
                    getPiece(cMsg._ControlName);

                    if ((!checkWon(cross)) && (!checkWon(nought)))
                        checkDraw();
                }
                else
                {
                    gameCoordinator.callCln(Msg);
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, "Error sending message to client:\n" + Ex.Message, "Tic-Tac-Toe Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Cursor = Cursors.Arrow;
                disconnectToolStripMenuItem.PerformClick();
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetGame();

            if (!isConnected)
            {
                if (MessageBox.Show("Cross to go first?", "Tic-Tac-Toe Server",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    isCross = true;
                    label1.Text = "       Cross player, ur turn to go!";
                }
                else
                {
                    isCross = false;
                    label1.Text = "      Nought player, ur turn to go!";
                }
            }
            else
            {
                isCross = choosenPlayer;
                if (isCross)
                {
                    label1.Text = "       Cross player, ur turn to go!";
                }
                else
                {
                    label1.Text = "      Nought player, ur turn to go!";
                }

                newGameToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = false;
            }
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();
            ColorDlg.Color = this.BackColor;
            ColorDlg.ShowDialog();

            this.BackColor = ColorDlg.Color;
            this.pictureBox1.BackColor = ColorDlg.Color;
            this.pictureBox2.BackColor = ColorDlg.Color;
            this.pictureBox3.BackColor = ColorDlg.Color;
            this.pictureBox4.BackColor = ColorDlg.Color;
            this.pictureBox5.BackColor = ColorDlg.Color;
            this.pictureBox6.BackColor = ColorDlg.Color;
            this.pictureBox7.BackColor = ColorDlg.Color;
            this.pictureBox8.BackColor = ColorDlg.Color;
            this.pictureBox9.BackColor = ColorDlg.Color;

            ColorDlg.Dispose();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                frmProxySettings objfrmSettings = new frmProxySettings();
                objfrmSettings.BackColor = this.BackColor;

                if (objfrmSettings.ShowDialog() == DialogResult.OK)
                {
                    this.host = objfrmSettings.Contribution;
                    this.port = objfrmSettings.Port;
                    this.isCross = objfrmSettings.Checked;
                    choosenPlayer = isCross;
                    if (isCross)
                    {
                        label1.Text = "       Cross player, ur turn to go!";
                    }
                    else
                    {
                        label1.Text = "      Nought player, ur turn to go!";
                    }
                          
                    isConnected = true;
                    resetGame();
                    newGameToolStripMenuItem.Enabled = false;
                    disconnectToolStripMenuItem.Enabled = false;
                }
                objfrmSettings.Dispose();
            }
            else
            {
                MessageBox.Show("You are allready connected!", "Tic-Tac-Toe Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameCoordinator != null)
            {
                gameCoordinator = null;
            }

            isConnected = false;
            newGameToolStripMenuItem.PerformClick();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout objfrmAbout = new frmAbout();
            objfrmAbout.BackColor = this.BackColor;
            objfrmAbout.ShowDialog();
            objfrmAbout.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}