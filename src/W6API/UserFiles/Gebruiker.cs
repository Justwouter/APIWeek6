using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


public class GebruikerMetWachwoord : IdentityUser
{
    public string? Password { get; init; }
    public List<Like> LikedAttractions {get;set;}  = new List<Like>();

}

public class GebruikerLogin
{
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
}
