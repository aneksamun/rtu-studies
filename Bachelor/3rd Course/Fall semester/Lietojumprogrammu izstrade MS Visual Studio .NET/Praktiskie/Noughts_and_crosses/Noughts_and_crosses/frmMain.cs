using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using NougthAndCroses.GameAbstraction;
using System.Collections.Generic;

namespace NougthAndCroses.UI
{
    public partial class frmMain : Form {

        private Pen crossPen = new Pen(Color.Red, 4);
        private Pen circlePen = new Pen(Color.Blue, 4);

        private char[,] board = new char[3, 3];
        private PictureBox[,] pictures = new PictureBox[3, 3];

        private Player player = null;

        #region [ Event handlers ]

        /// <summary>
        /// Initializes form components.
        /// </summary>
        public frmMain() {
            InitializeComponent();

            graphicalOverlay.Owner = this;
        }

        /// <summary>
        /// Form load event handler. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e) {
            // Delegating events for picture click. 
            this.firstFieldPicBox.Click += new EventHandler(this.pictureClick);
            this.secondFieldPicBox.Click += new EventHandler(this.pictureClick);
            this.thirdFieldPicBox.Click += new EventHandler(this.pictureClick);
            this.fourthFieldPicBox.Click += new EventHandler(this.pictureClick);
            this.fithFieldPicBox.Click += new EventHandler(this.pictureClick);
            this.sixthFieldPicBox.Click += new EventHandler(this.pictureClick);
            this.seventhFieldPicBox.Click += new EventHandler(this.pictureClick);
            this.eightFieldPicBox.Click += new EventHandler(this.pictureClick);
            this.ninthFieldPicBox.Click += new EventHandler(this.pictureClick);

            DetermineNewGameSettings();
        }

        private void pictureClick(object sender, System.EventArgs e) {
            // Checking whether game is over. 
            if (Game.IsOver) {
                MessageBox.Show(
                    "Game is over!",
                    "Tic-Tac-Toe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            PictureBox picBox = (PictureBox)sender;

            if (picBox.Image != null)
                return;

            switch (picBox.Name) {
                case "firstFieldPicBox":
                    ProcessMove(0, 0, picBox);
                    break;
                case "secondFieldPicBox":
                    ProcessMove(0, 1, picBox);
                    break;
                case "thirdFieldPicBox":
                    ProcessMove(0, 2, picBox);
                    break;
                case "fourthFieldPicBox":
                    ProcessMove(1, 0, picBox);
                    break;
                case "fithFieldPicBox":
                    ProcessMove(1, 1, picBox);
                    break;
                case "sixthFieldPicBox":
                    ProcessMove(1, 2, picBox);
                    break;
                case "seventhFieldPicBox":
                    ProcessMove(2, 0, picBox);
                    break;
                case "eightFieldPicBox":
                    ProcessMove(2, 1, picBox);
                    break;
                case "ninthFieldPicBox":
                    ProcessMove(2, 2, picBox);
                    break;
            }

            if (GameBehavior.PlayerWins(board, player)) {
                Game.IsOver = Game.IsWon = true;
                lblStatus.Text = string.Format("Congratulation! {0} player won", player.PlayerName);
                this.Invalidate(true);
                return;
            }

            if (GameBehavior.IsDraw(board)) {
                Game.IsOver = true;
                lblStatus.Text = "It's draw! Play again?";
                return;
            }

            DeterminateNextPlayer();
        }

        /// <summary>
        /// Preparing for the new game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e) {
            Array.Clear(board, 0, board.Length);

            foreach (var control in this.Controls) {
                if (control is PictureBox) {
                    PictureBox picture = control as PictureBox;
                    picture.Image = null;
                }
            }

            this.Invalidate();

            DetermineNewGameSettings();
        }

        /// <summary>
        /// Handles color choose event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorToolStripMenuItem_Click(object sender, EventArgs e) {
            ColorDialog ColorDlg = new ColorDialog();
            ColorDlg.Color = this.BackColor;
            ColorDlg.ShowDialog();

            this.BackColor = ColorDlg.Color;

            ColorDlg.Dispose();
        }

        /// <summary>
        /// Handles about form open. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAbout objfrmAbout = new frmAbout();
            objfrmAbout.BackColor = this.BackColor;
            objfrmAbout.ShowDialog();
            objfrmAbout.Dispose();
        }

        /// <summary>
        /// Handles form exit event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion

        #region [ Private methods ]

        /// <summary>
        /// Sets new game beginning settings. 
        /// </summary>
        private void DetermineNewGameSettings() {
            Game.IsOver = Game.IsWon = false;

            // Getting new players
            player = new Player(GameBehavior.DeterminePlayerType());

            if (player.IsCrossPlayer) {
                player.Remark = PlayerRemark.cross;
                player.PlayerName = PlayerName.crossPlayerName;
            } else {
                player.Remark = PlayerRemark.nought;
                player.PlayerName = PlayerName.noughtPlayerName;
            }

            lblStatus.Text = string.Format("{0} player turn to go", player.PlayerName);
        }

        /// <summary>
        /// Handles current player move. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="pic"></param>
        private void ProcessMove(int row, int column, PictureBox pic) {
            // Remarking field for current player.
            Bitmap bitmap = new Bitmap(pic.Width, pic.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            pic.Image = bitmap;

            board[row, column] = player.Remark;

            if (player.IsCrossPlayer)
                DrawCross(graphics);
            else
                DrawNought(graphics);
        }

        /// <summary>
        /// Setting settings for next player.
        /// </summary>
        private void DeterminateNextPlayer() {

            if (player.IsCrossPlayer) {
                player.Remark = PlayerRemark.nought;
                player.PlayerName = PlayerName.noughtPlayerName;
            } else {
                player.Remark = PlayerRemark.cross;
                player.PlayerName = PlayerName.crossPlayerName;
            }

            // Setting next player turn. 
            player.IsCrossPlayer = !player.IsCrossPlayer;
            lblStatus.Text = string.Format("{0} player turn to go", player.PlayerName);
        }

        /// <summary>
        /// Draws cross in the selected picture box.
        /// </summary>
        private void DrawCross(Graphics drawGraphics) {

            drawGraphics.DrawLine(crossPen, 10, 10, 50, 50);
            drawGraphics.DrawLine(crossPen, 50, 10, 10, 50);
        }

        /// <summary>
        /// Draws nought in the selected picture box.
        /// </summary>
        private void DrawNought(Graphics drawGraphics) {

            drawGraphics.DrawEllipse(circlePen, 8, 8, 40, 40);
        }

        #endregion

        /// <summary>
        /// Draws winner line.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphicalOverlay_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            Pen winnerPen = player.IsCrossPlayer ? crossPen : circlePen;

            // Checking rows columns sequencly.
            for (int i = 0; i < board.GetLength(0); i++) {
                bool found = true;

                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j] != player.Remark) {
                        found = false;
                        break;
                    }

                if (found) {
                    Point beginPoint = new Point();
                    beginPoint.X = pictures[i, 0].Location.X;
                    beginPoint.Y = (pictures[i, 0].Height / 2) + pictures[i, 0].Location.Y;

                    Point endPoint = new Point();
                    endPoint.X = pictures[i, 2].Location.X + pictures[i, 2].Width;
                    endPoint.Y = (pictures[i, 2].Height / 2) + pictures[i, 2].Location.Y;


                    g.DrawLine(winnerPen, beginPoint, endPoint);

                    return;
                }
            }

            // Checking rows and columns verticaly.
            for (int j = 0; j < board.GetLength(1); j++) {
                bool found = true;

                for (int i = 0; i < board.GetLength(0); i++)
                    if (board[i, j] != player.Remark) {
                        found = false;
                        break;
                    }

                if (found) {
                    Point beginPoint = new Point();
                    beginPoint.X = pictures[0, j].Location.X + (pictures[0, j].Width / 2);
                    beginPoint.Y = pictures[0, j].Location.Y;

                    Point endPoint = new Point();
                    endPoint.X = pictures[2, j].Location.X + (pictures[2, j].Width / 2);
                    endPoint.Y = pictures[2, j].Location.Y + pictures[2, j].Width;

                    g.DrawLine(winnerPen, beginPoint, endPoint);

                    return;
                }
            }

            bool isFound = true;

            for (int i = 0, j = 0; i < board.GetLength(0) && j < board.GetLength(1); i++, j++)
                if (board[i, j] != player.Remark) {
                    isFound = false;
                    break;
                }

            if (isFound) {
                Point beginPoint = new Point();
                beginPoint.X = pictures[0, 0].Location.X;
                beginPoint.Y = pictures[0, 0].Location.Y;

                Point endPoint = new Point();
                endPoint.X = pictures[2, 2].Location.X + pictures[2, 2].Height;
                endPoint.Y = pictures[2, 2].Location.Y + pictures[2, 2].Width;

                g.DrawLine(winnerPen, beginPoint, endPoint);

                return;
            }

            // Checking right side diagonale.
            for (int i = 0, j = board.GetLength(1) - 1; i < board.GetLength(0) && j > -1; i++, j--)
                if (board[i, j] != player.Remark) {
                    return;
                }

            Point startPoint = new Point();
            startPoint.X = pictures[0, 2].Location.X + pictures[0, 2].Height;
            startPoint.Y = pictures[0, 2].Location.Y;

            Point finishPoint = new Point();
            finishPoint.X = pictures[2, 0].Location.X;
            finishPoint.Y = pictures[2, 0].Location.Y + pictures[2, 0].Width;

            g.DrawLine(winnerPen, startPoint, finishPoint);
        }
    }
}