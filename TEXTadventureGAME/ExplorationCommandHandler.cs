namespace TEXTadventureGAME;

public static class ExplorationCommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            {"go", Move}
            ,{"take", Take}
            ,{"tron", Tron}
            ,{"troff", Troff}
            ,{"look", Look}
            ,{"drop", Drop}
            ,{"pull", Pull}
            ,{"inventory", Inventory}
            ,{"talk", EnterConversationState}
            ,{"inspect", Inspect}
        };

    private static void Inspect(Command command)
    {
        Player.Inspect(command);
    }

    private static void Pull(Command command)
    {
        if (command.Noun == "buttplug")
        {
            Items.CreateItem(ItemType.buttplug, "I am buttplug", "It's plug of butts");
            Player.AddToInventory(ItemType.buttplug);
            Conditions.ChangeCondition(ConditionType.MagicButtplug, true);
        }
        if (command.Noun == "beer")
        {
            Items.CreateItem(ItemType.beer, "Beer's beer", "It's rancid, but you could convince yourself to drink it... \n Should you, though? ");
            Player.AddToInventory(ItemType.beer);
            Conditions.ChangeCondition(ConditionType.MysticalBeer, true);
        }
    }


    private static void EnterConversationState(Command command)
    {
        Debugger.Write("Trying to enter conversation state.");
        States.ChangeState(StateType.Conversation);
    }
    
    public static void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> action = commandMap[command.Verb];
            action.Invoke(command);
        }
        else
        {
            IO.WriteLine("I can't do that, Dave. /n Unknown command.");
        }
    }
    
    private static void Inventory(Command command)
    {
        Player.ShowInventory();
    }

    private static void Drop(Command command)
    {
        Player.Drop(command);
    }
    
    private static void Look(Command command)
    {
        IO.WriteLine(Player.GetLocationDescription());
    }

    private static void Move(Command command)
    {
        Player.Move(command);
    }
    
    private static void Take(Command command)
    {
        Player.Take(command);
    }
    
    private static void Tron(Command command)
    {
        Debugger.Tron();
    }
    
    private static void Troff(Command command)
    {
        Debugger.Troff();
    }
}