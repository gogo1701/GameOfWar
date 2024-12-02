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




List<Card> GenerateDeck()
{
    List<Card> deck = new List<Card>();
    CardFace[] faces = (CardFace[])Enum.GetValues(typeof(CardFace));
    CardSuit[] suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));

    for (int suite = 0; suit < suits.Lenght; suite++)
    {
        for(int face = 0; face < faces.Lenght; face++)
        {
            CardFace currentFace = faces[face];
            CardSuit currentSuit = suits[suite];
            deck.Add(new Card
            {
                Face = currentFace,
                Suite = currentSuit

            });
        }
    }
    return deck;
}

void ProcessWar(Queue<Card> pool)
{
    while ((int)firstPlayerCard.Face == (int)secondPlayerCard.Face)
    {
        Console.WriteLine("WAR!");

        if (firstPlayerDeck.Count < 4)
        {
            AddCardsToWinnerDeck(firstPlayerDeck, secondPlayerDeck);
            Console.WriteLine($"First player does not have enough cards to contunue playing...");
            break;
        }
        if (secondPlayerDeck.Count < 4)
        {
            AddCardsToWinnerDeck(secondPlayerDeck, firstPlayerDeck);
            Console.WriteLine($"Second player does not have enough cards to contunue playing...");
            break;
        }

        AddWarCardsToPool(pool);

        firstPlayerCard = firstPlayerDeck.Dequeue();
        Console.WriteLine($"First player has drawn: {firstPlayerCard}");

        secondPlayerCard = secondPlayerDeck.Dequeue();
        Console.WriteLine($"Second player has drawn: {secondPlayerCard}");

        pool.Enqueue(firstPlayerCard);
        pool.Enqueue(secondPlayerCard);

    }
}