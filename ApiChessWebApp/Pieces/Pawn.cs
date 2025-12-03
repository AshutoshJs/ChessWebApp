using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;

//namespace ChessLogic.Pieces
namespace ChessLogic
{
    
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override string TypeOfPiece => PieceType.Pawn.ToString();
        public override string HtmlCode { get; set; } = "&#9817";//PiecesHtmlCodesHelper.GetHtmlCodes(PieceType.Pawn);
        public Pawn() { }
        public Pawn(int x, int y) : base(x, y) { }
        public Pawn(int x, int y, char z) : base(x, y, z) { }
        //override Piecetype property
        /*
        public override PieceType Type //New way:::public override PieceType Type => PieceType.Pawn;
        {
            get 
            { 
              return PieceType.Pawn;
            }
        }

        public override Player Color { get; }// to set this property we will use constructor

        public Pawn(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
            // throw new NotImplementedException();
        }
        */
    }
}

