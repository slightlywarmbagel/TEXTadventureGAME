namespace TEXTadventureGAME;

public static class Debugger
{
    private static bool isActive = false;

    public static void Write(string message)
    {
        if (isActive)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            IO.WriteLine(message);
            Console.ResetColor();
        }
    }

    public static void Tron()
    {
        isActive = true;
        IO.WriteLine("Debugging enabled fuck-o");
    }
    public static void Troff()
    {
        isActive = false;
        IO.WriteLine("Debugging disabled fuckface");
    }
}