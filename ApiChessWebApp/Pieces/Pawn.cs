using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;
using ApiChessWebApp.DatabaseContext;
using ApiChessWebApp.Helper;
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

        //pawn logic should be color-agnostic so assuming White goes DOWN and Black moves UP
        /*
         For any pawn move
         Is the move straight or diagonal?
         If straight:
         Is it forward?
         Is it 1 or 2 squares?
         If diagonal:
         Is there an enemy piece?
         Does color allow this direction?
         Is first-move rule respected?
         */
        public override bool CanMove(Spot from, Spot to, Piece piece, List<List<Spot>> boardSpotStates)
        {
            List<Cordinates> spotsForKing = new List<Cordinates>();
            int startX = from.Cordinates.X;
            int startY = from.Cordinates.Y;
            int endX = to.Cordinates.X;
            int endY = to.Cordinates.Y;
            int deltaX = endX - startX;//Positive deltaX = moving DOWN, Negative deltaX = moving UP
            int deltaY = endY - startY;
            if (startX < 0 || startY < 0 || startX > 7 || startY > 7 || endX < 0 || endY < 0 || endX > 7 || endY > 7)
            {
                return false;
            }
            //right diagronal if any pice there , left diagonal if there aany pice

            /*
             * two step logic
            pawn will cehk in this case whether there is any piece in btween and in that positon bcasue in case of other they
            will cut those piece but pawn cuts diagonally and move straingt so need to cehck both the box for empty
            */
            //if (startY == endY && (endX - startX == 2 ||  startX - endX == 2))
            if(startY == endY && (deltaX == 2 || deltaX == -2))
            {
                if (from.Piece.IsMovingFirstTime)
                {
                    if (from.Cordinates.X == 1 && from.Piece.IsWhite)// because downward movement
                    {
                        //return endX == startX + 2 && /*Pice null check*/boardSpotStates[startX + 1][startY].IsSpotEmpty && boardSpotStates[startX + 2][startY].IsSpotEmpty ? true : false;
                        return /*Pice null check*/boardSpotStates[startX + 1][startY].IsSpotEmpty && boardSpotStates[startX + 2][startY].IsSpotEmpty ? true : false;
                    }
                    else if (from.Cordinates.X == 6 && !from.Piece.IsWhite)
                    {
                        return /*Pice null check*/boardSpotStates[startX - 1][startY].IsSpotEmpty && boardSpotStates[startX - 2][startY].IsSpotEmpty ? true : false;
                        //return endX == startX - 2 && /*Pice null check*/boardSpotStates[startX - 1][startY].IsSpotEmpty && boardSpotStates[startX - 2][startY].IsSpotEmpty ? true : false;
                    }
                }
                else
                {
                    return false;
                }
            }
            // we have checked +2 case above so now here we will reach in case of +1 case only
            //normal one step logic

            //if (endX == startX + 1 && endY == startY && endX < 8 && boardSpotStates[endX][startY].IsSpotEmpty && from.Piece.IsWhite)// Dowward white movement
            if (deltaX == 1 && endY == startY  && endX < 8 && boardSpotStates[endX][startY].IsSpotEmpty && from.Piece.IsWhite)// Dowward white movement
            {
                return true;
            }

            if (deltaX == - 1 && endY == startY && endX < startX && endX >= 0 && boardSpotStates[endX][startY].IsSpotEmpty && !from.Piece.IsWhite)// Upward black movement
            {
                return true;
            }

            //diagonal logic
            if (!boardSpotStates[endX][endY].IsSpotEmpty && boardSpotStates[endX][endY].Piece.IsWhite != from.Piece.IsWhite)
            {
                if (from.Piece.IsWhite)
                {
                    //if ( ((endX == startX + 1 && endY == startY + 1) && endX <= 7 && endY <= 7 ) || ((endX == startX + 1 && endY == startY - 1) && endX <= 7 && endY <= 7))// Diagonal white movement
                    if ( endX <= 7 && endY <= 7 && endX > startX/*forward only check*/ && ((endX == startX + 1 && endY == startY + 1) || (endX == startX + 1 && endY == startY - 1) ))// Diagonal white movement  
                        return true;
                }
                else if(!from.Piece.IsWhite) //
                {
                    if (endX >= 0 && endY >= 0 && endX< startX/*forward only check*/ && ((endX == startX - 1 && endY == startY - 1) || (endX == startX - 1 && endY == startY + 1)))// Diagonal black movement
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

