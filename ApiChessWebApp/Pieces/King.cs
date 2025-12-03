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
        public override PieceType Type => PieceType.King;
        public override string TypeOfPiece => PieceType.King.ToString();
        public override string HtmlCode { get; set; } = "&#9812";// PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.King);
        
        public King() { }
        public King(int x, int y) : base(x, y) { }
        public King(int x, int y, char z) : base(x, y,z) { }
        /*
        public override PieceType Type => PieceType.King;

        public override Player Color { get; }

        public King(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
            // throw new NotImplementedException();
        }
        */
    }
}
