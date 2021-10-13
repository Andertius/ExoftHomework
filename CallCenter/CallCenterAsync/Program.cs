using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CallCenterAsync
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("To add a call, enter: 'call {call duration in milliseconds}'");
            Console.WriteLine("To cancel a call, enter: 'cancel {call number}'");
            Console.WriteLine("To see all the calls, enter: 'status'");
            int count = 1;
            var callHistory = new List<Call>();
            var tasks = new List<Task>();
            var tokens = new List<CancellationTokenSource>();

            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (input == "status")
                {
                    if (callHistory.Count == 0)
                    {
                        Console.WriteLine("No calls yet");
                        continue;
                    }

                    callHistory.ForEach(Console.WriteLine);
                }
                else if (input == "exit" || input == "quit")
                {
                    break;
                }
                else if (input.Length > 5 && input[..5] == "call " && Int32.TryParse(input[5..], out int duration))
                {
                    var cts = new CancellationTokenSource();
                    var token = cts.Token;
                    tokens.Add(cts);

                    var call = new Call(duration, count++);
                    callHistory.Add(call);

                    var task = Task.Run(() => CallCenter.ManageCallAsync(call, token), token);
                    tasks.Add(task);
                }
                else if (input.Length > 7 && input[..7] == "cancel " && Int32.TryParse(input[7..], out int callToCancel))
                {
                    tokens[callToCancel - 1].Cancel();
                    tokens[callToCancel - 1].Dispose();
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}
