using System;
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
             DisplayIntroductionMessage();
            //Set up the board in Board class (Board.SetUpBoard)
            Board.SetUpBoard();

            //Determine number of players - initally play with 2 for testing purposes
            int numberOfPlayers = PromptForPlayers();

            // Create the required players in Game Logic class and initialize players 
            //for start of a game
            SpaceRaceGame.SetUpPlayers(numberOfPlayers, SpaceRaceGame.names);

            Console.WriteLine("\nPress Enter to play a round...");

            // while no one has finished the game
            int roundNumber = 0;
            for () {
                SpaceRaceGame.PlayOneRound();
                roundNumber++;

            }

            /*          
             loop  until game is finished           
                call PlayGame in Game Logic class to play one round
                Output each player's details at end of round
             end loop
             Determine if anyone has won
             Output each player's details at end of the game
           */
           
                
            PressEnter();

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
            Console.WriteLine("This game is for 2 to 6 players.\nHow many players (2-6): ");
            string numPlayers = Console.ReadLine();

            //check user input
            while(int.TryParse(numPlayers, out int numOfPlayers) == false || 
                int.Parse(numPlayers)< 2 || int.Parse(numPlayers)> 6) 
            {
                Console.WriteLine("That is not a valid entry, please enter a number between 2 and 6: ");
                numPlayers = Console.ReadLine();
            } 
             int numberOfPlayers = int.Parse(numPlayers);
            
            return numberOfPlayers;
        }//end PromptForPlayers






        /// <summary>
        /// Displays the results of a round.
        /// Pre:  a round of the game has been played
        /// Post: the results are displayed.
        /// </summary>
        static void DisplayRoundResults(int roundnumber) {
            int numberOfPlayers = SpaceRaceGame.Players.Count;
            //some way to convert the number to
            Console.WriteLine("\n\t{} Round\n");

            for (int numplayers = 0; numplayers < numberOfPlayers; numplayers++) {
                
                Console.WriteLine(SpaceRaceGame.Players[numplayers].Name +
                    " on square "+ SpaceRaceGame.Players[numplayers].Location +
                    " with " + SpaceRaceGame.Players[numplayers].RocketFuel + 
                    " yottawatt of power remaining");
            }//end for           
        }//end DisplayRoundResults





        /// <summary>
        /// Displays a prompt and waits for a keypress.
        /// Pre:  none
        /// Post: a key has been pressed.
        /// </summary>
        static void PressEnter()
        {
            Console.Write("\nPress Enter to terminate program ...");
            Console.ReadLine();
        } // end PressAny



    }//end Console class
}
