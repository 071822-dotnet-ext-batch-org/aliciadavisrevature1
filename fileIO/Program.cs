using System;
using System.IO;

namespace fileIO
{
    class Program
    {
        static void Main(string[] args)
        {
           //to write to a file use the 'StreamWriter' object
           StreamWriter writer = new StreamWriter("file.txt", true);
           //loop it!
           string aliciasString = "This is a string of chars";

           // for (int i = 0; i < aliciasString.Length; i++)
           //{
           //   writer.Write(aliciasString[i]); 
           //}
           // writer.Close();
           foreach(char c in aliciasString){
                writer.WriteLine($"{interator++} {aliciasString}");
                writer.Close();
                //iterartor++;
           }
           

           /*
           StreamReader reader = new StreamReader("file.txt");
           
           int i = 0;
           while(!reader.EndOfStream)
           {
            string str = reader.ReadLine();
            Console.WriteLine($"{int++} - {str}");
           }
           */

           /*
           StreamReader reader = new StreamReader("file.txt");

           int i = 0;
           string str = "";
           while (!reader.EndOfStream)
           {
                str += reader.ReadLine() + " ";
           }
           Console.WriteLine(str);
           */



        }
    }
}
