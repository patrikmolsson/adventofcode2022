var lines = File.ReadAllLines("08/input.txt");

var forest = new Forest(lines);

Console.WriteLine($"Part one {forest.VisibleTrees().Count()}");
Console.WriteLine($"Part two: {forest.HighestScenicScore()}");

internal class Forest
{
    private readonly int[][] grid;

    public Forest(string[] lines)
    {
        this.grid = new int[lines.Length][];

        for (var row = 0; row < this.grid.Length; row++)
        {
            var line = lines[row];
            this.grid[row] = new int[line.Length];

            for (var col = 0; col < line.Length; col++)
            {
                var tree = line[col];

                this.grid[row][col] = int.Parse(tree.ToString());
            }
        }
    }

    public IEnumerable<(int row, int col)> VisibleTrees()
    {
        foreach (var (row, col) in this.Trees())
        {
            if (this.IsVisible(row, col))
            {
                yield return (row, col);
            }
        }
    }

    public int HighestScenicScore()
    {
        var currentHighScore = 0;

        foreach (var (row, col) in this.Trees())
        {
            var treeScore = this.ScenicScore(row, col);

            currentHighScore = Math.Max(currentHighScore, treeScore);
        }

        return currentHighScore;
    }

    public int ScenicScore(int row, int col) =>
        Enum.GetValues<Direction>().Select(dir =>
        {
            var trees = this.TreesInDirection(row, col, dir);

            return dir is Direction.North or Direction.West ? trees.Reverse().ToArray() : trees;
        }).Select(orderedTrees =>
        {
            var score = 0;
            var currentHeight = this.grid[row][col];

            for (var index = 0; index < orderedTrees.Length; index++)
            {
                var tree = orderedTrees[index];

                score++;

                if (tree >= currentHeight)
                {
                    break;
                }
            }

            return score;
        }).Aggregate((acc, curr) => acc * curr);

    private int[] TreesInDirection(int row, int col, Direction direction) =>
        direction switch
        {
            Direction.East => this.grid[row][(col + 1)..],
            Direction.North => this.grid[..row].Select(r => r[col]).ToArray(),
            Direction.South => this.grid[(row + 1)..].Select(r => r[col]).ToArray(),
            Direction.West => this.grid[row][..col],
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };


    private IEnumerable<(int row, int col)> Trees()
    {
        for (var row = 0; row < this.grid.Length; row++)
        {
            for (var col = 0; col < this.grid[row].Length; col++)
            {
                yield return (row, col);
            }
        }
    }

    private bool IsVisible(int row, int col) => Enum.GetValues<Direction>().Any(dir => this.VisibleFromDirection(row, col, dir));

    private bool VisibleFromDirection(int row, int col, Direction direction)
    {
        var treeHeight = this.grid[row][col];

        var treesInTheWay = this.TreesInDirection(row, col, direction);

        return treesInTheWay.Length == 0 || treesInTheWay.All(tree => tree < treeHeight);
    }
}

internal enum Direction
{
    North,
    South,
    West,
    East
}
