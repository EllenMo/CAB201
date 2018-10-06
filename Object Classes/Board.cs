using System.Diagnostics;

namespace Object_Classes {
	/// <summary>
	/// Models a game board for Space Race consisting of three different types of squares
	/// 
	/// Ordinary squares, Wormhole squares and Blackhole squares.
	/// 
	/// landing on a Wormhole or Blackhole square at the end of a player's move 
	/// results in the player moving to another square
	/// 
	/// </summary>
	/// 


	public static class Board {
		/// <summary>
		/// Models a game board for Space Race consisting of three different types of squares

		/// Ordinary squares, Wormhole squares and Blackhole squares.
		/// 
		/// landing on a Wormhole or Blackhole square at the end of a player's move 
		/// results in the player moving to another square
		/// 
		/// 
		/// </summary>

		public const int NUMBER_OF_SQUARES = 56;
		public const int START_SQUARE_NUMBER = 0;
		public const int FINISH_SQUARE_NUMBER = NUMBER_OF_SQUARES - 1;

		private static Square[] squares = new Square[NUMBER_OF_SQUARES];

		static int status = 0; // store the status of the squares 1 = normal 2= blackhole and 3=wormhole

		// static int[] board = new int[NUMBER_OF_SQUARES];


		public static Square[] Squares {
			get {
				Debug.Assert(squares != null, "squares != null",
				   "The game board has not been instantiated");
				return squares;
			}
		}

		public static Square StartSquare {
			get {
				return squares[START_SQUARE_NUMBER];
			}
		}


		/// <summary>
		///  Eight Wormhole squares.
		///  
		/// Each row represents a Wormhole square number, the square to jump forward to and the amount of fuel consumed in that jump.
		/// 
		/// For example {2, 22, 10} is a Wormhole on square 2, jumping to square 22 and using 10 units of fuel
		/// 
		/// </summary>
		private static int[,] wormHoles =
		{
			{2, 22, 10}, //squares[1]
			{3, 9, 3},
			{5, 17, 6},
			{12, 24, 6},
			{16, 47, 15},
			{29, 38, 4},
			{40, 51, 5},
			{45, 54, 4}
		};

		/// <summary>
		///  Eight Blackhole squares.
		///  
		/// Each row represents a Blackhole square number, the square to jump back to and the amount of fuel consumed in that jump.
		/// 
		/// For example {10, 4, 6} is a Blackhole on square 10, jumping to square 4 and using 6 units of fuel
		/// 
		/// </summary>
		private static int[,] blackHoles =
		{
			{10, 4, 6},
			{26, 8, 18},
			{30, 19, 11},
			{35,11, 24},
			{36, 34, 2},
			{49, 13, 36},
			{52, 41, 11},
			{53, 42, 11}
		};


		/// <summary>
		/// Parameterless Constructor
		/// Initialises a board consisting of a mix of Ordinary Squares,
		///     Wormhole Squares and Blackhole Squares.
		/// 
		/// Pre:  none
		/// Post: board is constructed
		/// </summary>
		/// 
		//private static int[] board = {1,4,6,7,8,9,11,13,14,15,17,18,19,20,21,22,23,24,25,27,28,31,32,33,34,37,38,39,41,42,43,44,46,47,48,50,51,54,55,56, };  // normal squares stops at 56 (including 56)
		private static int[] board = new int[NUMBER_OF_SQUARES];
		static Board() {

			for (int i = 0; i < 55; i++) {
				board [i] = i;
			}

		}

	
	public static void SetUpBoard() {

            // Create the 'start' square where all players will start.
            squares[START_SQUARE_NUMBER] = new Square("Start", START_SQUARE_NUMBER);

			for (int i = 1; i<55; i++)
			{
				for (int j = 0; j<8; j++)
				{
					if (i == blackHoles[j, 0])
					{
						squares[i] = new BlackholeSquare("blackhole", i, blackHoles[j, 1], blackHoles[j, 2]);
					}

					if (i == wormHoles[j, 0])
					{
						squares[i] = new WormholeSquare("wormhole", i, wormHoles[j, 1], wormHoles[j, 2]);
					}


				}
			}

			for (int k = 0; k < squares.Length; k++)
			{
				if (squares[k] == null)
				{
					squares[k] = new Square("ordinary", k);    
				}
			}


			// Create the main part of the board, squares 1 .. 54
			//  CODE NEEDS TO BE ADDED HERE
			//
			//   Need to call the appropriate constructor for each square
			//       either new Square(...),  new WormholeSquare(...) or new BlackholeSquare(...)
			//

			// Create the 'finish' square.
			squares[FINISH_SQUARE_NUMBER] = new Square("Finish", FINISH_SQUARE_NUMBER);

	

		} // end SetUpBoard

        /// <summary>
        /// Finds the destination square and the amount of fuel used for either a 
        /// Wormhole or Blackhole Square.
        /// 
        /// pre: squareNum is either a Wormhole or Blackhole square number
        /// post: destNum and amount are assigned correct values.
        /// </summary>
        /// <param name="holes">a 2D array representing either the Wormholes or Blackholes squares information</param>
        /// <param name="squareNum"> a square number of either a Wormhole or Blackhole square</param>
        /// <param name="destNum"> destination square's number</param>
        /// <param name="amount"> amont of fuel used to jump to the deestination square</param>
        private static void FindDestSquare(int[,] holes, int squareNum, out int destNum, out int amount) {
            const int start = 0, exit = 1, fuel = 2;
            destNum = 0; amount = 0;

			// ammount is the fuelss

			//  CODE NEEDS TO BE ADDED HERE 
			//destNum = start +;
			destNum = Squares[squareNum-1].NextSquare().Number;

			if (Squares[squareNum-1].Name == "blackhole")
			{
				amount = holes[Squares[squareNum-1].Number, fuel];
			}

			if (Squares[squareNum-1].Name == "wormhole")
			{
				amount = holes[Squares[squareNum-1].Number, fuel];
			}

			if (Squares[squareNum-1].Name == "ordinary")
			{
				amount = 0;
			}


        } //end FindDestSquare



    } //end class Board
}
