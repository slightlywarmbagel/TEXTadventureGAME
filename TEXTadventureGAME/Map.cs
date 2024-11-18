namespace TEXTadventureGAME;

public static class Map
{
    
    public static Location StartLocation;
    
    private static Dictionary<string, Location> nameToLocation = 
        new Dictionary<string, Location>();
    
    public static void Initialize()
    {
        Location crewQuarters = AddLocation("A1 'Crew Quarters'", 
            "A large circular room. Theres a glass pillar in the middle of the geometric room that shows outerspace. A hallway leads North and three doors sit East, South, and West.");
        Location mainHall = AddLocation("Main Hall",
            "Through the hallway you enter into the storage room and main hall of the ship. The walls are padded and hundreds of equipped storage bins line the walls. It's a bit of a mess. A door sits North.");
        Location pilotHub = AddLocation("Hub",
            "A large panel sits across the rounded glass room. This is where the Pilot commands. The door you came from rests to your south.");
        Location hole = AddLocation("Hole",
            "Maybe you shouldn't have come down here.  There's no way out.");
        Location crewRoomA = AddLocation("A2 'Crew Room A'",
            "A small room fit with a bed, dresser, and nightstand. A large window looks into space. It's dimly lit, and smells musty.");
        Location crewRoomYou = AddLocation("A3 'Your Room",
            "It's your bedroom. It has the same bed, dresser, and nightstand, but the sheets are rumpled. You should have cleaned up before you left.");
        Location crewRoomB = AddLocation("A3 'Crew Room B",
            "A small room fith with a bed and dresser. The nightstand is missing. The curtains are closed to the window");
        //add more locations in... make a map fool
        crewQuarters.AddConnection("north", mainHall);
        crewQuarters.AddConnection("east", crewRoomA);
        crewQuarters.AddConnection("south", crewRoomYou);
        crewQuarters.AddConnection("west", crewRoomB);
        
        mainHall.AddConnection("south", crewQuarters);
        mainHall.AddConnection("north", pilotHub);
        
        pilotHub.AddConnection("south", mainHall);
        
        crewRoomA.AddConnection("west", crewQuarters);
        crewRoomB.AddConnection("east", crewQuarters);
        crewRoomYou.AddConnection("north", crewQuarters);
        
        
        StartLocation = crewQuarters;
    }//add in the final locations... 
    
    private static Location AddLocation(string name, string description)
    {
        Location location = new Location(name, description);
        nameToLocation.Add(name, location);
        return location;
    }
    
    public static void AddConnection(string startLocation,
        string direction, string endLocation)
    {
        Location? start = FindLocation(startLocation);
        Location? end = FindLocation(endLocation);
        if (start == null || end == null)
        {
            IO.Error("Could not find location: " + 
                     startLocation + " and/or " + endLocation);
            return;
        }
        start.AddConnection(direction, end);
    }
    public static void RemoveConnection(string locationName, string direction)
    {
        Location? location = FindLocation(locationName);
        if (location == null)
            return;
        
        location.RemoveConnection(direction);
    }
    public static Location? FindLocation(string location)
    {   
        if (nameToLocation.ContainsKey(location))
            return nameToLocation[location];
        return null;
    }
    public static bool DoesLocationExist(string locationName)
    {
        if (FindLocation(locationName) != null)
            return true;
        return false;
    }
    public static Location? GetLocationByName(string locationName)
    {
        Location? location = FindLocation(locationName);
        return location;
    }

    public static void AddItem(ItemType itemType, string roomName)
    {
        Item item = Items.FindItem(itemType);
        AddItem(item, roomName);
    }
    
    
    public static void AddItem(Item? item, string roomName)
    {
        if (item == null)
            return;
        
        Location? location = GetLocationByName(roomName);
        if (location == null)
            return;
        
        AddItemToLocation(item, location);

    }

    private static void AddItemToLocation(Item? item, Location location)
    {
        location.AddItem(item);
    }

    public static void RemoveItem(ItemType itemType, string locationName)
    {
        Location? location = GetLocationByName(locationName);
        if (location == null)
            return;
        location.RemoveItem(itemType);
    }
}