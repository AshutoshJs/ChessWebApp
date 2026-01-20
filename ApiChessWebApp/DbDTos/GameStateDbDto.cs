namespace ApiChessWebApp.DbDTos
{
    public class GameStateDbDto
    {
        public int? Id { get; set; }//GameStateId
        public int? ChessStateId { get; set; }
        public int? FirstPlayerId { get; set; }
        public int? SecondPlayerId { get; set; }
        public DateTime CreatedData { get; set; }
        public DateTime UpdatedData { get; set; }
    }
}
