using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Stacks_LLists {
    internal class Program {
        static void Main(string[] args) {
            ArrayMethod();
            LinkedListMethod();
            StackMethod();
            QueueMethod();
        }

        static void ArrayMethod() {
            //Declare and initialize an array of expressions
            string[] expressions = new string[] {
                "5+3", "10-2", "7*4", "20/5", "3^5"
            };

            //Print the original expressions
            Console.WriteLine("Calculator history: ");
            foreach (string expression in expressions) {
                Console.WriteLine(expression);
            }
        }

        static void LinkedListMethod() {
            //Declare and initialize a linked list
            LinkedList<string> results = new LinkedList<string>();

            results.AddLast("Result: 8");
            results.AddLast("Result: 5");
            results.AddLast("Result: 28");
            results.AddLast("Result: 4");
            results.AddLast("Result: 9");

            //Remove a specific result
            results.Remove("Result: 5");

            //Print updated list
            Console.WriteLine("\nUpdated Calculation Results: ");
            foreach(string result in results) {
                Console.WriteLine(result);
            }
        }

        static void StackMethod() {
            //Declare and initialize a stack
            Stack<string> undoStack = new Stack<string>();

            undoStack.Push("Entered 5+3");
            undoStack.Push("Entered 10-2");
            undoStack.Push("Entered 7*4");

            //Undo the last action
            string lastAction = undoStack.Pop();

            //Print undone action
            Console.WriteLine("\nUndoing: " + lastAction);
        }

        static void QueueMethod() {
            //Declare and initialize a QUEUE
            Queue<string> calculationQueue = new Queue<string>();

            calculationQueue.Enqueue("Calculate: 15 + 5");
            calculationQueue.Enqueue("Calculate: 12 - 3");
            calculationQueue.Enqueue("Calcualte: 9 * 2");

            //Process the next calculation
            string nextCalc = calculationQueue.Dequeue();
            //Print processed calculation
            Console.WriteLine("\n Processing:" + nextCalc);
        }


    }
}
