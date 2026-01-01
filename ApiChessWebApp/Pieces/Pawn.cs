using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;
using ApiChessWebApp.DatabaseContext;
using ApiChessWebApp.Models;

//namespace ChessLogic.Pieces
namespace ChessLogic
{
    
    public class Pawn : Piece
    {
        private ChessDbContext _dbContext;
        public override string TypeOfPiece => PieceType.Pawn.ToString();
        public override string HtmlCode { get; set; } //= "&#9817";
        public Pawn() { }
        public Pawn(int x, int y) : base(x, y) {}
        public Pawn(int x, int y, char z) : base(x, y, z) { }
        public Pawn(int x, int y, char z, Colors c) : base(x, y, z, c) 
        {
            this.HtmlCode = c == Colors.White ? "&#9817" : "&#9823";
        }

        //Possible move just list then decide spot is empty or not
        /*public List<Cordinates> PossibleMoves(Cordinates presentCordnates, ChessState state, List<Cordinates> emptyCordinates)
        {
            List<Cordinates > result = new List<Cordinates>();
            if (this.IsMovingFirstTime == true)
            {
                //move two steps
                int z = presentCordnates.Z ?? 0 + 2;
                result.Add(new Cordinates(presentCordnates.X + 2, presentCordnates.Y + 2, (char)z));

                //move one step : check for empty space first filter possible move andd 
            }
            else
            {
                int z = presentCordnates.Z ?? 0 + 1;
                result.Add(new Cordinates(presentCordnates.X + 1, presentCordnates.Y + 1, (char)z));
            }
                return result;
        }

        public Piece MakeMove(Cordinates presentCordnates, ChessState state)
        {
            if(this.IsMovingFirstTime == true)
            {
                //move two steps
            }
            return this;
        }*/

        public override bool CanMove(Spot from, Spot to, Piece piece, List<List<Spot>> boardSpotStates)
        {
            List<Cordinates> spotsForKing = new List<Cordinates>();
            int startX = from.Cordinates.X;
            int startY = from.Cordinates.Y;
            int endX = to.Cordinates.X;
            int endY = to.Cordinates.Y;
            if (startX < 0 || startY < 0 || startX > 7 || startY > 7 || endX < 0 || endY < 0 || endX > 7 || endY > 7)
            {
                return false;
            }
            //right diagronal if any pice there , left diagonal if there aany pice
            endX == startX+
            if (piece.IsMovingFirstTime)
            {


            }
            else
            {

            }


            return true;
        }
    }
}

