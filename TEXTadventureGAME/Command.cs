namespace TEXTadventureGAME;

public class Command
    
//will store all information about commands. ik redundant but whateva
//not static bc u gotta remember multiple commands. various versions :D

{
    public string Verb = String.Empty;
    public string Noun = String.Empty;
    public bool IsValid = false;


    public bool HasNoNoun()
    {
        if (Noun == String.Empty)
            return true;
        return false;
    }
    public string ToString()
    {
        return "Command: Verb = [" + Verb + "], Noun = [" + Noun + "], IsValid = " + IsValid;
    }
}