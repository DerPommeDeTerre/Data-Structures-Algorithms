using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big_O_Notation {
    internal class Program {
        static void Main(string[] args) {
            DemonstrateArrayAccess();
            DemonstrateLinkedListTraversal();
            DemonstrateStackOperations();
            DemonstrateQueueOpeations();
        }
        static void DemonstrateArrayAccess() {
            Console.WriteLine("Array Access - O(1)");
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers[2]);
            Console.WriteLine();
        }
        static void DemonstrateLinkedListTraversal() {
            Console.WriteLine("Linked List Traversal - O(n)");
            LinkedList<int> list = new LinkedList<int>(new int[] {1,2,3,4,5});
            foreach(var num in list) {
                Console.WriteLine(num);
            }
            Console.WriteLine();
        }
        static void DemonstrateStackOperations() {
            Console.WriteLine("Stack Operations - O(1) Push/Pop");
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            Console.WriteLine(stack.Pop());
            Console.WriteLine();
        }
        static void DemonstrateQueueOpeations() {
            Console.WriteLine("Queue Operations - O(1) Enqueue/Dequeue");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine();
        }
    }
}
