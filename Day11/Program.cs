using System.Linq.Expressions;
using System.Text.RegularExpressions;

PartOne();
PartTwo();

void PartOne()
{
    MonkeyBusiness(true, 20);
}

void PartTwo()
{
    MonkeyBusiness(false, 10_000);
}

void MonkeyBusiness(bool withStressRelief, int rounds)
{
    var lines = File.ReadAllLines("11/input.txt");


    var monkeys = new List<Monkey>();
    foreach (var chunk in lines.Chunk(7))
    {
        monkeys.Add(new Monkey(chunk) { UseStressRelief = withStressRelief });
    }

    var divisors = monkeys.Aggregate(1, (i, monkey) => i * monkey.divisibleBy);

    for (var round = 1; round <= rounds; round++)
    {
        foreach (var monkey in monkeys)
        {
            var items = monkey.InspectItems(divisors);

            foreach (var item in items)
            {
                monkeys.ElementAt(item.newIndex).ReceiveItem(item.item);
            }
        }
    }

    Console.WriteLine(monkeys.OrderByDescending(m => m.NoInspects).Take(2)
        .Aggregate((long)1, (acc, curr) => acc * curr.NoInspects));
}

class Monkey
{
    private readonly Func<long, long, long> operation;
    private readonly Func<long, long> getFirstParam = old => old;
    private readonly Func<long, long> getSecondParam;
    public readonly int divisibleBy;
    private readonly int trueMonkeyIndex;
    private readonly int falseMonkeyIndex;
    private List<long> items;

    public Monkey(string[] lines)
    {
        this.items = lines[1].Split(", ").Select(GetIntFromString).Select(f => (long)f).ToList();
        var opLine = lines[2].Split(" = ")[1];
        var ops = opLine.Split(" ");

        var paramOne = Expression.Parameter(typeof(long), "one");
        var paramTwo = Expression.Parameter(typeof(long), "two");
        var operand = ops[1] switch
        {
            "+" => Expression.Add(paramOne, paramTwo),
            "*" => Expression.Multiply(paramOne, paramTwo),
        };

        this.operation = Expression.Lambda<Func<long, long, long>>(operand, paramOne, paramTwo).Compile();
        this.getSecondParam = (old) =>
        {
            if (ops[2] == "old")
            {
                return old;
            }

            return int.Parse(ops[2]);
        };

        this.divisibleBy = GetIntFromString(lines[3]);
        this.trueMonkeyIndex = GetIntFromString(lines[4]);
        this.falseMonkeyIndex = GetIntFromString(lines[5]);

        int GetIntFromString(string input)
        {
            return int.Parse(Regex.Replace(input, "[^0-9]", ""));
        }
    }

    public IEnumerable<(int newIndex, long item)> InspectItems(int divisors)
    {
        var items = this.items;

        this.items = new List<long>();

        foreach (var item in items)
        {
            NoInspects++;

            var newLevel = this.operation(this.getFirstParam(item), this.getSecondParam(item));

            if (this.UseStressRelief)
            {
                newLevel /= 3;
            }

            var test = newLevel % this.divisibleBy == 0;

            newLevel %= divisors;


            yield return (test ? this.trueMonkeyIndex : this.falseMonkeyIndex, newLevel);
        }
    }

    public bool UseStressRelief { get; init; }

    public int NoInspects { get; private set; }

    public void ReceiveItem(long item)
    {
        this.items.Add(item);
    }
}
