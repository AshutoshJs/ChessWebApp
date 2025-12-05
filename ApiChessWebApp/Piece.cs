namespace ApiChessWebApp
{
    public enum Colors
    {
        Black,
        White
    }
    public class Piece
    {
        public bool IsMovingFirstTime { get; set; }//because first time pawn can move 2 steps
        private Cordinates PieceCordinates { get; set; }
        public virtual string TypeOfPiece { get; set; }
        public virtual string HtmlCode { get; set; } 
        public Piece(){}
        public Piece(int x, int y){this.PieceCordinates = new Cordinates(x, y);}
        public Piece(int x, int y, char z){this.PieceCordinates = new Cordinates( x,  y, z);}


    }
}
