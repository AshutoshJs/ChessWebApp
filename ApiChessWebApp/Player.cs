namespace ApiChessWebApp
{
    public class Player
    {
        //Player 1 can be black always
        public Colors Color{ get; set; }
        public Player(){}
        public Player(Colors color) 
        {
            this.Color = color;
        }
        public Player(Colors color, List<List<Piece?>> pieces)
        {
           // this.Pieces = pieces;
        }
    }
}
