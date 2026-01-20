namespace ApiChessWebApp.Models
{
    public class MakeMoveViewModel: CheckMoveRequest
    {
        /*Inhereted properties
         public Cordinates From{ get; set; }
        public Cordinates To { get; set; }
        public string BoardCurrentSpotsState { get; set; }
         */
        //public Player Player1{ get; set; }
        //public Player Player2{ get; set; }

        //Rest properties of :::CheckMoveRequest

        public int GameId { get; set; }

    }
}
