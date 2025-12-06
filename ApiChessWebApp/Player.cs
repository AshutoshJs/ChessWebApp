namespace ApiChessWebApp
{
    public class Player
    {
        //Player 1 can be black always
        public string Name{ get; set; }
        public Colors Color{ get; set; }
        public bool IsWhite{ get; set; }
        public Player(){}
        public Player(Colors color) 
        {
            this.Color = color;
            this.IsWhite = color == Colors.White;
        }
        public Player(Colors color,string name)
        {
           this.Color= color;
            this.Name = name;
        }
    }
}
