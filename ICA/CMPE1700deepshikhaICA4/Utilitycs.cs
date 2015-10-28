using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE1700deepshikhaICA4
{
    class Utilitycs
    { //General print error message
        public static void PrintError(string Err = "Unknown Failure", string Dbg = "",
                                    bool printUsage = true, bool exit = false, int exitVal = 1)
        {

            //1 Print out error message
            ConsoleColor currBackColor = Console.BackgroundColor;
            ConsoleColor currForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: " + Err);
            if (Dbg.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Error.WriteLine(Dbg);
            }
            if (printUsage)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                PrintUsage();
            }
            Console.ForegroundColor = currForeColor;
            Console.BackgroundColor = currBackColor;

            if (exit)
                Environment.Exit(exitVal); // By convention, exit with a value != 0 for error
        }

        //General usage message
        public static void PrintUsage()
        {
            Console.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName + " <n> <-e | -d> [ <str> | -f <filename>] \n" +
                   @"Performs rot-n encryption and decryption.
<n> specifies amount to rotate or de-rotate by.
-e specifies to encrypt (rotate by n)
-d specifies to decrypt (rotate by -n)
<str> is the string to rotate by, unless -f is instead specified
-f <filename> means perform the operation on the text file specified instead of a string.");
        }
    }
}