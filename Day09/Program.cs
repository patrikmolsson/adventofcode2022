var lines = File.ReadAllLines("09/input.txt");

PartOne();
PartTwo();
void PartOne()
{
    PlanckLengths(1);
}

void PartTwo()
{
    PlanckLengths(9);
}

void PlanckLengths(int noTailingKnots)
{
    var head = new Knot();
    var tailingKnots = new List<Knot>();
    var tail = head;
    for (var i = 1; i <= noTailingKnots; i++)
    {
        tail = new Knot(tail);
        tailingKnots.Add(tail);
    }

    var set = new HashSet<(int x, int y)>() { (0, 0) };

    foreach (var line in lines)
    {
        var p = line.Split(" ");

        var direction = p[0] switch
        {
            "D" => Direction.Down,
            "U" => Direction.Up,
            "L" => Direction.Left,
            "R" => Direction.Right,
            _ => throw new ArgumentOutOfRangeException()
        };

        for (var i = 0; i < int.Parse(p[1]); i++)
        {
            head.Move(direction);
            foreach (var tailingKnot in tailingKnots)
            {
                tailingKnot.MoveTowardsHead();
            }

            set.Add((tail.X, tail.Y));
        }
    }

    Console.WriteLine(set.Count);
}

class Knot
{
    public int X
    {
        get;
        private set;
    }

    public int Y
    {
        get;
        private set;
    }

    private Knot? head;

    public Knot()
    {
    }

    public Knot(Knot head)
    {
        this.head = head;
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Down:
                this.Y--;
                break;
            case Direction.Up:
                this.Y++;
                break;
            case Direction.Left:
                this.X--;
                break;
            case Direction.Right:
                this.X++;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    public void MoveTowardsHead()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException("No head set");
        }

        if (this.IsAdjacentOrOnHead())
        {
            return;
        }

        var newDirections = this.GetTailDirection();

        foreach (var direction in newDirections)
        {
            this.Move(direction);
        }
    }

    private IEnumerable<Direction> GetTailDirection()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException("No head set");
        }

        if (this.head.X == this.X)
        {
            yield return YDirection();
            yield break;
        }

        if (this.head.Y == this.Y)
        {
            yield return XDirection();
            yield break;
        }

        yield return YDirection();
        yield return XDirection();

        Direction YDirection()
        {
            return this.head.Y > this.Y ? Direction.Up : Direction.Down;
        }

        Direction XDirection()
        {
            return this.head.X > this.X ? Direction.Right : Direction.Left;
        }
    }

    private bool IsAdjacentOrOnHead()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException("No head set");
        }

        if (this.head.Y == this.Y)
        {
            return Math.Abs(this.head.X - this.X) < 2;
        }

        if (this.head.X == this.X)
        {
            return Math.Abs(this.head.Y - this.Y) < 2;
        }

        return Math.Abs(this.head.X - this.X) == 1 && Math.Abs(this.head.Y - this.Y) == 1;
    }
}

enum Direction
{
    Up,
    Down,
    Left,
    Right
}
