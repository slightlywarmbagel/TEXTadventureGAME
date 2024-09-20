namespace TEXTadventureGAME;

public static class CommandProcessor
{
    public static Command GetCommand()
    {
        
        string input = IO.Read();
        Command command = Parser.Parse(input);
        
        Debugger.Write("After parsing: Verb = [" + command.Verb + "], Noun = [" + command.Noun + "]");
        
        command = CommandValidator.Validate(command);
        
        
        
        return command;
    }
}