using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp.Models;

namespace ApiChessWebApp.Pieces
{
    public class Rook : Piece
    {
        public override string TypeOfPiece => PieceType.Rook.ToString();
        public override string HtmlCode { get; set; } = "&#9814";//PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Rook);
        public Rook() {}
        public Rook(int x, int y) : base(x, y) { }
        public Rook(int x, int y, char z) : base(x, y,z) { }
        public Rook(int x, int y, char z,Colors c) : base(x, y, z, c) 
        {
            this.HtmlCode = c == Colors.White ? "&#9814" : "&#9820";
        }

        public override bool CanMove(Spot from, Spot to,Piece piece, List<List<Spot>> boardSpotStates)
        {
            int startX = from.Cordinates.X;
            int startY = from.Cordinates.Y;
            int endX = to.Cordinates.X;
            int endY = to.Cordinates.Y;
            //bool currentPlayerColor = piece.IsWhite;
            /*now we check from piece par same color ka na ho bac uss case mai hum nahi move kar sakte to from destnation
            1- ya tho kahli ho tho move possible 
            2-ya vaha opposite color pieece ho
             */
            if (to.Piece != null && to.Piece.IsWhite == from.Piece.IsWhite)
            {
                return false;
            }
            //check for max values for both the cordinates as x and y has to less than them
            //my case indexing starts from 0 and ends at 7 so max and min is 0 and 7 
            //although this thing will be handled form FE
            
            if(startX<0 || startY<0 || startX > 7 || startY > 7 || endX < 0 || endY < 0 || endX > 7 || endY > 7)
            {
                return false;
            }

            bool isMovingRowWise = from.Cordinates.X == to.Cordinates.X;
            bool isMovingColumnWise = from.Cordinates.Y == to.Cordinates.Y;

            if (isMovingRowWise == false && isMovingColumnWise == false)
            {
                return false;
            }

            if (isMovingRowWise)// x will be constant y is variable
            {
               // moving forward
               if(startY < endY)
                {
                    //Rightward direction movement
                    for (int i = startY+1; i <= endY-1; i++)
                    {
                        if (boardSpotStates[startX][i].Piece != null/* && boardSpotStates[startX][i].Piece.Color == from.Piece.Color*/)
                        {
                            return false;
                        }

                    }
                    /*if (boardSpotStates[startX][endY].Piece.Color != from.Piece.Color)
                     {
                         return true;
                     }*/
                }
                else//moving backward 
                {
                    //Leftward direction movement
                    for (int i = startY-1; i >= endY+1; i--)
                    {
                        if (boardSpotStates[startX][i].Piece != null /*&& boardSpotStates[startX][i].Piece.Color == from.Piece.Color*/)
                        {
                            return false;
                        }
                    }

                    /*if (boardSpotStates[startX][endY].Piece == null || boardSpotStates[startX][endY].Piece.Color != from.Piece.Color)
                    {
                        return true;
                    }*/
                    
                }

            }
            else//MOVING IN Y DIRECTION => y will be constatn x is variable 
            {
                if (startX < endX)
                {
                    //downward direction movement
                    for (int i = startX + 1; i <= endX - 1; i++)//int i = startY+1; i <= endY-1; i++
                    {
                        if (boardSpotStates[i][startY].Piece != null /*&& boardSpotStates[i][startY].Piece.Color == from.Piece.Color*/)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //upward direction movement
                    for (int i = startX - 1; i >= endX + 1; i--)
                    {
                        if (boardSpotStates[i][startY].Piece != null /*&& boardSpotStates[startX][i].Piece.Color == from.Piece.Color */)
                        {
                            return false;
                        }
                    }
                }
                
            }
            //now check path is clear
            return true;
        }
    }
}
