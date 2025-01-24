using System.Runtime.InteropServices;

namespace Tetris;

enum E_SceneType
{
    Begin, Play, End
}

class Game
{
    public const int width = 50;
    public const int height = 35;
    public static ISceneUpdate scene;

    public Game()
    {
        Console.CursorVisible = false;
        Console.SetWindowSize(width, height);
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            Console.SetBufferSize(width, height);
        }
        ChangeScene(E_SceneType.Begin);
    }

    public static void ChangeScene(E_SceneType aSceneType)
    {
        Console.Clear();
        switch (aSceneType) {
            case E_SceneType.Begin:
                scene = new BeginScene();
                break;
            case E_SceneType.Play:
                scene = new PlayScene();
                break;
            case E_SceneType.End:
                scene = new EndScene();
                break;
        }
    }
}
