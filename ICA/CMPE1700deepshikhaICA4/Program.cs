using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMPE1700deepshikhaICA4
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                bool decrypt = false;  //Am I encrypting or decrypting?
                uint n = 0; //What is the amount I am (de)rotating?
                bool fileIO = false; //Am I encrypting/decrypting a file?
                string text = ""; //What is the string I am [en|de]crypting?
                string fileName = ""; //What is the file I am [en|de]crypting?

                //Check args

                //Confirm I have between 3 and 4 args
                if (args.Count() < 3 || args.Count() > 4)
                    Utilitycs.PrintError("Invalid number of arguments (" + args.Count() + ")", "Expected either 3 or 4 arguments.", true, true, -1);

                //First arg should be n
                try
                {
                    n = uint.Parse(args[0]);
                }
                catch (Exception e)
                {
                    Utilitycs.PrintError("Invalid rotation number (" + args[0] + ").", e.Message, true, true, -2);
                }

                //Next arg should be either -e or -d
                switch (args[1])
                {
                    case "-e": decrypt = false; break;
                    case "-d": decrypt = true; break;
                    default:
                        Utilitycs.PrintError("Unexpected encryption/decryption flag (" + args[1] + ").", "Expected -e or -d.", false, true, -3);
                        break;
                }

                //Next arg should be either -f or the string to (de)rotate.
                if (args[2] == "-f")
                {
                    if (args.Count() < 4)
                        Utilitycs.PrintError("Expected filename after -f argument.", "", false, true, -4);
                    fileIO = true;
                    fileName = args[3];
                }
                else
                {
                    if (args.Count() > 3)
                        Utilitycs.PrintError("Unexpected arguments after string, starting with \"" + args[3] + "\". Perhaps you need to put the string in quotes?"
                            , "", false, true, -5);
                    fileIO = false;
                    text = args[2];
                }


                //REPLACE THIS SECTION WITH YOUR OWN CODE.  YOU'LL WANT A FEW ADDITIONAL METHODS, TOO.


                //if (!fileIO)
                //    Console.WriteLine("Here is where I would " + (decrypt ? "decrypt" : "encrypt") +
                //    " the string \"" + text + "\" using rot " + n + ".");
                //else
                //    Console.WriteLine("Here is where I would " + (decrypt ? "decrypt" : "encrypt") +
                //    " the file \"" + fileName + "\" using rot " + n + ".");
                   StreamWriter outputfile;

                    StreamReader inputfile;
                string newtextfile = null;

                string scratext = null;
               
          
                switch (fileIO)
                {
                    case false:
                        scratext = Rot(text, n, decrypt);
                        Console.WriteLine(scratext);
                        break;
                    case true:
                        try
                        {
                            inputfile = new StreamReader(fileName);
                              newtextfile = inputfile.ReadToEnd();
                            inputfile.Close();
                        }
                        catch
                        {
                            Utilitycs.PrintError("Error loading file", "", true, true, -100);
                        }
                        break;
                }

                               scratext = Rot(newtextfile, n, decrypt);

                       
                        try
                        {
                            outputfile = new StreamWriter(fileName);
                            foreach (char character in scratext)
                                outputfile.Write(character);

                            outputfile.Close();
                        }
                        catch
                        {
                            Utilitycs.PrintError("Error saving over file", "", true, true, -101);
                        }
                        Console.WriteLine("Success!");
                }
            }

        private static string Rot(string phrase, uint rot1, bool decrypt)
        {
            
            uint rot = rot1;
                rot %= 26;
              rot1 %= 10;
            char[] array = phrase.ToCharArray();
            

          
            for (int i = 0; i < array.Length; i++)
            {
                  long valuecharacter= array[i]; 


                   if(valuecharacter >= 'a' && valuecharacter <= 'z')

                {
                   
                      valuecharacter +=decrypt ? -rot : rot;


                    if (valuecharacter > 'z')
                    {
                        valuecharacter = (char)(valuecharacter - 26);
                     
                    }
                    else if (valuecharacter < 'a')
                    {
                        valuecharacter = (char)(valuecharacter + 26);
                       
                    }
                }

                if (valuecharacter >= 'A' && valuecharacter <= 'Z')
                {
                    
                    valuecharacter += decrypt ? -rot : rot;


                    if (valuecharacter > 'Z')
                    {
                        valuecharacter = (char)(valuecharacter - 26);
                        
                    }
                    else if (valuecharacter < 'A')
                    {
                        valuecharacter = (char)(valuecharacter - 26);
                      
                    }
                }

              
                 if (valuecharacter >= '0' && valuecharacter <= '9')
                {
                   
                    valuecharacter += decrypt ? -rot1 : rot1;
                    if (valuecharacter > '9')
                    {
                        valuecharacter = (char)(valuecharacter - 10);

                       
                    }
                  if (valuecharacter < '0')
                    {
                        valuecharacter = (char)(valuecharacter + 10);
                       
                    }
                }
              
                array[i] = (char)valuecharacter;
            }
         
            return new string(array);
        }

    }
    }
   
       
       




        


        