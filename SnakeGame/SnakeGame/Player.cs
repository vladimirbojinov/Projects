namespace SnakeGame;

internal class Player
{
	private (int, int) DefaultHeadPos = (1, 3);
	private (int, int) DefaultTailPos = (1, 1);

	public Player()
	{
		this.Head = DefaultHeadPos;
		this.Tail = DefaultTailPos;
		this.Body = new Queue<(int, int)>();

		this.Body.Enqueue((1, 1));
		this.Body.Enqueue((1, 2));
		this.Body.Enqueue((1, 3));
	}

	public (int row, int col) Head { get; private set; }
	public (int row, int col) Tail { get; private set; }
	public Queue<(int, int)> Body { get; private set; }

	public void Move(int row, int col, bool hasEaten)
	{
		if (!hasEaten)
		{
			Body.Dequeue();
		}
		Body.Enqueue((row, col)); 

		this.Head = (row, col);
		this.Tail = Body.Peek();
	}
}