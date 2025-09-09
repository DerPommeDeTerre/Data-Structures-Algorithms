using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchActivity {
    internal class Program {
        static void Main(string[] args) {

            //Array for Binary Search
            int[] BinarySearchArray = GeerateSortUserIds(1000000);

            //Empty array
            //int[] BinarySearchArray = new int[0];

            //Generate target value
            //rand.Next(int maxValue)
            Random rand = new Random();
            //Calculating a new random target
            int target = BinarySearchArray[rand.Next(BinarySearchArray.Length)];

            //Target for empty array
            //int target = 100;

            //Target that is not index at the array
            //int target = BinarySearchArray.Length + rand.Next(1, 10);//TEN values outside the ARRAY

            Console.WriteLine("The TARGET is: " + target + "\n");

            //Clock to measure time
            Stopwatch stopwatch = Stopwatch.StartNew();
            //----------BINARY SEARCH-------------
            int result = BinarySearch(BinarySearchArray, target);
            stopwatch.Stop();
            long binaryTime = stopwatch.ElapsedMilliseconds;

            //----------LINEAR SEARCH-------------
            stopwatch.Restart();
            int result2 = LinearSearch(BinarySearchArray, target);
            stopwatch.Stop();
            long linearTime = stopwatch.ElapsedMilliseconds;

            if (result != -1) {
                Console.WriteLine("User ID found at index: " + result);
                Console.WriteLine("Binary Time: " + binaryTime + " ms");
                Console.WriteLine("Linear Time: " + linearTime + " ms");
            } else {
                Console.WriteLine("User ID: " + target + " not found");
                Console.WriteLine("Time: " + binaryTime + " ms");
                Console.WriteLine("Time: " + linearTime + " ms");
            }

            if (result2 != -1) {
                Console.WriteLine("User ID found at index: " + result2);
                Console.WriteLine("Binary Time: " + binaryTime + " ms");
                Console.WriteLine("Linear Time: " + linearTime + " ms");
            } else {
                Console.WriteLine("User ID: " + target + " not found");
                Console.WriteLine("Time: " + binaryTime + " ms");
                Console.WriteLine("Time: " + linearTime + " ms");
            }
        }
        static int[] GeerateSortUserIds(int n) {
            
            int[] ids = new int[n];

            for(int i = 0; i < n; i++) {
                ids[i] = i + 1;
            }
            return ids;
        }
        static int BinarySearch(int[] arr, int target) {

            int left = 0; //Begining limit
            int right = arr.Length - 1; //End limit

            while(left <= right) {
                int mid = left + (right - left) / 2;//MIDDLE index
                if (arr[mid] == target) {
                    Console.WriteLine("Middle is: " + mid);
                    return mid;
                } else if (arr[mid] < target) {
                    Console.WriteLine("Middle is: " + mid);
                    left = mid + 1;
                } else {
                    Console.WriteLine("Middle is: " + mid);
                    right = mid - 1;
                }
            }
            return -1;
        }
        static int LinearSearch(int[] arr, int target) {
            for(int i = 0; i < arr.Length; i++) {
                if (arr[i] == target) {
                    return i;
                }
            }
            return -1;
        }
    }
}
