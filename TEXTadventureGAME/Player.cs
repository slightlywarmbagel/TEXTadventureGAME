using System.Data;

namespace TEXTadventureGAME;

public static class Player
{
    private static Location currentLocation;
    public static List<Item> Inventory = new List<Item>();

    public static void Initialize()
    {
        currentLocation = Map.StartLocation;
        IO.WriteLine(currentLocation.GetDescription());
        
    }
    
    public static void Move(Command command)
    {
        if (currentLocation.CanMoveInDirection(command.Noun))
        {
            currentLocation = currentLocation.GetLocationInDirection(command.Noun);
            IO.WriteLine(currentLocation.GetDescription());
        }
        else
        {
            IO.WriteLine("Can't go that way.");
        }
    }
    
    public static void AddToInventory(ItemType itemType)
    {
        Item? item = Items.FindItem(itemType);
        if (item == null)
            return;
        Inventory.Add(item);
    }

    public static void RemoveFromInventory(ItemType itemType)
    {
        Item? item = Items.FindItem(itemType);
        if (item == null)
            return;
        Inventory.Remove(item);
    }

    public static void Take(Command command)
    {
        IO.WriteLine("taking " + command.Noun);
        
        Item item = currentLocation.FindItem(command.Noun);
        
        //make beer and infinite beers. can take beer anywhere
        if (item == null)
        {
            IO.WriteLine("There is no " + command.Noun + " here.");
        }
        else if (!item.IsTakeable)
        {
            IO.WriteLine("The " + command.Noun + " cannot be taken.");
        }
        else
        {

            //add to our inventory
            Inventory.Add(item);
            //item.Pickup();
            currentLocation.RemoveItem(item);
            IO.WriteLine("You take the " + command.Noun + ".");
            
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
            IO.WriteLine($"You drop the {item.Name}.");
            //have to preface the quotation with the dollar sign. 
            //without the dollar sign, doesn't know that the {item.Name} isn't a string. It tells the system to pop out the curly bracket
        }
    }
    
    public static void ShowInventory()
    { 
        if (Inventory.Count == 0)
        { 
            IO.WriteLine("Your pocket are empty.");
        }
        else
        {
            IO.WriteLine("You are carrying:");
            foreach (Item item in Inventory)
            {
                string article = SemanticTools.CreateArticle(item.Name);
                IO.WriteLine("  " + article + " " + item.Name);
            }
        }
    }
    public static void Use(Command command)
    {
        if (command.Noun == "beer")
        {
            Conditions.ChangeCondition(ConditionType.IsDrunk, true);
        }
    }
    public static void MoveToLocation(string locationName)
    {
        Location? newLocation = Map.GetLocationByName(locationName);
        
        if (newLocation == null)
        {
            IO.WriteLine("There is no location named " + locationName + ".");
            return;
        }
        currentLocation = newLocation;
        IO.WriteLine(currentLocation.GetDescription());
    }
}