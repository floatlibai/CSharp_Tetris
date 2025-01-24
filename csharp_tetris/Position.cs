namespace Tetris;

internal class Position
{
    public int x;
    public int y;

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool Equals(Position aPosition)
    {
        return x == aPosition.x && y == aPosition.y;
    }

    public static Position operator +(Position p1, Position p2)
    {
        return new Position(p1.x + p2.x, p1.y + p2.y);
    }
}
