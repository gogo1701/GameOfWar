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
- **Programming Language:** *C#* <br> 
- **Framework:** *.NET 6 (Long Term Support)* <br>
- **Tools:** *Visual Studio*


## 💻 Implementation Details
Classes and Enumerations
Card: Represents a single card with a face (e.g., Ace, King) and suit (e.g., Hearts, Spades).
Enumerations:
CardFace: Defines the face values of cards (2 through Ace).
CardSuit: Defines the four suits (Spades, Clubs, Hearts, Diamonds) using Unicode characters.
Core Methods
GenerateDeck: Creates a standard 52-card deck.
ShuffleDeck: Randomizes the order of cards.
DealCardsToPlayers: Distributes cards evenly to both players.
GameHasWinner: Checks if one player has won the game.
DrawPlayersCards: Simulates each player drawing a card from their deck.
ProcessWar: Handles the "war" scenario when cards are tied.
DetermineRoundWinner: Determines the winner of each round and allocates cards accordingly.


## 🚀 How to Play
- Clone the repository and open the project in Visual Studio.
- Run the game 
- Follow the console prompts to play the game:
- Press Enter to draw a card for each turn.
- The game announces the winner of each round.
- Continue playing until one player wins.




## 🔗 Links
**Replit Link:**
**Source Code:** 

