namespace TEXTadventureGAME;

public class Command
    
//will store all information about commands. ik redundant but whateva
//not static bc u gotta remember multiple commands. various versions :D

{
    public string Verb;
    public string Noun;
    public bool IsValid = false;

    public string ToString()
    {
        return "Command: Verb = [" + Verb + "], Noun = [" + Noun + "], IsValid = " + IsValid;
    }
}