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
            
            // how to make it so you can't go somewhere unless a condition is true
            if (currentLocation.Name == "Bedroom" && command.Noun == "east" && Conditions.IsFalse(ConditionType.HasKey))
            {
                IO.WriteLine("You need the key to move the bedroom.");
                return;
            }
            //manually code both times. you cannot drop it. 
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

   /* if (item != null)
    {
        inventory 
    }
    if (Item.Name == "key")
    {
         Conditions.IsFalse(ConditionType.HasKey);
    }
    */
    
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
    
    
    
    
// Player enters room and program tells player what's in the room ie; item's initial description
// player takes item and item is now in inventory
// player types "inspect {item/noun}"
// gives back inspected description of item
// why? player shouldn't know that the book on the shelf is a shakespeare story just by a first glance. 
//      i want the player to be able to pick up the keycard and then inspect it to find out that it's the card to the kitchen etc

    public static void Inspect(string itemType)
    {
        if (Command.Noun == Item)
        {
            IO.WriteLine();
        }
    }
     
    
    
    public static void Inspect(Command command)
    
    {
    if (Command.Noun("Inspect", StringComparison.OrdinalIgnoreCase))
    {
        if (Item(Input, out string description))
        {
            Console.WriteLine($"Description of {userInput}: {description}");
        }
        else
        {
            Console.WriteLine("Item not found. Please try again.");
        }
    }
    else
    {
        Console.WriteLine("Invalid command. Please use 'Inspect'.");
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