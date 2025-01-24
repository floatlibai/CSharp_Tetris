namespace Tetris;

internal class PlayScene : ISceneUpdate
{

    Map map;
    BrickWorker brickWorker;
    Score score;

    public PlayScene()
    {

        map = new Map(this);
        brickWorker = new BrickWorker();
        score = new Score(this);
        // 添加输入时间监听
        InputThread.Instance.inputEvent += CheckInputThread;
    }

    private void CheckInputThread()
    {
        if (Console.KeyAvailable) {
            lock (brickWorker) {
                switch (Console.ReadKey(true).Key) {
                    case ConsoleKey.LeftArrow:
                        if (brickWorker.CanRotate(E_ChangeDirection.Left, map)) {
                            brickWorker.Rotate(E_ChangeDirection.Left);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (brickWorker.CanRotate(E_ChangeDirection.Right, map)) {
                            brickWorker.Rotate(E_ChangeDirection.Right);

                        }
                        break;
                    case ConsoleKey.A:
                        if (brickWorker.CanMoveRL(E_ChangeDirection.Left, map)) {
                            brickWorker.MoveRL(E_ChangeDirection.Left);

                        }
                        break;
                    case ConsoleKey.D:
                        if (brickWorker.CanMoveRL(E_ChangeDirection.Right, map)) {
                            brickWorker.MoveRL(E_ChangeDirection.Right);

                        }
                        break;
                    case ConsoleKey.S:
                        if (brickWorker.CanAutoMoveDown(map)) {
                            brickWorker.AutoMoveDown();
                        }
                        break;
                }
            }
        }
    }
    public void StopThread()
    {
        InputThread.Instance.inputEvent -= CheckInputThread;
    }

    public void Update()
    {
        lock (brickWorker) {
            map.Draw();
            brickWorker.Draw();
            if (brickWorker.CanAutoMoveDown(map)) {
                brickWorker.AutoMoveDown();
            }
            if (map.cleard) {
                score.Isclear();
                map.cleard = false;
            }

        }
        Thread.Sleep(100);
    }
}
