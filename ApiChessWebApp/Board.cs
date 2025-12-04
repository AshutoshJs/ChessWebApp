using System.Numerics;
using ApiChessWebApp.Pieces;
using ChessLogic;
using ChessLogic.Pieces;

namespace ApiChessWebApp
{
    public class Board
    {
        //public readonly Piece[,] pieces = new Piece[8,8];
        public List<List<Piece?>> Pieces { get; set; } = new List<List<Piece?>>(8);
        
        public Board(){}
        public Board(string s, string o) : this(){}
        public Board(string temp) 
        {
            this.FillBoxInitialCordiantes();

            //now set the pieces
            Pieces[0][0] = new Rook(0,0,'a');
            Pieces[0][1] = new Knight(0,1,'b');
            Pieces[0][2] = new Bishop(0,2,'c');
            Pieces[0][3] = new Queen(0,3,'d');
            Pieces[0][4] = new King(0,4,'e');
            Pieces[0][5] = new Bishop(0,5,'f');
            Pieces[0][6] = new Knight(0,6,'g');
            Pieces[0][7] = new Rook(0,7,'h');
            for (int i = 0; i <= 7; i++)
            {
                char z = GetCordinateChar(i);
                Pieces[1][i] = new Pawn(1,i,z);
                Pieces[6][i] = new Pawn(6,i,z);
            }
            Pieces[7][0] = new Rook(7, 0,'a');
            Pieces[7][1] = new Knight(7,1,'b');
            Pieces[7][2] = new Bishop(7,2,'c');
            Pieces[7][3] = new Queen(7,3,'d');
            Pieces[7][4] = new King(7,4,'e');
            Pieces[7][5] = new Bishop(7,5,'f');
            Pieces[7][6] = new Knight(7,6,'g');
            Pieces[7][7] = new Rook(7,7,'h');
        }

        public Board(Player playerOne, Player playerTwo):this()
        {
            
        }

        public List<List<Piece?>> FillBoxInitialCordiantes()
        {
            for (int i = 0; i < 8; i++)
            {
                this.Pieces.Add(new List<Piece?>(8));
                for (int j = 0; j < 8; j++)
                {
                    char z = GetCordinateChar(j);

                    this.Pieces[i].Add(new Piece(i, j, z));
                }
            }
            return new List<List<Piece?>>();
        }

        public static char GetCordinateChar(int i)
        {
            switch (i)
            {
                case 0:
                    return 'a';
                    break;
                case 1:
                    return 'b';
                    break;
                case 2:
                    return 'c';
                    break;
                case 3:
                    return 'd';
                    break;
                case 4:
                    return 'e';
                    break;
                case 5:
                    return 'f';
                    break;
                case 6:
                    return 'g';
                    break;
                case 7:
                    return 'h';
                    break;
                default:
                    return ' ';
            }
            //char a = ' ';
            //if (i == 0)
            //    a = 'a';
            //else if (i == 1)
            //    a = 'b';
            //else if (i == 2)
            //    a = 'c';
            //else if (i == 3)
            //    a = 'd';
            //else if (i == 4)
            //    a = 'e';
            //else if (i == 5)
            //    a = 'f';
            //else if (i == 6)
            //    a = 'g';
            //else if (i == 7)
            //    a = 'h';

            //return a;
        }
    }
}
/*
         *  public List<List<Piece?>> Pieces { get; set; } = new List<List<Piece?>>();
         If you attempt to do the following:

         List<List<int>> matrix = new List<List<int>>();
         matrix[2][2] = 1;
         
         You will get a runtime error. Specifically, you'll get an ArgumentOutOfRangeException because
          the matrix list is empty when you try to access matrix[2].
         
         Why this happens:
         
         When you declare the matrix as new List<List<int>>(), it creates an empty list
        (i.e., matrix is an empty list with no rows).
         
         When you try to access matrix[2], you're attempting to access the 3rd element (index 2)
        of an empty list, which doesn't exist, leading to the exception.
         
         How to fix it:
         
         To avoid this error, you need to initialize the inner lists first 
        (i.e., create rows in the matrix). Here's how you can properly populate a List<List<int>>:
         
         
         */