using System.Text.Json;
using ApiChessWebApp.DatabaseContext;
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

        [HttpGet(Name = "TestMove")]
        ///
        public IActionResult TestRookMove(string? pieceType)
        {

            var boardState = _db.ChessState.First(x => x.Id == 1).GameState;
            Board2 chessState = JsonSerializer.Deserialize<Board2>(boardState.ToString());
            if(pieceType.ToLower() == PieceType.Bishop.ToString().ToLower())
            {
                Bishop b = new Bishop();
                var temp = b.CanMove(new Spot(new Cordinates() { X = 0, Y = 0 }), new Spot(new Cordinates() { X = 3, Y = 3 }), null, chessState.Spots);
            }
            else if (pieceType.ToLower() == PieceType.Rook.ToString().ToLower())
            {
                Rook b = new Rook();
                var temp = b.CanMove(new Spot(new Cordinates() { X = 2, Y = 0 }), new Spot(new Cordinates() { X = 6, Y = 0 }), null, chessState.Spots);
            }

                // Rook rook = new Rook());


                return Ok();

        }

    }
}
