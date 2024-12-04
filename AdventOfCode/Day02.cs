namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {Solver01()}, part 1");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {Solver02()}, part 1");

    private long Solver01()
    {
        var totalSafe = 0;
        foreach (string line in _input.ReplaceLineEndings("\n").TrimEnd().Split('\n'))
        {
            var reports = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var total = reports.Select(long.Parse).ToArray();

            var safe = IsSafeReport(total);

            if (safe)
                totalSafe++;
        }

        return totalSafe;
    }

    private long Solver02()
    {
        var totalSafe = 0;
        foreach (string line in _input.ReplaceLineEndings("\n").TrimEnd().Split('\n'))
        {
            var reports = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var report = reports.Select(long.Parse).ToArray();


            if (IsSafeReport(report) || CanBeMadeSafeByRemovingOne(report))
            {
                totalSafe++;
            }
        }

        return totalSafe;
    }

    private bool IsSafeReport(long[] levels)
    {
        bool isIncreasing = levels[1] > levels[0];
        for (int i = 1; i < levels.Length; i++)
        {
            long difference = levels[i] - levels[i - 1];

            if (difference == 0 || Math.Abs(difference) > 3)
            {
                return false;
            }

            if ((isIncreasing && difference < 0) || (!isIncreasing && difference > 0))
            {
                return false;
            }
        }

        return true;
    }

    private bool CanBeMadeSafeByRemovingOne(long[] levels)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            var reducedLevels = levels.Where((_, index) => index != i).ToArray();
            if (IsSafeReport(reducedLevels))
            {
                return true;
            }
        }

        return false;
    }
}