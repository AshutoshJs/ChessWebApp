using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiChessWebApp.Pieces
{
    public class Rook : Piece
    {
        public override PieceType Type => PieceType.Rook;
        public override string TypeOfPiece => PieceType.Rook.ToString();
        public override string HtmlCode { get; set; } = PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Rook);
       
        public Rook() {}
        public Rook(int x, int y) : base(x, y) { }
        public Rook(int x, int y, char z) : base(x, y,z) { }
        /*
        public override PieceType Type => PieceType.Rook;

        public override Player Color { get; }

        public Rook(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Rook copy = new Rook(Color);
            copy.HasMoved = HasMoved;
            return copy;
            // throw new NotImplementedException();
        }
        */
    }
}
