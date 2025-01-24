namespace Tetris;

internal class Score : Map
{
    protected String scoreSumName;
    protected String scoreLineCountName;

    public int ScoreNum;
    public int ScoreLine;
    int scoreInit = 0;
    int lineInit = 0;
    public Score(PlayScene playScene) : base(playScene)
    {
        scoreSumName = "分数:";
        scoreLineCountName = "行数:";

        // 1 line 10 points
        Console.SetCursorPosition(2, height - 4);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(scoreSumName);
        Console.SetCursorPosition(2, height - 3);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(scoreLineCountName);
        // init count 0
        Console.SetCursorPosition(7, height - 4);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(scoreInit);
        Console.SetCursorPosition(7, height - 3);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(lineInit);

    }

    public void DrawScore(int ScoreNum, int ScoreLine)
    {
        Console.SetCursorPosition(7, Game.height - 4);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(ScoreNum);
        Console.SetCursorPosition(7, Game.height - 3);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(ScoreLine);
    }

    public int updateScore()
    {
        return ++scoreCount;
    }

    public int GetScore()
    {
        return score += 10;
    }

    // 判断是否消除一行
    public void Isclear()
    {
        DrawScore(GetScore(), updateScore());
    }
}
