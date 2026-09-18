 /// <summary>
/// Defines a maze using a dictionary.
///
/// Dictionary format:
/// (x,y) : [left, right, up, down]
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;

    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Move left if there is no wall.
    /// </summary>
    public void MoveLeft()
    {
        var directions = _mazeMap[(_currX, _currY)];

        if (!directions[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX--;
    }

    /// <summary>
    /// Move right if there is no wall.
    /// </summary>
    public void MoveRight()
    {
        var directions = _mazeMap[(_currX, _currY)];

        if (!directions[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX++;
    }

    /// <summary>
    /// Move up if there is no wall.
    /// </summary>
    public void MoveUp()
    {
        var directions = _mazeMap[(_currX, _currY)];

        if (!directions[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY--;
    }

    /// <summary>
    /// Move down if there is no wall.
    /// </summary>
    public void MoveDown()
    {
        var directions = _mazeMap[(_currX, _currY)];

        if (!directions[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}