using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkPerformedDelegate del1 = new WorkPerformedDelegate(WorkPerformed1);
            //WorkPerformedDelegate del2 = new WorkPerformedDelegate(WorkPerformed2);

            //del1(5, WorkType.GoToMeetings);
            //del2(10, WorkType.GenerateReports);

            var worker = new Worker();
            worker.workPerformedEvent += Worker_WorkPerformed;
            worker.WorkCompletedEvent += Worker_WorkCompleted;
            worker.DoWork(8, WorkType.GoToMeetings);           
        }

        static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked : " + e.Hours + " on work : " + e.WorkType);
        }

        static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work comleted");
        }

        //static void WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine("Work performed1 called : " +hours.ToString());
        //}

        //static void WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("Work performed2 called : " + hours.ToString());
        //}
    }

    public enum WorkType
    {
        GoToMeetings,
        GenerateReports,
        FillTimesheet
    }
}
