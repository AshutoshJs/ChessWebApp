namespace ApiChessWebApp
{
    public enum Colors
    {
        Black,
        White
    }
    public class Piece
    {
        public Colors Color { get; set; } =  Colors.Black;
        public int[,] Cordinates { get; set; }


    }
}
