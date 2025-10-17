namespace GameOfWar
{
    public class Card
    {

        // Create a string property Suit with a private setter
        public string Suit { get; private set; }


        // Create an int property Rank with a private setter - values should range from 0 for a face value of 2 to 12 for an Ace
        public int Rank { get; private set; }


        // Create a public constructor that takes suit and rank as arguments and assigns them to Suit and Rank
        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }


        // Overload the > operator to compare two cards by rank
        public static bool operator > (Card card1, Card card2)
        {
            return card1.Rank > card2.Rank;
        }


        // Overload the < operator to compare two cards by rank
        public static bool operator < (Card card1, Card card2)
        {
            return card1.Rank < card2.Rank;
        }


        // Create a public string method RankString that returns a string representation of this card's rank, 2-10 and Jack, Queen, King, Ace
        public string RankString()
        {
            return Deck.RankNames[Rank];
        }
    }
}