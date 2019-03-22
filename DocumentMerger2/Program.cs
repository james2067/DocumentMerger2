using System;
using System.IO;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileCharacters = "";

            if (args.Length < 3)
            {
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
                Console.WriteLine("The correct format is DocumentMerger2.exe <input_file_1> <input_file_2> ... <input_file_n> <output_file>\n");
            }

            else
            {
                int i = 0;

                for (i = 0; i < args.Length - 1; i++)
                {
                    string fileName1 = args[i];

                    try
                    {
                        StreamReader sr = new StreamReader(fileName1 + ".txt");

                        string line = sr.ReadLine();
                        fileCharacters = fileCharacters + line;

                        while (line != null)
                        {
                            line = sr.ReadLine();
                            fileCharacters += line;
                            fileCharacters = fileCharacters + line;
                        }
                        sr.Close();
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                }

                String mergedFile = args[args.Length - 1];

                try
                {
                    StreamWriter sw = new StreamWriter(mergedFile + ".txt.");
                    sw.Write(fileCharacters);
                    Console.WriteLine("\n" + mergedFile + " was successfully saved");
                    sw.Close();
                }

                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);

                }
            }
            Console.ReadLine();
        }
    }
}