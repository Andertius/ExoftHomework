using System;
using System.Threading;

namespace CallCenterThread
{
    public static class CallCenter
    {
        public static void ManageCallAsync(object obj)
        {
            Call call = ((ThreadArgs)obj).Call;
            CancellationToken token = ((ThreadArgs)obj).Token;

            Console.WriteLine($"Starting {call.Number}");
            call.Status = Status.Active;

            lock (call)
            {
                if (token.IsCancellationRequested)
                {
                    call.Status = Status.Cancelled;
                    Console.WriteLine($"Canceled {call.Number}");
                    return;
                }
                
                Monitor.Wait(call, call.Duration);
                
                if (token.IsCancellationRequested)
                {
                    call.Status = Status.Cancelled;
                    Console.WriteLine($"Canceled {call.Number}");
                    return;
                }
            }

            call.Status = Status.Finished;
            Console.WriteLine($"Finished {call.Number}");
        }
    }
}
