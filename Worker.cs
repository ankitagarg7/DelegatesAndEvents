using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //public delegate void WorkPerformedDelegate(int hours, WorkType workType);

    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> workPerformedEvent;
        public event EventHandler WorkCompletedEvent;

        public virtual void DoWork(int hours, WorkType workType)
        {
            //Do work here and notify the customer that the work has been performed
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            // workPerformedEvent?.Invoke(hours, workType);   // raising event via event
            var del = workPerformedEvent as EventHandler<WorkPerformedEventArgs>;  // casting the event as a delegate as the data type of event is delegate
            del?.Invoke(this, new WorkPerformedEventArgs(hours, workType)); // raising event via delegate
        }

        protected virtual void OnWorkCompleted()
        {
            EventHandler del = WorkCompletedEvent as EventHandler;
            del?.Invoke(this, EventArgs.Empty);
        }
    }
}
