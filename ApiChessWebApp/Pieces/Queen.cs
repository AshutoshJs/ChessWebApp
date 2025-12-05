using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;

namespace ChessLogic
{
    public class Queen : Piece
    {
        public override string TypeOfPiece => PieceType.Queen.ToString();
        public override string HtmlCode { get; set; } = "&#9813";// PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Queen);
        public Queen(){}
        public Queen(int x, int y) : base(x, y) { }
        public Queen(int x, int y, char z) : base(x, y, z) { }
    }
}
