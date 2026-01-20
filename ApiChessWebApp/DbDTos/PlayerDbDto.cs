namespace ApiChessWebApp.DbDTos
{
   public class PlayerDbDto
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Color { get; set; }
        public bool IsWhite { get; set; }
        public bool IsMyTurn { get; set; }
        public int TotalMovesCount { get; set; }
        public int ChessStateId { get; set; }
        public bool IsWinner { get; set; }
        public DateTime CreatedData { get; set; }
        public DateTime UpdatedData { get; set; }
        public PlayerDbDto() {}
        public PlayerDbDto(Player player)
        {
            this.Id = player.Id;
            this.Name = player.Name;
            this.Color = player.Color.ToString();
            this.IsWhite = player.IsWhite;
            this.IsMyTurn = player.IsMyTurn;
            this.TotalMovesCount = player.TotalMovesCount;
            this.ChessStateId = player.ChessStateId;
            this.IsWinner = player.IsWinner;
        }
    }
}
