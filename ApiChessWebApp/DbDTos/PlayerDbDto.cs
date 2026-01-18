namespace ApiChessWebApp.DbDTos
{
    public class PlayerDbDto
    {
        /*Id int AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(255),
  Color VARCHAR(255),
  IsWhite bool,
  IsMyTurn bool,
  TotalMovesCount int,
  IsWinner bool,
  CreatedData datetime DEFAULT(now()),
  UpdatedData datetime DEFAULT(now())*/
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Color { get; set; }
        public bool IsWhite { get; set; }
        public bool IsMyTurn { get; set; }
        public int TotalMovesCount { get; set; }
        public DateTime CreatedData { get; set; }
        public DateTime UpdatedData { get; set; }

        public PlayerDbDto() {}

        public PlayerDbDto(Player player)
        {
            
        }
    }
}
