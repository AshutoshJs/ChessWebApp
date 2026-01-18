namespace ApiChessWebApp.Models
{
    public class MakeMoveViewModel: CheckMoveRequest
    {
        public Player Player1{ get; set; }
        public Player Player2{ get; set; }

        //Rest properties of :::CheckMoveRequest

        public int GameId { get; set; }

    }
}
