namespace Tetris;

class BrickInfo
{
    // Position[] The relative coordinates of the other three cells
    // List<Position[]> different rotation states
    private List<Position[]> list;

    public BrickInfo(E_CellType type)
    {
        list = new List<Position[]>();
        switch (type) {
            case E_CellType.OShape:
                // list添加形状信息
                list.Add(new Position[3] {
                    new Position(2,0),
                        new Position(0,1),
                        new Position(2,1)
                    });
                break;
            case E_CellType.IShape:
                list.Add(new Position[3] {
                    new Position(0, -1),
                    new Position(0, 1),
                    new Position(0, 2),

                    });
                list.Add(new Position[3] {
                   new Position(-4, 0),
                    new Position(-2, 0),
                    new Position(2, 0),
                    });
                list.Add(new Position[3] {
                    new Position(0, -2),
                    new Position(0, -1),
                    new Position(0, 1),
                    });
                list.Add(new Position[3] {
                    new Position(-2, 0),
                    new Position(2, 0),
                    new Position(4, 0),
                    });
                break;
            case E_CellType.TShape:
                list.Add(new Position[3] {
                    new Position(-2, 0),
                    new Position(2, 0),
                    new Position(0, 1),
                    });
                list.Add(new Position[3] {
                    new Position(0,-1),
                        new Position(-2,0),
                        new Position(0,1)
                    });
                list.Add(new Position[3] {
                    new Position(0,-1),
                        new Position(-2,0),
                        new Position(2,0)
                    });
                list.Add(new Position[3] {
                   new Position(0,-1),
                        new Position(2,0),
                        new Position(0,1)
                    });
                break;
            case E_CellType.SShape:
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(2,0),
                        new Position(2,1)
                    });
                list.Add(new Position[3]{
                        new Position(2,0),
                        new Position(0,1),
                        new Position(-2,1)
                    });
                list.Add(new Position[3]{
                       new Position(-2,-1),
                        new Position(-2,0),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(2,-1),
                        new Position(-2,0)
                    });
                break;
            case E_CellType.ZShape:
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(-2,0),
                        new Position(-2,1)
                    });
                list.Add(new Position[3]{
                        new Position(-2,-1),
                        new Position(0,-1),
                        new Position(2,0)
                    });
                list.Add(new Position[3]{
                        new Position(2,-1),
                        new Position(2,0),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(0,1),
                        new Position(2,1),
                        new Position(-2,0)
                    });
                break;
            case E_CellType.LShape:
                list.Add(new Position[3]{
                        new Position(-2,-1),
                        new Position(0,-1),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(2,-1),
                        new Position(-2,0),
                        new Position(2,0)
                    });
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(2,1),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(2,0),
                        new Position(-2,0),
                        new Position(-2,1)
                    });
                break;
            case E_CellType.JShape:
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(0,1),
                        new Position(2,-1)
                    });
                list.Add(new Position[3]{
                        new Position(2,0),
                        new Position(-2,0),
                        new Position(2,1)
                    });
                list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(-2,1),
                        new Position(0,1)
                    });
                list.Add(new Position[3]{
                        new Position(-2,-1),
                        new Position(-2,0),
                        new Position(2,0)
                    });
                break;
            default:
                break;
        }
    }

    // offset information api
    public Position[] this[int index]
    {
        get {
            if (index < 0) {
                return list[0];

            } else if (index >= list.Count) {
                return list[list.Count - 1];
            } else
                return list[index];
        }
    }
    public int Count
    {
        get => list.Count;
    }
}
