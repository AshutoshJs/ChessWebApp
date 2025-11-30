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
        public override PieceType Type => PieceType.Queen;
        public override string TypeOfPiece => PieceType.Queen.ToString();
        public override string HtmlCode { get; set; } = PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Queen);
      
        public Queen()
        {
            
        }
        public Queen(int x, int y) : base(x, y) { }
        /*
        public override PieceType Type => PieceType.Queen;

        public override Player Color { get; }

        public Queen(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
            // throw new NotImplementedException();
        }
        */
    }
}
