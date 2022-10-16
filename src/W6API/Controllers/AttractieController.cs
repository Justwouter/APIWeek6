using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.CookiePolicy;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace W6API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractieController : ControllerBase
    {
        private readonly PretparkContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AttractieController(PretparkContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Attractie
        [HttpGet, Authorize(Roles = "Medewerker")]
        public async Task<ActionResult<IEnumerable<Attractie>>> GetAttractie()
        {
          if (_context.Attractie == null)
          {
            return NotFound();
          }
            return await _context.Attractie.ToListAsync();
        }

        // GET: api/Attractie/5
        [HttpGet("{id}"), Authorize(Roles = "Medewerker")]
        public async Task<ActionResult<Attractie>> GetAttractie(int id)
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attractie = await _context.Attractie.FindAsync(id);

            if (attractie == null)
            {
                return NotFound();
            }

            return attractie;
        }

        // PUT: api/Attractie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"),Authorize(Roles = "Medewerker")]
        public async Task<IActionResult> PutAttractie(int id, Attractie attractie)
        {
            if (id != attractie.Id)
            {
                return BadRequest();
            }

            _context.Entry(attractie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttractieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Attractie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost,Authorize(Roles = "Medewerker")]
        public async Task<ActionResult<Attractie>> PostAttractie(Attractie attractie)
        {
          if (_context.Attractie == null)
          {
              return Problem("Entity set 'PretparkContext.Attractie'  is null.");
          }
            _context.Attractie.Add(attractie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttractie", new { id = attractie.Id }, attractie);
        }

        // DELETE: api/Attractie/5
        [HttpDelete("{id}"),Authorize(Roles = "Medewerker")]
        public async Task<IActionResult> DeleteAttractie(int id)
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attractie = await _context.Attractie.FindAsync(id);
            if (attractie == null)
            {
                return NotFound();
            }

            _context.Attractie.Remove(attractie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        


        [HttpGet("FilterEngheid"),Authorize(Roles = "Gast")]
        public async Task<ActionResult<IEnumerable<Attractie>>> GetAttractieScareFilter()
        {
            return await _context.Attractie.OrderByDescending(x => x.engheid).ToListAsync();
        }

        [HttpGet("FilterLikes"),Authorize(Roles = "Gast")]
        public async Task<ActionResult<IEnumerable<Attractie>>> GetAttractieLikeAmt()
        {
            return await _context.Attractie.OrderByDescending(x => x.UserLikes.Count()).ToListAsync();
        }

        [HttpGet("FilterBouwjaar"),Authorize(Roles = "Gast")]
        public async Task<ActionResult<IEnumerable<Attractie>>> GetAttractieBuildYear()
        {
            return await _context.Attractie.OrderByDescending(x => x.bouwJaar).ToListAsync();
        }

        private bool AttractieExists(int id)
        {
            return (_context.Attractie?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
