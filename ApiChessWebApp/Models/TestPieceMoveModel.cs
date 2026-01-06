namespace ApiChessWebApp.Models
{
    public class TestPieceMoveModel
    {
        public Cordinates? from { get; set; }
        public Cordinates? to { get; set; }
        public string? pieceType { get; set; } = "Pawn";
    }
}
