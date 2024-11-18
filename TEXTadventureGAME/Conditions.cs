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