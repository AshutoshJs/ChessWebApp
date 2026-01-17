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
            Board_Old board = new Board_Old("ee");
            return Ok(board);

        }


        [HttpGet(Name = "InitalizeGame")]
        public IActionResult InitalizeGame()
        {
            Player player1 = new Player(Colors.White, "Ayan");
            Player player2 = new Player(Colors.Black, "Payan");

            Board board = new Board(player1,player2);
            
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
            Board chessState = JsonSerializer.Deserialize<Board>(boardState.ToString());


            // get all spot list here from chess board state object 



            return Ok(boardState);
        }

        /// <summary>
        /// To test piece move possibility
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(Name = "CheckMove")]
        public IActionResult CheckMove(MakeMoveRequest? request)
        {
            var boardState = _db.ChessState.First(x => x.Id == 1).GameState;
            GameState spots = JsonSerializer.Deserialize<GameState>(boardState);

            var from1 = spots.Spots.Select(x => x.Where(k => k.Cordinates.Equals(request.From))).FirstOrDefault().FirstOrDefault();


            var to1 = spots.Spots.Select(x => x.Where(k => k.Cordinates.Equals(request.To))).FirstOrDefault();

            var from = spots.Spots.SelectMany(row => row).FirstOrDefault(s => s.Cordinates.Equals(request.From));
            var to = spots.Spots.SelectMany(row => row).FirstOrDefault(s => s.Cordinates.Equals(request.To));
            //var isMovePossible = from.Piece.CanMove(from, to, spots.Spots);
            //return Ok(isMovePossible);
            return Ok();
        }

        /// <summary>
        /// On draggging one piece to another box this fucntion will do checking and moving thing
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(Name = "MakeMove")]
        public IActionResult MakeMove(MakeMoveRequest? request)
        {
            // will require who is player makeing the move 
            List<List<Spot>> spots = JsonSerializer.Deserialize<List<List<Spot>>>(request.BoardCurrentSpotsState);
            

            return Ok();
        }

    }
}
