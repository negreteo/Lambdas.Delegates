using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambdas.Delegates
{
  public delegate int BizRulesDelegate (int x, int y);

  class Program
  {
    static void Main (string[] args)
    {
      // Lambda
      BizRulesDelegate addDelegate = (x, y) => x + y;
      BizRulesDelegate multiplyDelegate = (x, y) => x * y;

      var data = new ProcessData ();
      data.Process (2, 3, addDelegate);
      data.Process (2, 3, multiplyDelegate);

      // Action<T>
      Action<int, int> addAction = (x, y) => System.Console.WriteLine (x + y);
      Action<int, int> multiplyAction = (x, y) => System.Console.WriteLine (x * y);

      data.ProcessAction (3, 4, addAction);
      data.ProcessAction (3, 4, multiplyAction);

      // Func<T, TResult>
      Func<int, int, int> funcAddDelegate = (x, y) => x + y;
      Func<int, int, int> funcMultiplyDelegate = (x, y) => x * y;

      data.ProcessFunc (4, 5, funcAddDelegate);
      data.ProcessFunc (4, 5, funcMultiplyDelegate);

      // Lambdas to query objects

      var customers = new List<Customer>
      {
        new Customer { City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1 },
        new Customer { City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID = 500 },
        new Customer { City = "Seattle", FirstName = "Suki", LastName = "Pizorro", ID = 3 },
        new Customer { City = "New York City", FirstName = "Michelle", LastName = "Smith", ID = 4 },
      };

      var phoenixCustomers = customers
        .Where (c => c.City == "Phoenix" && c.ID < 500)
        .OrderBy (c => c.FirstName);

      foreach (var customer in phoenixCustomers)
      {
        System.Console.WriteLine ($"{customer.FirstName} lives in {customer.City}");
      }

    } // Main

  } // Program

  public enum WorkType
  {
    GoToMeetings,
    Golf,
    GenerateReports
  }

}
