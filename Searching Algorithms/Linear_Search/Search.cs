using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Search {
    internal class Search {
        public static int LinearSearch(int[] arr, int target) {
            for(int i = 0; i < arr.Length; i++) {
                if (arr[i] == target) {
                    return i;//Returns the position in the array
                }
            }
            return -1;//Value used in the condition
        }
    }
}
