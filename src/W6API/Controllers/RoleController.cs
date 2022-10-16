using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.ComponentModel.DataAnnotations;

namespace W6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly PretparkContext _context;
        private readonly RoleManager<IdentityRole> _RoleManager;

        public RoleController(PretparkContext context, RoleManager<IdentityRole> RoleManager)
        {
            _context = context;
            _RoleManager = RoleManager;

        }


        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetRole()
        {
          if (_RoleManager.Roles == null)
          {
              return NotFound();
          }
            return await _RoleManager.Roles.ToListAsync();
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityRole>> GetRole(string id)
        {
          if (_RoleManager.Roles == null)
          {
              return NotFound();
          }
            var role = await _RoleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }


        // POST: api/Role
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
          if (_RoleManager.Roles == null)
          {
              return Problem("Entity set 'PretparkContext.Role'  is null.");
          }
            await _RoleManager.CreateAsync(role);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoleExists(role.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _RoleManager.FindByIdAsync(id); 
            if ( role == null)
            {
                return NotFound();
            }
            await _RoleManager.DeleteAsync(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(string id)
        {
            return (_RoleManager.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
