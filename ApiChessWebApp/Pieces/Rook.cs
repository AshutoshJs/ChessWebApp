using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
