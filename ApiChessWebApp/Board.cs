namespace ApiChessWebApp
{
    public class Board
    {
        //public readonly Piece[,] pieces = new Piece[8,8];
        public Piece[,] pieces = new Piece[8, 8];
        public Board(){}

        public Board(string temp)
        {
            pieces = new Piece[8, 8];
            pieces[0,0].Color = Colors.White;
            pieces[0,0].Cordinates = new int[8, 8];

        }

        public void PutCordinate()
        {

            for(int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    //pieces = new int[i, j];
                }
            }
        }
    }
}
