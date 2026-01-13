namespace ApiChessWebApp
{
    public class Cordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string? Z { get; set; } = "";
        public Cordinates(){}
        public Cordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Cordinates(int x, int y, char z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z.ToString();
        }
        public override bool Equals(object? obj)
        {
            // If the passed object is null, return False
            if (obj == null)
            {
                return false;
            }
            // If the passed object is not Customer Type, return False
            if (!(obj is Cordinates))
            {
                return false;
            }

            return (this.X == ((Cordinates)obj).X)
                && (this.Y == ((Cordinates)obj).Y);
        }
    }
}
