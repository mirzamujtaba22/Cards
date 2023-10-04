
using Cards.Application.CardService;
using Cards.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cards.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CardsController : Controller
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            this._cardService = cardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _cardService.GetAllAsync();
            return Ok(cards);
        }

        [HttpGet]
        [Route("Id")]
        [ActionName("GetCard")]
        public async Task<IActionResult> GetCard(int id)
        {
            var cards = await _cardService.GetByID(id);
            if (cards != null)
            {
                return Ok(cards);
            }
            return NotFound("Card Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] Card card)
        {
            card.Id = new int();
            await _cardService.AddAsync(card);
            return CreatedAtAction(nameof(AddCard), new { card.Id }, card);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCard([FromBody] Card card)
        {
            var existingcard = await _cardService.UpdateAsync(card);
            return Ok(existingcard);
        }
        [HttpDelete]
        [Route("Id")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var numberOfRowsEffected = await _cardService.DeleteAsync(id);
            if (numberOfRowsEffected > 0)
            {   
                return Ok();
            }
           
            return NotFound("Card Not Found");
        }
    }
}
