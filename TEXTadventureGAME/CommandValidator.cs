namespace TEXTadventureGAME;

public static class CommandValidator
{
    public static Command Validate(Command command)
    {

        
        if (Vocabulary.IsVerb(command.Verb))
        {
            if (Vocabulary.IsStandaloneVerb(command.Verb))
            {
                if (command.HasNoNoun())
                {
                    command.IsValid = true;
                }
            }
            else if (Vocabulary.IsNoun(command.Noun))
            {
                Debugger.Write("Valid Noun");
                command.IsValid = true;
            }
        }
        
        return command;
    }
}