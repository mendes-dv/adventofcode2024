using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day03 : BaseDay
{
    private readonly string _input;

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {Solver01()}, part 1");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {Solver02()}, part 2");

    private long Solver01()
    {
        string pattern = @"mul\(\d{1,3},\d{1,3}\)";
        MatchCollection matches = Regex.Matches(_input, pattern);

        var total = 0;
        foreach (Match match in matches)
        {
            string[] split = match.Value.Split(new char[] { '(', ',', ')' });
            total += int.Parse(split[1]) * int.Parse(split[2]);
        }

        return total;
    }

    private long Solver02()
    {
        string pattern = @"mul\(\d{1,3},\d{1,3}\)|don't\(\)|do\(\)";
        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(_input);

        var output = 0;
        var startStop = true;
        foreach (Match match in matches) {
            if (match.Value.Contains("don't()") || match.Value.Contains("do()")){
                startStop = !match.Value.Contains("don't()");
                continue;
            }
            if(!startStop){
                continue;
            }
            string[] split = match.Value.Split(new char[] { '(', ',', ')' });
            output += int.Parse(split[1]) * int.Parse(split[2]);
        }
        
        return output;
    }
}