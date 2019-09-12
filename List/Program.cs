using System;

namespace ListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print all elements
            Console.WriteLine("All elements of the list are as follows: ");
            foreach (int? element in List.list)
            {
                Console.WriteLine(element);
            }

            // Insert element at a particular index
            List.InsertElementToList(88, 4);
            Console.WriteLine("Inserted 88 at index 4");

            // Print all elements after Insert
            Console.WriteLine("\nAll elements of the list after performing Insert operation: ");
            foreach (int? element in List.list)
            {
                Console.WriteLine(element);
            }

            // Update element at a particular index
            List.UpdateElementInList(41, 5);
            Console.WriteLine("\nUpdated existing value with 41 at index 5");

            // Print all elements after update
            Console.WriteLine("\nAll elements of the list after performing Update operation: ");
            foreach (int? element in List.list)
            {
                Console.WriteLine(element);
            }

            // Print all elements after all operations
            Console.WriteLine("\nAll elements of the list after performing all the operations are as follows: ");
            foreach (int? element in List.list)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}
