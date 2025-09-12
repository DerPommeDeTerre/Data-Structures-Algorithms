using System.Collections.Concurrent;
using System.Diagnostics;

namespace QuickMergeBubbleSorts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 5, 3, 8, 4, 2, 7, 1, 6 };
            Random rand = new Random();
            int[] numbers = Enumerable.Range(1, 50000).OrderBy(x => rand.Next()).ToArray();

            Stopwatch stopwatch = Stopwatch.StartNew();

            int[] quicksortArray = (int[])numbers.Clone();
            QuickSort(quicksortArray, 0, quicksortArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quicksort time: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Restart();
            int[] mergeSortArray = (int[])numbers.Clone();
            MergeSort(mergeSortArray, 0, mergeSortArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Mege sort time: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Restart();
            int[] arraySort = (int[])numbers.Clone();
            Array.Sort(arraySort);
            stopwatch.Stop();
            Console.WriteLine("Array sort time: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Restart();
            int[] bubbleArray = (int[])numbers.Clone();
            BubbleSort(bubbleArray);
            Console.WriteLine("Bubble sort time: " + stopwatch.ElapsedMilliseconds + " ms");
        }
        static void BubbleSort(int[] arr) {
            for (int i = 0; i < arr.Length - 1; i++) {
                for (int j = 0; j < arr.Length - 1; j++) {
                    if (arr[j] > arr[j + 1]) {
                        //SWAP
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
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
        static int Partition(int[]arr, int low, int high) {
            int pivot = arr[high];//Pivot always at the end
            int i = low - 1;//Location of i
            for(int j = low; j < high; j++) { //Location of j
                if (arr[j] < pivot) {//LEFT and RIGHT side
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            //Pivot insertion in the middle
            i++;
            int temp2 = arr[i];
            arr[i] = arr[high];
            arr[high] = temp2;
            return i;
        }
        static void MergeSort(int[] arr, int left, int right) {
            if(left < right) {
                int mid = (left + right) / 2;//MIDDLE position
                MergeSort(arr, left, mid);//LEFT part
                MergeSort(arr, mid + 1, right);//RIGHT part
                Merge(arr, left, mid, right);//Merge halves
            }
        }
        static void Merge(int[] arr, int left, int mid, int right) {
            //Calculate # of elements on the left side
            int leftLength = mid - left + 1;
            //Calculate # of elements in the right side
            int rightLength = right - mid;

            int[] leftArr = new int[leftLength];
            int[] rightArr = new int[rightLength];

            //Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
            Array.Copy(arr, left, leftArr, 0, leftLength);
            Array.Copy(arr, mid + 1, rightArr, 0, rightLength);

            int i = 0;//LEFT array
            int j = 0;//RIGHT array
            int k = left;

            //Merging conditions
            while(i < leftLength && j < rightLength) {
                if (leftArr[i] <= rightArr[j]) {
                    arr[k] = leftArr[i];
                    k++;
                    i++;
                } else {
                    arr[k] = rightArr[j];
                    k++;
                    j++;
                }
            }//Copy remaining elements from leftArr into the main array
            while(i < leftLength) {
                arr[k] = leftArr[i];
                k++;
                i++;
            }
            while(j < rightLength) {
                arr[k] = rightArr[j];
                k++;
                j++;
            }
        }

    }
}
