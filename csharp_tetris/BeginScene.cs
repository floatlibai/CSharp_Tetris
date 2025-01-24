namespace Tetris;

internal class BeginScene : MenuScene
{
    public BeginScene()
    {
        title = "俄罗斯方块";
        firstOption = "开始游戏";
    }

    public override void Select2Do()
    {
        if (selectIndex == 0) {
            Game.ChangeScene(E_SceneType.Play);
        } else {
            Environment.Exit(0);
        }
    }
}
