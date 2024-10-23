namespace TEXTadventureGAME;

public static class IO
{
    
    public static void Write(string output)
    {
        Console.WriteLine(output);
    }
    
    
    public static string Read()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }

    public static void Error(string output)
    {
        Console.ForegroundColor = ConsoleColor.Red; //makes the text another color heehee
        Write("ERROR: " + output);
        Console.ResetColor();
    }
}