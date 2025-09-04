using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort_MergeSort {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = { 5, 3, 8, 4, 2, 7, 1, 6 };
            //Random rand = new Random();
            //int[] numbers = Enumerable.Range(1, 10000).OrderBy(x => rand.Next()).ToArray();

            Console.WriteLine("Original Array");
            Console.WriteLine(string.Join(", ", numbers));

            Stopwatch stopwatch = Stopwatch.StartNew();

            int[] bubbleSortArray = (int[])numbers.Clone();
            BubbleSort(bubbleSortArray);
            stopwatch.Stop();
            Console.WriteLine("Bubble sort time: " + stopwatch.ElapsedMilliseconds + " ms");
            //Console.WriteLine(string.Join(", ", bubbleSortArray));

            stopwatch.Restart();
            int[] quicksortArray = (int[])numbers.Clone();
            QuickSort(quicksortArray, 0, quicksortArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quicksort Time: " + stopwatch.ElapsedMilliseconds + " ms");
            Console.WriteLine(string.Join(", ", bubbleSortArray));

            stopwatch.Restart();
            int[] mergeSortArray = (int[])numbers.Clone();
            MergeSort(mergeSortArray, 0, mergeSortArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Mege Sort Time: " + stopwatch.ElapsedMilliseconds + " ms");
            Console.WriteLine(string.Join(", ", mergeSortArray ));
        }

        static void BubbleSort(int[] arr) {
            for (int i = 0; i < arr.Length - 1; i++) {
                for (int j = 0; j < arr.Length - i - 1; j++) {
                    if (arr[j] > arr[j + 1]) {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        static void QuickSort(int[] arr, int low, int high) {
            if (low < high) {
                int pivot = Partition(arr, low, high);
                QuickSort(arr, low, pivot - 1);
                QuickSort(arr, pivot + 1, high);

            }
        }

        static int Partition(int[] arr, int low, int high) {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++) {
                if (arr[j] < pivot) {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            // Place pivot in the correct position
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;  // Return pivot index
        }
        // Recursive MergeSort function
        static void MergeSort(int[] arr, int left, int right) {
            // Check if the array has more than one element (base condition)
            if (left < right) {
                // Find the middle index (splitting point)
                int mid = (left + right) / 2;

                // Recursively sort the left half of the array
                MergeSort(arr, left, mid);

                // Recursively sort the right half of the array
                MergeSort(arr, mid + 1, right);

                // Merge the two sorted halves back together
                Merge(arr, left, mid, right);
            }
        }

        // Function that merges two sorted subarrays into one sorted array
        static void Merge(int[] arr, int left, int mid, int right) {
            // Size of the left subarray (from 'left' to 'mid')
            int n1 = mid - left + 1;

            // Size of the right subarray (from 'mid+1' to 'right')
            int n2 = right - mid;

            // Create temporary arrays to hold the left and right halves
            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            // Explanation of Array.Copy (commented out for clarity):
            // Array.Copy(
            //     sourceArray,       // array to copy from
            //     sourceIndex,       // starting index in sourceArray
            //     destinationArray,  // array to copy into
            //     destinationIndex,  // starting index in destinationArray
            //     length);           // number of elements to copy

            // Copy data into leftArr from the original array
            Array.Copy(arr, left, leftArr, 0, n1);

            // Copy data into rightArr from the original array
            Array.Copy(arr, mid + 1, rightArr, 0, n2);

            // Index pointer for leftArr
            int i = 0;

            // Index pointer for rightArr
            int j = 0;

            // Index pointer for the original array (arr)
            int k = left;

            // Merge elements from leftArr and rightArr into arr
            while (i < n1 && j < n2) {
                // If current element in leftArr is smaller or equal, place it into arr
                if (leftArr[i] <= rightArr[j]) {
                    arr[k++] = leftArr[i++];
                } else {
                    // Otherwise, take the element from rightArr
                    arr[k++] = rightArr[j++];
                }
            }

            // Copy any remaining elements from leftArr (if any left)
            while (i < n1) {
                arr[k++] = leftArr[i++];
            }

            // Copy any remaining elements from rightArr (if any left)
            while (j < n2) {
                arr[k++] = rightArr[j++];
            }
        }
    }
}
