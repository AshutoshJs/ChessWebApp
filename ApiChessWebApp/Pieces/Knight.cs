using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;

namespace ChessLogic
{
    internal class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override string TypeOfPiece => PieceType.Knight.ToString();
        public override string HtmlCode { get; set; } = PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Knight);
        public Knight() { }

        public Knight(int x, int y):base(x, y)
        {}
        /*
        public override PieceType Type => PieceType.Knight;

        public override Player Color { get; }

        public Knight(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
            // throw new NotImplementedException();
        }
        */
    }
}
