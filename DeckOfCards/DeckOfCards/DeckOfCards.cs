// Fig. 8.10: DeckOfCards.cs
// DeckOfCards class represents a deck of playing cards.
using System;
using System.Runtime.Serialization.Formatters;

public class DeckOfCards
{
   private Card[] deck; 
   private int currentCard; // index of next Card to be dealt
   public const int NUMBER_OF_CARDS = 52; 
   private Random randomNumbers; 

    private int[]  faceCounters;
    private int[]  suitCounters;
    private Card[] hand;

    #region Constructors
    public DeckOfCards()
    {
        faceCounters = new int[Card.faces.Length];
        suitCounters = new int[Card.suits.Length];
        hand = new Card[5] ;

        deck = new Card[NUMBER_OF_CARDS]; 
        currentCard = 0;  
        randomNumbers = new Random(); 

        // populate deck with Card objects
        for (int count = 0; count < deck.Length; count++)
            deck[count] = new Card(count % 13, count / 13);
    } 
    #endregion


    #region Utility methods
    public void Shuffle()
    {
        // after shuffling, dealing should start at deck[ 0 ] again
        currentCard = 0; 

        // for each Card, pick another random Card and swap them
        for (int first = 0; first < deck.Length; first++)
        {
            // select a random number between 0 and 51 
            int second = randomNumbers.Next(NUMBER_OF_CARDS);

            Card temp = deck[first];
            deck[first] = deck[second];
            deck[second] = temp;
        } 
    } 

    public Card DealCard()
    {
        if (currentCard < deck.Length)
            return deck[currentCard++]; 
        else
            return null; 
    } 


    // Initialize counterrs, deal hand and count face and suit occurences 
    public void MakeStatistcs()
    {   // Deal 5 cards
        DealHand();
        // initialize counters
        for (int i = 0; i < faceCounters.Length; i++)
        {
            faceCounters[i] = 0;
        }
        for (int i = 0; i < suitCounters.Length; i++)
        {
            suitCounters[i] = 0;
        }
        // count face and suit occurences in hand[]
        for (int i = 0; i < hand.Length; i++)
        {
            if (hand[i] != null)
            {
                ++faceCounters[hand[i].Face];
                ++suitCounters[hand[i].Suit];
            }
        } // faceCounters {0,0,3,1,0, 1,...}
    }
    public string HandToString()
    {
        string output = "";
        for (int i = 0; i < hand.Length; i++)
        {
            output += ((hand[i]!=null)?hand[i].ToString():" ") + " ";

        }
        return output;
        //return String.Join(" ", hand[0],hand[1], hand[2], hand[3],hand[4]);
    }
    public bool HasCardsSameFace(int occurence)
    {
        if (occurence <= 1 || occurence > 4) return false;
        for (int i = 0; i < faceCounters.Length; i++)
        {
            if (faceCounters[i] == occurence)
            {
                return true;
            }
        }
        return false;
    }
    public bool Has2Plus2Faces()
    {
        bool hasTwo = false;
        for (int i = 0; i < faceCounters.Length; i++)
        {
            if (faceCounters[i] == 2 && hasTwo) return true;// next two found, Success!
            else
                if(faceCounters[i] == 2) hasTwo = true; // first two found
        }
        return false;
    }
    public bool Has2Plus2Suits()
    {
        bool hasTwo = false;
        for (int i = 0; i < suitCounters.Length; i++)
        {
            if (suitCounters[i] == 2 && hasTwo) return true;// next two found, Success!
            else
                if (suitCounters[i] == 2) hasTwo = true; // first two found
        }
        return false;
    }
    public bool HasCardsSameSuit(int occurence)
    {
        if (occurence <= 1 || occurence > 5) return false;
        for (int i = 0; i < faceCounters.Length; i++)
        {
            if (faceCounters[i] == 2)
            {
                return true;
            }
        }
        return false;
    }
    private void DealHand()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i] = DealCard();
        }
    }
    #endregion

} 

 