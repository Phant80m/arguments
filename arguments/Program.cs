using System.Net;
using System.Diagnostics;

namespace arguments
{
    class Program
    {
        static void Main(string[] args)
        {
            // error (if) is there is no given arguemnts, 
            // example: ./arguments.exe - (will output an error)
            if (args[0] == "--test")
            {
                Console.WriteLine("If you see this message, program worked!");
            }
            else if (args[0] == "--help")
            {
                // shows a list of available command line arguments
                Console.WriteLine("List of arguments:"
                    + System.Environment.NewLine + " -test | tests to see if program works"
                    + System.Environment.NewLine + " -help | shows a list of available command line arguments"
                    + System.Environment.NewLine + " -version | shows the version of the program");
            }
            else if (args[0] == "--version")
            {
                Console.WriteLine("Version: 1.0.0");
            }
            else if(args[0] == "--install")
            {
                Console.WriteLine("Invalid Syntax:");
            }
            else if (args[0] == "--install-minecraft")
            {
                Minecraft();
                
            }
            else
            {
                // what outputs if command is not valid
                Console.WriteLine("not a valid argument, type '--help' for help");
            }
        }

        // FUNCTION DOWNLOADS MINECRAFT (java) (non .msi)
        static void Minecraft()
        {
            Console.WriteLine("Installing Minecraft...");
            Directory.CreateDirectory(".\\Cache");
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://launcher.mojang.com/download/Minecraft.exe", ".\\Cache\\Minecraft.exe");
            Console.WriteLine("Setup Downloaded!");
            Console.WriteLine("Quite installation starting:");
            Process P = new Process();
            P.StartInfo.FileName = ".\\Cache\\Minecraft.exe";
            P.StartInfo.Arguments = string.Format(" /qb /i \"{0}\" ALLUSERS=1", Minecraft);
            P.Start();
            P.WaitForExit();
            Console.WriteLine("Application installed successfully!");
        }
    }

}