namespace ApiChessWebApp
{
    public enum Colors
    {
        Black,
        White
    }
    public class Piece
    {
        public Cordinates PieceCordinates { get; set; }
        public Colors Color { get; set; } //=  Colors.Black;
        public virtual PieceType Type { get; set; }

        public virtual string TypeOfPiece { get; set; }
        public virtual string HtmlCode { get; set; } //=  Colors.Black;

        public Piece(){}

        public Piece(int x, int y)
        {
            this.PieceCordinates = new Cordinates( x,  y);
        }
    }
}
