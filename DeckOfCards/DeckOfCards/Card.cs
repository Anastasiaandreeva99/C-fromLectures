// Fig. 8.9: Card.cs
// Card class represents a playing card.
public class Card
{
    public static string[] faces = { "Ace", "Deuce", "Three", "Four", "Five", "Six",
         "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
    public static string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private int face; // face of card ("Ace", "Deuce", ...)
    private int suit; // suit of card ("Hearts", "Diamonds", ...)
    
    public Card(int cardFace, int cardSuit)
    {
        Face = cardFace;
        Suit = cardSuit;
    } 

    public int Face
    {
        get
        {
            return face;
        }
        private set
        {
            face = (value >= 0 && value <= faces.Length) ? value : 0;
        }
    }
    public int Suit
    {
        get
        {
            return suit;
        }
        private set
        {
            suit = (value >= 0 && value <= suits.Length) ? value : 0;
        }
    }

    public override string ToString()
    {
        return faces[face] + " of " + suits[suit];
    } 
} 

