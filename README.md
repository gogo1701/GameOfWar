# Game Of War

`Game of War is a classic two-player card game brought to life as a console-based application. This project demonstrates the fundamentals of programming and game logic implementation in C#.`


## 🎯 Project Goals
- Implement a functional two-player card game.
- Use object-oriented programming principles such as classes, enumerations, and methods.
- Develop problem-solving skills through algorithm design and implementation.
- Practice working with data structures like lists and queues.


## 📜 Rules of the Game

**Setup:**

A standard deck of 52 cards is shuffled and divided equally between `two players.`
Each player `receives 26 cards` in their deck.

**Gameplay:**

- Each player `draws the top card` from their deck.
- The player with the `higher card value wins` the round and takes both cards.
- In case of a tie ***(WAR)*** (same card values):
- Each player places `three cards face down.`
- They then draw a fourth card face up to determine the winner.
- The `winner takes all the cards` on the table.

**Winning the Game:**

- The game continues until one player collects `all 52 cards.`
- If a player runs out of cards during a war, the other player wins by default.

**Card Hierarchy:**

- Cards are ranked from `lowest (2) to highest (Ace)`.
- Suits have no impact on card value.


## 🛠 Technologies Used
- **Programming Language:** *C#*, *MySQL*, *SQL* <br> 
- **Framework:** *.NET 6 Console-based App* <br>
- **Tools:** *Visual Studio*, *MAMP*
- **NuGet Packages:** *MySql.Data*


## 💻 Implementation Details
### Classes In GameLogic file:
- Card: Represents a single card with a face (e.g., Ace, King) and suit (e.g., Hearts, Spades).
### Enumerations In GameLogic file:
- CardFace: Defines the face values of cards (2 through Ace).
- CardSuit: Defines the four suits (Spades, Clubs, Hearts, Diamonds) using Unicode characters.
### Core Methods in GameLogic file:
- GenerateDeck: Creates a standard 52-card deck.
- ShuffleDeck: Randomizes the order of cards.
- DealCardsToPlayers: Distributes cards evenly to both players.
- GameHasWinner: Checks if one player has won the game.
- DrawPlayersCards: Simulates each player drawing a card from their deck.
- ProcessWar: Handles the "war" scenario when cards are tied.
- DetermineRoundWinner: Determines the winner of each round and allocates cards accordingly.
### Other Classes
- DrawCardClass: Helps with the drawing of cards in console.
- UserDAO: Helps with connection to MySql database and CRUD operations related to it.

## 💪 Extra Functionality
This project also includes a profile system, where players have profiles and can see how much games they have won/lost. This is a scheme of how the connection works. <br>
![gameofwarDAo drawio](https://github.com/user-attachments/assets/34fb4cea-ae9a-49e0-a21f-8c90d44ca747)

## 🚀 How to Play
- Clone the repository and open the project in Visual Studio.
- Follow instructions on how to run the DB (found in DB folder).
- Run the game 
- Follow the console prompts to play the game:
- Press Enter to draw a card for each turn.
- The game announces the winner of each round.
- Continue playing until one player wins.

