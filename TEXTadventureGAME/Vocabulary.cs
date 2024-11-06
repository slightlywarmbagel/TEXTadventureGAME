namespace TEXTadventureGAME;

public static class Vocabulary
{
    public static List<string> notStandaloneVerbs = new List<string>()
    {"eat", "go", "take", "drop"};
    
    public static List<string> standaloneVerbs = new List<string>()
        {"look", "inventory", "exit", "tron", "troff", "talk"};
    //add eat into this one and you just comically eat a chunk out of the world. it goes back to normal afterwards and says so in the description that says you ate the world. 
    
    public static List<string> nouns = new List<string>()
        {"north", "south", "east", "west", "up", "down"};



    public static bool IsVerb(string word)
    {
        return notStandaloneVerbs.Contains(word) || standaloneVerbs.Contains(word);
    }

    public static bool IsStandaloneVerb(string word)
    {
        return standaloneVerbs.Contains(word);
    }

    public static bool IsNoun(string word)
    {
        return nouns.Contains(word);
    }


    public static void AddNoun(string name)
    {
        name = name.ToLower();
        if (!nouns.Contains(name))//will look into the list of names and see if its there or not
            nouns.Add(name);
    }
}
