using System;

namespace Homework1
{
    public abstract class Vehicle : IMovable
    {
        public Vehicle(string name, int year, string serial, int wheels)
        {
            Name = name;
            Year = year;
            Serial = serial;
            WheelCount = wheels;
        }

        public string Name { get; }

        public int Year { get; }

        public string Serial { get; }

        public int WheelCount { get; }

        public bool IsOnMove { get; private set; }

        public void Move()
        {
            IsOnMove = true;
            Console.WriteLine("Started moving");
        }

        public void Stop()
        {
            IsOnMove = false;
            Console.WriteLine("Stopped moving");
        }

        public override string ToString()
            => $"{Name} - {Year}, Serial code: {Serial}";
    }
}
