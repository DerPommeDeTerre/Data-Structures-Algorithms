using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksQueues {
    internal class Program {
        static void Main(string[] args) {
            PopAndPush();
            EnqueueAndDequeue();
        }

        static void PopAndPush() {
            Stack<string> actionStack = new Stack<string>();

            actionStack.Push("Typed 'Hello'");
            actionStack.Push("Typed 'World'");
            actionStack.Push("'Deleted World'");

            Console.WriteLine("Undoing Last Action: " + actionStack.Pop() + "\n");
        }

        static void EnqueueAndDequeue() {
            Queue<string> printQueue = new Queue<string>();

            printQueue.Enqueue("Document 1");
            printQueue.Enqueue("Document 2");
            printQueue.Enqueue("Document 3");

            while (printQueue.Count > 0) {
                Console.WriteLine("Printing: " + printQueue.Dequeue());
            }
        }
    }
}
