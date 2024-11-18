using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace TEXTadventureGAME;

public static class Items
{
    private static float Speed;
    
    private static Dictionary<ItemType, Item> nameToItem = new Dictionary<ItemType, Item>();
    
    //this finds the items and puts them into inventory, its like a big table 

    public static void initialize()
    {
        Item? key = new Item(ItemType.key, 
            "It's a... a key? Sike! It's cake that looks eerily like a key. It's probably good at opening doors...",
            "There's a suspicious looking 1800's key lying on the table against the wall.");
        
        Map.AddItem(key, "Storage Room");

        Item? beer = CreateItem(ItemType.beer, "Beer's beer",
            "There is a beer just sitting on the ground...menacingly... temptingly...Your mouth waters.");
        Map.AddItem(beer, "Crew Quarters");
        
        
        Item keyCard = new Item(ItemType.keycard, "It's your key card. It's made of a hard, unbendable plastic. It's worn around the edges.", "In your pocket, your keycard sticks out just slightly");
        //adjust the name
        Item gator = new Item(ItemType.alligator, "Alligator's beer.", "There is a smiling alligator."); 
        
        Map.AddItem(keyCard, "Crew Quarters");
        Map.AddItem(key, "Crew Quarters");
        Map.AddItem(gator, "Crew Quarters");
        Map.AddItem(beer, "Crew Quarters");
        
    }
    
    public static Item? CreateItem(ItemType itemType, string description, string initialLocationDescription, bool isTakeable = true)
    {
        if (nameToItem.ContainsKey(itemType))
        {
            IO.Error($"Item {itemType.ToString()} already exists");
            return null;
        }

       // if (nameToItem.ContainsKey("beer"))
        {
            //add beer to inventory
        }
        Item item = new Item(itemType, description, initialLocationDescription, isTakeable);
        nameToItem.Add(itemType, item);
        Vocabulary.AddNoun(itemType.ToString());
        return item;
    }
    

    public static Item? FindItem(ItemType itemType)
    {
        if (nameToItem.ContainsKey(itemType))
            return nameToItem[itemType];
        return null;
    }
}