using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Session2_API_CORE.Context;
using Session2_API_CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Session2_API_CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyCardController : ControllerBase
    {
        private readonly WSR_Session2_10Context _context;

        public LoyaltyCardController(WSR_Session2_10Context context)
        {
            _context = context;
        }

        // GET: api/LoyaltyCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoyaltyCard>>> Get()
        {
            if (_context.LoyaltyCards is null)
                return NotFound();

            return Ok(await _context.LoyaltyCards.ToListAsync());
        }

        // GET api/<LoyaltyCardController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<LoyaltyCard>>> Get(int id)
        {
            var loyaltyCard = await _context.LoyaltyCards.FindAsync(id);

            if (loyaltyCard == null)
                return NotFound();

            return Ok(loyaltyCard);
        }

        // GET api/LoyaltyCard?CardHolder=EKATERINA
        [HttpGet("CardHolder")]
        public async Task<ActionResult<IEnumerable<LoyaltyCard>>> GetByName(string CardHolder)
        {
            IEnumerable<LoyaltyCard> loyaltyCard = _context.LoyaltyCards.Where(x => x.CardHolder.Contains(CardHolder));

            if (loyaltyCard == null)
                return NotFound();

            return Ok(loyaltyCard);
        }

        // POST api/<LoyaltyCardController>
        [HttpPost]
        public async Task<ActionResult<LoyaltyCard>> Post(LoyaltyCard loyaltyCard)
        {
            _context.LoyaltyCards.Add(loyaltyCard);
            await _context.SaveChangesAsync();

            return Ok(loyaltyCard);
        }

        // PUT api/<LoyaltyCardController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<LoyaltyCard>>> Put(int id, LoyaltyCard loyaltyCard)
        {
            if (id != loyaltyCard.Id)
                return BadRequest();

            _context.Entry(loyaltyCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!_context.CameraLoads.Any(x => x.Id == id))
                    NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE api/<LoyaltyCardController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var loyaltyCard = await _context.LoyaltyCards.FindAsync(id);

            _context.LoyaltyCards.Remove(loyaltyCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
