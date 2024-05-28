namespace test;

using utils;

public class TestParser
{
    [Fact]
    public void test()
    {
        string input = @"21.0
21.0
21.0
21.0
21.0
1541.0
1541.0
1541.0
1541.0
1541.0
1541.0
1541.0
1541.0
1541.0
1541.0
1541.0
1541.0
1541.0  ";

        var numbers = Parser.DataToIntList(input);
        Assert.Equal(21, numbers.ElementAt(0));
        Assert.Equal(18, numbers.Count());
    }

}
