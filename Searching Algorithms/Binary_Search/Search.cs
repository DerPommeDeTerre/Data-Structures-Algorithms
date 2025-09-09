using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search {
    internal class Search {

        public static int BinarySearch(int[] arr, int target) {
            
            int left = 0; //Beginning of the array
            int right = arr.Length - 1; //End of the array
            
            while(left <= right) {
                int mid = left + (right - left) / 2; //MIDDLE index calculation
                if (arr[mid] == target) { //Returns value if middle == target
                    Console.WriteLine("Middle is: " + arr[mid]);
                    return mid;
                } else if (arr[mid] < target) { //Search on RIGHT half
                    Console.WriteLine("Middle is: " + arr[mid]);
                    left = mid + 1;
                } else { //Search on LEFT half
                    Console.WriteLine("Middle is: " + arr[mid]);
                    right = mid - 1;
                }
            }
            return -1; //VALUE was not found
        }
    }
}
