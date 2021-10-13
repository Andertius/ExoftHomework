using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallCenterAsync
{
    public static class CallCenter
    {
        public static async Task ManageCallAsync(Call call, CancellationToken token)
        {
            try
            {
                Console.WriteLine($"Starting {call.Number}");
                call.Status = Status.Active;
                await Task.Delay(call.Duration, token);
                call.Status = Status.Finished;
                Console.WriteLine($"Finished {call.Number}");
            }
            catch (TaskCanceledException)
            {
                call.Status = Status.Cancelled;
                Console.WriteLine($"Cancelled {call.Number}");
            }
        }
    }
}
