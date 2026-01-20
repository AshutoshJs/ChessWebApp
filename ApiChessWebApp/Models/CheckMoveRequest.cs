namespace ApiChessWebApp.Models
{
    public class CheckMoveRequest
    {
        //public Spot From { get; set; }
        //public Spot To { get; set; }

        public Cordinates From{ get; set; }
        public Cordinates To { get; set; }
        public string? BoardCurrentSpotsState { get; set; }
    }
}
