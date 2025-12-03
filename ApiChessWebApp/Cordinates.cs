namespace ApiChessWebApp
{
    public class Cordinates
    {
        public int x { get; set; }
        public int y { get; set; }
        public char? z { get; set; } = ' ';
        public Cordinates()
        {
            
        }
        public Cordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Cordinates(int x, int y, char z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
