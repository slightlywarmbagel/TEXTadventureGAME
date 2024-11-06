namespace TEXTadventureGAME;

public static class CommandHandler
{
    public static void Handle(Command command)
    {
        switch (States.GetCurrentState())
        {
            case StateType.Exploring:
                // use the handler for when exploring
                ExplorationCommandHandler.Handle(command);
                break;
            case StateType.Conversation:
                //use the handler for when in conversation
                ConversationCommandHandler.Handle(command);
                break;
        }
    }
}