using System;

namespace Lambdas.Delegates
{
  public class ProcessData
  {
    public void Process (int x, int y, BizRulesDelegate delegateRule)
    {
      var result = delegateRule (x, y);
      System.Console.WriteLine (result);
    }

    public void ProcessAction (int x, int y, Action<int, int> action)
    {
      action (x, y);
      Console.WriteLine ("Action has been processed");
    }

    public void ProcessFunc (int x, int y, Func<int, int, int> func)
    {
      var result = func (x, y);
      Console.WriteLine (result);
    }

  }
}
