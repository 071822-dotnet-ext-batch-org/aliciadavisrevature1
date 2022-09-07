using Internal;
using System.Reflection;

namespace ReflectionDemoProj;
class Program
{
    public static string MyMood { get; set;} = "cheery";//Properties count as a member
    public static int MyPopsicleSticks { get; set; } = 4;
    public static int a = 5, b = 10, c = 20;//Does not count as a member

    static void Main(string[] args)
    {
        #region Access the properties and fields in a class... even the class you are currently in!
        //First we are going to use reflection to get the data from some local vars.
        Type programType = typeof(Program);

        //The Type of object representing Program give you more internal metadata than a Program object created programmatically
        //Program p = new Program();

        //Basic integers do not count as members for purposes of Reflection as shown here
        //MemberInfo[] membInfoArr = programType.GetMember("a");
        //foreach (MemberInfo mi in membInfoArr)
        //{
        //    Console.WriteLine($"{mi.DeclaringType} declared {mi.Name} with a type of {mi.GetType}....")
        //}

        //Because a is a field, not a property, we must get it with '.GetField()'
        FieldInfo? fi = programType.GetField(a, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
        if (fi != null)
        {
        Console.WriteLine($"{fi?.Name} is a/an {fi?.GetType()} and it's value is {fi?.GetValue(null)}");
        fi?.SetValue(10);
        Console.WriteLine($"{fi?.Name} is a/an {fi?.GetType()} and it's new value is {fi?.GetValue(null)}");
        }
        else Console.WriteLine($"fi was null");

        //Here we get members but not all metadata is available... so we get more specific with below....
        MemberInfo[] gms = programType.GetMembers();
        foreach (var i in gms)
        {
            Console.WriteLine($"{i.Name} is a {i.GetType()} and it's value is unavailable?");
        }

        //Get the property info (bc properties have backing info, etc...)
        PropertyInfo[] gps = programType.GetProperties();
        foreach (var i in gps)
        {
            //Yes, you still have to send in the containing class Type obj when getting the property value.
            Console.WriteLine($"{i.Name} is a {i.GetType()} and it's value is {i.GetValue(programType)}");
        }

        var x = programType.GetProperty("MyMood");
        Console.WriteLine($"The value of {x.Name} is {x.GetValue(programType)}");
        #endregion


        #region 
        Assembly assemblyType = typeof(Program).Assembly;
        Console.WriteLine($"{assemblyType.Location}");
        Console.WriteLine($"{assemblyType.EntryPoint}");
        Console.WriteLine($"{assemblyType.FullName}");
        Console.WriteLine($"{assemblyType.ToString}");
        Console.WriteLine($"{assemblyType.GetHashCode()}");
        Console.WriteLine($"{assemblyType.GetName()}");
        Console.WriteLine($"{assemblyType.SecurityRuleSet}");
        //Console.WriteLine($"{assemblyType.LoadModule().ToString}");
        Console.WriteLine($"{assemblyType.IsFullyTrusted}");

        Type[] assemblyMembers = assemblyType.GetTypes();//Get all the Types of the Assembly

        foreach (var i in assemblyMembers)//Iterate over the types
        {
            //Print the data about each type
            Console.WriteLine($"{i.Name} is a '{i.GetType()}', \n\tIt's namespace is '{i.Namespace}'. \n\tIt's a '{i.MemberType}' type of member. \n");
            //If the types have members
            if (i.GetMembers() != null)
            {
                //Get all the types of members
                MemberInfo[] members = i.GetMembers();
                //Iterate over the member and if it has the method we're looking for and that method is parameterless, Invoke it.
                foreach (MethodInfo ii in members)
                {
                    if (ii.Name == "GetMyAge" && ii.GetParameters().Length == 0)
                    {
                        int age = (int)ii.Invoke(i, null);
                        Console.WriteLine($"The return from GetMyAge() is {age}");
                    }
                }
            }
        }
        #endregion
    }
}