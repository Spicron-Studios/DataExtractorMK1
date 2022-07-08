using BLL;
using System;
using System.Collections.Generic;

namespace FireHawkXMLDataExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = "";
            bool bFlag = true;
            while (bFlag)
            {
                
                Console.WriteLine("Please Enter the File Location.");
                fileLocation = Console.ReadLine();
                if (fileLocation == "")
                {
                    Console.Clear();
                    bFlag = true;
                }
                else
                {
                    clAlgorithm algorithm = new clAlgorithm(fileLocation);
                    Console.WriteLine("Proceding to Exctract Text from file...");
                    Console.WriteLine(algorithm.FirstTest());
                    Console.WriteLine("Checking List");
                    List<string> companlist = algorithm.GeilteredList();

                    foreach (string item in companlist)
                    {
                        Console.WriteLine(item);
                    }
                    bFlag = false;
                }


            }

            
        }
    }
}
