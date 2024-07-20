


namespace Albert;

/// <summary>
/// A speical Module for writing Console Applications   
/// </summary>
public static class ConsoleWriter
{

    public static string ConsoleLine => "----------------------------";

    /// <summary>
    /// Clear console and Create a Title
    /// </summary>
    /// <param name="_title">Title</param>
    public static void WriteTitle(string _title)
    {
        //Create a Title
        Clear();
        WriteLine(_title);
        WriteLine(ConsoleLine);



    }

    public static void WriteSeperator()
    {
       WriteLine(ConsoleLine);
    }

    /// <summary>
    /// Method to exit or return to part  of aconsole application 
    /// </summary>
    /// <param name="_program">Method you want ot go to</param>
    public static void WriteExit(Action _program)
    {
        Write("Do you want to exit?(yes/no): ");
        var ans = ReadLine();
        switch (ans)
        {
            case "y" or "yes" or "Yes" or "Y" or "YES" :
                WriteLine("Goodbye!");
                break;
            case "n":
                _program.Invoke();
                break;
        }

    }

    public static void WriteDocument(string _title, string _text)
    {

        WriteLine(_title);    
        WriteLine(ConsoleLine);
        WriteLine(_text);
        WriteLine(ConsoleLine);
    }
    /// <summary>
    /// WriteExit Method for going to another part of the Pragram
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_program"></param>
    public static void WriteExit(Action _start,Action _program)
    {
        Write("Do you want to exit?(yes/no):  ");
        var choice = ReadLine();

        switch(choice)
        {
            case "y" or "Yes" or "yes" or "Y" or "YES":
                _start.Invoke();
                break;
            default:
                _program.Invoke();
                break;
        }
    }
     
       
   


}
