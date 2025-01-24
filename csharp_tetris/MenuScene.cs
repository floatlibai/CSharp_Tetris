namespace Tetris;

abstract class MenuScene : ISceneUpdate
{
    protected int selectIndex = 0;
    protected string title;
    protected string firstOption;
    protected string secondOption = "结束游戏";
    public abstract void Select2Do();

    public void Update()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(Game.width / 2 - title.Length, 5);
        Console.Write(title);

        Console.SetCursorPosition(Game.width / 2 - firstOption.Length, 8);
        Console.ForegroundColor = selectIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
        Console.Write(firstOption);

        Console.SetCursorPosition(Game.width / 2 - secondOption.Length, 10);
        Console.ForegroundColor = selectIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
        Console.Write(secondOption);

        switch (Console.ReadKey(true).Key) {
            case ConsoleKey.UpArrow:
                selectIndex = Math.Max(selectIndex - 1, 0);
                break;
            case ConsoleKey.DownArrow:
                selectIndex = Math.Min(selectIndex + 1, 1);
                break;
            case ConsoleKey.Enter:
                Select2Do();
                break;
        }
    }
}
