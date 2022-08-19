using System;

namespace polyinherit
{
 public class Animal  // Base class (parent). Has single responsibility to outline Animal. Public so access to members is not limited
{
  public virtual void animalSound() //The virtual keyword modifies the method and will allow it to be overriden by a derived class (or classes)
  {
    Console.WriteLine("What sound does the animal make?");
  }

   public virtual void animalLimbs() 
  {
    Console.WriteLine("How many limbs does the animal have?");
  }
}//EoC
}//EoN