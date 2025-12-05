namespace ApiChessWebApp
{
    public class Spots//Spots has pieces
    {
        public Cordinates Cordinates { get; set; }

        public Piece Piece {get; set; }
        //private Piece _piece;


        //public Piece Piece
        //{
        //    get { return _piece; }
        //    set { _piece = value; }
        //}

        // public bool _isSpotEmpty;
        public bool IsSpotEmpty => this.Piece == null;


        public Spots()
        {
            
        }

        public Spots(Cordinates c)
        {
            this.Cordinates = c;
        }
    }
}
