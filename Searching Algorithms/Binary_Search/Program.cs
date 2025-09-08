using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search {
    internal class Program {
        static void Main(string[] args) {

            //int[] numbers = { 10, 20, 30, 40, 50 };
            //int target = 30;

            int[] numbers = GenerateSortUserIds(100);
            Random rand = new Random();
            int target = numbers[rand.Next(numbers.Length)];
            Console.WriteLine("Target is: " + target);


            int result = Search.BinarySearch(numbers, target);

            if (result != -1) {
                Console.WriteLine("Element foud at index: " + result);
            } else {
                Console.WriteLine("Element not found.");
            }
        }
        static int[] GenerateSortUserIds(int n) { //Method to populate the ARRAY
            int[] ids = new int[n];
            for (int i = 0; i < n; i++) {
                ids[i] = i + 1;
            }
            return ids;
        }
    }
}
