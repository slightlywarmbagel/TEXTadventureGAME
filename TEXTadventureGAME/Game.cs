using System.Data;
using System.Text;

namespace TEXTadventureGAME;

public static class Game
{
    
    
    /*method called play*/
    /*two types of class - one is for organizing STATIC
     the other is for organizing and templates of a bunch of things - like bullet hell. you dont code every bullet. you stamp.*/
    /*method should just do one thing and one thing only--metahorical in a sense*/
   
    
    
    private static bool isPlaying = true;

    public static void Play()
    {
        ShowIntroText();
        Initialize();
        
        while (isPlaying)
        {
            
            Command command = CommandProcessor.GetCommand();
            if (command.IsValid)
            {
                Debugger.Write(command.ToString());
                CommandHandler.Handle(command);
            }
        }
    }

    private static void Initialize()
    {
        Map.Initialize();
        Items.Initialize();
        Player.Initialize();
        States.Initialize();
        Conditions.Initialize();
        
    }

    private static void ShowIntroText()
    {
        IO.WriteLine("This is some intro text.");
        IO.WriteLine("Here is another line that has a lot of text and is really reallyre allrndfjndsfkndskfs long.");
    }
}

