namespace ApiChessWebApp.Models2
{
    
        public class Rootobject
        {
            public Piece Piece { get; set; }
            public Cordinates Cordinates { get; set; }
            public bool IsSpotEmpty { get; set; }
        }

        public class Piece
        {
            public string Color { get; set; }
            public bool IsWhite { get; set; }
            public string HtmlCode { get; set; }
            public int ColorCode { get; set; }
            public string TypeOfPiece { get; set; }
            public bool IsMovingFirstTime { get; set; }
        }

        public class Cordinates
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string Z { get; set; }
        }
}
