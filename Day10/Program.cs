IEnumerable<string> GetLines()
{
    var lines = File.ReadAllLines("10/input.txt");

    return lines;
}

var register = 1;
var signalStrengths = new Dictionary<int, int>();
var ops = GetLines();

using var opsEnumerator = ops.GetEnumerator();

for (var cycle = 1; cycle <= 240; cycle++)
{
    ProcessCycleV2(cycle);

    opsEnumerator.MoveNext();
    var line = opsEnumerator.Current;
    var op = line.Split(" ")[0];

    switch (op)
    {
        case "addx":
        {
            var x = int.Parse(line.Split(" ")[1]);

            cycle++;
            ProcessCycleV2(cycle);

            register += x;
            break;
        }
        case "noop":
        {
            break;
        }
    }
}

// Console.WriteLine(signalStrengths.Values.Sum());

bool IsTrackableCycle(int cycle)
{
    return (cycle - 20) % 40 == 0;
}

void ProcessCycle(int cycle)
{
    if (!IsTrackableCycle(cycle))
    {
        return;
    }

    signalStrengths.Add(cycle, register * cycle);
}

void ProcessCycleV2(int cycle)
{
    // 1 -> 1
    // 40 -> 40
    // 41 -> 1
    // 80 -> 40
    // 81 -> 1
    var cycled = ((cycle - 1) % 40) + 1;

    var cycledZeroIndex = cycled - 1;

    if (cycledZeroIndex <= register + 1 && cycledZeroIndex >= register - 1)
    {
        Console.Write("#");
    }
    else
    {
        Console.Write(".");
    }

    if (cycle % 40 == 0)
    {
        Console.WriteLine();
    }
}
