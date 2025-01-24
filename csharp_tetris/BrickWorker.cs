namespace Tetris;

enum E_ChangeDirection
{
    Left, Right,
}

internal class BrickWorker : IDraw
{
    private List<Cell> brick;
    private Dictionary<E_CellType, BrickInfo> brickInfoDict;
    private BrickInfo brickInfo;
    private int infoIndex;
    public BrickWorker()
    {
        brickInfoDict = new Dictionary<E_CellType, BrickInfo>()
        {
                { E_CellType.IShape ,new BrickInfo(E_CellType.IShape)},
                { E_CellType.JShape ,new BrickInfo(E_CellType.JShape)},
                { E_CellType.LShape ,new BrickInfo(E_CellType.LShape)},
                { E_CellType.OShape ,new BrickInfo(E_CellType.OShape)},
                { E_CellType.SShape ,new BrickInfo(E_CellType.SShape)},
                { E_CellType.TShape ,new BrickInfo(E_CellType.TShape)},
                { E_CellType.ZShape ,new BrickInfo(E_CellType.ZShape)},
            };
        RandomCreatBrick();
    }

    public void Draw()
    {
        for (int i = 0; i < brick.Count; i++) {
            brick[i].Draw();
        }
    }

    public void RandomCreatBrick()
    {
        Random r = new Random();
        E_CellType type = (E_CellType) r.Next(1, 8);
        // A brick consists of four small cells
        brick = new List<Cell>()
        {
                new Cell(type),
                new Cell(type),
                new Cell(type),
                new Cell(type),
            };
        // init brick center position
        brick[0].position = new Position(24, -5);
        // save brickinfo
        brickInfo = brickInfoDict[type];
        // random rotate state
        infoIndex = r.Next(0, brickInfo.Count);
        // get state position offset
        Position[] positions = brickInfo[infoIndex];
        for (int i = 0; i < positions.Length; i++) {
            // other cells' position
            brick[i + 1].position = brick[0].position + positions[i];
        }

    }

    public void Clear()
    {
        for (int i = 0; i < brick.Count; i++) {
            brick[i].Clear();

        }
    }

    public void Rotate(E_ChangeDirection direction)
    {
        Clear();
        switch (direction) {
            case E_ChangeDirection.Left:
                --infoIndex;
                if (infoIndex < 0) {
                    infoIndex = brickInfo.Count - 1;
                }
                break;
            case E_ChangeDirection.Right:
                ++infoIndex;
                if (infoIndex >= brickInfo.Count) {
                    infoIndex = 0;
                }
                break;
            default:
                break;
        }
        Position[] positions = brickInfo[infoIndex];
        for (int i = 0; i < positions.Length; i++) {
            brick[i + 1].position = brick[0].position + positions[i];

        }
        Draw();
    }

    public bool CanRotate(E_ChangeDirection direction, Map map)
    {
        int index = infoIndex;
        switch (direction) {
            case E_ChangeDirection.Left:
                --index;
                if (index < 0) {
                    index = brickInfo.Count - 1;

                }

                break;
            case E_ChangeDirection.Right:
                ++index;
                if (index >= brickInfo.Count) {
                    index = 0;
                }
                break;
            default:
                break;
        }
        Position[] tmpPositions = brickInfo[index];
        Position tempPostion;
        // border check
        for (int i = 0; i < tmpPositions.Length; i++) {
            tempPostion = brick[0].position + tmpPositions[i];
            if (tempPostion.x < 2 || tempPostion.x >= Game.width - 2 || tempPostion.y >= map.height) {
                return false;
            }
        }
        // coincides with the dynamic wall or not
        for (int i = 0; i < tmpPositions.Length; i++) {
            tempPostion = brick[0].position + tmpPositions[i];
            for (int j = 0; j < map.dynamicWall.Count; j++) {
                if (tempPostion == map.dynamicWall[j].position) {
                    return false;
                }

            }

        }
        return true;
    }

    public void MoveRL(E_ChangeDirection direction)
    {
        Clear();
        Position movePosition = new Position(direction == E_ChangeDirection.Left ? -2 : 2, 0);
        for (int i = 0; i < brick.Count; i++) {

            brick[i].position += movePosition;

        }
        Draw();
    }

    public bool CanMoveRL(E_ChangeDirection direction, Map map)
    {
        Position movePosition = new Position(direction == E_ChangeDirection.Left ? -2 : 2, 0);
        Position position;
        for (int i = 0; i < brick.Count; i++) {
            position = brick[i].position + movePosition;
            if (position.x < 2 || position.x >= Game.width - 2) {
                return false;
            }
        }

        for (int i = 0; i < brick.Count; i++) {
            position = brick[i].position + movePosition;

            for (int j = 0; j < map.dynamicWall.Count; j++) {
                if (position == map.dynamicWall[j].position) {
                    return false;
                }
            }
        }
        return true;
    }

    public void AutoMoveDown()
    {
        Clear();
        Position downMove = new Position(0, 1);
        for (int i = 0; i < brick.Count; i++) {
            brick[i].position += downMove;
        }
        Draw();
    }

    public bool CanAutoMoveDown(Map map)
    {
        Position position;
        Position downMove = new Position(0, 1);

        for (int i = 0; i < brick.Count; i++) {
            position = brick[i].position + downMove;
            if (position.y >= map.height) {
                // stop
                map.Add2DynamicWall(brick);
                RandomCreatBrick();
                return false;
            }
        }
        // dynamic
        for (int i = 0; i < brick.Count; i++) {
            position = brick[i].position + downMove;
            for (int j = 0; j < map.dynamicWall.Count; j++) {
                if (position == map.dynamicWall[j].position) {
                    // stop
                    map.Add2DynamicWall(brick);
                    RandomCreatBrick();
                    return false;
                }
            }
        }
        return true;
    }
}
