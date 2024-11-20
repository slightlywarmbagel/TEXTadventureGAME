using System.ComponentModel.Design.Serialization;
using System.Data.SqlTypes;

namespace TEXTadventureGAME;

public static class Conditions
{
    //need list of EVERY condition in the class to work
    private static Dictionary<ConditionType, Condition> conditions =
        new Dictionary<ConditionType, Condition>();


    public static void Initialize()
    {
        Condition isDrunked = new Condition(ConditionType.IsDrunk);
        isDrunked.AddToActivateCallList(ConditionActions.WriteOutput("Hic!"));
        isDrunked.AddToActivateCallList(
            //FIX THE NAMES OF THESE LOCATIONS BECAUSE THEY ARE INCORRECT!!!
            ConditionActions.AddMapConnection(
                "Entrance Hall", "west", 
                "Treasure Room"));
        isDrunked.AddToActivateCallList(
            ConditionActions.RemoveMapConnection(
                "Entrance Hall", "north"));
        isDrunked.AddToActivateCallList(ConditionActions.MovePlayerToLocation(
            "Hole"));
        AddCondition(isDrunked);

        Condition magicButtplug = new Condition(ConditionType.MagicButtplug);
        magicButtplug.AddToActivateCallList(ConditionActions.WriteOutput("A buttplug appears out of thin air!"));
        AddCondition(magicButtplug);
        
        Condition mysticalBeer = new Condition(ConditionType.MysticalBeer);
        mysticalBeer.AddToActivateCallList(ConditionActions.WriteOutput("A mystical beer appears out of thing air!"));
        AddCondition(mysticalBeer);
        
        // to make a condition
        // Step 1: Go to th ConditionType.cs file and add a name for this condition type
        // Step 2: Create a condition like below
        //      conditionNameHere is just whatever name you want for the condition
        //      make sure you use the right condition type that we created in step 1
        Condition conditionNameHere = new Condition(ConditionType.IsDrunk);
        // Step 3: add any things you want to happen when the condition gets set to true, like:
        conditionNameHere.AddToActivateCallList(ConditionActions.WriteOutput("You is beer"));
        // the options are: WriteOutput, AddMapConnection, RemoveMapConnection, MovePlayerToLocation, 
        // AddItemToInventory, RemoveItemFromInventory, AddItemToLocation, RemoveItemFromLocation
        // (look in the ConditionActions.cs file to see all these methods)
        // examples:
        // to print a message:
        //      conditionNameHere.AddToActivateCallList(ConditionActions.WriteOutput("I am message!"));
        // to add a new connection to the map:
        //      conditionNameHere.AddToActivateCallList(ConditionActions.AddMapConnection("Galley Room", "east", "Bedroom"));
        // to remove a map connection:
        //      conditionNameHere.AddToActivateCallList(ConditionActions.RemoveMapConnection("Galley Room", "east");
        // to move player to a location:
        //      conditionNameHere.AddToActivateCallList(ConditionActions.MovePlayerToLocation("Galley Room");
        // to add item to the player's inventory: (must pass in the itemtype, not the name aka not "gun")
        //      conditionNameHere.AddToActivateCallList(ConditionActions.AddItemToInventory(ItemType.gun);
        // remove item from inventory: (must pass in the itemtype, not the name aka not "gun")
        //      conditionNameHere.AddToActivateCallList(ConditionActions.RemoveItemFromInventory(ItemType.gun);
        // to add an item to a location:
        //      conditionNameHere.AddToActivateCallList(ConditionActions.AddItemToLocation(ItemType.gun, "Bedroom");
        // remove an item to a location:
        //      conditionNameHere.AddToActivateCallList(ConditionActions.RemoveItemFromLocation(ItemType.gun, "Bedroom");
    }
    
    public static void AddCondition(Condition condition)
    {
        conditions.Add(condition.Type, condition);
    }

    public static bool IsTrue(ConditionType conditionType)
    {
        if (NotInDictionary(conditionType))
            return false;
        return conditions[conditionType].IsActive;
    }

    public static bool IsFalse(ConditionType conditionType)
    {
        if (NotInDictionary(conditionType))
            return true;
        return !conditions[conditionType].IsActive;
    }


    //is a condition active? like do we have the key? 
    //is a condition inactive or false, do you not have the key? 
    //add a new condiiton
    //change condition's value (make it true or false)
    
    
    public static void ChangeCondition(ConditionType conditionType, 
        bool isSettingToTrue)
    {
        if (NotInDictionary(conditionType))
        {
            IO.Error("Condition " + conditionType + " is not valid. Womp womp.");
            return;
        }

        if (isSettingToTrue && IsFalse(conditionType))
        {
            conditions[conditionType].Activate();
        }
        else if (IsTrue(conditionType))
        {
            conditions[conditionType].Deactivate();
        }
        
    }

    private static bool NotInDictionary(ConditionType conditionType)
    {
        return !conditions.ContainsKey(conditionType);
    }
    
    
}