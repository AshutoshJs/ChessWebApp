namespace ApiChessWebApp
{
    public class Cordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char? Z { get; set; } = ' ';
        public Cordinates()
        {
            
        }
        public Cordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Cordinates(int x, int y, char z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}
