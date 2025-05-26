namespace SnakeGame;

public class PlayerField
{
	public PlayerField(int rows, int cols)
	{
		this.Rows = rows;
		this.Cols = cols;
		this.Matrix = new char[rows, cols];
	}

	public int Rows { get; private set; }
	public int Cols { get; private set; }
	public char[,] Matrix { get; private set; }

	public void Fill(char background, char borderChar)
	{
		for (int i = 0; i < this.Matrix.GetLength(0); i++)
		{
			if (i == 0)
			{
				Console.WriteLine();
			}

			for (int j = 0; j < this.Matrix.GetLength(1); j++)
			{
				if ((i == 0 || j == 0) ||
					(i == this.Matrix.GetLength(0) - 1 || j == this.Matrix.GetLength(1) - 1))
				{
					this.Matrix[i, j] = borderChar;
				}
				else
				{
					this.Matrix[i, j] = background;
				}

			}
		}
	}

	public void ConsolePrint()
	{
		for (int i = 0; i < this.Matrix.GetLength(0); i++)
		{
			for (int j = 0; j < this.Matrix.GetLength(1); j++)
			{
				Console.Write(this.Matrix[i, j]);
			}

			Console.WriteLine();
		}
	}

	public void ChangeAt(int row, int col, char value)
		=> this.Matrix[row, col] = value;

	public void ChangeAt((int row, int col) pos, char value)
		=> this.Matrix[pos.row, pos.col] = value;

	public int GetFieldRows() 
		=> this.Matrix.GetLength(0);

	public int GetFieldCols()
		=> this.Matrix.GetLength(1);
}
