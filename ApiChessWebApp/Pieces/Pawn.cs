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
        public override string TypeOfPiece => PieceType.Pawn.ToString();
        public override string HtmlCode { get; set; } = "&#9817";
        public Pawn() { }
        public Pawn(int x, int y) : base(x, y) {}
        public Pawn(int x, int y, char z) : base(x, y, z) {}
    }
}

