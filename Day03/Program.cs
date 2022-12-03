PartOne();
PartTwo();

int Priority(char input)
{
    return input switch
    {
        >= 'a' and <= 'z' => input - 'a' + 1,
        >= 'A' and <= 'Z' => input - 'A' + 1 + 26,
        _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
    };
}

void PartOne()
{
    var lines = File.ReadAllLines("03/input.txt");

    var rucksacks = lines.Select(line => new Rucksack(line)).ToList();

    Console.WriteLine($"Part one: {rucksacks.Sum(s => Priority(s.CompartmentOverlappingItem))}");
}

void PartTwo()
{
    var lines = File.ReadAllLines("03/input.txt");

    var rucksacks = lines.Select(line => new Rucksack(line)).ToList();

    var groups = rucksacks
        .Select((rucksack, index) => new { rucksack, index })
        .GroupBy((r) => r.index / 3, r => r.rucksack)
        .ToList();

    var sum = groups.Sum(g =>
    {
        var set = new HashSet<char>(g.First().AllItems);
        foreach (var rucksack in g)
        {
            set.IntersectWith(rucksack.AllItems);
        }

        return Priority(set.Single());
    });

    Console.WriteLine($"Part two: {sum}");
}

internal class Rucksack
{
    private readonly ISet<char> compartmentOne;
    private readonly ISet<char> compartmentTwo;


    public Rucksack(string input)
    {
        this.compartmentOne = new HashSet<char>(input[..(input.Length / 2)]);
        this.compartmentTwo = new HashSet<char>(input[(input.Length / 2)..]);
    }

    public char CompartmentOverlappingItem => this.compartmentOne.Intersect(this.compartmentTwo).Single();

    public IEnumerable<char> AllItems => this.compartmentOne.Union(this.compartmentTwo);
}
