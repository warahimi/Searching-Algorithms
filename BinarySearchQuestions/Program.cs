using System;

namespace BinarySearchQuestions
{
    internal class Prgoram
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 10, 11 ,12,12, 12,40};
            BinarySearchQuestions bs = new BinarySearchQuestions();
            int target = 2;

            //foreach (var x in bs.searchRangeBruteForce(arr, target))
            //{
            //    Console.Write(x + " ");
            //}
            //Console.WriteLine();
            //foreach (var x in bs.searchRangeOptimal(arr, target))
            //{
            //    Console.Write(x + " ");
            //}

            //Console.WriteLine();

            //Console.WriteLine("Lower bound: "+ bs.lowerBound(arr,1));
            //Console.WriteLine("Lower bound: "+ bs.upperBound(arr,1));
            //Console.WriteLine(bs.searchInsertIndex(arr,-130));
            //Console.WriteLine("Number of Occurance: "+ bs.numberOfOccurance(arr, 40));

            //int[] rotatedSortedArray = {6,7, 8, 9, 0, 1, 1, 1, 3, 4, 5 };

            //int result = bs.searchInRotatedSortedArray(rotatedSortedArray, 1);
            //Console.WriteLine(result);
            //Console.WriteLine(bs.minimumInRotatedSortedArrayWithDuplicate(rotatedSortedArray));

            //int[] singleElement = { 0, 0, 1,1, 2, 2, 3, 3 ,4, 4, 5, 5, 6, 6, 7, 7 ,8};
            //Console.WriteLine(bs.findSingleElementBruteForce(singleElement));
            //Console.WriteLine(bs.findSingleElement(singleElement));
            //Console.WriteLine(bs.findSingleElement2(singleElement));

            //int[] peak = { 1,2,3,4,5,3,2};
            //Console.WriteLine(bs.findPeakElementBruteForce1(peak));
            //Console.WriteLine(bs.findPeakElementBruteForce2(peak));
            //int n = 25;
            //Console.WriteLine(bs.sqrt(n));
            //Console.WriteLine(bs.sqrt2(n));
            //Console.WriteLine(bs.sqrt3(n));
            //Console.WriteLine(bs.sqrtBS(n));

            int n = 81;
            Console.WriteLine(bs.nthRoot(n,4));
        }
    }
}