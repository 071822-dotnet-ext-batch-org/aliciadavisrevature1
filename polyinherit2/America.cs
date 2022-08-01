using System;
using System.Collections;

namespace polyinherit2
{
class America : Location  // Intermediate class (parent and child). Use the ":" in order to inherit from the class "Location"
{
   public virtual void Continent() 
  {
    Console.WriteLine("I'm in North America.");
  }

  public virtual void State()
  {
    Console.WriteLine("What state are you in?");
  }
}
}//EoN