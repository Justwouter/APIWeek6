using Microsoft.EntityFrameworkCore;

[Owned]
public class Geslacht{

    private string identifies = "Onbekend";

    public string Identifies{
        get{return identifies;}
        set{if(value == "Man" || value == "Vrouw" || value == "Anders" || value == "Onbekend"){identifies = value;}}
    }


}