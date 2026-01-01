using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;
using ApiChessWebApp.Helper;

namespace ChessLogic.Pieces
{
    public class King : Piece
    {
        public override string TypeOfPiece => PieceType.King.ToString();
        public override string HtmlCode { get; set; } //= "&#9812";
        public King() { }
        public King(int x, int y) : base(x, y) { }
        public King(int x, int y, char z) : base(x, y, z) { }
        public King(int x, int y, char z, Colors c) : base(x, y, z, c)
        { 
            this.HtmlCode = c == Colors.White ? "&#9812" : "&#9818";
        }

        public override bool CanMove(Spot from, Spot to, Piece piece, List<List<Spot>> boardSpotStates)
        {
            List<Cordinates> spotsForKing = new List<Cordinates>();
            int startX = from.Cordinates.X;
            int startY = from.Cordinates.Y;
            int endX = to.Cordinates.X;
            int endY = to.Cordinates.Y;

            if (startX < 0 || startY < 0 || startX > 7 || startY > 7 || endX < 0 || endY < 0 || endX > 7 || endY > 7)
            {
                return false;
            }
            // total 8 moves 
            var move1/*left up 21 -> 10*/ = ModifyCordinates.SubstractVariableInCordinates(from.Cordinates, 1, AddSubstractFlag.XYBoth);
            var move2/*right down 21 -> 32*/= ModifyCordinates.AddVariableInCordinates(from.Cordinates, 1, AddSubstractFlag.XYBoth);
            var move3/*right up 21 -> 12*/= ModifyCordinates.SubstractInXAddInYCordinates(from.Cordinates, 1);
            var move4/*left down 21 -> 30*/= ModifyCordinates.AddInXSubstractInYCordinates(from.Cordinates, 1);
            var move5/*right forward*/= ModifyCordinates.AddVariableInCordinates(from.Cordinates, 1, AddSubstractFlag.YOnly);
            var move6/*right backward*/= ModifyCordinates.SubstractVariableInCordinates(from.Cordinates, 1, AddSubstractFlag.YOnly);
            var move7/*move up*/= ModifyCordinates.SubstractVariableInCordinates(from.Cordinates, 1, AddSubstractFlag.XOnly);
            var move8/*move up*/= ModifyCordinates.AddVariableInCordinates(from.Cordinates, 1, AddSubstractFlag.XOnly);
            spotsForKing.Add(move1);
            spotsForKing.Add(move2);
            spotsForKing.Add(move3);
            spotsForKing.Add(move4);
            spotsForKing.Add(move5);
            spotsForKing.Add(move6);
            spotsForKing.Add(move7);
            spotsForKing.Add(move8);
            spotsForKing = spotsForKing.Where(x => (x.X >= 0 && x.X <= 7) && (x.Y >= 0 && x.Y <= 7)).ToList();
            return spotsForKing.Any(x => x.Equals(to.Cordinates));
        }
    }
}
