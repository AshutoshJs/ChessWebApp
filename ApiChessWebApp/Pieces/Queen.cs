using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;
using ApiChessWebApp.Pieces;

namespace ChessLogic
{
    public class Queen : Piece
    {
        public override string TypeOfPiece => PieceType.Queen.ToString();
        public override string HtmlCode { get; set; } //= "&#9813";// PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Queen);
        public Queen(){}
        public Queen(int x, int y) : base(x, y) { }
        public Queen(int x, int y, char z) : base(x, y, z) { }
        public Queen(int x, int y, char z, Colors c) : base(x, y, z, c)
        {
            this.HtmlCode = c == Colors.White ? "&#9813" : "&#9819";
        }

        public override bool CanMove(Spot from, Spot to, Piece piece, List<List<Spot>> boardSpotStates)
        {
            /*List<Cordinates> spotsForKnight = new List<Cordinates>();
            decimal startX = from.Cordinates.X;
            decimal startY = from.Cordinates.Y;
            decimal endX = to.Cordinates.X;
            decimal endY = to.Cordinates.Y;
            if (startX < 0 || startY < 0 || startX > 7 || startY > 7 || endX < 0 || endY < 0 || endX > 7 || endY > 7)
            {
                return false;
            }
            */
            Bishop bishop = new Bishop();
            Rook rook = new Rook();

            if(bishop.CanMove(from, to, piece, boardSpotStates) || rook.CanMove(from, to, piece, boardSpotStates))
            {
                return true;
            }
            else
            {
                return false;
            }

                return false;
        }
    }
}
