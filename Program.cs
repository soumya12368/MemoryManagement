using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement_Assignment14
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            {
                // Get user input for initial data
                Console.WriteLine("Enter initial data (comma-separated):");
                string input = Console.ReadLine();
                List<object> initialData = new List<object>(input.Split(','));

                // Create an instance of LargeDataCollection
                using (var largeDataCollection = new LargeDataCollection(initialData))
                {
                    // Demonstrate adding elements
                    Console.Write("Enter an element to add: ");
                    object elementToAdd = Console.ReadLine();
                    largeDataCollection.AddElement(elementToAdd);

                    // Demonstrate removing elements
                    Console.Write("Enter an element to remove: ");
                    object elementToRemove = Console.ReadLine();
                    largeDataCollection.RemoveElement(elementToRemove);

                    // Demonstrate accessing elements
                    Console.Write("Enter an index to access: ");
                    int index = int.Parse(Console.ReadLine());
                    Console.WriteLine("Element at index " + index + ": " + largeDataCollection.GetElement(index));

                    // Display remaining elements
                    Console.WriteLine("Remaining elements:");
                    for (int i = 0; i < initialData.Count; i++)
                    {
                        //Console.WriteLine($"Index {i}: {largeDataCollection.GetElement(i)}");
                        Console.WriteLine(largeDataCollection.GetElement(i));
                    }
                } // Dispose will be called automatically when exiting the using block
            }
        }
        public class LargeDataCollection : IDisposable
        {
            private List<object> internalData;

            // Constructor to initialize the collection with initial data
            public LargeDataCollection(IEnumerable<object> initialData)
            {
                internalData = new List<object>(initialData);
            }

            // Method to add elements to the collection
            public void AddElement(object element)
            {
                internalData.Add(element);
            }

            // Method to remove elements from the collection
            public void RemoveElement(object element)
            {
                internalData.Remove(element);
            }

            // Method to access elements from the collection
            public object GetElement(int index)
            {
                if (index >= 0 && index < internalData.Count)
                {
                    return internalData[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }

            // Dispose method to release unmanaged resources and free up memory
            public void Dispose()
            {
                // Release any unmanaged resources here

                // Set the internal data structure to null to free up memory
                internalData = null;

                // Optional: Suppress finalization if there are no unmanaged resources
                GC.SuppressFinalize(this);
            }   
          }
    }
}
