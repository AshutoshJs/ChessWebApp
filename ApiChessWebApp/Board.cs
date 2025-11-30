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
            var initState = this.Pieces;
            var count = this.Pieces.Count;
            var capacity = this.Pieces.Capacity;
            for (int i = 0; i < 8; i++)
            {
                
                this.Pieces.Add(new List<Piece?>(8));
                for (int j = 0; j < 8; j++)
                {
                    this.Pieces[i].Add(new Piece(i,j));
                }

            }
           

            Pieces[0][0] = new Rook(0,0);
            Pieces[0][1] = new Knight(0,1);
            Pieces[0][2] = new Bishop(0,2);
            Pieces[0][3] = new Queen(0,3);
            Pieces[0][4] = new King(0,4);
            Pieces[0][5] = new Bishop(0,5);
            Pieces[0][6] = new Knight(0,6);
            Pieces[0][7] = new Rook(0,7);
            for (int i = 0; i <= 7; i++)
            {
                Pieces[1][i] = new Pawn(1,i);
                Pieces[6][i] = new Pawn(6,i);
            }
            Pieces[7][0] = new Rook(7, 0);
            Pieces[7][1] = new Knight(7,1);
            Pieces[7][2] = new Bishop(7,2);
            Pieces[7][3] = new Queen(7,3);
            Pieces[7][4] = new King(7,4);
            Pieces[7][5] = new Bishop(7,5);
            Pieces[7][6] = new Knight(7,6);
            Pieces[7][7] = new Rook(7,7);
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