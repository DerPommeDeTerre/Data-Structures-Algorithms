using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble_Sort {
    internal class Program {
        static void Main(string[] args) {

            //int[] numbers = { 5, 3, 8, 4, 2, 7, 1, 6 };
            Random rand = new Random();
            int[] numbers = Enumerable.Range(1, 10000).OrderBy(x => rand.Next()).ToArray();

            //Console.WriteLine("Original Array");
            //Console.WriteLine(string.Join(", ", numbers));

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

            //stopwatch.Restart();
            //int[] mergeSortArray = (int[])numbers.Clone();
            //MergeSort(mergeSortArray, 0, mergeSortArray.Length - 1);
            //stopwatch.Stop();
            //Console.WriteLine("Mege Sort Time: " + stopwatch.ElapsedMilliseconds + " ms");
        }
        static void BubbleSort(int[] arr) {
            for(int i = 0; i < arr.Length - 1; i++) {
                for(int j = 0; j < arr.Length - i - 1; j++) {
                    if (arr[j] > arr[j + 1]) {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        static void QuickSort(int[] arr, int low, int high) {
            if(low < high) {
                int pivot = Partition(arr, low, high);
                QuickSort(arr, low, pivot - 1);
                QuickSort(arr, pivot + 1, high);

            }
        }

        static int Partition(int[] arr, int low, int high) {
            int pivot = arr[high];
            int i = low - 1;
            for(int j = low; j < high; j++) {
                if (arr[j] < pivot) {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            // Place pivot in the correct position
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;  // Return pivot index
        }

    }
}
