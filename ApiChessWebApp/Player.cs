namespace ApiChessWebApp
{
    public class Player
    {
        //Player 1 can be black always
        public int Id { get; set; }
        public string Name{ get; set; }
        public Colors Color{ get; set; }
        public bool IsWhite{ get; set; }
        public bool IsMyTurn { get; set; }// while initalizing black will always have first turn later add constructor to make is dyanmic
        public int TotalMovesCount{ get; set; }
        public bool IsWinner { get; set; }
        public int ChessStateId { get; set; }
        public Player(){}
        public Player(Colors color) 
        {
            this.Color = color;
            this.IsWhite = color == Colors.White;
        }
        public Player(Colors color,string name, bool IsMyTurn = false)
        {
           this.Color= color;
            this.Name = name;
            this.IsWhite = color == Colors.White;
            this.IsMyTurn = IsMyTurn;
        }

        public Board MakeMove(Spot from, Spot to, List<List<Spot>> boardSpots)
        {
            //first check isTurn has to be true then procced for possibility of move
            if (IsMyTurn) 
            {
                if(from.Piece.CanMove(from, to, boardSpots))
                {
                    //#########If we killing kind then game over here so make class for response############
                    
                    //make move

                    //from valle pice ko null kar 
                    //to value mai pice daal
                    to.Piece = from.Piece;
                    // here pice will be from Piece and cordinates will be same in spot object
                    Spot newtoSpot = new Spot(to.Cordinates, from.Piece);

                    // here pice will be empty and cordinates will be same in spot object
                    Spot newFromSpot = new Spot(from.Cordinates);

                  
                    //actulaly board state mai update kar de
                    boardSpots[to.Cordinates.X][to.Cordinates.Y] = newtoSpot;
                    boardSpots[from.Cordinates.X][from.Cordinates.Y] = newFromSpot;
                    //boardSpots.Where(x => x.Where(x => x == from));
                    this.IsMyTurn = false;
                    return new Board(boardSpots);
                }             
            }
            else 
            {
            
            }
                //can move possible according to piece type
                //then make move if possible

                //if move poos
                return null;
        }
    }
}
