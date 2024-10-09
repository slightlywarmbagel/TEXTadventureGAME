namespace TEXTadventureGAME;

public static class Player
{
    private static Location currentLocation;
    public static List<Item> Inventory = new List<Item>();

    public static void Initialize()
    {
        currentLocation = Map.StartLocation;
        IO.Write(currentLocation.GetDescription());
        
    }
    
    public static void Move(Command command)
    {
        if (currentLocation.CanMoveInDirection(command.Noun))
        {
            currentLocation = currentLocation.GetLocationInDirection(command.Noun);
            IO.Write(currentLocation.GetDescription());
        }
        else
        {
            IO.Write("Can't go that way.");
        }
    }

    public static void Take(Command command)
    {
        IO.Write("taking " + command.Noun);
        
        Item item = currentLocation.FindItem(command.Noun);
        
        //make beer and infinite beers. can take beer anywhere
        if (item == null)
        {
            IO.Write("There is no " + command.Noun + " here.");
        }
        else if (!item.IsTakeable)
        {
            IO.Write("The " + command.Noun + " cannot be taken.");
        }
        else
        {

            //add to our inventory
            Inventory.Add(item);
            item.Pickup();
            currentLocation.RemoveItem(item);
            IO.Write("You take the " + command.Noun + ".");
            
        }

    }

    public static string GetLocationDescription()
    {
        return currentLocation.GetDescription();
    }

    public static void Drop(Command command)
    {
        //find item in inventory
        Item? item = Inventory.FirstOrDefault(i => 
            i.Name.ToLower() == command.Noun.ToLower());
        //the question mark tells C# that it's okay for the variable Item to store a null.  
        //variable name is i, can be anything though. 
        
        
        //if exists
        if (item != null)
        {
            Inventory.Remove(item);
            currentLocation.DropItem(item);
            IO.Write($"You drop the {item.Name}.");
            //have to preface the quotation with the dollar sign. 
            //without the dollar sign, doesn't know that the {item.Name} isn't a string. It tells the system to pop out the curly bracket
        }
            //remove from inventory list
            //put item at location
            //print out text that we dropped the item
        //else
            //print that you are dumb. 
    }
}