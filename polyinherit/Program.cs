using System;

namespace polyinherit
{
class Program 
{
  static void Main(string[] args) //The static modifier is not instantiated or extended. The members within are all static. This is a container for the static members.
  {
    Animal myAnimal = new Animal();  // Create a Animal object
    Animal myCat = new Cat();  // Create a Cat object
    Animal myDog = new Dog();  // Create a Dog object
    Animal myFish = new Fish();  // Create a Fish object

    myAnimal.animalSound(); // This and 'Animal myAnimal = new Animal();' exemplify part of the LS Principle
    myCat.animalSound(); //LSP: The derived class (Cat) does not affect behavior (animalSound) of base class (Animal), but extends/modifies without changing base (Animal) behavior (animalSound).
    myDog.animalSound();
    myFish.animalSound();

    Console.WriteLine(); //Create a space between commands

    myAnimal.animalLimbs();
    myCat.animalLimbs();
    myDog.animalLimbs();
    myFish.animalLimbs();
  }
}//EoC
}//EoN
