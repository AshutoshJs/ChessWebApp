using System.Text.Json;
using System.Text.Json.Serialization;
using ApiChessWebApp.DatabaseContext;
using ApiChessWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiChessWebApp.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    [Route("api/[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private readonly ChessDbContext _db;
       
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger, ChessDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet(Name = "InitalizeGameold")]
        public IActionResult InitalizeGameOld()//public IEnumerable<Board> InitalizeGame()
        {
            Board board = new Board("ee");
            return Ok(board);

        }


        [HttpGet(Name = "InitalizeGame")]
        public IActionResult InitalizeGame()
        {
            Player player1 = new Player(Colors.White, "Ayan");
            Player player2 = new Player(Colors.Black, "Payan");
            Board2 board = new Board2(player1,player2);
            
            var value = JsonSerializer.Serialize(board);
            ChessState chessState = new ChessState()
            {
                GameState = value

            };
            var game = _db.ChessState.FirstOrDefault(x => x.Id == 1);
            if (game != null)
            {
                game.GameState = value;
            }else
            {
                _db.ChessState.Add(chessState);
            }
            _db.SaveChanges();
            return Ok(board);
        }

        [HttpGet(Name = "GetPossibleMovesOnHover")]
        public IActionResult GetPossibleMovesOnHover()
        {
           var list = _db.ChessState.ToList();
            return Ok();
        }

        [HttpPost(Name = "MovePiece")]
        public IActionResult MovePiece(MovePieceModel? request)
        {
            var boardState = _db.ChessState.First(x => x.Id == 1).GameState;
            Board2 chessState = JsonSerializer.Deserialize<Board2>(boardState.ToString());


            // get all spot list here from chess board state object 



            return Ok(boardState);
        }


    }
}
