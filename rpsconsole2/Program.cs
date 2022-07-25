using System;

namespace rpsconsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //Welcome message...
            Console.WriteLine("\t\tWelcome to your favorite game!\n\t\tThis is Rock Paper Scissors!");
            
            //Instructions to play... explanation of the game flow. which keys are used, etc
            Console.WriteLine("To play, press Enter.\n\n\tPress the number corresponding to Rock, Paper, or Scissors to make your choice.\nThe computer will make its choice and you will be notified as to the winner.");
            
            //(Unseen to the user) create some variables to store which choice the user made,
            //computer choice, computer wins, user wins, number of ties, player1 name (user), player2 name (computer for now)
            int computerChoice = 0;
            Random rand = new Random(); //the Random class gets us a pseudorandom decimal between 0 and 1.
            int player1Choice = 0;
            int player1Wins = 0;//how many rounds p1 has won
            int computerWins = 0;//how many rounds the computer has won
            int numberOfTies = 0;//how many ties
            int maxLength = 15;
            string player1Name = "";
            string computerName = "iMac";
            string player1Location = "";
            string player1ChoiceStr = "";
            string playAgain = "";
            bool successfulConversion = false;
            bool isTie = true;

            //Start the game by pressing Enter
            Console.Read();

            //Generate Computers name


            //Get the users name
            Console.WriteLine("What is your name?\n Please enter a name of 15 characters or less.");
            player1Name = Console.ReadLine();
            //Convert.ToVar(player1Name); did not use
            //var player1Name = "";did not use
            if (player1Name.Length > maxLength)
            {
                Console.WriteLine("Please enter a name that is less than 15 characters");
                player1Name = Console.ReadLine ();
            }

            Console.WriteLine("Where are you from?");
            player1Location = Console.ReadLine();

            Console.WriteLine("Welcome to R-P-S Game, {0} from {1}. I am {2}.", player1Name, player1Location, computerName);

            //this loop is for each beginning of a game
            while(true)
            {
        
             //If neither player has won at least 2 games
            while ((player1Wins < 2) || (computerWins < 2))
            {
                //a while loop to keep prompting the user for choice til there isn't a tie
                //while (isTie)
                //{
                
                
                 //Get the users choice
                 Console.WriteLine("Please enter....\n\t1 for Rock.\n\t2 for Paper.\n\t3 for Scissors.");
                 player1ChoiceStr = Console.ReadLine();
            
                 successfulConversion = Int32.TryParse(player1ChoiceStr, out player1Choice);
                 Console.WriteLine($"The number you inputted was {player1Choice}.");
 

                 //Get the computers random choice
                  computerChoice = rand.Next(3)+1;
                   Console.WriteLine($"The number {computerName} chose was {computerChoice}.");

                 //Evaluate the choices to determine the winner of the round.
                   if(player1Choice == computerChoice)
                   {
                       //tell them it was a tie and loop back up to the top to reprompt
                        Console.WriteLine($"This round was a tie!....Let's try again.");
                        numberOfTies++;//++ increments the int by exactly 1.
                        //isTie = true;
                    }
                    else if ((player1Choice == 1 && computerChoice == 3) || 
                                (player1Choice == 2 && computerChoice == 1) || 
                                 (player1Choice == 3 && computerChoice == 2))
                    {// if the user won
                        Console.WriteLine($"Congrats, {player1Name}, you won this round.");
                        player1Wins++;
                        //isTie = false;
                        Console.WriteLine($"\r\n{player1Name}:{player1Wins}");
                        Console.WriteLine($"\r\n{computerName}:{computerWins}");
                            if (player1Wins == 2 && computerWins < 2)
                            {
                            Console.WriteLine($"Congrats, {player1Name}! You won!");
                            isTie = false;
                            }
                            else if(computerWins == 2 && player1Wins < 2)
                            {
                            Console.WriteLine($"Sorry, {computerName} won this game.");
                            isTie = false;
                            }
                    }        
                    else
                    {// if the computer won
                        Console.WriteLine($"I'm sorry, {computerName} won this round.");
                        computerWins++;
                        //isTie = false;
                        Console.WriteLine($"\r\n{player1Name}:{player1Wins}");
                        Console.WriteLine($"\r\n{computerName}:{computerWins}");
                            if(computerWins == 2 && player1Wins < 2)
                            {
                            Console.WriteLine($"Sorry, {computerName} won this game.");
                            isTie = false;
                            }
                            else if(player1Wins == 2 && computerWins < 2)
                            {
                            Console.WriteLine($"Congrats, {player1Name}! You won!");
                            isTie = false;
                            }
                    //}
                    
                }

            }
                //Ask if they want to play again (if using rounds, each game would need to be stored.)
                Console.WriteLine($"Hey {player1Name}, would you like to play again\n\tEnter 'Y' to play again or 'N' to quit the program.");
                playAgain = Console.ReadLine();
                if (String.Equals("Y", playAgain, StringComparison.OrdinalIgnoreCase))
                {
                Console.WriteLine($"Great! Try again...");
                isTie = true;
                }
                else
                {
                //continue;//will end the current loop and immediately start the next iteration of the same loop.
                Console.WriteLine($"I'm sorry to see you go.... The Final Score:");
                Console.WriteLine($"\r\n{player1Name}: Won {player1Wins} rounds.");
                Console.WriteLine($"\r\n{computerName}: Won {computerWins} rounds.");
                break;
                }
            }
            }
        }
    }
    

            /**
            |   1 == rock
            |   2 == paper
            |   3 == scissors
            */

            //Tell them who won, if there is a winner
            //Ask to make another choice if it was a tie. (loop up to 'get the users choice')

 /*Update the tally for this gaming session of how many games the computer won and the user have won

            Tell the user the tally results as of now. (Keep the tally live til the user wants to quit)

            Quit if they don't want to play. loop up to begin again if they DO want to play again.

            **/

                       
            /*try
            {
            player1Choice = Int32.Parse(player1ChoiceStr);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"The parse method failed because {ex.Message}"); //this method to write to the console is string interpolation
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"The parse method failed because {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"The parse method failed because {ex.Message}");
            }*/