using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_EXTRA {
    internal class Program {
        static void Main(string[] args) {

            LinkedList<string> linkedList = new LinkedList<string>();
            //----------LINKED LIST as a stack-----------
            //linkedList.AddFirst("A");
            //linkedList.AddFirst("B");
            //linkedList.AddFirst("C");
            //linkedList.AddFirst("D");
            //linkedList.AddFirst("E");
            //linkedList.AddFirst("F");

            //linkedList.RemoveFirst();

            //----------LINLED LIST as queue---------
            linkedList.AddLast("A");
            linkedList.AddLast("B");
            linkedList.AddLast("C");
            linkedList.AddLast("D");
            linkedList.AddLast("E");
            linkedList.AddLast("F");

            //linkedList.RemoveLast();

            //Get node
            LinkedListNode<string> nodeE = linkedList.Find("E");
            linkedList.AddAfter(nodeE, "EE");
            linkedList.Remove("E");

            string first = linkedList.First.Value;
            Console.WriteLine(first);

            string last = linkedList.Last.Value;
            Console.WriteLine(last);

            foreach (string element in linkedList) {
                Console.Write(element + " ");
            }
        }
    }
}
