namespace GameOfWar
{
    public class GameState
    {
        
        public Deck CardDeck { get; set; }
        
        public Deck PlayerDeck { get; set; }
        
        public Deck ComputerDeck { get; set; }

        public Deck TableDeck { get; set; }

        public string Winner { get; set; }

        public GameState()
        {
            Winner = string.Empty;
            CardDeck = new Deck(null, false);
            PlayerDeck = new Deck(null, true);
            ComputerDeck = new Deck(null, true);
            TableDeck = new Deck(null, true);
        }
    }
}