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
            
            CommandProcessor.GetCommand();
            /*
            string[] words = input.Split(' ');
            /*this is splitting text strings by the space that separates the words*/
            /*words is an array
            if (words.Length > 2)
                Console.WriteLine("Too many words");
            
            foreach (string word in words)
                /*an easier for loop
            {
                Console.WriteLine(word);
            }
            
            
            if (input == "exit")
            {
                isPlaying = false;
            } 
            */
        }
    }
}

