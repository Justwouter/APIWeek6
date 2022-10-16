using System.ComponentModel.DataAnnotations.Schema;

public class Attractie
{
    public int Id { get; set; }
    public string Naam { get; set; } = null!;
    public DateTime bouwJaar {get;set;}
    public int engheid {get;set;}

    [NotMapped]
    public int like {get;set;}
    public List<GebruikerMetWachwoord> UserLikes {get;set;} 
}