// See https://aka.ms/new-console-template for more information

using System.Globalization;

PartOne();
PartTwo();

List<Elf> CreateElfes()
{
    var lines = File.ReadAllLines("01/input.txt");

    var elfes = new List<Elf>();

    var elf = new Elf();
    foreach (var line in lines)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            elfes.Add(elf);
            elf = new Elf();
            continue;
        }

        elf.AddFoodItem(line);
    }

    elfes.Add(elf);

    return elfes;
}

void PartOne()
{
    var elfes = CreateElfes();

    Console.WriteLine($"Max elf: {elfes.MaxBy(s => s.TotalAmountOfCalories).TotalAmountOfCalories}");
}

void PartTwo()
{
    var elfes = CreateElfes();

    Console.WriteLine($"Max elfes: {elfes.OrderByDescending(s => s.TotalAmountOfCalories).Take(3).Sum(s => s.TotalAmountOfCalories)}");
}

internal class Elf
{
    public void AddFoodItem(string foodItem) =>
        this.FoodItemsCaloryCount.Add(int.Parse(foodItem, NumberStyles.Integer, CultureInfo.InvariantCulture));

    private IList<int> FoodItemsCaloryCount { get; } = new List<int>();

    public int TotalAmountOfCalories => this.FoodItemsCaloryCount.Sum();
}
