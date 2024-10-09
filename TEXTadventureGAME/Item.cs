namespace TEXTadventureGAME;

public class Item
{
    public string Name; 
    //function
    public string Description;
    public string InitialLocationDescription;

    public int UseCount;
    //expiration
    public bool IsTakeable;
    public bool IsEdible;
    public bool HasBeenPickedUp = false;
    


    public Item(string name, string description, string initialLocationDescription, bool isTakeable = true)
    {
        this.Name = name;
        Description = description;
        InitialLocationDescription = initialLocationDescription;
        IsTakeable = isTakeable;
        //HasBeenPickedUp = false; same thing as above just different wording. redundant 
        Vocabulary.AddNoun(name);
    }

    public void Pickup()
    {
        HasBeenPickedUp = true;
    }

    public string GetLocationDescription()
    {
        if (HasBeenPickedUp)
            return Description;
        else
        {
            return InitialLocationDescription;
        }
        //if haven't been picked up
            //return the initial location description
        //if has been picked up
            //return the description
    }
}