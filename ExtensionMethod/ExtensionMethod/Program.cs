using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace ExtensionMethod
{
    public class TestClass
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override string ToString()
        {
            return $"{A} {B} {C}";
        }
    }

    public class Program
    {
        static void Main()
        {
            var list = new List<TestClass>()
            {
                new TestClass { A = 6, B = 6, C = 6 },
                new TestClass { A = 1, B = 1, C = 1 },
                new TestClass { A = 3, B = 3, C = 3 },
                new TestClass { A = 3, B = 3, C = 3 },
                new TestClass { A = 7, B = 7, C = 7 },
                new TestClass { A = 5, B = 5, C = 5 },
                new TestClass { A = 5, B = 5, C = 5 },
                new TestClass { A = 2, B = 2, C = 2 },
                new TestClass { A = 4, B = 4, C = 4 },
                new TestClass { A = 4, B = 4, C = 4 },
            };

            list = list.Distinct("C").ToList();
            list.ForEach(Console.WriteLine);
        }
    }

    public static class Extension
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> list, string propertyName) where T : class
        {
            return list.Distinct(new PropertyComparer<T>(propertyName));
        }
    }

    public class PropertyComparer<T> : IEqualityComparer<T> where T : class
    {
        public PropertyComparer(string prop)
        {
            Property = typeof(T).GetProperty(prop);
        }

        public PropertyInfo Property { get; }

        public bool Equals(T x, T y)
        {
            return Property.GetValue(x).Equals(Property.GetValue(y));
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return Property.GetValue(obj).GetHashCode();
        }
    }
}
