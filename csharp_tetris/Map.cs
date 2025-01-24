namespace Tetris;

internal class Map : IDraw
{
    private List<Cell> staticWall = new List<Cell>();
    public List<Cell> dynamicWall = new List<Cell>();
    public int scoreCount; // Number of rows to be eliminated
    public int score;
    public int dWidth; // Horizontal capacity of dynamic walls
    public int height;
    private int[] record; // record bricks count for each row
    private PlayScene playScene;

    public Map(PlayScene playScene)
    {
        this.playScene = playScene;
        height = Game.height - 6;
        record = new int[height];
        dWidth = 0;
        // Horizontal
        for (int i = 0; i < Game.width; i += 2) {
            staticWall.Add(new Cell(E_CellType.Wall, i, Game.height - 6));
            staticWall.Add(new Cell(E_CellType.Wall, i, Game.height - 1));
            dWidth++;
        }
        dWidth -= 2;
        // Vertical
        for (int i = 0; i < Game.height; i++) {
            staticWall.Add(new Cell(E_CellType.Wall, 0, i));
            staticWall.Add(new Cell(E_CellType.Wall, Game.width, i));
        }
    }

    public void Draw()
    {
        for (int i = 0; i < staticWall.Count; i++) {
            staticWall[i].Draw();
        }
        for (int i = 0; i < dynamicWall.Count; i++) {
            dynamicWall[i].Draw();
        }
    }

    public void ClearDynamicWall()
    {
        for (int i = 0; i < dynamicWall.Count; i++) {
            dynamicWall[i].Clear();
        }
    }

    public void Add2DynamicWall(List<Cell> cells)
    {
        for (int i = 0; i < cells.Count; i++) {
            cells[i].ChangeType(E_CellType.Wall);
            dynamicWall.Add(cells[i]);
            if (cells[i].position.y <= 0) {
                Game.ChangeScene(E_SceneType.End);
                return;
            }
            // record bricks count for each row
            record[height - 1 - cells[i].position.y]++;
        }
        ClearDynamicWall();

    }

    public bool cleard = false;
    public void Clear()
    {
        // remove full rows
        List<Cell> removeCells = new List<Cell>();
        for (int i = 0; i < record.Length; i++) {
            if (record[i] == dWidth) {
                for (int j = 0; j < dynamicWall.Count; j++) {
                    if (i == (height - dynamicWall[j].position.y - 1)) {
                        removeCells.Add(dynamicWall[i]);
                    } else if ((height - dynamicWall[j].position.y - 1) > i) {
                        //bricks sink
                        dynamicWall[i].position.y++;
                    }
                }
                // remove
                for (int j = 0; j < removeCells.Count; j++) {
                    dynamicWall.Remove(removeCells[j]);
                }
                // record sink
                for (int j = i; j < record.Length - 1; j++) {
                    record[j] = record[j + 1];
                }
                record[record.Length - 1] = 0; // recursive call down to above
                cleard = true;
                Clear();
                break;
            }
        }

    }
}
