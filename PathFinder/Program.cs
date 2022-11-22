
// 0 - free space
// 1 - start
// 2 - wall
// 3 - finish
// 4 - way
Cell[][] field = new Cell[][]
{
    new Cell[] { new Cell(0), new Cell(0), new Cell(2), new Cell(0), new Cell(0), new Cell(3) },
    new Cell[] { new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(2), new Cell(0) },
    new Cell[] { new Cell(0), new Cell(2), new Cell(2), new Cell(2), new Cell(2), new Cell(2) },
    new Cell[] { new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
    new Cell[] { new Cell(2), new Cell(2), new Cell(2), new Cell(2), new Cell(2), new Cell(0) },
    new Cell[] { new Cell(1), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) }
};

int fieldRows = field.Length;
int fieldCols = field[0].Length;

SetCellNumbers();
Cell currentCell = GetStartCell();
List<Cell> path = new List<Cell>();


while (true)
{
    Cell nextCell = null;

    if (!currentCell.Top)
    {
        nextCell = GetCellByPos(currentCell.RowPos, currentCell.ColPos + 1);
        currentCell.Top = true;
    }
    else if (!currentCell.Right)
    {
        nextCell = GetCellByPos(currentCell.RowPos + 1, currentCell.ColPos);
        currentCell.Right = true;
    }
    else if (!currentCell.Bottom)
    {
        nextCell = GetCellByPos(currentCell.RowPos, currentCell.ColPos - 1);
        currentCell.Bottom = true;
    }
    else if (!currentCell.Left)
    {
        nextCell = GetCellByPos(currentCell.RowPos - 1, currentCell.ColPos);
        currentCell.Left = true;
    }

    if (nextCell != null)
    {
        path.Add(currentCell);
        currentCell = nextCell;
    }
    else
    {
        currentCell = path[path.Count - 2];
    }

    if (currentCell.Type == 0)
        path.Add(currentCell);

    if (currentCell.Type == 1)
        break;

}

System.Console.WriteLine("ended");

Cell GetCellByPos(int row, int col)
{
    try
    {
        return field[row][col];
    }
    catch (System.Exception)
    {
        return null;
    }
}

Cell GetStartCell()
{
    for (int i = 0; i < fieldRows; i++)
        for (int j = 0; j < fieldCols; j++)
            if (field[i][j].Type == 1)
                return field[i][j];

    return null;
}

void SetCellNumbers()
{
    // set current pos to cell
    for (int i = 0; i < fieldRows; i++)
    {
        for (int j = 0; j < fieldCols; j++)
        {
            field[i][j].RowPos = i;
            field[i][j].ColPos = j;
        }
    }
}

public class Cell
{
    public bool Top = false;
    public bool Right = false;
    public bool Bottom = false;
    public bool Left = false;

    public int Type;
    public int RowPos;
    public int ColPos;

    public Cell(int type)
    {
        Type = type;
    }

}