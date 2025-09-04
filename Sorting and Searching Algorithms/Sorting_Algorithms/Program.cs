using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms {
    internal class Program {
        static void Main(string[] args) {

            Random random = new Random();
            int[] numbers = Enumerable.Range(1, 10000).OrderBy(x => random.Next()).ToArray();

            Stopwatch stopwatch = Stopwatch.StartNew();

            int[] bubbleSortArray = (int[])numbers.Clone();
            BubbleSort(bubbleSortArray);
            stopwatch.Stop();
            Console.WriteLine("Bubble Sort Time: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Restart();
            int[] QuickSortArray = (int[])numbers.Clone();
            QuickSort(QuickSortArray, 0, QuickSortArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quicksort Time: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Restart();
            int[] MergeSortArray = (int[])numbers.Clone();
            MergeSort(MergeSortArray, 0, MergeSortArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Merge Sort Time: " + stopwatch.ElapsedMilliseconds + " ms");

        }
        public static void BubbleSort(int[] arr) {
            for(int i = 0; i < arr.Length - 1; i++) {
                for(int j = 0; j < arr.Length - i - 1; j++) {
                    if (arr[j] > arr[j + 1]) {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }
        public static void QuickSort(int[] arr, int low, int high) {
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
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }
        static void MergeSort(int[] arr, int left, int right) {
            if(left < right) {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }
        static void Merge(int[] arr, int left, int mid, int right) {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            //Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);

            Array.Copy(arr, left, leftArr, 0, n1);
            Array.Copy(arr, mid + 1, rightArr, 0, n2);

            int i = 0;
            int j = 0;
            int k = left;

            while(i < n1 && j < n2) {
                if (leftArr[i] <= rightArr[j]) {
                    arr[k++] = leftArr[i++];
                } else {
                    arr[k++] = rightArr[j++];
                }
            }
            while(i < n1) {
                arr[k++] = leftArr[i++];
            }
            while(j < n2) {
                arr[k++] = rightArr[j++];
            }
        }
    }
}
