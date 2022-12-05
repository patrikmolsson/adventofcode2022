// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("05/input.txt");
PartOne();
PartTwo();

IEnumerable<(int quantity, int sourceNo, int destinationNo)> MoveInstructions()
{
    var index = 0;
    var onlyWhitespaceRegex = new Regex("^\\s*$");
    for (; index < lines.Length; index++)
    {
        var line = lines[index];

        if (onlyWhitespaceRegex.IsMatch(line))
        {
            index++;
            break;
        }
    }

    var numberRegex = new Regex("\\d+");
    for (; index < lines.Length; index++)
    {
        var line = lines[index];
        var matches = numberRegex.Matches(line);

        var quantity = int.Parse(matches[0].Value);
        var sourceNo = int.Parse(matches[1].Value);
        var destinationNo = int.Parse(matches[2].Value);

        yield return (quantity, sourceNo, destinationNo);
    }
}

void PartOne()
{
    var stacks = InitializeStack();
    var crateMover = new CrateMover9000(stacks);
    foreach (var moveInstruction in MoveInstructions())
    {
        crateMover.MoveItems(moveInstruction.quantity, moveInstruction.sourceNo, moveInstruction.destinationNo);
    }

    crateMover.EchoState();
}

void PartTwo()
{
    var stacks = InitializeStack();
    var crateMover = new CrateMover9001(stacks);
    foreach (var moveInstruction in MoveInstructions())
    {
        crateMover.MoveItems(moveInstruction.quantity, moveInstruction.sourceNo, moveInstruction.destinationNo);
    }

    crateMover.EchoState();
}

Stack<char>[] InitializeStack()
{
    var queues = new Dictionary<int, Queue<char>>();

    var regex = new Regex("\\d");
    foreach (var line in lines)
    {
        if (regex.IsMatch(line))
        {
            break;
        }

        var parts = line
            .Chunk(4)
            .Select(str => str[1])
            .ToList();

        for (var index = 0; index < parts.Count; index++)
        {
            var part = parts[index];
            if (!queues.TryGetValue(index, out var queue))
            {
                queue = new Queue<char>();
                queues.Add(index, queue);
            }

            if (part != ' ')
            {
                queue.Enqueue(part);
            }
        }
    }

    return queues.Select(q => new Stack<char>(q.Value.Reverse())).ToArray();
}

internal class CrateMover9001 : CrateMover9000
{
    public new void MoveItems(int quantity, int sourceNo, int destinationNo)
    {
        var source = this.cargoStacks[sourceNo - 1];
        var destination = this.cargoStacks[destinationNo - 1];


        foreach (var c in SourceItems().Reverse())
        {
            destination.Push(c);
        }

        IEnumerable<char> SourceItems()
        {
            for (var i = 0; i < quantity; i++)
            {
                yield return source.Pop();
            }
        }
    }

    public CrateMover9001(Stack<char>[] cargoStacks) : base(cargoStacks)
    {
    }
}

internal class CrateMover9000
{
    protected readonly Stack<char>[] cargoStacks;

    public CrateMover9000(Stack<char>[] cargoStacks)
    {
        this.cargoStacks = cargoStacks;
    }

    public void MoveItems(int quantity, int sourceNo, int destinationNo)
    {
        var source = this.cargoStacks[sourceNo - 1];
        var destination = this.cargoStacks[destinationNo - 1];

        for (int i = 0; i < quantity; i++)
        {
            destination.Push(source.Pop());
        }
    }

    public void EchoState()
    {
        var sb = new StringBuilder();
        foreach (var cargoStack in this.cargoStacks)
        {
            sb.Append(cargoStack.Peek());
        }

        Console.WriteLine($"{this.GetType().Name}: {sb}");
    }
}
