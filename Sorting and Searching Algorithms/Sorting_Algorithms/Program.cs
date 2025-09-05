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
            //Array, Beginning, Ending
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
            for(int i = 0; i < arr.Length - 1; i++) { //Número de vueltas que va
                //desde el último número más grande
                for(int j = 0; j < arr.Length - i - 1; j++) {
                    //j posición actual
                    //arr[j] se compara con arr[j+1]
                    //-1 contiene al ciclo dentro del arreglo
                    //-i evita evaluar todo el arreglo inicia desde el número más grande ya acomodado
                    if (arr[j] > arr[j + 1]) {
                        //SWAP
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        public static void QuickSort(int[] arr, int low, int high) {
            if(low < high) {
                int pivot = Partition(arr, low, high); //Pivot location
                QuickSort(arr, low, pivot - 1);//Left Partition
                QuickSort(arr, pivot + 1, high);//Right Partition
            }
        }
        private static int Partition(int[] arr, int low, int high) {
            int pivot = arr[high];//Pivot always at the END
            int i = low - 1;//Location of i
            for (int j = low; j < high; j++) { //Location of j
                if (arr[j] < pivot) {//LEFT and RIGHT side
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }//Pivot insertion in the middle
            i++;
            int temp2 = arr[i];
            arr[i] = arr[high];
            arr[high] = temp2;

            return i;
        }
        static void MergeSort(int[] arr, int left, int right) {
            if(left < right) {
                int mid = (left + right) / 2;//MIDLE position
                MergeSort(arr, left, mid); //LEFT part
                MergeSort(arr, mid + 1, right);//RIGHT half
                Merge(arr, left, mid, right);//Merge halves
            }
        }
        static void Merge(int[] arr, int left, int mid, int right) {
            //Calculates number of elements in the left side
            int leftLength = mid - left + 1;
            //Calculates number of elements in the right side
            int rightLength = right - mid;

            int[] leftArr = new int[leftLength];//Temporary LEFT array
            int[] rightArr = new int[rightLength];//Temporary RIGHT array

            //Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
            Array.Copy(arr, left, leftArr, 0, leftLength);
            Array.Copy(arr, mid + 1, rightArr, 0, rightLength);

            int i = 0; //LEFT array
            int j = 0;//RIGHT array
            int k = left;

            //Merging conditions
            while(i < leftLength && j < rightLength) {
                // Compare the current elements of leftArr and rightArr
                if (leftArr[i] <= rightArr[j]) {
                    // If leftArr[i] is smaller or equal, place it in the main array at position k
                    arr[k] = leftArr[i];
                    k++; // Move to next position in main array
                    i++; // Move to next element in leftArr
                } else {
                    // If rightArr[j] is smaller, place it in the main array at position k
                    arr[k] = rightArr[j];
                    k++; // Move to next position in main array
                    j++; // Move to next element in rightArr
                }
            }// Copy any remaining elements from leftArr into the main array
            while (i < leftLength) {
                arr[k] = leftArr[i]; // Place leftover element
                k++;
                i++;
            }
            while(j < rightLength) { // Copy any remaining elements from rightArr into the main array
                arr[k] = rightArr[j]; // Place leftover element
                k++;
                j++;
            }
        }
    }
}
