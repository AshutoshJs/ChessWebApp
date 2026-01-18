namespace ApiChessWebApp
{
    public class Game
    {
        //board, palyer term
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Board BoardState { get; set; }
        public int GameId { get; set; }
    }
}
