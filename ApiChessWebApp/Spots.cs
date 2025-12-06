namespace ApiChessWebApp
{
    public class Spots//Spots has pieces
    {
        public Cordinates Cordinates { get; set; }
        public Piece Piece {get; set; }
        public bool IsSpotEmpty => this.Piece == null;
        public Spots(){}
        public Spots(Cordinates c)
        {
            this.Cordinates = c;
        }
    }
}
