using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace TEXTadventureGAME;

public static class Items
{
   
    
    private static Dictionary<ItemType, Item> nameToItem = new Dictionary<ItemType, Item>();
    
    //this finds the items and puts them into inventory, its like a big table 

    public static void Initialize()
    {
        //read the json file text
        string path  = Path.Combine(Environment.CurrentDirectory, "Items.json");
        string rawText = File.ReadAllText(path);
        
        
        //convert the text to ItemsJsonData
        ItemsJsonData? data = JsonSerializer.Deserialize<ItemsJsonData>(rawText);
        //deserialize means that it reads that text (from the file) and makes it into class. raw text. bam. 
        
        //create all the items 
        foreach (ItemJsonData itemData in data.Items)
            //red error in this text, was originally data. Items plural?,
        // tried to fix the other plurals but it just made things worse... sigh. 
        {
            if (!Enum.TryParse(itemData.ItemType,
                    true, out ItemType itemType))
            {
                IO.Error("Invalid item type " + itemData.ItemType +
                         "in Items.json");
                continue;
            }

            Item? item = CreateItem(itemType, itemData.Description, 
                itemData.InitialLocationText, itemData.IsTakeable);
            
            if (item != null)
            {
                Map.AddItem(itemType, itemData.Location);
            }
        }
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