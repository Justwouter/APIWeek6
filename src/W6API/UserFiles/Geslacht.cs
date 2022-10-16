using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

[Owned]
public class Geslacht{

    [Required]
    [RegularExpression("Man|Vrouw|Onbekend|Anders", ErrorMessage = "Please choose Man, Vrouw, Onbekend or Anders")] 
    public string? identifies {get;set;}

}