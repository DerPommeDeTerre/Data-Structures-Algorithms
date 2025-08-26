using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Linked_Lists {
    internal class Program {
        static void Main(string[] args) {
            BasicListMethod();
            LinkedListMethod();
        }

        static void BasicListMethod() {
            string[] cardDeck = {
                "Ace of Spades",
                "King of Hearts",
                "Queen of Diamonds",
                "Jack of Clubs",
            };

            Console.WriteLine("Original Card Deck:");
            foreach(string card in cardDeck) { //Goes through each element CARD in the array
                Console.WriteLine(card);
            }
        }

        static void LinkedListMethod() {
            //Declare a linked list for sorted cards
            LinkedList<string> sortedCards = new LinkedList<string>();

            //Add cards to the linked list
            sortedCards.AddLast("Jack of clubs");
            sortedCards.AddLast("Queen of Diamonds");
            sortedCards.AddLast("King of Hearts");
            sortedCards.AddLast("Ace of Spades");

            //Print the sorted linked list
            Console.WriteLine("\nSorted Card Deck:");
            foreach(string card in sortedCards) {
                Console.WriteLine(card);
            }

            //Remove a card from the LINKED LIST
            sortedCards.Remove("Jack of clubs");

            //Print updated list
            Console.WriteLine("\nUpdated Sorted Card Deck:");
            foreach(string card in sortedCards) {
                Console.WriteLine(card);
            }
        }
    }
}
