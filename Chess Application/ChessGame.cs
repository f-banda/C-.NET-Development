using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_5
{
    public partial class ChessGame : Form
    {
        // Declaring/Initializing Variables
        private ChessBoard chessBoard = new ChessBoard();
        Player Player1 = new Player(PlayerColor.Black);
        Player Player2 = new Player(PlayerColor.White);
        Player WhosTurn = null;

        int Player1Shift = 0;
        int Player2Shift = 0;

        int x1 = -1;
        int x2 = -1;
        int y1 = -1;
        int y2 = -1;

        Icon WhiteRook = new Icon(Assignment_5.Properties.Resources.WhiteRookPiece, new Size(32, 32));
        Icon WhitePawn = new Icon(Assignment_5.Properties.Resources.WhitePawnPiece, new Size(32, 32));
        Icon WhiteBishop = new Icon(Assignment_5.Properties.Resources.WhiteBishopPiece, new Size(32, 32));
        Icon WhiteKnight = new Icon(Assignment_5.Properties.Resources.WhiteKnightPiece, new Size(32, 32));
        Icon WhiteQueen = new Icon(Assignment_5.Properties.Resources.WhiteQueenPiece, new Size(32, 32));
        Icon WhiteKing = new Icon(Assignment_5.Properties.Resources.WhiteKingPiece, new Size(32, 32));

        Icon BlackRook = new Icon(Assignment_5.Properties.Resources.BlackRookPiece, new Size(32, 32));
        Icon BlackPawn = new Icon(Assignment_5.Properties.Resources.BlackPawnPiece, new Size(32, 32));
        Icon BlackBishop = new Icon(Assignment_5.Properties.Resources.BlackBishopPiece, new Size(32, 32));
        Icon BlackKnight = new Icon(Assignment_5.Properties.Resources.BlackKnightPiece, new Size(32, 32));
        Icon BlackQueen = new Icon(Assignment_5.Properties.Resources.BlackQueenPiece, new Size(32, 32));
        Icon BlackKing = new Icon(Assignment_5.Properties.Resources.BlackKingPiece, new Size(32, 32));

        private void surrenderButton_Click(object sender, EventArgs e)
        {
            if (WhosTurn == Player1)
            {
                Win(Player2);
            }
            else
            {
                Win(Player1);
            }
        }

        private void Win(Player player)
        {
            if(Player1.Lost.Count < Player2.Lost.Count)
            {
                winnerLabel.Visible = true;
                winnerLabel.Text = "Winner:\nPlayer 1 Wins!";
            }
            else if (Player2.Lost.Count < Player1.Lost.Count)
            {
                winnerLabel.Visible = true;
                winnerLabel.Text = "Winner:\nPlayer2 Wins!";
            }
            else
            {
                winnerLabel.Visible = true;
                winnerLabel.Text = "Tie.";
            }

            ConsoleOutput.Text = "Game has been concluded.\nTime elapsed: " + Player1.GameLength().Add(Player2.GameLength());

            ChessBoard.Refresh();

        }

        // Creating the chess board
        private void CreateBoard(Graphics g)
        {
            int count = 0;

            using (SolidBrush brush = new SolidBrush(Color.Gray))
            {
                foreach (var coord in chessBoard.GetSquares())
                {
                    int beginningX = (int)coord.xaxis * 64;
                    int beginningY = (int)coord.yaxis * 64;

                    Rectangle rect = new Rectangle(beginningX, beginningY, 64, 64);
                    g.FillRectangle(brush, rect);

                    count++;

                    if (count % 8 == 0 && count != 0)
                    {
                        if (brush.Color == Color.DarkTurquoise)
                        {
                            brush.Color = Color.Gray;
                        }
                        else
                        {
                            brush.Color = Color.DarkTurquoise;
                        }
                        count = 0;
                    }

                    if (brush.Color == Color.DarkTurquoise)
                    {
                        brush.Color = Color.Gray;
                    }
                    else
                    {
                        brush.Color = Color.DarkTurquoise;
                    }

                    int offsetx = 64 / 2;
                    int offsety = 64 / 2;

                    if (coord.Piece is Rook)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawIcon(WhiteRook, new Rectangle(beginningX, beginningY, 64, 64));
                        else
                            g.DrawIcon(BlackRook, new Rectangle(beginningX, beginningY, 64, 64));
                    }
                    else if (coord.Piece is Knight)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawIcon(WhiteKnight, new Rectangle(beginningX, beginningY, 64, 64));
                        else
                            g.DrawIcon(BlackKnight, new Rectangle(beginningX, beginningY, 64, 64));
                    }
                    else if (coord.Piece is Bishop)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawIcon(WhiteBishop, new Rectangle(beginningX, beginningY, 64, 64));
                        else
                            g.DrawIcon(BlackBishop, new Rectangle(beginningX, beginningY, 64, 64));
                    }
                    else if (coord.Piece is King)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawIcon(WhiteKing, new Rectangle(beginningX, beginningY, 64, 64));
                        else
                            g.DrawIcon(BlackKing, new Rectangle(beginningX, beginningY, 64, 64));
                    }
                    else if (coord.Piece is Queen)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawIcon(WhiteQueen, new Rectangle(beginningX, beginningY, 64, 64));
                        else
                            g.DrawIcon(BlackQueen, new Rectangle(beginningX, beginningY, 64, 64));
                    }
                    else if (coord.Piece is Pawn)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawIcon(WhitePawn, new Rectangle(beginningX, beginningY, 64, 64));
                        else
                            g.DrawIcon(BlackPawn, new Rectangle(beginningX, beginningY, 64, 64));
                    }
                }
            }
        }

        private bool Checked(Player one, Player two)
        {
            Piece oppKing = null;

            foreach (Piece piece in two.Gained)
            {
                if (piece is King)
                {
                    oppKing = piece;
                    break;
                }
            }
            if (oppKing == null)
            {
                Win(WhosTurn);
            }

            int[,] occupation = chessBoard.Occupation();
            foreach (Piece piece in one.Gained)
            {
                if (piece.checkMate(occupation, piece.Current, oppKing.Current))
                {
                    return true;
                }
            }
            return false;
        }

        private void ChessBoard_Paint(object sender, PaintEventArgs e)
        {
            if (WhosTurn == Player1)
            {
                turnLabel.Text = "Turn:\nPlayer1";
            }
            else
            {
                turnLabel.Text = "Turn:\nPlayer2";
            }

            Graphics g = e.Graphics;
            CreateBoard(g);
        }

        public ChessGame()
        {
            InitializeComponent();
            WhosTurn = Player2;
            SetupBoard();
            Player1.gameStart();
        }

        private void ChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = ChessBoard.CreateGraphics();
            SelectPiece(e.X, e.Y, g);
        }

        private void SelectPiece(int x, int y, Graphics g)
        {
            foreach (var coord in chessBoard.GetSquares())
            {
                int beginningX = (int)coord.xaxis * 64;
                int beginningY = (int)coord.yaxis * 64;

                if (x1 == -1)
                {
                    if (x >= beginningX && x <= beginningX + 64)
                    {
                        if (y >= beginningY && y <= beginningY + 64)
                        {
                            Pen SelectedPiece = new Pen(Color.DarkBlue, 3);

                            g.DrawRectangle(SelectedPiece, beginningX, beginningY, 64 - 1, 64 - 1);

                            x1 = (int)coord.xaxis;
                            y1 = (int)coord.yaxis;
                        }
                    }
                }
                else
                {
                    if (x2 == -1)
                    {
                        if (x >= beginningX && x <= beginningX + 64)
                        {
                            if (y >= beginningY && y <= beginningY + 64)
                            {
                                Pen NewSeletedPiece = new Pen(Color.LightBlue, 3);
                                g.DrawRectangle(NewSeletedPiece, beginningX, beginningY, 64 - 1, 64 - 1);
                                x2 = (int)coord.xaxis;
                                y2 = (int)coord.yaxis;
                                Location start = new Location((xaxis)x1, (yaxis)y1);

                                if (x1 == x2 && y1 == y2)
                                {
                                    ConsoleOutput.Text = "Piece cannot be moved to the same spot.";
                                    x1 = y1 = x2 = y2 = -1;
                                    ChessBoard.Refresh();
                                    break;
                                }
                                else
                                {
                                    int[,] table = chessBoard.Occupation();

                                    Piece selected = chessBoard.GetPiece(x1, y1);

                                    if (selected == null)
                                    {
                                        ConsoleOutput.Text = "Piece has not been selected.";
                                    }
                                    else if (selected.Player == WhosTurn)
                                    {
                                        Location end = new Location((xaxis)x2, (yaxis)y2);

                                        if (!chessBoard.Move(selected, start, end))
                                        {
                                            ConsoleOutput.Text = "Invalid move.";
                                        }
                                        else
                                        {
                                            Player one;
                                            Player two;

                                            if (WhosTurn == Player1)
                                            {
                                                double xcreds = Math.Pow((x2 - x1), 2.0);
                                                double ycreds = Math.Pow((y2 - y1), 2.0);

                                                Player1Shift += Convert.ToInt32(Math.Sqrt(xcreds + ycreds));
                                                one = Player1;
                                                two = Player2;
                                            }
                                            else
                                            {
                                                two = Player1;
                                                one = Player2;

                                                double xcreds = Math.Pow((x2 - x1), 2.0);
                                                double ycreds = Math.Pow((y2 - y1), 2.0);

                                                Player2Shift += Convert.ToInt32(Math.Sqrt(xcreds + ycreds));
                                            }

                                            if (Checked(one, two))
                                            {
                                                ConsoleOutput.Text = "Check";
                                            }
                                            if (Checked(two, one))
                                            {
                                                ConsoleOutput.Text = "Check, but invalid";
                                            }

                                            if (WhosTurn == Player1)
                                            {
                                                WhosTurn = Player2;
                                                Player2.gameStart();
                                                Player1.gameEnd();
                                            }
                                            else
                                            {
                                                WhosTurn = Player1;
                                                Player1.gameStart();
                                                Player2.gameEnd();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ConsoleOutput.Text = "Please select a valid piece";
                                    }

                                    x1 = y1 = x2 = y2 = -1;
                                    ChessBoard.Refresh();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SetupBoard()
        {
            // Set up player one's side
            chessBoard.Add(new Pawn(Player1), new Location(xaxis.a, yaxis.seven));
            chessBoard.Add(new Pawn(Player1), new Location(xaxis.b, yaxis.seven));
            chessBoard.Add(new Pawn(Player1), new Location(xaxis.c, yaxis.seven));
            chessBoard.Add(new Pawn(Player1), new Location(xaxis.d, yaxis.seven));
            chessBoard.Add(new Pawn(Player1), new Location(xaxis.e, yaxis.seven));
            chessBoard.Add(new Pawn(Player1), new Location(xaxis.f, yaxis.seven));
            chessBoard.Add(new Pawn(Player1), new Location(xaxis.g, yaxis.seven));
            chessBoard.Add(new Pawn(Player1), new Location(xaxis.h, yaxis.seven));
            chessBoard.Add(new Rook(Player1), new Location(xaxis.a, yaxis.eight));
            chessBoard.Add(new Rook(Player1), new Location(xaxis.h, yaxis.eight));
            chessBoard.Add(new Knight(Player1), new Location(xaxis.b, yaxis.eight));
            chessBoard.Add(new Knight(Player1), new Location(xaxis.g, yaxis.eight));
            chessBoard.Add(new Bishop(Player1), new Location(xaxis.f, yaxis.eight));
            chessBoard.Add(new Bishop(Player1), new Location(xaxis.c, yaxis.eight));
            chessBoard.Add(new Queen(Player1), new Location(xaxis.e, yaxis.eight));
            chessBoard.Add(new King(Player1), new Location(xaxis.d, yaxis.eight));

            // Set up player two's side
            chessBoard.Add(new Pawn(Player2), new Location(xaxis.a, yaxis.two));
            chessBoard.Add(new Pawn(Player2), new Location(xaxis.b, yaxis.two));
            chessBoard.Add(new Pawn(Player2), new Location(xaxis.c, yaxis.two));
            chessBoard.Add(new Pawn(Player2), new Location(xaxis.d, yaxis.two));
            chessBoard.Add(new Pawn(Player2), new Location(xaxis.e, yaxis.two));
            chessBoard.Add(new Pawn(Player2), new Location(xaxis.f, yaxis.two));
            chessBoard.Add(new Pawn(Player2), new Location(xaxis.g, yaxis.two));
            chessBoard.Add(new Pawn(Player2), new Location(xaxis.h, yaxis.two));
            chessBoard.Add(new Rook(Player2), new Location(xaxis.a, yaxis.one));
            chessBoard.Add(new Rook(Player2), new Location(xaxis.h, yaxis.one));
            chessBoard.Add(new Knight(Player2), new Location(xaxis.b, yaxis.one));
            chessBoard.Add(new Knight(Player2), new Location(xaxis.g, yaxis.one));
            chessBoard.Add(new Bishop(Player2), new Location(xaxis.f, yaxis.one));
            chessBoard.Add(new Bishop(Player2), new Location(xaxis.c, yaxis.one));
            chessBoard.Add(new Queen(Player2), new Location(xaxis.e, yaxis.one));
            chessBoard.Add(new King(Player2), new Location(xaxis.d, yaxis.one));
        }
    }

    public class ChessBoard
    {
        private Location[,] board;
        private int maxY = 8;
        private int maxX = 8;

        public ChessBoard()
        {
            board = new Location[maxX, maxY];
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxX; y++)
                {
                    board[x, y] = new Location((xaxis)x, (yaxis)y);
                }
            }
        }

        public Location[,] GetSquares()
        {
            return board;
        }

        public void Add(Piece piece, Location location)
        {
            if (board[(int)location.xaxis, (int)location.yaxis].Piece == null)
            {
                board[(int)location.xaxis, (int)location.yaxis].Piece = piece;
                piece.Current = board[(int)location.xaxis, (int)location.yaxis];
            }
            else
            {
                throw new Exception("Location already taken.");
            }
        }

        public bool Move(Piece piece, Location start, Location end)
        {
            if (piece.PossibleShift(this.Occupation(), start, end))
            {
                if (board[(int)end.xaxis, (int)end.yaxis].Piece != null && board[(int)start.xaxis, (int)start.yaxis].Piece.Player != board[(int)end.xaxis, (int)end.yaxis].Piece.Player)
                {
                    board[(int)end.xaxis, (int)end.yaxis].Piece.Player.Lost.Add(board[(int)end.xaxis, (int)end.yaxis].Piece);
                    piece.Current = null;
                    piece.didMove();
                    piece.Player.Gained.Remove(piece);
                }
                board[(int)end.xaxis, (int)end.yaxis].Piece = board[(int)start.xaxis, (int)start.yaxis].Piece;
                piece.Current = end;
                board[(int)start.xaxis, (int)start.yaxis].Piece = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int[,] Occupation()
        {
            int[,] table = new int[8, 8];
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxX; y++)
                {
                    if (board[x, y].Piece == null)
                    {
                        table[x, y] = 0;
                    }
                    else if (board[x, y].Piece.Player.Color == PlayerColor.White)
                    {
                        table[x, y] = 1;
                    }
                    else if (board[x, y].Piece.Player.Color == PlayerColor.Black)
                    {
                        table[x, y] = 2;
                    }
                }
            }
            return table;
        }

        public Piece GetPiece(int x, int y)
        {
            if(board[x, y] == null)
            {
                return null;
            }
            else
            {
                return board[x, y].Piece;
            }
        }

    }

    public enum Type { King, Queen, Knight, Bishop, Rook, Pawn }
    public enum xaxis { a, b, c, d, e, f, g, h };
    public enum yaxis { eight, seven, six, five, four, three, two, one };

    public class Location
    {
        public xaxis xaxis
        {
            get;
            set;
        }

        public yaxis yaxis
        {
            get;
            set;
        }

        public Location(xaxis Xaxis, yaxis Yaxis)
        {
            this.xaxis = Xaxis;
            this.yaxis = Yaxis;
        }

        public Piece Piece
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Enum.GetName(typeof(xaxis), xaxis) + Enum.GetName(typeof(yaxis), yaxis);
        }
    }

    public class Piece
    {
        private bool initiatedMove = false;
        private Player player;
        protected Location current;
        protected int shift;

        protected int[] xaxis, yaxis = new int[8];

        public Location Current
        {
            get;
            set;
        }

        private Type type;

        public Piece(Player player, Type type)
        {
            this.player = player;
            this.type = type;
            player.AddPiece(this);
        }

        public Player Player
        {
            get { return player; }
        }

        public void didMove()
        {
            initiatedMove = true;
        }

        public virtual bool PossibleShift(int[,] board, Location start, Location stop)
        {
            int limitX = 8;
            int limitY = 8;
            int currentShift = 1;
            int currentShiftDir = 1;
            int localX = (int)start.xaxis;
            int localY = (int)start.yaxis;
            int opp = 0;

            if (Player.Color == PlayerColor.White)
            {
                opp = (int)PlayerColor.Black;
            }
            else
            {
                opp = (int)PlayerColor.White;
            }

            int maxShift = (xaxis.Length / shift);

            if (this is Pawn)
            {
                maxShift = 1;
            }

            // Check if shift is legal
            for (int i = 0; i < xaxis.Length; i++)
            {
                // Knight
                int offsetX = xaxis[i];
                int offsetY = yaxis[i];

                if (player.Color == PlayerColor.White && this is Pawn)
                {
                    offsetX *= -1;
                    offsetY *= -1;
                }

                int x = localX + offsetX;
                int y = localY + offsetY;

                // Valid shift count
                if (x >= 0 && y >= 0 && y < limitY && x < limitX)
                {
                    if (board[x, y] == 0 || board[x, y] == opp)
                    {
                        if (this is Pawn && initiatedMove && i == 1)
                        {
                            // Do not allow shift
                        }
                        else if (this is Pawn && x == (int)stop.xaxis && y == (int)stop.yaxis && board[x, y] == opp && i == 0)
                        {
                            // Check not possible
                        }
                        else if (this is Pawn && x == (int)stop.xaxis && y == (int)stop.yaxis && board[x, y] == opp && i == 1)
                        {
                            // Not possible
                        }
                        else if (x == (int)stop.xaxis && y == (int)stop.yaxis)
                        {
                            return true;
                        }
                    }
                    // Check if square belongs to opp
                    else if (board[x, y] != opp)
                    {
                        int accumulatedShifts = currentShiftDir * maxShift;
                        i += accumulatedShifts - 1 - i;
                        currentShift = maxShift - 1;
                    }
                }
                else
                {
                    int accumulatedShifts = currentShiftDir * maxShift;
                    i += accumulatedShifts - 1 - i;
                    currentShift = maxShift - 1;
                }

                currentShift++;

                if (currentShift % maxShift == 0)
                {
                    currentShiftDir++;
                    currentShift = 0;
                }

            }
            return false;
        } // End of PossibleShift

        public virtual bool checkMate(int[,] board, Location start, Location stop)
        {
            int opp = 0;

            if (Player.Color == PlayerColor.White)
            {
                opp = (int)PlayerColor.Black;
            }
            else
            {
                opp = (int)PlayerColor.White;
            }

            int localX = (int)start.xaxis;
            int localY = (int)start.yaxis;
            int maxX = 8;
            int maxY = 8;
            int maxShift = xaxis.Length / shift;

            if (this is Pawn)
            {
                maxShift = 1;
            }

            int currentShift = 1;
            int currentShiftDir = 1;

            for (int i = 0; i < xaxis.Length; i++)
            {
                int offsetX = xaxis[i];
                int offsetY = yaxis[i];
                if (Player.Color == PlayerColor.White && this is Pawn)
                {
                    offsetX *= -1;
                    offsetY *= -1;
                }

                int x = localX + offsetX;
                int y = localY + offsetY;

                if (x >= 0 && y >= 0 && x < maxX && y < maxY)
                {
                    if (board[x, y] == 0 || (board[x, y] == opp))
                    {
                        if (this is Pawn && initiatedMove && i == 1)
                        {
                            // Not possible
                        }
                        else if (this is Pawn && x == (int)stop.xaxis && y == (int)stop.yaxis && board[x, y] == opp && i == 0)
                        {
                            // Not possible
                        }
                        else if (this is Pawn && x == (int)stop.xaxis && y == (int)stop.yaxis && board[x, y] == opp && i == 1)
                        {
                            // Not possible
                        }
                        else if (x == (int)stop.xaxis && y == (int)stop.yaxis)
                        {
                            return true;
                        }
                        else if (board[x, y] == opp)
                        {
                            return false;
                        }
                    }
                    // Check if square belongs to opp
                    else if (board[x, y] != opp)
                    {
                        int accumulatedShifts = currentShiftDir * maxShift;
                        i += accumulatedShifts - 1 - i;
                        currentShift = maxShift - 1;
                    }
                }
                else
                {
                    int accumulatedShifts = currentShiftDir * maxShift;
                    i += accumulatedShifts - 1 - i;
                    currentShift = maxShift - 1;
                }

                currentShift++;

                if (currentShift % maxShift == 0)
                {
                    currentShiftDir++;
                    currentShift = 0;
                }

            }

            return false;

        }

    } // End of piece class

    public enum PlayerColor
    {
        White = 1,
        Black = 2
    }

    public class Player
    {
        PlayerColor color;
        List<Piece> gained;
        List<Piece> lost;

        int idealSteps = 0;

        TimeSpan gameLength = new TimeSpan();
        DateTime timeStart = DateTime.Now;

        public Player(PlayerColor color)
        {
            this.color = color;
            this.gained = new List<Piece>();
            this.lost = new List<Piece>();
        }

        public List<Piece> Gained
        {
            get { return gained; }
        }

        public void AddPiece(Piece piece)
        {
            Gained.Add(piece);
        }

        public List<Piece> Lost
        {
            get { return lost; }
        }

        public void SumSteps(int steps)
        {
            idealSteps += steps;
        }

        public void gameStart()
        {
            timeStart = DateTime.Now;
        }

        public void gameEnd()
        {
            DateTime currentTime = DateTime.Now;
            gameLength += (currentTime - timeStart);
        }

        public TimeSpan GameLength()
        {
            return gameLength;
        }

        public PlayerColor Color
        {
            get { return color; }
        }

    } // End of Player class

} // End of ChessGame : Form
