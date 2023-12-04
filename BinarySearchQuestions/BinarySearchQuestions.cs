using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchQuestions
{
    internal class BinarySearchQuestions
    {
        public int[] searchRangeBruteForce(int[] nums, int target)
        {
            int first = -1;
            int last = -1;

            for(int i=0; i<nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    first = i;
                    last = i;
                    while (last < nums.Length && nums[last] == target)
                    {
                        last++;
                    }
                    if (first != last)
                        last--;

                    break;
                }
            }

            return new int[] { first, last };
        }
        public int[] searchRangeOptimal(int[] nums, int target)
        {
            int first = firstOccurance(nums, target);
            int last = lastOccurance(nums, target);

            return new int[] { first, last };
        }
        private int firstOccurance(int[] nums, int target)
        {
            int first = -1;
            int low = 0; 
            int high = nums.Length-1;

            while(low <= high)
            {
                int mid = (low+high)/2;

                if (nums[mid] == target)
                {
                    first= mid;
                    high= mid - 1;
                }
                else if (target < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return first;
        }

        private int lastOccurance(int[] nums, int target)
        {
            int last = -1;
            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (nums[mid] == target)
                {
                    last = mid;
                    low = mid + 1;
                }
                else if (target < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return last;
        }

        public int numberOfOccurance(int[] nums, int target)
        {
            int first = firstOccurance(nums, target);
            if (first == -1)
                return 0;
            int last = lastOccurance(nums, target);
            return last - first + 1;
        }

        public int lowerBound(int[] nums, int target)
        {
            int ans = nums.Length;
            int low = 0;
            int high = nums.Length - 1;

            while(low <= high)
            {
                int mid = (low + high) / 2;

                if (nums[mid] >= target) // might be the aswer 
                {
                    ans= mid;
                    high = mid - 1; // looking left for smaller item
                }
                else
                {
                    low = + mid + 1; // looking that right 
                }
            }
            return ans;
        }

        public int upperBound(int[] nums, int target)
        {
            int ans = nums.Length;
            int low = 0; 
            int high = nums.Length - 1;

            while(low <= high)
            {
                int mid = ((low + high) / 2);

                if (nums[mid] > target)
                {
                    ans= mid;
                    high = mid - 1; // look the left sub array for other smaller possible value 
                }
                else
                {
                    low = mid + 1; // look for the right 
                }
            }
            return ans;
        }

        public int searchInsertIndex(int[] nums, int target)
        {
            int ans = nums.Length;
            int low = 0;
            int high = nums.Length - 1;

            while(low <= high)
            {
                int mid = (((low + high) / 2));
                if (nums[mid] >= target)
                {
                    ans = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return ans;
        }

        // Search in a rotated sorted array 
        /*
         [7,8,9,1,2,3,4,5,6] target=1
         */
        public int searchInRotatedSortedArray(int[] nums, int target)
        {
            int low = 0; 
            int high = nums.Length - 1;
            while(low <= high)
            {
                int mid = (low + high) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                // find the sorted half 
                if (nums[low] <= nums[mid])// for left half to be sorted it must follow this property
                {
                    // left half is sorted
                    if (nums[low] <= target && target <= nums[mid]) // check if the target is in the sorted portion 
                    {
                        // target lies in the left half 
                        high = mid - 1; // eliminate the right half
                    }
                    else
                    {
                        // the target does not lie in the left half
                        low = mid + 1; // eleminate the left half and move right
                    }

                }
                else //if (nums[mid] < nums[high])
                {
                    // right hlaf will be sorted 

                    if (nums[mid] <= target && target <= nums[high])
                    {
                        // target lies in the right half 
                        low = mid + 1; // eliminate the left half
                    }
                    else
                    {
                        // target does not lie in the right half
                        high = mid - 1; // eliminate the right half
                    }
                }
            }
            return -1; 
        }

        public bool searchInRotatedSortedArrayWithDuplicats(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (nums[mid] == target)
                {
                    return true;
                }

                // shrinking the array 
                if (nums[low] == nums[mid] && nums[mid] == nums[high])
                {
                    low++;
                    high--;
                    continue;
                }
                // find the sorted half 
                if (nums[low] <= nums[mid])// for left half to be sorted it must follow this property
                {
                    // left half is sorted
                    if (nums[low] <= target && target <= nums[mid]) // check if the target is in the sorted portion 
                    {
                        // target lies in the left half 
                        high = mid - 1; // eliminate the right half
                    }
                    else
                    {
                        // the target does not lie in the left half
                        low = mid + 1; // eleminate the left half and move right
                    }

                }
                else //if (nums[mid] < nums[high])
                {
                    // right hlaf will be sorted 

                    if (nums[mid] <= target && target <= nums[high])
                    {
                        // target lies in the right half 
                        low = mid + 1; // eliminate the left half
                    }
                    else
                    {
                        // target does not lie in the right half
                        high = mid - 1; // eliminate the right half
                    }
                }
            }
            return false;
        }

        public int minimumInRotatedSortedArray(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1; 
            int min = int.MaxValue;

            while(low <= high)
            {
                int mid = (low + high) / 2;


                if (nums[low] <= nums[high]) // if the entire array is already sorted 
                {
                    return nums[low];
                }

                // if the left half is softed , pick up the smalles from left half 
                if (nums[low] <= nums[mid])
                {
                    min = Math.Min(min, nums[low]);
                    low = mid + 1;
                }
                else // the right half will be sorted so pick the smallest and eliminate 
                {
                    min = Math.Min(min, nums[mid]);
                    low = mid + 1;
                }
            }
            return min;
        }


        public int minimumInRotatedSortedArrayWithDuplicate(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;
            int min = int.MaxValue;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                // Compare and update min with the elements at low, mid, and high
                min = Math.Min(Math.Min(min, nums[low]), nums[mid]);

                if (nums[low] == nums[mid] && nums[mid] == nums[high])
                {
                    low++;
                    high--;
                }
                else if (nums[low] <= nums[mid])
                {
                    // Left half is sorted
                    low = mid + 1;
                }
                else
                {
                    // Right half is sorted
                    high = mid - 1;
                }
            }
            return min;
        }

        // arr = {1,1,2,2,3,4,4,5,5}
        public int findSingleElementBruteForce(int[] arr)
        {
            if (arr.Length == 0)
                return -1;
            if (arr.Length == 1)
                return arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if(i==0)
                {
                    if (arr[i] != arr[i + 1])
                        return arr[i];
                }
                else if(i == arr.Length - 1)
                {
                    if (arr[i] != arr[i-1])
                        return arr[i];
                }
                else
                {
                    if (arr[i] != arr[i-1] && arr[i] != arr[i+1])
                        return arr[i];
                }

            }

            return-1;
        }

        public int findSingleElement(int[] arr)
        {
            int n = arr.Length;
            if (n == 0) return -1 ;
            if (n == 1) return arr[0];

            if (arr[0] != arr[1]) return arr[0]; // first element 
            if (arr[n-1] != arr[n-2]) return arr[n-1]; // last element

            int low = 1;
            int high = n - 2;

            while(low <= high)
            {
                int mid = (low + high) / 2;
                // check of the mid/curren element is not equal to its right and left
                if (arr[mid] != arr[mid-1] && arr[mid] != arr[mid+1])
                {
                    return arr[mid];
                }
                // elimination , 
                if( (mid % 2 != 0 && arr[mid] == arr[mid-1]) // is the mid at odd index and is equal to its left
                    || (mid % 2 == 9 && arr[mid] == arr[mid + 1]) ) // or if we are the even index it is equal to its right
                {
                    // we are at the left half of the array and the single element is in the right half 
                    low = mid + 1;  // eliminate the left half 
                }
                else 
                {
                    // we are that the right half , and the element is in the left half 
                    high = mid - 1;
                }
            }
            return -1; // dummy statement 
        }

        public  int findSingleElement2(int[] arr)
        {
            int low = 0, high = arr.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                // Check if the mid is the unique element
                if (mid % 2 == 0)
                {
                    // If mid is even and next element is same, search in right half
                    if (arr[mid] == arr[mid + 1])
                        low = mid + 2;
                    else
                        // Else search in left half
                        high = mid;
                }
                else
                {
                    // If mid is odd
                    if (arr[mid] == arr[mid - 1])
                        // If previous element is same, search in right half
                        low = mid + 1;
                    else
                        // Else search in left half
                        high = mid - 1;
                }
            }

            // When low meets high, that's our single element
            return arr[low];
        }

        public int findPeakElementBruteForce1(int[] arr)
        {
            if(arr.Length == 1)
            {
                return arr[0];
            }
            int peak = arr[0];
            int i;
            for(i = 1; i< arr.Length - 1; i++)
            {
                if (arr[i] > arr[i-1] && arr[i] > arr[i+1])
                {
                    peak = arr[i];
                    break;
                }
            }
            if(i== arr.Length -1 && arr[i] > peak)
                peak = arr[i];
            return peak;
        }
        public int findPeakElementBruteForce2(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0; i< n; i++)
            {
                if( (i==0 || arr[i] > arr[i-1]) && (i==n-1 || arr[i] > arr[i+1]) )
                {
                    return arr[i];
                }
            }
            return-1;
        }

        int findPeak(int[] arr)
        {
            int n = arr.Length;
            if (n == 1)
                return 0;
            if (arr[0] > arr[1])
                return 0;
            if (arr[n - 1] > arr[n - 2])
                return n - 1;

            int low = 1;
            int high = n - 2; 

            while(low <= high )
            {
                int mid = (low + high)/2;

                if (arr[mid] > arr[mid -1] && arr[mid] > arr[mid+1])
                {
                    return mid; // found peak index
                }
                //peak index might on the rigth 
                //check if mid is ling on the increasing curve 
                if (arr[mid] > arr[mid-1])
                {
                    // peak will alway be on the right , 
                    low = mid + 1;
                }
                else// if (arr[mid] > arr[mid+1]) // mid is on the decreasing curve
                {
                    // search on the left half
                    high = mid - 1;
                }
            }
            return -1; // dummy statement 
        }

        public int sqrt (int n)
        {
            if(n < 0) 
                return -1;
            if(n == 0)
                return 0;
            int answer = 0;
            int i = 1;
            while( (i * i)  <= n)
            {
                i++;
            }
            return i - 1;
        }
        public int sqrt2(int n)
        {
            int answer = 0;
            for(int i = 1; ; i++)
            {
                if (i * i <= n)
                    answer = i;
                else
                    break;
            }
            return answer;
        }

        public int sqrt3(int n)
        {
            int answer = 0;
            if (n <= 0)
                return answer;

            for(int i = 1; ; i++)
            {
                if((i * i) <= n)
                {
                    answer = i;
                }
                else
                    break;
            }
            return answer;
        }

        public int sqrtBS(int n)
        {
            int ans = 0;
            int low = 0;
            int high = n;

            while(low <= high)
            {
                int mid = (low + high) / 2;
                if( mid * mid <= n )
                {
                    ans = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            //return ans;
            return high;
        }

        public int nthRoot(int n, int r)
        {
            int result = 0; 
            if (n <= 0)
                return -1;
            for(int i = 0; i < n; i++)
            {
                int x = 1; 
                for(int j = 0; j < r;j++)
                {
                    x *= i;
                }
                Console.WriteLine("x = "+x);
                if ( x == n )
                {
                    result = i;
                    break;
                }
                else if(x > n)
                {
                    result = -1;
                    break;
                }
            }
            return result; 
        }
    }
}
