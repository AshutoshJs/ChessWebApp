using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;

namespace ChessLogic.Pieces
{
    public class King : Piece
    {
        public override string TypeOfPiece => PieceType.King.ToString();
        public override string HtmlCode { get; set; } = "&#9812";
        public King() { }
        public King(int x, int y) : base(x, y) { }
        public King(int x, int y, char z) : base(x, y,z) { }
    }
}
