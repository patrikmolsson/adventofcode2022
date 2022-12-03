PartOne();
PartTwo();

void PartOne()
{
    var lines = File.ReadAllLines("02/input.txt");

    var plays = lines.Select(line =>
    {
        var spl = line.Split(' ');

        return new Round(spl[0][0], (char)(spl[1][0] - ('X' - 'A')));
    });

    Console.WriteLine($"Score: {plays.Sum(s => s.Score)}");
}

void PartTwo()
{
    var lines = File.ReadAllLines("02/input.txt");

    char InstructionToPlay(char opponentPlay, char instruction)
    {
        return instruction switch
        {
            'X' => Round.Normalize((char)(opponentPlay - 1)),
            'Y' => Round.Normalize(opponentPlay),
            'Z' => Round.Normalize((char)(opponentPlay + 1)),
            _ => throw new ArgumentOutOfRangeException(nameof(instruction), instruction, null)
        };
    }

    var plays = lines.Select(line =>
    {
        var spl = line.Split(' ');

        var opponentPlay = spl[0][0];
        var instruction = spl[1][0];

        return new Round(opponentPlay, InstructionToPlay(opponentPlay, instruction));
    });

    Console.WriteLine($"Score: {plays.Sum(s => s.Score)}");
}

internal class Round
{
    private readonly char opponentPlay;
    private readonly char myPlay;

    public Round(char opponentPlay, char myPlay)
    {
        this.opponentPlay = opponentPlay;
        this.myPlay = myPlay;
    }

    public int Score => this.PlayToScore() + this.ResultToScore();

    private int PlayToScore() => (this.myPlay - 'A') + 1;

    private int ResultToScore()
    {
        if (this.opponentPlay == this.myPlay)
        {
            return 3;
        }

        return this.IsWin() ? 6 : 0;
    }

    private bool IsWin()
    {
        return Normalize((char)(this.opponentPlay + 1)) == this.myPlay;
    }

    public static char Normalize(char play) => (char)('A' + (play - 'A' + 3) % 3);
}
