﻿using GameOfWar;
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
|| + Both cards return to the winner&#39;s deck.                              ||
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

List<Card> deck = GenerateDeck();

ShuffleDeck();

Queue<Card> firstPlayerDeck = new Queue<Card>();
Queue<Card> secondPlayerDeck = new Queue<Card>();

DealCardsToPlayers();

Card firstPlayerCard;
Card secondPlayerCard;

int totalMoves = 0;

while(!GameHasWinner())
{
    Console.ReadLine();

    DrawPlayersCards();

    Queue<Card> pool = new Queue<Card>();

    pool.Enqueue(firstPlayerCard);
    pool.Enqueue(secondPlayerCard);


    ProcessWar(pool);
    DetermineRoundWinner(pool);

    Console.WriteLine("==================================================================");
    Console.WriteLine($"First player currently has {firstPlayerDeck.Count} cards.");
    Console.WriteLine($"Second player currently has {secondPlayerDeck.Count} cards.");
    Console.WriteLine("==================================================================");
}

void ShuffleDeck(List<Card> deck)
{
    Random random = new Random();

    for(int i = 0; i < deck.Count; i++)
    {
        int firstCardIndex = random.Next(deck.Count);

        Card tempCard = deck[firstCardIndex];
        deck[firstCardIndex] = deck[i];
        deck[i] = tempCard;
    }
}

void DealCardsToPlayers()
{
    while(deck.Count > 0)
    {
        Card[] firstTwoDrawnCards = deck.Take(2).ToArray();

        firstPlayerDeck.Enqueue(firstTwoDrawnCards[0]);
        secondPlayerDeck.Enqueue(firstTwoDrawnCards[0]);
    }
}

bool GameHasWinner()
{
    if (!firstPlayerDeck.Any())
    {
        Console.WriteLine($"After a total of {totalMoves} moves, the second player has won!");
        return true;
    }
    if (!secondPlayerDeck.Any())
    {
        Console.WriteLine($"After a total of {totalMoves} moves, the first player has won!");
        return true;
    }
    return false;

}

void DrawPlayersCards()
{
    firstPlayerCard = firstPlayerDeck.Dequeue();
    Console.WriteLine($"First player has drawn: {firstPlayerCard}");
    secondPlayerCard = secondPlayerDeck.Dequeue();
    Console.WriteLine($"Second player has drawn: {secondPlayerCard}");

}

void AddCardsToWinnerDeck(Queue<Card> loserDeck, Queue<Card> winnerDeck)
{
    while(loserDeck.Count > 0)
    {
        winnerDeck.Enqueue(loserDeck.Dequeue());
    }
}

void AddWarCardsToPool(Queue<Card> pool)
{
    for(int i =0; i < 3; i++)
    {
        pool.Enqueue(firstPlayerDeck.Dequeue());
        pool.Enqueue(secondPlayerDeck.Dequeue());
    }
}

void DetermineRoundWinner(Queue<Card> pool)
{
    if((int)firstPlayerCard.Face > (int)secondPlayerCard.Face)
    {
        Console.WriteLine("The first player has won the cards!");
    
        foreach (var card in pool)
        {
            firstPlayerDeck.Enqueue(card);
        }
    }
    else
    {
        Console.WriteLine("The second player has won the cards!");
        
        foreach(var card in pool)
        {
            secondPlayerDeck.Enqueue(card);
        }
    }
}