using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using t3service.Models;
using t3service.Helpers;

namespace t3service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        /**
         * Creates a new game in the database. P2 will always be the computer for now.
         */
        // GET api/values
        [HttpPost]
        public ActionResult<Games> NewGame([FromBody] Games game)
        {
            GameManager gm = new GameManager();
            gm.InitGame(game);
            return Ok(game);
        }

        /**
         * Validates and performs movement. It's a game updater.
         */
        [HttpPost]
        public ActionResult<Games> Move([FromBody] Movement movement)
        {
            GameManager gm = new GameManager();
            Games game = gm.Move(movement);
            return Ok(game);
        }

        /**
         * Used to obtain an already existing game.
         */
        [HttpGet]
        public ActionResult<Games> GetGame([FromRoute] Guid gameId)
        {
            GameManager gm = new GameManager();
            Games game = gm.GetGame(gameId);
            return Ok(game);
        }
    }
}