using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAlgorithms
{
    internal class Search
    {
        public bool linearSearch(int[] arr, int item)
        {
            foreach(var x in arr)
            {
                if (x == item)
                    return true;
            }
            return false;
        }

        public bool binarySearch(int[] arr, int item)
        {
            int low = 0;
            int high = arr.Length - 1;

            while(low <= high)
            {
                int mid = (low + high) / 2;

                if (arr[mid] == item)
                {
                    return true;
                }
                else if (item < arr[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return false;
        }
    }
}
