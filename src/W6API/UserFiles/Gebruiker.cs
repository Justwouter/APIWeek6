using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


public class GebruikerMetWachwoord : IdentityUser
{
    public string? Password { get; init; }
    public string UserType {get;set;}
    public List<Attractie> LikedAttractions {get;set;} = new List<Attractie>();

}


public class GebruikerLogin
{
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
}
