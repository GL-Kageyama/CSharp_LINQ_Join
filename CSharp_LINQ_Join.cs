using System;
using System.Linq;
using System.Collections.Generic;

namespace Join
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var joinClass = new JoinClass();

            joinClass.GetJoin();
        }
    }

    class JoinClass
    {
        public void GetJoin()
        {
            var outer1 = new[]
            {
                new { Name = "Emily", Age = 11 },
                new { Name = "Ava", Age = 21 },
                new { Name = "David", Age = 65 },
                new { Name = "Alexander", Age = 43 },
                new { Name = "Joe", Age = 21 },
            };

            var outer2 = new[]
            {
                new { Name = "George", Age = 72 },
                new { Name = "Adeline", Age = 28 },
            };

            var inner = new[]
            {
                new { Name = "George", comeFrom = "Ohio" },
                new { Name = "Emily", comeFrom = "Kansas" },
                new { Name = "Joe", comeFrom = "Mississippi" },
            };

            // Empty set
            IEnumerable<decimal> empty = Enumerable.Empty<decimal>();

            // Join()
            // Perform an inner join
            var query = outer1.Join(inner,
                                    e => e.Name,
                                    n => n.Name,
                                    (e, n) => new {e.Name, e.Age, n.comeFrom});
            foreach (var fri in query)
                Console.WriteLine(fri);
            Console.WriteLine();

            // Concat()
            // Concatenate two sequences
            var query2 = outer1.Concat(outer2);
            foreach (var fri2 in query2)
                Console.WriteLine(fri2);
            Console.WriteLine();

            // DefaultIfEmpty()
            // Get the sequence or get the specified value if empty
            var query3 = outer1.DefaultIfEmpty();
            foreach (var fri3 in query3)
                Console.WriteLine(fri3);
            Console.WriteLine();
            // For empty sets
            var query4 = empty.DefaultIfEmpty();
            foreach (var em in query4)
                Console.WriteLine(em);
            Console.WriteLine();

            // Zip()
            // Merge two sequences into one with the specified function
            var query5 = outer1.Zip(outer2, (a1, a2) => a1.Name + " & " + a2.Name);
            foreach (var nameZ in query5)
                Console.WriteLine(nameZ);
            Console.WriteLine();
        }
    }
}