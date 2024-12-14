using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWar
{
    public class GameLogic
    {
        public void ShuffleDeck(ref List<Card> deck)
        {
            Random random = new Random();

            for (int i = 0; i < deck.Count; i++)
            {
                int firstCardIndex = random.Next(deck.Count);

                Card tempCard = deck[firstCardIndex];
                deck[firstCardIndex] = deck[i];
                deck[i] = tempCard;
            }
        }

        public void DealCardsToPlayers(ref List<Card> deck, ref Queue<Card> firstPlayerDeck, ref Queue<Card> secondPlayerDeck)
        {
            bool giveToFirstPlayer = true;
            while (deck.Any())
            {
                if (giveToFirstPlayer)
                {
                    firstPlayerDeck.Enqueue(deck[0]);
                }
                else
                {
                    secondPlayerDeck.Enqueue(deck[0]);
                }

                deck.RemoveAt(0);
                giveToFirstPlayer = !giveToFirstPlayer;
            }
        }


        public bool GameHasWinner(ref Queue<Card> firstPlayerDeck, ref Queue<Card> secondPlayerDeck, ref int totalMoves)
        {
            if (firstPlayerDeck.Count < 4)
            {
                Console.WriteLine($"After a total of {totalMoves} moves, the second player has won!");
                return true;
            }
            if (secondPlayerDeck.Count < 4)
            {
                Console.WriteLine($"After a total of {totalMoves} moves, the first player has won!");
                return true;
            }
            return false;

        }

        public void DrawPlayersCards(ref Card firstPlayerCard, ref Card secondPlayerCard, ref Queue<Card> firstPlayerDeck, ref Queue<Card> secondPlayerDeck)
        {

            firstPlayerCard = firstPlayerDeck.Dequeue();
            Console.WriteLine($"First player has drawn: {firstPlayerCard}");
            DrawCardClass.PrintCard(firstPlayerCard);

            secondPlayerCard = secondPlayerDeck.Dequeue();
            Console.WriteLine($"Second player has drawn: {secondPlayerCard}");
            DrawCardClass.PrintCard(secondPlayerCard);


        }

        public void AddCardsToWinnerDeck(Queue<Card> loserDeck, Queue<Card> winnerDeck)
        {
            while (loserDeck.Count > 0)
            {
                winnerDeck.Enqueue(loserDeck.Dequeue());
            }
        }

        public void AddWarCardsToPool(Queue<Card> pool, ref Queue<Card> firstPlayerDeck, ref Queue<Card> secondPlayerDeck)
        {
            for (int i = 0; i < 3; i++)
            {
                pool.Enqueue(firstPlayerDeck.Dequeue());
                pool.Enqueue(secondPlayerDeck.Dequeue());
            }
        }

        public void DetermineRoundWinner(Queue<Card> pool, ref Card firstPlayerCard, ref Card secondPlayerCard, ref Queue<Card> firstPlayerDeck, ref Queue<Card> secondPlayerDeck)
        {
            if ((int)firstPlayerCard.Face > (int)secondPlayerCard.Face)
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

                foreach (var card in pool)
                {
                    secondPlayerDeck.Enqueue(card);
                }
            }
        }

        public List<Card> GenerateDeck()
        {
            List<Card> deck = new List<Card>();
            CardFace[] faces = (CardFace[])Enum.GetValues(typeof(CardFace));
            CardSuit[] suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));

            for (int suite = 0; suite < suits.Length; suite++)
            {
                for (int face = 0; face < faces.Length; face++)
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

        public void ProcessWar(ref Queue<Card> pool, ref Card firstPlayerCard, ref Card secondPlayerCard, ref Queue<Card> firstPlayerDeck, ref Queue<Card> secondPlayerDeck)
        {
            while ((int)firstPlayerCard.Face == (int)secondPlayerCard.Face)
            {
                Console.WriteLine("WAR!");

                if (firstPlayerDeck.Count < 4)
                {
                    Console.WriteLine("First player does not have enough cards to continue. Second player wins the game!");
                    secondPlayerDeck = new Queue<Card>(secondPlayerDeck.Concat(pool));
                    firstPlayerDeck.Clear();
                    return; // Exit war logic
                }

                if (secondPlayerDeck.Count < 4)
                {
                    Console.WriteLine("Second player does not have enough cards to continue. First player wins the game!");
                    firstPlayerDeck = new Queue<Card>(firstPlayerDeck.Concat(pool));
                    secondPlayerDeck.Clear();
                    return;
                }

                AddWarCardsToPool(pool, ref firstPlayerDeck,ref secondPlayerDeck);

                firstPlayerCard = firstPlayerDeck.Dequeue();
                secondPlayerCard = secondPlayerDeck.Dequeue();

                Console.WriteLine($"First player has drawn: {firstPlayerCard}");
                Console.WriteLine($"Second player has drawn: {secondPlayerCard}");

                pool.Enqueue(firstPlayerCard);
                pool.Enqueue(secondPlayerCard);
            }
        }

    }
}
