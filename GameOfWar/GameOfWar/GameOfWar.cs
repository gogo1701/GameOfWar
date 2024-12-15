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

    string border = new string('*', 50);

    Console.WriteLine(border);
    Console.WriteLine("*                                                *");
    Console.WriteLine("*            Welcome to the Game Of War          *");
    Console.WriteLine("*                 Ultra Deluxe!                  *");
    Console.WriteLine("*                                                *");
    Console.WriteLine(border);
    Console.WriteLine("*                 Main Menu                      *");
    Console.WriteLine(border);
    Console.WriteLine();

    Console.WriteLine("Account Details:");
    Console.WriteLine("  [1] Login");
    Console.WriteLine("  [2] Register");
    Console.WriteLine("  [3] Logout");
    Console.WriteLine();
    Console.WriteLine("Play the Game:");
    Console.WriteLine("  [4] Play Game");
    Console.WriteLine();
    Console.WriteLine("More Options:");
    Console.WriteLine("  [5] See Statistics");
    Console.WriteLine("  [6] Exit");
    Console.WriteLine();

    Console.WriteLine(border);

    int input = int.Parse(Console.ReadLine());

    if (input > 6 || input < 1)
    {
        Console.Clear();
        Console.WriteLine("Input is NOT correct. Please enter 1,2,3,4,5 or 6.");
        Console.WriteLine("Press any key to continue.");

    }

    if (input == 1)
    {
        Console.Clear();
        Console.WriteLine("Please enter username and password.");
        Console.Write("Username:");
        string username = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Password:");
        string password = Console.ReadLine();
        Console.WriteLine();

        User newUser = userDAO.login(username, password);
        if (newUser != null)
        {
            userLoggined = newUser;
            Console.WriteLine("Login information correct! Welcome back! Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            continue;

        }
        else
        {
            Console.WriteLine("Login information is not correct. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            continue;
        }


    }
    else if (input == 2)
    {
        Console.Clear();
        string username = "nothing";
        string password = "nothing";

        Console.Write("What username would you like to have? :");
        username = Console.ReadLine();

        Console.Write("What password would you like to have? :");
        password = Console.ReadLine();

        User newUser = new User();

        newUser.Username = username;
        newUser.Password = password;
        newUser.winsGame = 0;
        newUser.losesGame = 0;

        int result = userDAO.signUp(newUser);

        if (result == 0)
        {
            Console.WriteLine("--------------------------------------------- ERROR -------------------------------------------------");
            Console.WriteLine("It seems there is already a user with this username. Please register again with a different username.");
            Console.WriteLine("Press any key to continue.");
        }
        else
        {
            Console.WriteLine("Account created sucessfully. Please press any key to continue.");
        }

        Console.ReadKey();
        Console.Clear();
    }
    else if (input == 3)
    {
        if (userLoggined == null)
        {
            Console.WriteLine("There is no account logged in. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            userLoggined = null;
            Console.WriteLine("Account logged out. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
    else if (input == 4 && userLoggined != null)
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

        while (!gameLogic.GameHasWinner(ref firstPlayerDeck, ref secondPlayerDeck, ref totalMoves, ref userLoggined))
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
    }
    else if (input == 5 && userLoggined != null) 
    {
        Console.Clear(); 

        string border1 = new string('*', 40); 

        Console.WriteLine(border1);
        Console.WriteLine("*" + new string(' ', 38) + "*");
        Console.WriteLine("* Statistics for user: " + userLoggined.Username.PadRight(18) + "*");
        Console.WriteLine("*" + new string(' ', 38) + "*");
        Console.WriteLine("* Wins: " + userLoggined.winsGame.ToString().PadRight(30) + "*");
        Console.WriteLine("* Loses: " + userLoggined.losesGame.ToString().PadRight(29) + "*");
        Console.WriteLine("*" + new string(' ', 38) + "*");
        Console.WriteLine(border1);

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        Console.Clear();


    }else if(input == 6)
    {
        Console.Clear();
        Console.WriteLine("Thank you for playing! Have a great day!");
        break;
    }
    else if (userLoggined == null)
    {
        Console.WriteLine("Either your input is invalid or you are trying to enter the game without having logged on. Please log in or try again. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }


}


