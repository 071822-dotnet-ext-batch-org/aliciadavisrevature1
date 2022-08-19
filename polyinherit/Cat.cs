using System;

namespace polyinherit
{
class Cat : Animal  // Derived class (child). Use the ":" in order to inherit from the class "Animal". Has single responsibility to define Cat. Run Time
{
  public override void animalSound() //The method is overriding a declared virtual method that was inherited from the base class. Is requried to modify the virtual implementation of the inherited method.
  {
    Console.WriteLine("The cat says: meow");
  }

   public override void animalLimbs() //"Derived_Class.animalLimbs() hides the inherited memeber Animal.animalLimbs(). To make the current member override that implementation, add the override keyword. Otherwise add a new keyword.
  {
    Console.WriteLine("The cat has 4 legs");
  }
}//EoC
}//EoN