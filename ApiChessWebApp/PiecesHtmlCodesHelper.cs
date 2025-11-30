using System.Linq;

namespace ApiChessWebApp
{
    public static class PiecesHtmlCodesHelper
    {
        public static Dictionary<PieceType, string> HtmlCodes { get; set; } = new Dictionary<PieceType, string>()
        {
            { PieceType.King, "&#9812" },
            { PieceType.Queen, "&#9813"},
            { PieceType.Rook, "&#9814"},
            { PieceType.Bishop,"&#9815"},
            { PieceType.Knight, "&#9816"},
            { PieceType.Pawn, "&#9817"}
        };
       

        //public PiecesHtmlCodesHelper() {}
        public static string GetHtmlCodes(PieceType pieceType)
        {
            return HtmlCodes.Where(x => HtmlCodes.ContainsKey(pieceType)).Select(x => x.Value).FirstOrDefault();
        }
    }
}
