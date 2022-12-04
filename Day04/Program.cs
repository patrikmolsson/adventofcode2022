PartOne();
PartTwo();

IEnumerable<(Elf elfOne, Elf elfTwo)> CreateElfPairs()
{
    var lines = File.ReadAllLines("04/input.txt");

    return lines.Select(line =>
    {
        var pairs = line.Split(',');

        return (new Elf(pairs[0]), new Elf(pairs[1]));
    });
}

void PartOne()
{
    var elfPairs = CreateElfPairs();

    var count = elfPairs.Count(s => s.elfOne.EitherFullyContains(s.elfTwo));

    Console.WriteLine($"PartOne: {count}");
}

void PartTwo()
{
    var elfPairs = CreateElfPairs();

    var count = elfPairs.Count(s => s.elfOne.AnyOverlap(s.elfTwo));

    Console.WriteLine($"PartTwo: {count}");
}


class Elf
{
    private readonly int lowerBound;
    private readonly int higherBound;

    public Elf(string input)
    {
        var bounds = input.Split('-');
        this.lowerBound = int.Parse(bounds[0]);
        this.higherBound = int.Parse(bounds[1]);
    }

    public bool EitherFullyContains(Elf elf)
    {
        return this.Contains(elf) || elf.Contains(this);
    }

    private bool Contains(Elf elf)
    {
        return this.lowerBound <= elf.lowerBound && this.higherBound >= elf.higherBound;
    }

    public bool AnyOverlap(Elf elf)
    {
        return this.InBounds(elf.lowerBound) || this.InBounds(elf.higherBound) || this.EitherFullyContains(elf);
    }

    private bool InBounds(int bound)
    {
        return bound >= this.lowerBound && bound <= this.higherBound;
    }
}
