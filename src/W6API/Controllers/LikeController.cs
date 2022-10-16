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
using System;
using System.Diagnostics;

namespace W6API.Controller;

[Route("api/[controller]")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly PretparkContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public LikeController(PretparkContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
    }


    [HttpPost("{id}"), Authorize(Roles = "Gast")]
    public async Task<ActionResult<List<GebruikerMetWachwoord>>> LikeAttractie(int id){
        if (_context.Attractie == null)
        {
            return NotFound();
        }
        var attractie = await _context.Attractie.Include("UserLikes").SingleAsync(a => a.Id == id);
        if (attractie == null)
        {
            return NotFound();
        }
        var currentUser = await _context.Gebruikers.SingleOrDefaultAsync(g => g.UserName == getSignedUser());
        if (currentUser == null)
        {
            return NotFound();
        }
        //Check if user has liked the attraction. If so, remove the like
        if(currentUser.LikedAttractions.Where(a => a.Id == attractie.Id).Count() > 0){
            attractie.UserLikes.Remove(currentUser);
            currentUser.LikedAttractions.Remove(attractie);
        }
        else{
            attractie.UserLikes.Add(currentUser);
            currentUser.LikedAttractions.Add(attractie);
        }
        await _context.SaveChangesAsync();
        return attractie.UserLikes;

    }

    [HttpGet,Authorize(Roles = "Gast")]
    public async Task<ActionResult<IEnumerable<Attractie>>> GetLikedAttractions(){
        var currentUser = await _context.Gebruikers.Include("LikedAttractions").SingleOrDefaultAsync(g => g.UserName == getSignedUser());

        if(currentUser !=null){
            if(!await _userManager.IsInRoleAsync(currentUser, "Medewerker")){
                return currentUser.LikedAttractions.ToList();
            }
        }
        return NotFound();
    }

    private string getSignedUser() {
        Request.Headers.TryGetValue("Authorization", out var headervalue);
        string cleanToken = headervalue.ToString().Substring(7);
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(cleanToken);
        var tokenS = jsonToken as JwtSecurityToken;
        string[] loggedInUserDisgusting = tokenS.Claims.ToList()[0].ToString().Split(": ");
        string loggedInUser = loggedInUserDisgusting[1];
        return loggedInUser;
    }




}
