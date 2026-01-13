
using ApiChessWebApp.Models;

namespace ApiChessWebApp
{
    public enum Colors
    {
        Black,
        White
    }
    public class Piece
    {
        public bool IsMovingFirstTime { get; set; } = true;//because first time pawn can move 2 steps
        private Cordinates PieceCordinates { get; set; }
        public Colors? ColorCode{ get; set; }
        public string? Color { get; set; }
        public bool IsWhite{ get; set; }
        public virtual string TypeOfPiece { get; set; }
        public virtual string HtmlCode { get; set; } = "";
        public Piece(){}
        public Piece(int x, int y){this.PieceCordinates = new Cordinates(x, y);}
        public Piece(int x, int y, char z){this.PieceCordinates = new Cordinates( x,  y, z);}
        public Piece(int x, int y, char z, Colors c)
        {
            this.PieceCordinates = new Cordinates(x, y, z); 
            this.ColorCode = c;
            this.IsWhite = ColorCode == Colors.White;
            this.Color = c.ToString();
        }
        public virtual bool CanMove(Spot from, Spot to, List<List<Spot>> boardSpotsState)
        {
            return true;
        }
    }
}
