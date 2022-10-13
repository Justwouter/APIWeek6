public class Like{
    public int Id {get;set;}
    public Attractie attractie {get;set;} = null!;
    public GebruikerMetWachwoord gebruiker {get;set;} = null!;

    public Like(Attractie attractie, GebruikerMetWachwoord gebruiker){
        this.attractie = attractie;
        this.gebruiker = gebruiker;
    }

    protected Like(){}
}