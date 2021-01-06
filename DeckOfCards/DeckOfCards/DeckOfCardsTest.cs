// Fig. 8.11: DeckOfCardsTest.cs
// Card shuffling and dealing application.
using System;

public class DeckOfCardsTest
{
    // execute application
    public static void Main(string[] args)
    {
        DeckOfCards myDeckOfCards = new DeckOfCards();
        myDeckOfCards.Shuffle(); // place Cards in random order

        // display all 52 Cards in the order in which they are dealt
        for (int i = 0; i < DeckOfCards.NUMBER_OF_CARDS / 5 + 1; i++)
        {
            myDeckOfCards.MakeStatistcs();
            Console.WriteLine(myDeckOfCards.HandToString());
            Console.WriteLine();
            Console.WriteLine($"Has 2 faces {(myDeckOfCards.HasCardsSameFace(2))}");
            Console.WriteLine($"Has 2 suits {(myDeckOfCards.HasCardsSameSuit(2))}");
            Console.WriteLine($"Has 2 plus faces {(myDeckOfCards.Has2Plus2Faces())}");
            Console.WriteLine($"Has 2 plus 2 suits {(myDeckOfCards.Has2Plus2Suits())}");
            Console.WriteLine();
        } // end for
    } // end Main
} // end class DeckOfCardsTest

