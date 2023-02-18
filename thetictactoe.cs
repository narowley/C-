using System; //Using system class

namespace TicTacToe{
    class MyProgram{
        static bool game_end = false; // Boolean variable used to determine if game is ended or not
        static char[] board = {'0', '1', '2', '3','4','5','6','7','8','9'}; // Sets up board and items that will fill board
        static int player = 1; // Determines who turn it is. 1 - Player 1. 2 - Player 2
        static int choice; // Establishes variable that will determine who's turn it is
        static int winner = 0; // Determines who the winner is. 0 - Draw. 1 - Player 1. 2 - Player 2.

        static void Main(string [] args) { //Main function
            Console.Clear(); //Clears console and introduces player to game
            Console.WriteLine("Welcome to Tic Tac Toe! Player 1 is O and Player 2 is X.");
            Console.WriteLine("\n");
            Console.WriteLine("Please select which tile to fill in with correpsonding number");
            while (game_end == false){ //Loops through game process until the game is over
                PrintBoard(); //Displays board and current O's and X's
                TakeTurn(); //Player takes their turn. Will adapt based off current player
                WinCheck(); //Checks if the game has been won
            }
            PrintBoard(); // Prints board final time to show end board
            if (winner != 0){ // If the game isn't a draw, the game announces who won
                Console.WriteLine("Player {0} Wins!", winner);
            }
            else { //Announces the game is a draw
                Console.WriteLine("Draw! Better luck next time!");
            }
        }
        private static void PrintBoard(){ //Using refrences, the board is printed. The board adapts based off what has been filled in
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }
        private static void TakeTurn(){
            if (player == 1){ //Player 1
                while (true){ //Loops until player inputs valid number
                    Console.WriteLine("Player 1 Turn: Where would you like to place your O? ");
                    try{ //Uses try catch to guarantee that the user inputs only numbers between 1 and 9
                        choice = Convert.ToInt32(Console.ReadLine()); //User input. Converted from string to integer. If non-numeric number is inputed, error is raised and catch is used
                        if (board[choice] != 'X' && board[choice] != 'O'){ // Checks to make sure the space is empty
                            board[choice] = 'O'; // Replaces player's choice with 0
                            player = 2; //Sets it to player 2's turn
                            break; //Ends loop
                        }
                        else{
                            Console.WriteLine("That spot is already taken. Please choose another location."); //This is used in case the player's choice is already full
                        }
                    }
                    catch{
                        Console.WriteLine("Please enter a number from 1-9."); //Used in case input besides 1 or 9 is used
                    }
                }
            }
            else if (player == 2){ //Player 2 - Same as player 1 but with X instead of O
                while (true){
                    Console.WriteLine("Player 2 Turn: Where would you like to place your X? ");
                    try{
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (board[choice] != 'X' && board[choice] != 'O'){
                            board[choice] = 'X';
                            player = 1;
                            break;
                        }
                        else{
                            Console.WriteLine("That spot is already taken. Please choose another location.");
                        }
                    }
                    catch{
                        Console.WriteLine("Please enter a number from 1-9.");
                    }
                }
            }
        }
        private static void WinCheck(){ //Game checks 9 different possibilities for winning. If the first item in row, column, or diagonal matches the second and third, the WhoWon funciton is called.
            // The WhoWon checks to see who won based off the item in the first checked spot
            // Horizontal Line Check
            if (board[1] == board[2] && board[1] == board[3]){
                WhoWon(1);
            }
            else if (board[4] == board[5] && board[4] == board[6]){
                WhoWon(4);
            }
            else if (board[7] == board[8] && board[7] == board[9]){
                WhoWon(7);
            }
            // Vertical Line Check
            else if (board[1] == board[4] && board[1] == board[7]){
                WhoWon(1);
            }
            else if (board[2] == board[5] && board[2] == board[8]){
                WhoWon(2);
            }
            else if (board[3] == board[6] && board[3] == board[9]){
                WhoWon(3);
            }
            // Horizontal Line Check
            else if (board[1] == board[5] && board[1] == board[9]){
                WhoWon(1);
            }
            else if (board[3] == board[5] && board[3] == board[7]){
                WhoWon(3);
            }
            // Draw Check
            else if (board[1] != '1' && board[2] != '2' && board[3] != '3' && board[4] != '4' && board[5] != '5' && board[6] != '6' && board[7] != '7' && board[8] != '8' && board[9] != '9'){
                game_end = true;
                winner = 0;
            }
            // Else statement used if game isn't over
            else{
                game_end = false;
            }
        }
        private static void WhoWon(int check){ // Used to determine who won based off checked location
            game_end = true; // Ends game
            if (board[check] == 'X'){ //If checked location is X, player 2 wins
                winner = 2;
            }
            else if (board[check] == 'O'){ //If checked location is O, player 1 wins
                winner = 1;
            }
        }
    }
}