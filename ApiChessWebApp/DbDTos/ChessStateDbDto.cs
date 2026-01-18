namespace ApiChessWebApp.DbDTos
{
    public class ChessStateDbDto
    {
        /*
           Id int AUTO_INCREMENT PRIMARY KEY,
           GameState JSON,
           UniqueKey VARCHAR(255) DEFAULT (UUID()),
           CreatedData datetime,
           UpdatedData datetime
        */
        public int Id{ get; set; }
        public string GameState { get; set; }
        public string? UniqueKey { get; set; }
    }
}
