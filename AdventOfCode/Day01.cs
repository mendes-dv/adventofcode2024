namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {Solver01()}, part 1");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {Solver02()}, part 2");

    private long Solver01()
    {
        List<long> listABuffer = new();
        List<long> listBBuffer = new();
        foreach (string line in _input.ReplaceLineEndings("\n").TrimEnd().Split('\n'))
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            listABuffer.Add(long.Parse(parts[0]));
            listBBuffer.Add(long.Parse(parts[1]));
        }
        var listA = listABuffer.ToArray();
        var listB = listBBuffer.ToArray();
        
        return CalculateTotalDistance(listA, listB);
    }

    private long CalculateTotalDistance(long[] list1, long[] list2)
    {
        var sortedA = list1.Order().ToList();
        var sortedB = list2.Order().ToList();
        long totalDistance = 0;
        for (int i = 0; i < sortedA.Count(); i++)
        {
            totalDistance += Math.Abs(sortedA[i] - sortedB[i]);
        }

        return totalDistance;
    }
    
    
    private long Solver02()
    {
        List<long> listABuffer = new();
        List<long> listBBuffer = new();
        foreach (string line in _input.ReplaceLineEndings("\n").TrimEnd().Split('\n'))
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            listABuffer.Add(long.Parse(parts[0]));
            listBBuffer.Add(long.Parse(parts[1]));
        }
        var listA = listABuffer.ToArray();
        var listB = listBBuffer.ToArray();
        
        return CalculateToMatches(listA, listB);
    }
    
    private long CalculateToMatches(long[] list1, long[] list2)
    {
        var sortedA = list1.Order().ToList();
        var sortedB = list2.Order().ToList();
        long totalDifference = 0;
        for (int i = 0; i < sortedA.Count(); i++)
        {
            var match = sortedB.Count(c => c == sortedA[i]);
            
            totalDifference += Math.Abs(sortedA[i] * match);
        }

        return totalDifference;
    }
}