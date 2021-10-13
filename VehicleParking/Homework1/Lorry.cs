using System;

namespace Homework1
{
    class Lorry : Vehicle, IEngineStartable
    {
        public Lorry(string name, int year, string serial)
            : base(name, year, serial, 6)
        { }

        public bool IsEngineStarted { get; set; }

        public void StartEngine()
        {
            IsEngineStarted = true;
            Console.WriteLine("Engine started");
        }

        public void StopEngine()
        {
            IsEngineStarted = false;
            Console.WriteLine("Engine stopped");
        }

        public int Kilometrage()
        {
            var rand = new Random();
            return rand.Next();
        }
    }
}
