namespace BullsAndCows.Web.Controllers
{
    using BullsAndCows.Data;
    using BullsAndCows.GameLogics;
    using BullsAndCows.Models;
    using BullsAndCows.Web.Infrastructure;
    using BullsAndCows.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;


    public class GamesController : BaseApiController
    {
        private const int defaultPageSize = 10;

        private IGameResultValidator resultValidator;
        private IUserIdProvider userIdProvider;

        private Random rand;

        //If you want to see the help page, comment all in Startup.cs, leaving only ConfigureAuth(app) uncommented
        //public GamesController()
        //    :this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        //{
        //}
        public GamesController(IBullsAndCowsData data)
            : base(data)
        {
            //this.resultValidator = resultValidator;
            //this.userIdProvider = userIdProvider;
            rand = new Random();
        }


        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var games = ReturnGamePages(0);

            return Ok(games);
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetByID(int id)
        {
            var article = this.data.Games.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            var articleModel = new GameDataModel();
            return Ok(articleModel);
        }

        //[HttpGet]
        //public IHttpActionResult Get(string category)
        //{
        //    return Get(category, 0);
        //}

        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            var games = ReturnGamePages(page);

            return Ok(games);
        }

        private IHttpActionResult ReturnGamePages(int page)
        {
            var sortedGames = GetAllSorted();
            if (sortedGames == null)
            {
                return BadRequest("No games");
            }

            var games = GetAllSorted().Skip(page * defaultPageSize).Take(defaultPageSize);

            return Ok(games);
        }
        //[HttpGet]
        //public IHttpActionResult Get(string category, int page)
        //{
        //    var articles = GetAllSorted()
        //        .Skip(page * defaultPageSize)
        //        .Take(defaultPageSize);

        //    return Ok(articles);
        //}

        private IEnumerable<GameDataModel> GetAllSorted()
        {
            var games = this.data.Games.All();

            if (games != null)
            {
                return this.data.Games.All()
                   .OrderBy(a => a.GameState)
                   .ThenBy(a => a.Name)
                   .ThenBy(a => a.DateCreated)
                   .ThenBy(a => a.RedUser.UserName)
                   .Select(GameDataModel.FromGame);
            }
            return null;
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Post()
        {
            var currentUserId = new Guid(this.userIdProvider.GetUserId());

            var newGame = new Game
            {
                RedId = currentUserId,
            };

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            return Ok(newGame.Id);
        }

        //[HttpPost]
        //public IHttpActionResult Join()
        //{
        //    var currentUserId = new Guid(this.userIdProvider.GetUserId());

        //    var game = this.data.Games
        //        .All()
        //        .Where(g => g.GameState == GameState.AvailableForJoining && g.RedId != currentUserId)
        //        .FirstOrDefault();

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    game.BlueId = currentUserId;

        //    if (rand.Next(0, 2) == 0)
        //    {
        //        game.GameState = GameState.TurnRed;
        //    }
        //    else
        //    {
        //        game.GameState = GameState.TurnBlue;
        //    }

        //    this.data.SaveChanges();

        //    return Ok(game.Id);
        //}

        //[HttpGet]
        //public IHttpActionResult Status(string gameId)
        //{
        //    var currentUserId = this.userIdProvider.GetUserId();
        //    var idAsGuid = new Guid(gameId);

        //    var game = this.data.Games.All()
        //        .Where(x => x.Id == idAsGuid)
        //        .Select(x => new { x.RedId, x.BlueId })
        //        .FirstOrDefault();
        //    if (game == null)
        //    {
        //        return this.NotFound();
        //    }

        //    if (game.RedId != currentUserId &&
        //        game.BlueId != currentUserId)
        //    {
        //        return this.BadRequest("This is not your game!");
        //    }

        //    var gameInfo = this.data.Games.All()
        //        .Where(g => g.Id == idAsGuid)
        //        .Select(g => new GameInfoDataModel()
        //        {
        //            Board = g.Board,
        //            Id = g.Id,
        //            State = g.State,
        //            FirstPlayerName = g.FirstPlayer.UserName,
        //            SecondPlayerName = g.SecondPlayer.UserName,
        //        })
        //        .FirstOrDefault();

        //    return Ok(gameInfo);
        //}

        ///// <param name="row">1,2 or 3</param>
        ///// <param name="col">1,2 or 3</param>
        //[HttpPost]
        //public IHttpActionResult Play(PlayRequestDataModel request)
        //{
        //    var currentUserId = this.userIdProvider.GetUserId();

        //    if (request == null || !ModelState.IsValid)
        //    {
        //        return this.BadRequest(ModelState);
        //    }

        //    var idAsGuid = new Guid(request.GameId);

        //    var game = this.data.Games.Find(idAsGuid);
        //    if (game == null)
        //    {
        //        return this.BadRequest("Invalid game id!");
        //    }

        //    if (game.FirstPlayerId != currentUserId &&
        //        game.SecondPlayerId != currentUserId)
        //    {
        //        return this.BadRequest("This is not your game!");
        //    }

        //    if (game.State != GameState.TurnX &&
        //        game.State != GameState.TurnO)
        //    {
        //        return this.BadRequest("Invalid game state!");
        //    }

        //    if ((game.State == GameState.TurnX &&
        //        game.FirstPlayerId != currentUserId)
        //        ||
        //        (game.State == GameState.TurnO &&
        //        game.SecondPlayerId != currentUserId))
        //    {
        //        return this.BadRequest("It's not your turn!");
        //    }

        //    var positionIndex = (request.Row - 1) * 3 + request.Col - 1;
        //    if (game.Board[positionIndex] != '-')
        //    {
        //        return this.BadRequest("Invalid position!");
        //    }

        //    // Update games state and board
        //    var boardAsStringBuilder = new StringBuilder(game.Board);
        //    boardAsStringBuilder[positionIndex] =
        //        game.State == GameState.TurnX ? 'X' : 'O';
        //    game.Board = boardAsStringBuilder.ToString();

        //    game.State = game.State == GameState.TurnX ?
        //        GameState.TurnO : GameState.TurnX;

        //    this.data.SaveChanges();

        //    var gameResult = resultValidator.GetResult(game.Board);
        //    switch (gameResult)
        //    {
        //        case GameResult.NotFinished:
        //            break;
        //        case GameResult.WonByX:
        //            game.State = GameState.WonByX;
        //            this.data.SaveChanges();
        //            break;
        //        case GameResult.WonByO:
        //            game.State = GameState.WonByO;
        //            this.data.SaveChanges();
        //            break;
        //        case GameResult.Draw:
        //            game.State = GameState.Draw;
        //            this.data.SaveChanges();
        //            break;
        //        default:
        //            break;
        //    }

        //    return this.Ok();
        //}
    }
}
