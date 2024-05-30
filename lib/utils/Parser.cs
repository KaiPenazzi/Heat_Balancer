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
            var doubleN = 0.0;
            try
            {
                doubleN = double.Parse(strNumber);
                numbers.Add(Convert.ToInt32(doubleN));
            }
            catch (Exception e)
            {
                Console.WriteLine("error while parsing: '" + strNumber + "'\n" + e.ToString());
            }
        }

        return numbers;
    }
}
