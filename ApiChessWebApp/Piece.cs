namespace ApiChessWebApp
{
    public enum Colors
    {
        Black,
        White
    }
    public class Piece
    {
        public int x {  get; set; }
        public int y { get; set; }
        public PieceType types { get; set; }  
        //public Colors Color { get; set; } //=  Colors.Black;
        //public int[,] Cordinates { get; set; }


    }
}
