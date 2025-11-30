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
        public override PieceType Type => PieceType.Bishop;
        public override string TypeOfPiece => PieceType.Bishop.ToString();
        public override string HtmlCode { get; set; } = PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Bishop);

        public Bishop() { }
        public Bishop(int x, int y) : base(x, y) { }
       

    }
}
