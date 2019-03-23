using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            string docOne, docTwo, mergeDoc, choice;
            bool again = true;
            Console.WriteLine("Document Merger");

            while (again)
            {
                Console.Write("What is the name of the first document?: ");
                docOne = Console.ReadLine();
                while (!File.Exists(docOne))
                {
                    Console.WriteLine("File does not exist in the current directory!");
                    Console.WriteLine("Enter another name: ");
                    docOne = Console.ReadLine();
                }

                Console.Write("What is the name of the second document?: ");
                docTwo = Console.ReadLine();
                while (!File.Exists(docTwo))
                {
                    Console.WriteLine("File does not exist in the current directory!");
                    Console.WriteLine("Enter another name: ");
                    docTwo = Console.ReadLine();
                }

                string[] docOneText = File.ReadAllLines(docOne);
                string[] docTwoText = File.ReadAllLines(docTwo);

                docOne = Path.GetFileNameWithoutExtension(docOne);
                docTwo = Path.GetFileNameWithoutExtension(docTwo);

                mergeDoc = (docOne + docTwo + ".txt");

            }
            string[] args = { docOne, docTwo, mergeDoc };
            if (args.Length > 0)
            {
                try
                {
                    using (StreamWriter writer = File.CreateText(mergeDoc))
                    {
                        int lineNum = 0;
                        while (lineNum < docOneText.Length || lineNum < docTwoText.Length)
                        {
                            if (lineNum < docOneText.Length)
                                writer.WriteLine(docOneText[lineNum]);
                            if (lineNum < docTwoText.Length)
                                writer.WriteLine(docTwoText[lineNum]);
                            lineNum++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine(mergeDoc + " was successfully saved. The document contains " + mergeDoc.Length + " characters.");

                    Console.WriteLine("Would you like to create another file? (y/n): ");
                    choice = Console.ReadLine().ToLower();
                    if (choice == "y")
                    {
                        again = true;
                    }
                    else
                    {
                        again = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Not enough arguments provided.");
            }
        }
    }
}
