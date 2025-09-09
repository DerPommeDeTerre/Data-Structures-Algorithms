using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Implementation {
    internal class Program {
        static void Main(string[] args) {

            int[] productIds = GenerateSortedArray(10000);
            int[] emptyArray = new int[];

            int targetId = GetTarget("valid");
            int targetId = GetTarget("invalid");

            Console.WriteLine("Target is: " + targetId + "\n");



            int index = BinarySearch(productIds, targetId);

            if(index != -1) {
                Console.WriteLine("Product with ID: " + targetId + " found at " + index + " index position.");
            } else {
                Console.WriteLine("Product with ID: " + targetId + " not found.");
            }
        }
        static int[] GenerateSortedArray(int n) {
            
            int[] ids = new int[n];

            for(int i = 0; i < n; i++) {
                ids[i] = i + 1;
            }
            return ids;
        }
        static int BinarySearch(int[] arr, int target) {
            ;
            //Limits setting
            int left = 0; //Begining index = 0
            int right = arr.Length - 1; //Ending index
            
            while(left <= right) { 
                int mid = left + (right - left) / 2;
                Console.WriteLine("Middle index is: " + mid);
                if (arr[mid] == target) {
                    return mid;
                } else if (arr[mid] < target) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
            return -1;
        }
        static int GetTarget(string type) {
            return type == "valid" ? 1055 : 10101;
        }
    }
}
