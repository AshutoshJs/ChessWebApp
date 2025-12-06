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
        public override string TypeOfPiece => PieceType.Knight.ToString();
        public override string HtmlCode { get; set; } //= "&#9816";
        public Knight() { }
        public Knight(int x, int y):base(x, y){}
        public Knight(int x, int y, char z) : base(x, y, z) { }
        public Knight(int x, int y, char z, Colors c) : base(x, y, z, c) 
        {
            this.HtmlCode = c == Colors.White ? "&#9816" : "&#9822";
        }
    }
}
