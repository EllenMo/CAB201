using System.Drawing;
using System.ComponentModel;
using Object_Classes;


namespace Game_Logic_Class
{
    public static class SpaceRaceGame
    {
        // Minimum and maximum number of players.
        public const int MIN_PLAYERS = 2;
        public const int MAX_PLAYERS = 6;
   
        private static int numberOfPlayers = 2;  //default value for test purposes only 
        public static int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
            set
            {
                numberOfPlayers = value;
            }
        }

        public static string[] names = { "One", "Two", "Three", "Four", "Five", "Six" };  // default values
        
        // Only used in Part B - GUI Implementation, the colours of each player's token
        private static Brush[] playerTokenColours = new Brush[MAX_PLAYERS] { Brushes.Yellow, Brushes.Red,
                                                                       Brushes.Orange, Brushes.White,
                                                                      Brushes.Green, Brushes.DarkViolet};
        /// <summary>
        /// A BindingList is like an array which grows as elements are added to it.
        /// </summary>
        private static BindingList<Player> players = new BindingList<Player>();
        public static BindingList<Player> Players
        {
            get
            {
                return players;
            }
        }

        // The pair of die
        private static Die die1 = new Die(), die2 = new Die();
       

        /// <summary>
        /// Set up the conditions for this game as well as
        ///   creating the required number of players, adding each player 
        ///   to the Binding List and initialize the player's instance variables
        ///   except for playerTokenColour and playerTokenImage in Console implementation.
        ///   
        ///     
        /// Pre:  none
        /// Post:  required number of players have been initialsed for start of a game.
        /// </summary>
        public static void SetUpPlayers(int numberOfPlayers, string[] names) 
        {
            for (int i = 0; i < numberOfPlayers; i++) { // for number of players
                string playerName = names[i];

                //create a new player object
                Player player = new Player(playerName);

                //initialize player's instance variables for start of a game
                player.Position = 0;
                player.Location = Board.Squares[0];
                player.SquaresToMove = 0;
                player.RocketFuel = Player.INITIAL_FUEL_AMOUNT;
                player.HasPower = true;
                player.AtFinish = false;

                //add player to the binding list
                Players.Add(player);
            } 
                
        }//end SetUpPlayers

        /// <summary>
        ///  Plays one round of a game
        /// </summary>
        public static void PlayOneRound(){
            //initialise die
            Die d1 = new Die();
            Die d2 = new Die();

            for (int i = 0; i < Players.Count; i++) {               

                //player.play method if players arent on last square or out of fuel
                if (Players[i].AtFinish == false) {
                    if (Players[i].RocketFuel != 0) {
                        Players[i].Play(d1, d2);
                    }
                }
               
            }//end for


        }//end PlayOneRound

    }//end SpaceRaceGame
}