using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ApiChessWebApp;
using ApiChessWebApp.Helper;

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


        public override bool CanMove(Spot from, Spot to, List<List<Spot>> boardSpotStates)
        {
            List<Cordinates> spotsForKnight = new List<Cordinates>();
            int startX = from.Cordinates.X;
            int startY = from.Cordinates.Y;
            int endX = to.Cordinates.X;
            int endY = to.Cordinates.Y;

            if (startX < 0 || startY < 0 || startX > 7 || startY > 7 || endX < 0 || endY < 0 || endX > 7 || endY > 7)
            {
                return false;
            }

            // add 2 in x yhen make 2 cordinates adding +1 and -1 y
            var newX1 = ModifyCordinates.AddVariableInCordinates(from.Cordinates, 2, AddSubstractFlag.XOnly);
            
            var newCord1 = ModifyCordinates.AddVariableInCordinates(newX1, 1, AddSubstractFlag.YOnly);
            var newCord2 = ModifyCordinates.SubstractVariableInCordinates(newX1, 1, AddSubstractFlag.YOnly);
            spotsForKnight.Add(newCord1);
            spotsForKnight.Add(newCord2);
            
            //substract 2 in x and then make 2 cordinates addign +1 and -1 in y
            var newX2 = ModifyCordinates.SubstractVariableInCordinates(from.Cordinates, 2, AddSubstractFlag.XOnly);
            
            spotsForKnight.Add(ModifyCordinates.AddVariableInCordinates(newX2, 1, AddSubstractFlag.YOnly));
            spotsForKnight.Add(ModifyCordinates.SubstractVariableInCordinates(newX2, 1, AddSubstractFlag.YOnly));
            
            
            // add 2 in y then make 2 cordinates adding +1 and -1  in x
            var newY1 = ModifyCordinates.AddVariableInCordinates(from.Cordinates, 2, AddSubstractFlag.YOnly);
            
            spotsForKnight.Add(ModifyCordinates.AddVariableInCordinates(newY1, 1, AddSubstractFlag.XOnly));
            spotsForKnight.Add(ModifyCordinates.SubstractVariableInCordinates(newY1, 1, AddSubstractFlag.XOnly));


            //substract 2 in y and then make 2 cordinates addign +1 and -1 in x
            var newY2 = ModifyCordinates.SubstractVariableInCordinates(from.Cordinates, 2, AddSubstractFlag.YOnly);
            spotsForKnight.Add(ModifyCordinates.AddVariableInCordinates(newY2, 1, AddSubstractFlag.XOnly));
            spotsForKnight.Add(ModifyCordinates.SubstractVariableInCordinates(newY2, 1, AddSubstractFlag.XOnly));

            //filter valid cordinates as we might get some cordinates as -2,-1 that is less thatn 0 or greater than 7

            var invalidSpotsForKnight = spotsForKnight.Where(x => x.X < 0 || x.X >7 || x.Y < 0 || x.Y >7).ToList();

            //var validSpotsForKnight = spotsForKnight.Where(x => invalidSpotsForKnight.All( y=> !y.Equals(x)));
            var validSpotsForKnight = spotsForKnight.Where(x => !invalidSpotsForKnight.Any(y => y.Equals(x)));


            //now check whether form cordinates lies in that 
            var isValidMove = validSpotsForKnight.Any(x => x.Equals(to));

            return isValidMove;
        }

        /*
         CanMoveSecond()
                Sanity-check questions (answer before changing code)
                Answer these in plain text:
                1️⃣ If (dx, dy) for a move is (2, 1), should the sign (+ / -) matter?
                2️⃣ If |dx| == 2 and |dy| == 1, do you need to generate all 8 moves explicitly?
                3️⃣ Conceptually, which is clearer:
                “Generate 8 squares and compare”
                or “Check a math condition between start and end”?
         */

    }
}
