using System;
using System.Collections.Generic;
//DO NOT DELETE the two following using statements *********************************
using Game_Logic_Class;
using Object_Classes;


namespace Space_Race
{
    class Console_Class
    {
        /// <summary>
        /// Algorithm below currently plays only one game
        /// 
        /// when have this working correctly, add the abilty for the user to 
        /// play more than 1 game if they choose to do so.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // initialise values
            string playGame = "Y";
            int numberOfPlayers;

            DisplayIntroductionMessage();

            //Set up the board in Board class (Board.SetUpBoard)
            Board.SetUpBoard();

            //Determine number of players - initally play with 2 for testing purposes
            numberOfPlayers = PromptForPlayers();
            SpaceRaceGame.SetUpPlayers();

            // loop through multiple games if the user wants to play multiple
            while (playGame == "Y" || playGame == "y") {

                // initialise counters
                int roundNumber = 0;
                bool nextround = true;
                bool winnerExists = false;
                

                PressEnterRound(nextround);

                    // while no one has finished the game
                    while (nextround && !winnerExists) {
                        // add one to round counter
                        roundNumber++;

                        //play the round and display results
                        SpaceRaceGame.PlayOneRound();
                        DisplayRoundResults(roundNumber);

                        //prompt user to add input for next round
                        PressEnterRound(nextround);                       

                        //check if anyone has won
                        winnerExists = WinnerExists();
                        CheckFuel();
                        

                    }//end round while


                //output winner details
                DisplayWinners();
                //output player details
                DisplayGameResults();
                //check for continuation
                PressEnterContinue();
                // ask user if they want to play another game
                playGame = PromptForNewGame();

                if (playGame == "Y" || playGame == "y") {

                    //clear players list
                    SpaceRaceGame.Players.Clear();

                    //Determine number of players - initally play with 2 for testing purposes
                    numberOfPlayers = PromptForPlayers();

                    // Create the required players in Game Logic class and initialize players 
                    //for start of a game                    
                    SpaceRaceGame.SetUpPlayers();

                } else {
                    //display exit message
                    PressEnterTerminate();
                }               

            }// end game while           
           
            

        }//end Main

   
        /// <summary>
        /// Display a welcome message to the console
        /// Pre:    none.
        /// Post:   A welcome message is displayed to the console.
        /// </summary>
        static void DisplayIntroductionMessage()
        {
            Console.WriteLine("Welcome to Space Race.\n");
        } //end DisplayIntroductionMessage



    
        //####################################################//
        //the following method has been added by Ellen Morwitch
        ///<summary>
        /// Displays a prompt for the number of players and waits for a response.
        /// Pre:  none
        /// Post: the required number of players is set up and initialized for the start of a game.
        /// </summary>
        static int PromptForPlayers() {

            //display message to user
            Console.WriteLine("\tThis game is for 2 to 6 players.\n\tHow many players (2-6): ");
            string numPlayers = Console.ReadLine();

            //check user input
            while(int.TryParse(numPlayers, out int numOfPlayers) == false || 
                int.Parse(numPlayers)< 2 || int.Parse(numPlayers)> 6) 
            {
                Console.WriteLine("\tThat is not a valid entry, please enter a number between 2 and 6: ");
                numPlayers = Console.ReadLine();
            } 
             int numberOfPlayers = int.Parse(numPlayers);
            
            return numberOfPlayers;

        }//end PromptForPlayers

        

        //####################################################
        // The following method has been added by Ellen Morwitch
        /// <summary>
        /// Displays the results of a round.
        /// Pre:  a round of the game has been played
        /// Post: the results are displayed.
        /// </summary>
        static void DisplayRoundResults(int roundnumber) {

            int numberOfPlayers = SpaceRaceGame.Players.Count;
            // display round title
            if (roundnumber == 1) {
                Console.WriteLine("\n\tFirst Round\n");
            } else {
                Console.WriteLine("\n\tNext Round\n");
            }
            

            for (int numplayers = 0; numplayers < numberOfPlayers; numplayers++) {
                
                Console.WriteLine("\t" +SpaceRaceGame.Players[numplayers].Name +
                    " on square "+ SpaceRaceGame.Players[numplayers].Location.Name +
                    " with " + SpaceRaceGame.Players[numplayers].RocketFuel + 
                    " yottawatt of power remaining");
            }//end for    
            

        }//end DisplayRoundResults




        //####################################################
        // The following method has been added by Ellen Morwitch
        /// <summary>
        /// Checks if there is a winner in this round.
        /// Pre:  a round of the game has been played
        /// Post: it has been determined whether there is a winner in the round.
        /// </summary>
        static bool WinnerExists() {
            int numberOfPlayers = SpaceRaceGame.Players.Count;
            bool winnerExists = false;

            for (int numplayers = 0; numplayers < numberOfPlayers; numplayers++) {
                if (SpaceRaceGame.Players[numplayers].AtFinish) {
                    winnerExists = true;
                }
            }//end for

            return winnerExists;
        }//end WinnerExists


        //####################################################
        // The following method has been added by Ellen Morwitch
        /// <summary>
        /// Checks that at least one player still has fuel left.
        /// Pre:  a number of rounds have been played
        /// Post: a message is displayed if no players have fuel left.
        /// </summary>
        static void CheckFuel() {
            int numPlayers = SpaceRaceGame.Players.Count;
            List<bool> anyFuelLeft = new List<bool>(numPlayers);

            for (int numplayer = 0; numplayer > numPlayers; numplayer++) {
                if (SpaceRaceGame.Players[numplayer].RocketFuel != 0) {
                    anyFuelLeft[numplayer] = true;
                } else {
                    anyFuelLeft[numplayer] = false;
                }//end if else                
            }//end for

            if (!anyFuelLeft.Contains(true)) {
                Console.WriteLine("All players have run out of fuel.");
            }
            
        }//end CheckFuel



        //####################################################
        // The following method has been added by Ellen Morwitch
        /// <summary>
        /// Displays the winner/s of the game.
        /// Pre:  a game has been played
        /// Post: the winner/s are displayed.
        /// </summary>
        static void DisplayWinners() {

            int numberOfPlayers = SpaceRaceGame.Players.Count;
            string winners = "";

            // display player results
            for (int numplayers = 0; numplayers < numberOfPlayers; numplayers++) {
                if (SpaceRaceGame.Players[numplayers].AtFinish) {
                    winners = winners + SpaceRaceGame.Players[numplayers].Name + ", ";
                }
            }//end for    
            Console.WriteLine("\tThe follwing player(s) finished the game:");
            Console.WriteLine("\t\t" +winners);

        }//end DisplayWinners




        //####################################################
        // The following method has been added by Ellen Morwitch
        /// <summary>
        /// Displays the results of a game.
        /// Pre:  a game has been played
        /// Post: the results are displayed.
        /// </summary>
        static void DisplayGameResults() {

            int numberOfPlayers = SpaceRaceGame.Players.Count;
            Console.WriteLine("\tIndividual players finished with the amount of fuel at the locations specified:");

            // display player results
            for (int numplayers = 0; numplayers < numberOfPlayers; numplayers++) {
                Console.WriteLine("\t" +SpaceRaceGame.Players[numplayers].Name +
                    " with " + SpaceRaceGame.Players[numplayers].RocketFuel +
                    " yottawatt of power remaining" +
                    " at square " + SpaceRaceGame.Players[numplayers].Location.Name);
            }//end for    

            

        }//end DisplayGameResults


        //####################################################//
        //the following method has been added by Ellen Morwitch
        ///<summary>
        /// Asks user if they want to play another game.
        /// Pre:  a game has been played
        /// Post: a new game is started.
        /// </summary>
        static string PromptForNewGame() {

            //display message to user
            Console.WriteLine("\tAnother game? (Y or N):");
            string newGame = Console.ReadLine();
            return newGame;

        }//end PromptForPlayers

        //####################################################//
        //the following method has been added by Ellen Morwitch
        /// <summary>
        /// Prompts user for a keypress to play round.
        /// Pre:  none
        /// Post: a key has been pressed.
        /// </summary>
        static bool PressEnterRound(bool nextround) {

            Console.Write("\nPress Enter to play a round ...");
            //checking for input and changing nextround value to match
            ConsoleKeyInfo _Key = Console.ReadKey();
            switch (_Key.Key) {
                case ConsoleKey.Enter:
                    nextround = true;
                    break;
            }
            return nextround;
        } // end PressEnterRound


        //####################################################//
        //the following method has been added by Ellen Morwitch
        /// <summary>
        /// Prompts user for a keypress to continue.
        /// Pre:  game info is displayed
        /// Post: user has pressed enter.
        /// </summary>
        static void PressEnterContinue() {
            Console.Write("\nPress Enter to continue ...");
            Console.ReadLine();
        } // end PressEnterContinue

        //####################################################//
        //the following method has been altered by Ellen Morwitch
        /// <summary>
        /// Displays closing message and waits for a keypress.
        /// Pre:  none
        /// Post: a key has been pressed.
        /// </summary>
        static void PressEnterTerminate()
        {
            Console.WriteLine("\tThanks for playing Space Race.");
            Console.Write("\n\tPress Enter to terminate program ...");
            Console.ReadLine();
        } // end PressEnterTerminate



    }//end Console class
}
