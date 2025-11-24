using Microsoft.AspNetCore.Mvc;

namespace ApiChessWebApp.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    [Route("api/[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
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


             return StatusCode(200, board);
        }
    }
}
