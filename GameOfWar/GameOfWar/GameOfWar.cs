using GameOfWar;
using Org.BouncyCastle.Bcpg;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;



GameLogic gameLogic = new GameLogic();
UserDAO userDAO = new UserDAO();

User userLoggined = null;

List<Card> deck = gameLogic.GenerateDeck();

gameLogic.ShuffleDeck(ref deck);

Queue<Card> firstPlayerDeck = new Queue<Card>();
Queue<Card> secondPlayerDeck = new Queue<Card>();

gameLogic.DealCardsToPlayers(ref deck, ref firstPlayerDeck, ref secondPlayerDeck);

Card firstPlayerCard = null;
Card secondPlayerCard = null;

int totalMoves = 0;


while (true)
{

    Console.WriteLine("Welcome to the Game Of War Ultra Deluxe!");
    Console.WriteLine("Please enter one of these options:");
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Register");
    Console.WriteLine("3. Play Game");

    int input = int.Parse(Console.ReadLine());

    while(input > 3)
    {
        Console.Clear();
        Console.WriteLine("Input is NOT correct. Please enter 1,2 or 3.");
        Console.WriteLine("Input: ");
        input = int.Parse(Console.ReadLine());
    }
    
    if(input == 1)
    {
        Console.WriteLine("Please enter username and password.");
        Console.Write("Username:");
        string username = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Password:");
        string password = Console.ReadLine();
        Console.WriteLine();

        User newUser = userDAO.login(username, password);
        if(newUser != null)
        {
            userLoggined = newUser;
            
        }
        else
        {
            Console.WriteLine("Login information is not correct. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            continue;
        }
        
    }
    else if(input == 2)
    {

    }
    else if(input == 3 && userLoggined != null)
    {
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

        while (!gameLogic.GameHasWinner(ref firstPlayerDeck, ref secondPlayerDeck, ref totalMoves, userLoggined))
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
    }else
    {

    }

    
}


