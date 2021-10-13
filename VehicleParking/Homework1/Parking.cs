using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework1
{
    class Parking : ICollection<Vehicle>
    {
        public Parking()
        {
            Vehicles = new();
        }

        List<Vehicle> Vehicles { get; }

        public int Count => Vehicles.Count;

        public bool IsReadOnly => false;

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
            => Vehicles.GetEnumerator();

        public void Add(Vehicle item)
        {
            Vehicles.Add(item);
        }

        public void Clear()
        {
            Vehicles.Clear();
        }

        public bool Contains(Vehicle item)
            => Vehicles.Contains(item);

        public void CopyTo(Vehicle[] array, int arrayIndex)
        {
            Vehicles.CopyTo(array, arrayIndex);
        }

        public bool Remove(Vehicle item)
            => Vehicles.Remove(item);

        IEnumerator<Vehicle> IEnumerable<Vehicle>.GetEnumerator()
            => Vehicles.GetEnumerator();

        public void ListAllVehicles()
        {
            foreach (var vehicle in Vehicles)
            {
                Console.WriteLine($"{vehicle}");
            }
        }
    }
}
