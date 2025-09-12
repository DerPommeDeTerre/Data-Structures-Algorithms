using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Application {
    internal class Program {

        //----------FIRST MAIN----------
        //static void Main(string[] args) {
        //    int[] userIds = { 101, 203, 345, 456, 567, 678, 789 };
        //    int searchId = 456;

        //    Stopwatch stopwatch = Stopwatch.StartNew();//WATCH inicialization

        //    int result = BinarySearch(userIds, searchId);
        //    stopwatch.Stop();

        //    Console.WriteLine(
        //        result != -1 ? "Userd ID " + searchId + " found at " + result : "User ID not found."
        //        );
        //    Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms");
        //}
        //----------SECOND MAIN----------
        //static void Main(string[] args) {
        //    int[] userIds = GenerateSortedUserIds(10000000);
        //    Random rand = new Random();
        //    int searchId = userIds[rand.Next(userIds.Length)];

        //    Stopwatch stopwatch = Stopwatch.StartNew();//WATCH inicialization

        //    int result = BinarySearch(userIds, searchId);
        //    stopwatch.Stop();

        //    Console.WriteLine(
        //        result != -1 ? "Userd ID " + searchId + " found at " + result : "User ID not found."
        //        );
        //    Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms");
        //}
        //----------THIRD MAIN----------
        static void Main(string[] args) {

            //int[] userIds = { 101, 203, 345, 456, 567, 678, 789 };

            int[] userIds = GenerateSortedUserIds(10000000);
            Random rand = new Random();
            int searchId = userIds[rand.Next(userIds.Length)];

            Stopwatch stopwatch = Stopwatch.StartNew();//WATCH inicialization
            int result = BinarySearch(userIds, searchId);
            stopwatch.Stop();
            long binaryTime = stopwatch.ElapsedTicks;
            Console.WriteLine("Binary Search found item at index: " + result);
            Console.WriteLine("Binary search time: " + binaryTime);

            stopwatch.Restart();
            int result2 = LinearSearch(userIds, searchId);
            stopwatch.Stop();
            long linearTime = stopwatch.ElapsedTicks;
            Console.WriteLine("Linear Search found item at index: " + result2);
            Console.WriteLine("Linear time: " + linearTime);
        }
        static int BinarySearch(int[] sortedArray, int target) {
            //Verify that array is not empty
            if(sortedArray.Length == 0) {
                return -1;
            }
            //Limits definition
            int left = 0;
            int right = sortedArray.Length - 1;
            //Condition to execute the code
            while(left <= right) {
                int mid = left + (right - left) / 2;
                if (sortedArray[mid] == target) {
                    return mid;
                } else if (sortedArray[mid] < target) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
            return -1;
        }
        static int[] GenerateSortedUserIds(int size) {

            Random rand = new Random();
            int[] randomNumbers = new int[size];
            for(int i = 0; i < size; i++) {
                randomNumbers[i] = rand.Next();
            }
            Array.Sort(randomNumbers);
            return randomNumbers;
        }
        static int LinearSearch(int[] array, int target) {
            for(int i = 0; i < array.Length; i++) {
                if (array[i] == target) {
                    return i;
                }
            }
            return -1;
        }
        
    }
}
