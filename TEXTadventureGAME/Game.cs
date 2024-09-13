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
        while (isPlaying)
        {
            
            Command command = CommandProcessor.GetCommand();
            if (command.IsValid)
            {
                IO.Write(command.ToString());
            }
            else
            {
                {
                    IO.Write("Invalid Command");
                }
            }
        }
    }
}

