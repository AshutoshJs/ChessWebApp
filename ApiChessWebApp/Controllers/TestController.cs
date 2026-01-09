using System.Text.Json;
using ApiChessWebApp.DatabaseContext;
using ApiChessWebApp.Models;
using ApiChessWebApp.Pieces;
using ChessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiChessWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ChessDbContext _db;
        private readonly ILogger<TestController> _logger;
        public TestController(ILogger<TestController> logger, ChessDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        public IActionResult TestMove(TestPieceMoveModel req)
        {
            //bool canmove = false;
            //var boardState = _db.ChessState.First(x => x.Id == 1).GameState;
            //Board2 chessState = JsonSerializer.Deserialize<Board2>(boardState.ToString());
            //if(req.pieceType.ToLower() == PieceType.Bishop.ToString().ToLower())
            //{
            //    Bishop b = new Bishop();
            //    var temp = b.CanMove(new Spot(new Cordinates() { X = 0, Y = 0 }), new Spot(new Cordinates() { X = 3, Y = 3 }), null, chessState.Spots);
            //}
            //else if (req.pieceType.ToLower() == PieceType.Rook.ToString().ToLower())
            //{
            //    Rook b = new Rook();
            //    var temp = b.CanMove(new Spot(new Cordinates() { X = 2, Y = 0 }), new Spot(new Cordinates() { X = 6, Y = 0 }), null, chessState.Spots);
            //}
            //else if (req.pieceType.ToLower() == PieceType.Pawn.ToString().ToLower())
            //{
            //    Pawn b = new Pawn();
            //    //var temp = b.CanMove(new Spot(new Cordinates() { X = 1, Y = 0 }, new Pawn(1, 0, 'a', Colors.White)), new Spot(new Cordinates() { X = 3, Y = 0 }, new Pawn(3, 0, 'a', Colors.White)), new Pawn(1, 0, 'a', Colors.White), chessState.Spots);
            //    var temp = b.CanMove(new Spot(req.from, new Pawn(1, 0, 'a', Colors.White)), new Spot(req.to, new Pawn(3, 0, 'a', Colors.White)), new Pawn(1, 0, 'a', Colors.White), chessState.Spots);
            //    canmove = temp;
            //}
            return Ok();
        }

    }
}
