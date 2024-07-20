namespace ABMedia83CMD
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            WriteTitle("ABMedia83 CMD");
            WriteLine("Programs");
            WriteSeperator();
            WriteLine("About = about");
            WriteSeperator();
            WriteLine();
           
            Write("Select your Program: ");
            var program = ReadLine();

            switch(program)
            {
                case "about":
                    About();

                    break;
                default:
                    WriteExit(Start);
                    break;
            }

            ReadLine();
            
        }

        static void About()
        {
            WriteTitle("About ABMedia83 CMD");
            WriteLine("ABMedia83 CMD was written to help me quickly do task that I need to do on my desktop.");
            WriteSeperator();
            WriteLine("Created by\nAlbert M. Byrd");
            WriteExit(Start, About);
        }




    }
}
