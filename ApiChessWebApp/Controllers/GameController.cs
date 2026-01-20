using System.Text.Json;
using System.Text.Json.Serialization;
using ApiChessWebApp.DatabaseContext;
using ApiChessWebApp.DbDTos;
using ApiChessWebApp.Models;
using ApiChessWebApp.Pieces;
using ChessLogic;
using ChessLogic.Pieces;
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
            Player player2 = new Player(Colors.Black, "Payan", true);

           

            Board board = new Board(player1,player2);
            
            var seralizedBoard = JsonSerializer.Serialize(board);

            ChessStateDbDto chessState = new ChessStateDbDto(){  GameState = seralizedBoard};
            /*
            var game = _db.ChessState.FirstOrDefault(x => x.Id == 1);

            if (game != null)
            {
                game.GameState = seralizedBoard;
            }else
            {
                _db.ChessState.Add(chessState);
            }
            */
            _db.ChessState.Add(chessState);
            
            _db.SaveChanges();
            var chessStateID = chessState.Id;
            player1.ChessStateId = chessStateID;
            player1.ChessStateId = chessStateID;
            var p1 = _db.Player.Add(new PlayerDbDto(player1));
            var p2 = _db.Player.Add(new PlayerDbDto(player2));
            _db.SaveChanges();
            var p1Id = player1.Id;
            var p2Id = player2.Id;
            _db.GameStateDbDto.Add(new GameStateDbDto() { ChessStateId = chessStateID , FirstPlayerId = p1Id, SecondPlayerId= p2Id });
            _db.SaveChanges();
            // return spots , player 1, plyer 2
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
        public IActionResult CheckMove(CheckMoveRequest? request)
        {
            var boardState = _db.ChessState.First(x => x.Id == 1).GameState;
            GameState spots = JsonSerializer.Deserialize<GameState>(boardState);

            var from1 = spots.Spots.Select(x => x.Where(k => k.Cordinates.Equals(request.From))).FirstOrDefault().FirstOrDefault();


            var to1 = spots.Spots.Select(x => x.Where(k => k.Cordinates.Equals(request.To))).FirstOrDefault();

            var temp = spots.Spots.SelectMany(row => row).FirstOrDefault();
            var temp2 = spots.Spots.Select(row => row).FirstOrDefault();
            var from = spots.Spots.SelectMany(row => row).FirstOrDefault(s => s.Cordinates.Equals(request.From));
            var to = spots.Spots.SelectMany(row => row).FirstOrDefault(s => s.Cordinates.Equals(request.To));
            var isMovePossible = false;
            if (from.Piece.TypeOfPiece == PieceType.Pawn.ToString())
            {
                Pawn p = new Pawn();
                isMovePossible = p.CanMove(from, to, spots.Spots);
            }else if (from.Piece.TypeOfPiece == PieceType.Rook.ToString()) {
                Rook p = new Rook();
                isMovePossible = p.CanMove(from, to, spots.Spots);
            }
            else if (from.Piece.TypeOfPiece == PieceType.Queen.ToString()) {
                Queen p = new Queen();
                isMovePossible = p.CanMove(from, to, spots.Spots);
            }
            else if (from.Piece.TypeOfPiece == PieceType.King.ToString()) {
                King p = new King();
                isMovePossible = p.CanMove(from, to, spots.Spots);
            }
            else if (from.Piece.TypeOfPiece == PieceType.Bishop.ToString()) {
                Bishop p = new Bishop();
                isMovePossible = p.CanMove(from, to, spots.Spots);
            }

            return Ok(isMovePossible);
          //  return Ok();
        }

        /// <summary>
        /// On draggging one piece to another box this fucntion will do checking and moving thing
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(Name = "MakeMove")]
        public IActionResult MakeMove(MakeMoveViewModel? request)
        {
            // will require who is player makeing the move \
            var gameState = _db.GameStateDbDto.Where(x => x.Id == request.GameId).First();
            var boardState = _db.ChessState.Where(x => x.Id == gameState.ChessStateId).First();
            // List<List<Spot>> spots = JsonSerializer.Deserialize<List<List<Spot>>>(request.BoardCurrentSpotsState);

            //List<List<Spot>> spots = JsonSerializer.Deserialize<List<List<Spot>>>(boardState.GameState);
            GameState spots = JsonSerializer.Deserialize<GameState>(boardState.GameState);

            
            var from = spots.Spots.SelectMany(row => row).FirstOrDefault(s => s.Cordinates.Equals(request.From));
            var to = spots.Spots.SelectMany(row => row).FirstOrDefault(s => s.Cordinates.Equals(request.To));
            
            var player1 = new Player(_db.Player.Where(x => x.Id == gameState.FirstPlayerId).First());
            var player2 = new Player(_db.Player.Where(x => x.Id == gameState.SecondPlayerId).First());
            var chessStateId = gameState.ChessStateId;
            Board newBoard;
            if (player1.IsMyTurn)
            {
                newBoard= player1.MakeMove(from,to, spots.Spots);
                player1.IsMyTurn = false;
                player2.IsMyTurn = true;
            }
            else if(player2.IsMyTurn)
            {
                newBoard= player2.MakeMove(from, to, spots.Spots);
                player1.IsMyTurn = true;
                player2.IsMyTurn = false;
            }
            else
            {
                return BadRequest("no turn found");
            }

                // Board board = new Board(request.Player1, request.Player2);


                var value = JsonSerializer.Serialize(newBoard);
            ChessStateDbDto chessState = new ChessStateDbDto()
            {
                GameState = value

            };

            var game = _db.ChessState.FirstOrDefault(x => x.Id == request.GameId);
            game.GameState = value;

            _db.ChessState.Add(chessState);
            _db.SaveChanges();
            return Ok();
        }

    }
}
