namespace TEXTadventureGAME;

public static class Map
{
    public static Location StartLocation;
    
    public static void Initialize()
    {
        Location crewQuarters = new Location("A1 'Crew Quarters'", 
            "A large circular room. Theres a glass pillar in the middle of the geometric room that shows outerspace. A hallway leads North and three doors sit East, South, and West.");
        Location mainHall = new Location("Main Hall",
            "Through the hallway you enter into the storage room and main hall of the ship. The walls are padded and hundreds of equipped storage bins line the walls. It's a bit of a mess. A door sits North.");
        Location pilotHub = new Location("Hub",
            "A large panel sits across the rounded glass room. This is where the Pilot commands. The door you came from rests to your south.");
        Location hole = new Location("Hole",
            "Maybe you shouldn't have come down here.  There's no way out.");
        Location crewRoomA = new Location("A2 'Crew Room A'",
            "A small room fit with a bed, dresser, and nightstand. A large window looks into space. It's dimly lit, and smells musty.");
        Location crewRoomYou = new Location("A3 'Your Room",
            "It's your bedroom. It has the same bed, dresser, and nightstand, but the sheets are rumpled. You should have cleaned up before you left.");
        Location crewRoomB = new Location("A3 'Crew Room B",
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

        Item key = new Item("Key", "It's a... a key? Sike! It's cake that looks eerily like a key. It's probably good at opening doors...", "There's a suspicious looking 1800's key lying on the table against the wall.");
        Item keyCard = new Item("Key Card: Lieutenant Husk", "It's your key card. It's made of a hard, unbendable plastic. It's worn around the edges.", "In your pocket, your keycard sticks out just slightly");
            //adjust the name
        Item beer = new Item("Beer", "Beer's beer.", "There is a beer just sitting on the ground...menacingly... temptingly...Your mouth waters.");
        crewQuarters.AddItem(key);
        crewQuarters.AddItem(keyCard);
        crewQuarters.AddItem(beer);
    }//im missing something... its not showing the location description. 
}