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
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger, ChessDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "InitalizeGame")]
        public IActionResult InitalizeGame()//public IEnumerable<Board> InitalizeGame()
        {
            Board board = new Board("ee");
            /*
            Question:yai kya return karega FE ko?
            Answer:inital cordinates of every piece ek calss chiyye jo usko reperesent kare

            Question:
            Answer:

            Question:
            Answer:
             */


            return Ok(board);
        }
        [HttpGet(Name = "InitalizeGameSecond")]
        public IActionResult InitalizeGameSecond()
        {
            Player player1 = new Player(Colors.White, "Ayan");
            Player player2 = new Player(Colors.Black, "Payan");
            Board2 board = new Board2(player1,player2);

            var value = JsonSerializer.Serialize(board);
            ChessState chessState = new ChessState()
            {
                GameState = value

            };
            _db.ChessState.Add(chessState);
            _db.SaveChanges();
            return Ok(board);
        }

        [HttpGet(Name = "GetPossibleMovesOnHover")]
        public IActionResult GetPossibleMovesOnHover()
        {
           var list = _db.ChessState.ToList();
            return Ok();
        }


    }
}
