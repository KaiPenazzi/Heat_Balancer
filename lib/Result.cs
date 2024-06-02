namespace result;

public class Result
{
    public int ID { get; }
    public List<int[]> Data { get; }

    public Result(int id)
    {
        ID = id;
        Data = new List<int[]>();
    }
}
