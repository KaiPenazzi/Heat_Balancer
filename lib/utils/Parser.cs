namespace utils;

using System.Collections.Generic;

public class Parser
{
    public static List<int> DataToIntList(string data)
    {
        List<int> numbers = new List<int>();
        string[] strNumbers = data.Split(",");

        foreach (var strNumber in strNumbers)
        {
            var doubleN = double.Parse(strNumber);
            numbers.Add((int)doubleN);
        }

        return numbers;
    }
}
