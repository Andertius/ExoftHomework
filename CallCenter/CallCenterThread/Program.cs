using System;
using System.Collections.Generic;
using System.Threading;

namespace CallCenterThread
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
            var threads = new List<Thread>();
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

                    var thread = new Thread(CallCenter.ManageCallAsync);
                    threads.Add(thread);
                    thread.Start(new ThreadArgs { Call = call, Token = token });
                }
                else if (input.Length > 7 && input[..7] == "cancel " && Int32.TryParse(input[7..], out int callToCancel))
                {
                    var call = callHistory[callToCancel - 1];

                    lock (call)
                    {
                        tokens[callToCancel - 1].Cancel();
                        Monitor.Pulse(call);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}
