using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Allo.Model;
using Allo.Services;

namespace Allo.Controllers
{
    [Area("v1")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly List<UserProfile> cards = new List<UserProfile>();

        // GET api/v1/cards/user/me@aideen.dev
        [HttpGet]
        [Route("api/[area]/cards/user/{email}")]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetByUser([FromServices] IUserProfileStore store, string email)
        {
            return Ok(await store.GetUserCardsAsync(email));
        }

        // GET api/v1/card/aAg87a9831
        [HttpGet]
        [Route("api/[area]/card/{id}", Name = "GetCard.v1")]
        public async Task<ActionResult<UserProfile>> Get([FromServices] IUserProfileStore store, string id)
        {
            var card = await store.GetCardAsync(id);
            if (card == null) return NotFound();
            return Ok(card);
        }

        // POST api/v1/cards
        [HttpPost]
        [Route("api/[area]/cards")]
        public async Task<ActionResult<UserProfile>> Post([FromServices] IUserProfileStore store, [FromBody] UserProfile card)
        {
            card.ID = null; // Users are horrible people, don't let them play hookie with the service
            var cardCreated = await store.StoreCardAsync(card);
            return  Created(Url.RouteUrl("GetCard.v1", new { id = cardCreated.ID }), cardCreated);
        }

        // PUT api/v1/card/5
        [HttpPut]
        [Route("api/[area]/card/{id}")]
        public async Task<ActionResult<UserProfile>> Put([FromServices] IUserProfileStore store, string id, [FromBody] UserProfile value)
        {
            value.ID = id;
            return Ok(await store.StoreCardAsync(value));
           
        }

        // DELETE api/v1/card/5
        [HttpDelete]
        [Route("api/[area]/card/{id}")]
        public async Task<ActionResult> Delete([FromServices] IUserProfileStore store, string id)
        {
            await store.RemoveCardAsync(id);

            return NoContent();
        }
    }
}
