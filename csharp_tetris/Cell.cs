namespace Tetris;

enum E_CellType
{
    Wall, IShape, JShape, LShape, OShape, SShape, TShape, ZShape
}

internal class Cell : IDraw
{
    public Position position;
    public E_CellType type;

    public Cell(E_CellType type)
    {
        this.type = type;
    }

    public Cell(E_CellType type, int x, int y) : this(type)
    {
        this.position = new Position(x, y);
    }

    public void Draw()
    {
        if (position.y < 0) {
            return;
        }

        Console.SetCursorPosition(position.x, position.y);
        switch (type) {
            case E_CellType.Wall:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case E_CellType.OShape:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case E_CellType.IShape:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case E_CellType.TShape:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case E_CellType.JShape: // fall-through
            case E_CellType.LShape:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
            case E_CellType.SShape: // fall-through
            case E_CellType.ZShape:
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            default:
                break;
        }
        Console.Write("卐");
    }

    public void Clear()
    {
        if (position.y < 0) {
            return;
        }

        Console.SetCursorPosition(position.x, position.y);
        Console.Write("  ");
    }

    // Bricks meet wall => wall
    public void ChangeType(E_CellType type)
    {
        this.type = type;
    }
}
