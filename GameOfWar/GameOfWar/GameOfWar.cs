using GameOfWar;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine(@"
================================================================================
|| Welcome to the Game of War!                                                ||
||                                                                            ||
|| HOW TO PLAY:                                                               ||
|| + Each of the two players are dealt one half of a shuffled deck of cards.  ||
|| + Each turn, each player draws one card from their deck.                   ||
|| + The player that drew the card with higher value gets both cards.         ||
|| + Both cards return to the winners deck.                                   ||
|| + If there is a draw, both players place the next three cards face down    ||
|| and then another card face-up. The owner of the higher face-up             ||
|| card gets all the cards on the table.                                      ||
||                                                                            ||
|| HOW TO WIN:                                                                ||
|| + The player who collects all the cards wins.                              ||
||                                                                            ||
|| CONTROLS:                                                                  ||
|| + Press [Enter] to draw a new card until we have a winner.                 ||
||                                                                            ||
|| Have fun!                                                                  ||
================================================================================");


GameLogic gameLogic = new GameLogic();

List<Card> deck = gameLogic.GenerateDeck();

gameLogic.ShuffleDeck(ref deck);

Queue<Card> firstPlayerDeck = new Queue<Card>();
Queue<Card> secondPlayerDeck = new Queue<Card>();

gameLogic.DealCardsToPlayers(ref deck, ref firstPlayerDeck, ref secondPlayerDeck);

Card firstPlayerCard = null;
Card secondPlayerCard = null;

int totalMoves = 0;

while(!gameLogic.GameHasWinner(ref firstPlayerDeck,ref secondPlayerDeck,ref totalMoves))
{
    Console.ReadLine();
    Console.Clear();

    gameLogic.DrawPlayersCards(ref firstPlayerCard, ref secondPlayerCard, ref firstPlayerDeck, ref secondPlayerDeck);

    Queue<Card> pool = new Queue<Card>();

    pool.Enqueue(firstPlayerCard);
    pool.Enqueue(secondPlayerCard);


    gameLogic.ProcessWar(ref pool, ref firstPlayerCard, ref secondPlayerCard, ref firstPlayerDeck, ref secondPlayerDeck);
    gameLogic.DetermineRoundWinner(pool, ref firstPlayerCard, ref secondPlayerCard, ref firstPlayerDeck, ref secondPlayerDeck);

    Console.WriteLine("==================================================================");
    Console.WriteLine($"First player currently has {firstPlayerDeck.Count} cards.");
    Console.WriteLine($"Second player currently has {secondPlayerDeck.Count} cards.");
    Console.WriteLine("==================================================================");

    totalMoves++;
}


