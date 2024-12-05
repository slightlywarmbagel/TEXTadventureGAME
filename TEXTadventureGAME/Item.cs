namespace TEXTadventureGAME;

public class Item
{
    public string Name { get; set; }
    // function
    public string Description { get; }
    public string InitialLocationDescription { get; }
    
    public string DetailedDescription { get; set; }  
    
    public int UseCount;
    // expiration
    public bool IsTakeable { get; private set; }
    public bool IsEdible { get; }
    public bool HasBeenPickedUp { get; private set; } = false;
    

    public string LocationDescription
    {
        get
        {
            string article = SemanticTools.CreateArticle(Name);
            return $"There is {article} {Name} here.";
        }
    }


    public Item(ItemType itemType, string description, string initialLocationDescription, string detailedDescription,
        bool isTakeable = true)
    {
        Name = itemType.ToString();
        Description = description;
        InitialLocationDescription = initialLocationDescription;
        IsTakeable = isTakeable;
        DetailedDescription = detailedDescription;
        
        //HasBeenPickedUp = false; same thing as above just different wording. redundant 
        Vocabulary.AddNoun(Name);
    }

    public void Pickup()
    {
        HasBeenPickedUp = true;
    }

    public string GetLocationDescription()
    {
        if (HasBeenPickedUp)
            return LocationDescription;
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