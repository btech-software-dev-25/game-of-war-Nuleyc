using System.Runtime.InteropServices;
using GameOfWar;

// Create an instance of the GameState class
GameState state = new
GameState();
// Shuffle CardDeck within your instance
state.CardDeck.Shuffle();
// Deal 26 cards each from CardDeck to your instance's PlayerDeck and ComputerDeck
state.PlayerDeck.PushCards(state.CardDeck.Deal(26));
state.ComputerDeck.PushCards(state.CardDeck.Deal(26));


// Create a function with the signature: static bool PlayCards(GameState state, int playerCardIndex)
static bool PlayCards(GameState state, int playerCardIndex)
{

    // The function should:
    //     Pull the card at playerCardIndex from state.PlayerDeck
    Card playerCard = state.PlayerDeck.PullCardAtIndex(playerCardIndex);
    //     Pull the card at index 0 from state.ComputerDeck
    Card computerCard = state.ComputerDeck.PullCardAtIndex(0);
    //     Compare the two cards
    if (playerCard > computerCard)
    {
        //         If the player card is higher, the player gets both cards along with any in state.TableDeck
        state.PlayerDeck.PushCard(playerCard);
        state.PlayerDeck.PushCard(computerCard);

        if (state.TableDeck.Count > 0)
        {
            state.PlayerDeck.PushCards(state.TableDeck.PullAllCards());
        }
        Console.WriteLine("You win this round!");
    }
    else if (computerCard > playerCard)
    {
        //         If the computer card is higher, the computer gets both cards along with any in state.TableDeck
        state.ComputerDeck.PushCard(playerCard);

        state.ComputerDeck.PushCard(computerCard);

        if (state.TableDeck.Count > 0)
        {
            state.ComputerDeck.PushCards(state.TableDeck.PullAllCards());
        }

        Console.WriteLine("Computer wins this round!");
    }
    else
    {
        //         If the player and computer cards are the same, both cards go into state.TableDeck
        state.TableDeck.PushCard(playerCard);
        state.TableDeck.PushCard(computerCard);
        Console.WriteLine("War! Cards added to the table deck.");
    }
    //     Check whether either state.PlayerDeck or state.ComputerDeck are empty
    if (state.ComputerDeck.Count == 0)
    {
        //         If the computer deck is empty, the player wins and state.Winner should be set to "Computer"
        state.Winner = "Player";
    }
    else if
    (state.PlayerDeck.Count == 0)
    {
        //         If the player deck is empty, the computer wins and state.Winner should be set to "Player"
        state.Winner = "Computer";
    }


    return true;
}


// Call Lib.RunGame(), passing two parameters: the state object you instantiated above and the name of your PlayCards function
Lib.RunGame(state, PlayCards);
