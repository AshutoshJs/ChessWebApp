
namespace ApiChessWebApp
{
    public class Spot//Spots has pieces
    {
      
        public Cordinates Cordinates { get; set; }

      
        public Piece Piece {get; set; }
        public bool IsSpotEmpty => this.Piece == null;
        public Spot(){}
        public Spot(Cordinates c)
        {
            this.Cordinates = c;
        }

        public Spot(Cordinates c, Piece p)
        {
            this.Cordinates = c;
            this.Piece = p;
        }
    }
}
