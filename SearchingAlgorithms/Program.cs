using System;

namespace SearchingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Search s = new Search();
            int[] arrLinearSearch = { 5, 6, 7, 3, 6, 7, 8, 1, 2 };
            int[] arrBinarySearch = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Linear Search: " + s.linearSearch(arrLinearSearch,2));
            Console.WriteLine("Linear Search: " + s.linearSearch(arrLinearSearch,20));

            Console.WriteLine("Binary Search: "+ s.binarySearch(arrBinarySearch,9));
            Console.WriteLine("Binary Search: "+ s.binarySearch(arrBinarySearch,90));


        }
    }
}