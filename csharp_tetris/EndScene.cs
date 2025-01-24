namespace Tetris;

internal class EndScene : MenuScene
{
    public EndScene()
    {
        title = "游戏结束";
        firstOption = "回到标题";
    }

    public override void Select2Do()
    {
        if (selectIndex == 0) {
            Game.ChangeScene(E_SceneType.Begin);
        } else {
            Environment.Exit(0);
        }
    }
}
