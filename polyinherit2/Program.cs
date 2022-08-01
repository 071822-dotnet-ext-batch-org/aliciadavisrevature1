using System;
using System.Collections;

namespace polyinherit2
{
class Program
{
    static void Main(string[] args) 
  {
    //Location myLocation = new Location();  // Create a Location object
    Location myAmerica = new America();  // Create an America object
    //Location myIan = new Ian();  // Create a Ian object
    //Location myLarry = new Larry();  // Create a Larry object
    //Location myJosh = new Josh();  // Create a Josh object
    Location myAlicia = new Alicia();  // Create an Alicia object

    //myLocation.Planet();
    myAmerica.Planet();
    //myAlicia.Planet();
    //myLarry.Planet();
    //myJosh.Planet();
    //myIan.Planet();

    //Where are the members of Group 3?
    //myJosh
    //myIan
    myAlicia.State();
    //myLarry

    
    
  }
}
}//EoN
