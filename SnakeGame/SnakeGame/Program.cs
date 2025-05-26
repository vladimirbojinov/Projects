namespace SnakeGame;

internal class Program
{
	static void Main()
	{
		Console.CursorVisible = false;
		string message =
			"""
			TO MOVE USE ( W S A D ) OR THE ARROWS
			PRESS ANY KEY TO START
			""";

		Console.WriteLine(message);

		GameEngine gameEngine = new();
		while (Console.ReadKey(true).Key != ConsoleKey.Escape)
		{
			gameEngine.Run(10, 30);
			Console.Clear();
			message =
				"""
				GAME OVER !
				IF YOU WISH TO END PRESS ( ESC )
				OR ANY BUTTON TO CONTINUE...
				""";
			Console.WriteLine(message);
		}
	}	
}
