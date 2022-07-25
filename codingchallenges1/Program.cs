using System;

namespace codingchallenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a string.");
            string userInput1 = Console.ReadLine();
            string stringToUpperResult = StringToUpper(userInput1);
            Console.WriteLine(stringToUpperResult);

            Console.WriteLine("Please, enter a string.");
            string userInput2 = Console.ReadLine();
            string stringToLowerResult = StringToUpper(userInput2);
            Console.WriteLine(stringToLowerResult);
        }
       // <summary>
        //This method has one string parameter and will
        //1) change the stringto all upper case and
        //2) return the new string
        //</summary>
        //<param name="userString"></ParamArrayAttribute>
        //<returns></returns>
        public static string StringToUpper(string userString)
        {
            return userString.ToUpper();
        }

        //This method has one string parameter and will
        //1)change the string to all lower case and
        //2) return the new string
        //</summary>
        //<param name="userString"></ParamArrayAttribute>
        //<returns></returns>
        public static string StringToLower(string userString)
        {
            return userString.ToLower();
        }
    }
}
