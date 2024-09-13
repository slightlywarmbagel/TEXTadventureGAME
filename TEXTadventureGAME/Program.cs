//ALL COMMENTS ARE NOT TOWARDS WHAT THE CODE DOES BUT WHAT THE CODE IS. Its literally just notes from the lecture

/*class is a container that holds stuff. Remember the bag metaphor, its that.*/
/* making a class. ALL classes MUST have the same name as the file*/
/*name spaces let us have classes that are the same name but still classify them as different*/
/* must have a class named Program and must have a method named Main*/
namespace TEXTadventureGAME;

public class Program
{
    /*a class is a container, think the bag. It holds things that allows you to avoid THOUSANDS of lines of code*/
    /*this is a method below. CAPITAL IT. this gives information or has you do something*/
    public static void Main(string[] args)
    {
        /*this is how you print something*/
        /*Console.WriteLine("Howdy howdy!");*/
        
        /*this plays the game*/
        Game.Play();
        
    }
}
/*this just tells the game to go. Its okay if it doesn't do much*/