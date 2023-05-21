namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose (r)ock, (p)aper, (s)cissors");
            string playerInput = Console.ReadLine();
            bool isValidInput = true;

            while (playerInput != "stop")
            {
                //The code for which move the computer will choose
                string computerMove = "";

                Random random = new Random();
                int computerInput = random.Next(1, 4);

                switch (computerInput)
                {
                    case 1: computerMove = "Rock"; break;
                    case 2: computerMove = "Paper"; break;
                    case 3: computerMove = "Scissors"; break;
                }

                //The code for the player input
                string playerMove = "";

                switch (playerInput)
                {
                    case "Rock":
                    case "rock":
                    case "r":
                         playerMove = "Rock"; 
                         break;

                    case "Paper":
                    case "paper":
                    case "p":
                         playerMove = "Paper";
                         break;

                    case "Scissors":
                    case "scissors":
                    case "s":
                         playerMove = "Scissors";
                         break;

                    default: Console.WriteLine("Invalid input. Try again!");
                             isValidInput = false;
                             break; 
                }

                //The code that decides who is the winner
                if (playerMove == "Rock" && computerMove == "Scissors" ||
                    playerMove == "Paper" && computerMove == "Rock" ||
                    playerMove == "Scissors" && computerMove == "Paper")
                {
                    Console.WriteLine($"The computer chose: {computerMove}");
                    Console.WriteLine("You win !");
                }
                else if (playerMove == "Rock" && computerMove == "Paper" ||
                         playerMove == "Paper" && computerMove == "Scissors" ||
                         playerMove == "Scissors" && computerMove == "Rock")
                {
                    Console.WriteLine($"The computer chose: {computerMove}");
                    Console.WriteLine("You lose.");
                }
                else if (isValidInput)
                {
                    Console.WriteLine($"The computer chose: {computerMove}");
                    Console.WriteLine("Draw !");
                }

                isValidInput = true;
                Console.WriteLine("Choose (r)ock, (p)aper, (s)cissors");
                playerInput = Console.ReadLine();
            }
        }
    }
}