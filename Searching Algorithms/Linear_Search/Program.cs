using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Search {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = { 10, 20, 30, 40, 50 };
            
            int target = 30;
            int result = Search.LinearSearch(numbers, target);

            if(result != -1) {
                Console.WriteLine("Element found at index: " + result);
            } else {
                Console.WriteLine("Element not found");
            }
        }
    }
}
