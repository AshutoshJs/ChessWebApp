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

        [HttpGet(Name = "InitalizeGameold")]
        public IActionResult TestRookMove()
        {
            var boardState = _db.ChessState.First(x => x.Id == 1).GameState;
            Board2 chessState = JsonSerializer.Deserialize<Board2>(boardState.ToString());
            Bishop b = new Bishop();
            var temp = b.CanMove(new Spot(new Cordinates() { X = 0, Y = 0 }), new Spot(new Cordinates() { X = 3, Y = 3 }), null, chessState.Spots);
           // Rook rook = new Rook());


            return Ok(temp);

        }

    }
}
