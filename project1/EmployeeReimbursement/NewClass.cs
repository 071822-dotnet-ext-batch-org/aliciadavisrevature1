using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewClass
{
public class ExceptionExample {
  public void mayThrowException() {
    try {
      riskyCode(); // A
      Console.Write("After A, ");
    } catch(Exception e) {
      Console.Write("Uh oh - something went wrong! ");
    } finally {
      Console.Write("Finally block, ");
    }
    Console.Write("continuing...");
  }
}
}