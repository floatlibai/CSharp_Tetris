namespace Tetris;

internal class InputThread
{
    Thread inputThead;

    public event Action inputEvent;

    private static InputThread instance = new InputThread();
    public static InputThread Instance
    {
        get {
            return instance;
        }
    }
    private InputThread()
    {
        inputThead = new Thread(InputCheck);
        inputThead.IsBackground = true;
        inputThead.Start();
    }

    public void InputCheck()
    {
        while (true) {
            inputEvent?.Invoke();
        }
    }
}
