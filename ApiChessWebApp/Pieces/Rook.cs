using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiChessWebApp.Pieces
{
    public class Rook : Piece
    {
        public override string TypeOfPiece => PieceType.Rook.ToString();
        public override string HtmlCode { get; set; } = PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Rook);
        public Rook() {}
        public Rook(int x, int y) : base(x, y) { }
        public Rook(int x, int y, char z) : base(x, y,z) { }
    }
}
