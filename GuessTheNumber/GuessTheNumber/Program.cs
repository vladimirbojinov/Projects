namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            int attempts = 0;

            Console.Write("Guess The number from 1 - 100: ");
            int playerInput = int.Parse(Console.ReadLine());

            while (playerInput != randomNumber)
            {
                if (playerInput > randomNumber)
                {
                    Console.WriteLine("Too Hight");
                }
                else
                {
                    Console.WriteLine("Too Low");
                }

                Console.Write("Guess The number from 1 - 100: ");
                playerInput = int.Parse(Console.ReadLine());
                attempts++;
            }

            if (playerInput == randomNumber)
            {
                Console.WriteLine("Good job you guessed the number !");
                Console.WriteLine($"Number of attempts {attempts}");
            }
        }
    }
}