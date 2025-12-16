using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;

namespace ChessLogic
{
    public class Bishop : Piece
    {
        public override string TypeOfPiece => PieceType.Bishop.ToString();
        public override string HtmlCode { get; set; } //PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Bishop);
        public Bishop() { }
        public Bishop(int x, int y) : base(x, y) { }
        public Bishop(int x, int y, char z) : base(x, y, z) { }
        public Bishop(int x, int y, char z, Colors c) : base(x, y, z, c) 
        {
            this.HtmlCode = c == Colors.White ? "&#9815" : "&#9821";
        }
        public override bool CanMove(Spot from, Spot to, Piece piece, List<List<Spot>> boardSpotStates)
        {
            List<Cordinates> spotsForKnight = new List<Cordinates>();
            decimal startX = from.Cordinates.X;
            decimal startY = from.Cordinates.Y;
            decimal endX = to.Cordinates.X;
            decimal endY = to.Cordinates.Y;

            if (startX < 0 || startY < 0 || startX > 7 || startY > 7 || endX < 0 || endY < 0 || endX > 7 || endY > 7)
            {
                return false;
            }


           if(startX < endX && startY < endY)//00 to 11 down-right
            {
                var x1=startX+1;
                var y1=startY+1;
                if( (endY - startY) / (endX - startX) == 1)
                {
                    //for(int i = 0; i < (endX - startX); i++)
                    
                    while(x1 < endX && y1 < endY)
                    {
                        if (boardSpotStates[(int)x1][(int)y1].Piece != null)
                        {
                            return false;
                        }
                        x1 = x1 + 1;
                        y1 = y1 + 1;

                    }

                    return true;
                }
            }
            else if (endX < startX && endY <startY)// 33 to 22  up-left
            {
                var x1 = startX - 1;
                var y1 = startY - 1;
                if ((endY - startY) / (endX - startX) == 1)
                {
                    //for(int i = 0; i < (endX - startX); i++)

                    while (x1 > endX && y1 > endY)
                    {
                        if (boardSpotStates[(int)x1][(int)y1].Piece != null)
                        {
                            return false;
                        }
                        x1 = x1 - 1;
                        y1 = y1 - 1;

                    }

                    return true;
                }

                // return (startY - endY) / (startX - endX) == 1;
            }
            else if (startX > endX && startY < endY)// 30 to 21 up right
            {
                var x1 = startX - 1;
                var y1 = startY + 1;
                if ((endY - startY) / (endX - startX) == 1)
                {
                    //for(int i = 0; i < (endX - startX); i++)

                    while (x1 > endX && y1 < endY)
                    {
                        if (boardSpotStates[(int)x1][(int)y1].Piece != null)
                        {
                            return false;
                        }
                        x1 = x1 - 1;
                        y1 = y1 + 1;

                    }

                    return true;
                }

                // return (startY - endY) / (startX - endX) == -1;
            }
            else if (startX < endX && startY > endY)// 03 to 12 up right
            {
                var x1 = startX + 1;
                var y1 = startY - 1;
                if ((endY - startY) / (endX - startX) == 1)
                {
                    //for(int i = 0; i < (endX - startX); i++)

                    while (x1 > endX && y1 < endY)
                    {
                        if (boardSpotStates[(int)x1][(int)y1].Piece != null)
                        {
                            return false;
                        }
                        x1 = x1 + 1;
                        y1 = y1 - 1;

                    }

                    return true;
                }
                //return (startY - endY) / (startX - endX) == -1;
            }

            return false;
        }
    }
}
