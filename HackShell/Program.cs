using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace HackShell
{
    class Program
    {
        static void Main()
        {
            //init all var
            string currentdir = "C:\\";
            string currentcommand;
            string[] PATH = { "C:\\Hackshell\\bin", };
            string ice = "0"; // is command entered
            //manual (yes this is inconvinent i know this is a work in progress)
            string manual = "This is the command reference. \n CD - Change directory or drive. Place dir. or drive letter behind 'CD' to switch drives. Place '..' behind 'CD' to go back a directory. \n dir - print current directory \n list - list all files and folders in current directory \n credits - displays where I've 'been inspired by' X  thing.";


            Console.WriteLine("Welcome to HackShell. Type 'man' for manual.\n HackShell and all affiliated names are copyright of Ruthenic Inc.");
            for (int i = 0; i < 5;)
            {


                //ask for command
                Console.Write(currentdir);
                Console.Write(">");
                currentcommand = (Console.ReadLine());
                string[] openfileexts = new string[] { ".bat", ".exe" };

                if (currentcommand == "dir")
                {
                    Console.WriteLine(currentdir);
                    ice = "1";
                }
                if (currentcommand == "list")
                {
                    string[] filesindir = Directory.GetFiles(currentdir);
                    string[] foldsindir = Directory.GetDirectories(currentdir);
                    Console.WriteLine(currentdir, "contains:");
                    foreach (string name in foldsindir)
                    {
                        Console.WriteLine(name);
                    }
                    foreach (string name in filesindir)
                    {
                        Console.WriteLine(name);
                    }
                    Console.WriteLine();
                    ice = "1";
                }
                if (currentcommand.Contains("cd"))
                {
                    string newpath = currentcommand.Replace("cd ", "");
                    if (!newpath.Contains(":\\"))
                    {
                        newpath = currentdir + "\\" + newpath;
                    }
                    if (newpath.Contains(".."))
                    {
                        int index = currentdir.LastIndexOf("\\");
                        if (index > 0)
                            newpath = currentdir.Substring(0, index + 1);
                    }
                    currentdir = newpath;
                    ice = "1";
                }
                if (currentcommand == "man")
                {
                    Console.WriteLine(manual);
                    ice = "1";
                }
                if (openfileexts.Any(currentcommand.Contains))
                {
                    System.Diagnostics.Process.Start(currentdir + "\\" + currentcommand);
                    ice = "1";
                }
                if (currentcommand == "credits")
                {
                    Console.WriteLine("");
                }
            }

        }
    }
}
