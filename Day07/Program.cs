var lines = System.IO.File.ReadAllLines("07/input.txt");

var allDirs = new HashSet<Directory>();
var breadcrumbs = new Stack<Directory>();

var root = new Directory("/");
var current = root;
breadcrumbs.Push(root);
allDirs.Add(root);


for (var index = 0; index < lines.Length; index++)
{
    var line = lines[index];

    var cmdArgs = line.Split(" ");
    var cmd = cmdArgs[1];

    switch (cmd)
    {
        case "cd":
            Cd();
            break;
        case "ls":
            Ls();
            break;
        default:
            throw new InvalidOperationException();
    }

    void Cd()
    {
        if (cmdArgs[2] == "/")
        {
            current = root;
            breadcrumbs = new Stack<Directory>();
            breadcrumbs.Push(root);
            return;
        }

        if (cmdArgs[2] == "..")
        {
            current = breadcrumbs.Pop();
            return;
        }

        breadcrumbs.Push(current);
        current = current.Directories.Find(s => s.name == cmdArgs[2]);
    }

    void Ls()
    {
        var target = current;
        var innerI = index + 1;
        for (; innerI < lines.Length; innerI++)
        {
            var contentLine = lines[innerI].Split(" ");

            if (contentLine[0] == "dir")
            {
                if (target.Directories.All(s => s.name != contentLine[1]))
                {
                    var dir = new Directory(contentLine[1]);
                    allDirs.Add(dir);
                    target.Directories.Add(dir);
                }
            }
            else if (contentLine[0] == "$")
            {
                break;
            }
            else
            {
                if (target.Files.All(s => s.Name != contentLine[1]))
                {
                    target.Files.Add(new File(int.Parse(contentLine[0]), contentLine[1]));
                }
            }
        }

        index = innerI - 1;
    }
}

var sizeOfAllSmall = allDirs.Where(s => s.Size.Value < 100000).Sum(s => s.Size.Value);
Console.WriteLine($"Part one {sizeOfAllSmall}");

var totalSize = root.Size.Value;
var limit = 40_000_000;
var requiredAdditionalSpace = totalSize - limit;


var directoryToDelete = allDirs.Where(s => s.Size.Value > requiredAdditionalSpace).OrderBy(s => s.Size.Value).First();
Console.WriteLine($"Part two: {directoryToDelete.Size.Value}");

class File
{
    public File(int size, string name)
    {
        this.Size = size;
        this.Name = name;
    }

    public int Size { get; }
    public string Name { get; }
}

class Directory
{
    public readonly string name;

    public Directory(string name)
    {
        this.name = name;
    }

    public List<File> Files { get; } = new();

    public List<Directory> Directories { get; } = new();

    public Lazy<int> Size => new(() =>
    {
        return this.Files.Sum(s => s.Size) + this.Directories.Sum(s => s.Size.Value);
    });
}
