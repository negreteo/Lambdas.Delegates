using System;

namespace Lambdas.Delegates
{
  public class Worker
  {
    public event EventHandler<WorkPerformedEventArgs> EventWorkPerformed; // Eliminates delegate declaration
    public event EventHandler EventWorkCompleted;

    public void DoWork (int hours, WorkType workType)
    {
      for (int i = 0; i < hours; i++)
      {
        System.Threading.Thread.Sleep (1000);
        RaiseEvent_OnWorkPerformed (i, workType);
      }

      RaiseEvent_OnWorkCompleted ();
    }

    // Raise events methods are prefixed with "On" or "Raised"
    protected virtual void RaiseEvent_OnWorkPerformed (int hours, WorkType workType)
    {
      if (EventWorkPerformed != null) EventWorkPerformed (this, new WorkPerformedEventArgs (hours, workType));
    }

    // Raise events methods are prefixed with "On" or "Raised"
    // EventHandler does not take arguments
    protected virtual void RaiseEvent_OnWorkCompleted ()
    {
      if (EventWorkCompleted != null) EventWorkCompleted (this, EventArgs.Empty);
    }

  }
}
