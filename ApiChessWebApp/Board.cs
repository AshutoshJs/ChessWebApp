using ApiChessWebApp.Pieces;
using ChessLogic.Pieces;
using ChessLogic;

namespace ApiChessWebApp
{
    public class Board
    {
        public List<List<Spot>> Spots { get; set; } = new List<List<Spot>>();
        public Board(){}

        public Board(List<List<Spot>> listofSpots) 
        {
            this.Spots = listofSpots;
        }
        public Board(string s)
        {
            for (int i = 0; i < 8; i++)
            {
                Spots.Add(new List<Spot>());
                for (int j = 0; j < 8; j++)
                {
                    var cordinate = new Cordinates(i, j, GetCordinateChar(j));
                    Spots[i].Add(new Spot(cordinate));
                }
            }
            //Spots has pieces
            Spots[0][0].Piece = new Rook(0, 0, 'a');
            Spots[0][1].Piece = new Knight(0, 1, 'b');
            Spots[0][2].Piece = new Bishop(0, 2, 'c');
            Spots[0][3].Piece = new Queen(0, 3, 'd');
            Spots[0][4].Piece = new King(0, 4, 'e');
            Spots[0][5].Piece = new Bishop(0, 5, 'f');
            Spots[0][6].Piece = new Knight(0, 6, 'g');
            Spots[0][7].Piece = new Rook(0, 7, 'h');
            for (int i = 0; i <= 7; i++)
            {
                char z = GetCordinateChar(i);
                Spots[1][i].Piece = new Pawn(1, i, z);
                Spots[6][i].Piece = new Pawn(6, i, z);
            }
            Spots[7][0].Piece = new Rook(7, 0, 'a');
            Spots[7][1].Piece = new Knight(7, 1, 'b');
            Spots[7][2].Piece = new Bishop(7, 2, 'c');
            Spots[7][3].Piece = new Queen(7, 3, 'd');
            Spots[7][4].Piece = new King(7, 4, 'e');
            Spots[7][5].Piece = new Bishop(7, 5, 'f');
            Spots[7][6].Piece = new Knight(7, 6, 'g');
            Spots[7][7].Piece = new Rook(7, 7, 'h');
        }

        //Used to initialize the board 
        public Board(Player a, Player b)
        {
            for (int i = 0; i < 8; i++)
            {
                Spots.Add(new List<Spot>());
                for (int j = 0; j < 8; j++)
                {
                    var cordinate = new Cordinates(i, j, GetCordinateChar(j));
                    Spots[i].Add(new Spot(cordinate));
                }
            }
            //Spots has pieces
            Spots[0][0].Piece = new Rook(0, 0, 'a', a.Color);
            Spots[0][1].Piece = new Knight(0, 1, 'b', a.Color);
            Spots[0][2].Piece = new Bishop(0, 2, 'c', a.Color);
            Spots[0][3].Piece = new Queen(0, 3, 'd', a.Color);
            Spots[0][4].Piece = new King(0, 4, 'e', a.Color);
            Spots[0][5].Piece = new Bishop(0, 5, 'f', a.Color);
            Spots[0][6].Piece = new Knight(0, 6, 'g', a.Color);
            Spots[0][7].Piece = new Rook(0, 7, 'h', a.Color);
            for (int i = 0; i <= 7; i++)
            {
                char z = GetCordinateChar(i);
                Spots[1][i].Piece = new Pawn(1, i, z, a.Color);
                Spots[6][i].Piece = new Pawn(6, i, z, b.Color);
            }
            Spots[7][0].Piece = new Rook(7, 0, 'a', b.Color);
            Spots[7][1].Piece = new Knight(7, 1, 'b', b.Color);
            Spots[7][2].Piece = new Bishop(7, 2, 'c', b.Color);
            Spots[7][3].Piece = new Queen(7, 3, 'd', b.Color);
            Spots[7][4].Piece = new King(7, 4, 'e', b.Color);
            Spots[7][5].Piece = new Bishop(7, 5, 'f', b.Color);
            Spots[7][6].Piece = new Knight(7, 6, 'g', b.Color);
            Spots[7][7].Piece = new Rook(7, 7, 'h', b.Color);
        }

        public static char GetCordinateChar(int i)
        {
            switch (i)
            {
                case 0:
                    return 'a';
                case 1:
                    return 'b';
                case 2:
                    return 'c';
                case 3:
                    return 'd';
                case 4:
                    return 'e';
                case 5:
                    return 'f';
                case 6:
                    return 'g';
                case 7:
                    return 'h';
                default:
                    return ' ';
            }
        }

    }
}
