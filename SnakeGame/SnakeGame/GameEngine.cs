using System.Text;

namespace SnakeGame;

public class GameEngine()
{
	private static int points = 0;
	private static int frameUpdate = 300;

	private static char snakeChar = 'O';
	private static char foodChar = '*';
	private static char backgroundChar = ' ';
	private static char borderChar = '\u25a0';

	private static Dictionary<string, (int, int)> directionMap = new()
	{
		["up"] = (-1, 0),
		["down"] = (1, 0),
		["left"] = (0, -1),
		["right"] = (0, 1),
	};

	private static Dictionary<ConsoleKey, ConsoleKey> reverseKeyMap = new()
	{
		[ConsoleKey.UpArrow] = ConsoleKey.DownArrow,
		[ConsoleKey.DownArrow] = ConsoleKey.UpArrow,
		[ConsoleKey.LeftArrow] = ConsoleKey.RightArrow,
		[ConsoleKey.RightArrow] = ConsoleKey.LeftArrow,
		[ConsoleKey.W] = ConsoleKey.S,
		[ConsoleKey.S] = ConsoleKey.W,
		[ConsoleKey.A] = ConsoleKey.D,
		[ConsoleKey.D] = ConsoleKey.A,
	};

	private static HashSet<ConsoleKey> validKeys = new()
	{
		ConsoleKey.UpArrow,
		ConsoleKey.DownArrow,
		ConsoleKey.LeftArrow,
		ConsoleKey.RightArrow,
		ConsoleKey.W,
		ConsoleKey.S,
		ConsoleKey.A,
		ConsoleKey.D,
	};

	public void Run(int fieldRows, int fieldCols)
	{
		Console.CursorVisible = false;

		ConsoleKey currentKey = ConsoleKey.RightArrow;
		ConsoleKey lastKey = currentKey;

		PlayerField playerField = new(fieldRows, fieldCols);
		Player player = new();

		Console.Clear();
		playerField.Fill(backgroundChar, borderChar);

		foreach ((int, int) part in player.Body)
		{
			playerField.ChangeAt(part, snakeChar);
		}

		GenerateFood(playerField);
		while (true)
		{
			Console.SetCursorPosition(0, 0);

			if (Console.KeyAvailable)
			{
				currentKey = Console.ReadKey(true).Key;
				while (Console.KeyAvailable) Console.ReadKey(true);
			}

			if (!IsKeyValid(currentKey)) currentKey = lastKey;
			currentKey = PreventReverseDirection(lastKey, currentKey);

			if (!MoveLogic(player, playerField, currentKey)) break;

			playerField.ConsolePrint();
			MenuConsolePrint(playerField);

			lastKey = currentKey;
			Task.Delay(frameUpdate).Wait();
		}
	}

	private static ConsoleKey PreventReverseDirection(ConsoleKey lastKey, ConsoleKey currentKey)
	{
		if (!reverseKeyMap.ContainsKey(currentKey)) return currentKey;

		if (reverseKeyMap[currentKey] == lastKey)
		{
			currentKey = reverseKeyMap[currentKey];
		}

		return currentKey;
	}

	private static void GenerateFood(PlayerField playerField)
	{
		Random random = new();

		int randomRow = random.Next(1, playerField.GetFieldRows() - 1);
		int randomCol = random.Next(1, playerField.GetFieldCols() - 1);

		while (playerField.Matrix[randomRow, randomCol] == snakeChar)
		{
			randomRow = random.Next(1, playerField.GetFieldRows() - 1);
			randomCol = random.Next(1, playerField.GetFieldCols() - 1);
		}

		playerField.ChangeAt(randomRow, randomCol, foodChar);
	}

	private static void MenuConsolePrint(PlayerField playerField)
	{
		StringBuilder sb = new();
		sb.AppendLine(new string('=', playerField.Cols));
		sb.AppendLine($"Points:{new string(' ', (playerField.Cols - ("Points:".Length - 1)) - 5)}{points:D4}");
		sb.AppendLine(new string('=', playerField.Cols));

		Console.WriteLine(sb.ToString().Trim());
	}

	private static bool MoveLogic(Player player, PlayerField playerField, ConsoleKey key)
	{
		string direction = key switch
		{
			ConsoleKey.UpArrow or ConsoleKey.W => "up",
			ConsoleKey.DownArrow or ConsoleKey.S => "down",
			ConsoleKey.LeftArrow or ConsoleKey.A => "left",
			ConsoleKey.RightArrow or ConsoleKey.D => "right",
		};

		(int row, int col) newPos = (player.Head.row, player.Head.col);

		newPos.row += directionMap[direction].Item1;
		newPos.col += directionMap[direction].Item2;

		if (playerField.Matrix[newPos.row, newPos.col] == snakeChar) return false;

		bool hasEaten = false;
		if (playerField.Matrix[newPos.row, newPos.col] == foodChar)
		{
			hasEaten = true;
			GenerateFood(playerField);
			points += 5;

			if (points % 10 == 0 && frameUpdate >= 120) frameUpdate -= 10;
		}

		if (newPos.row >= 1 && newPos.row < playerField.GetFieldRows() - 1 &&
			newPos.col >= 1 && newPos.col < playerField.GetFieldCols() - 1)
		{
			playerField.ChangeAt(player.Tail, backgroundChar);
			player.Move(newPos.row, newPos.col, hasEaten);

			foreach ((int, int) part in player.Body)
			{
				playerField.ChangeAt(part, snakeChar);
			}
		}
		else return false;

		return true;
	}

	private static bool IsKeyValid(ConsoleKey key)
		=> validKeys.Contains(key);
}