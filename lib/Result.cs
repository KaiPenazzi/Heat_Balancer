namespace result;

public class Result
{
    public int ID { get; }
    public string Name { get; }
    public List<int[]> Data { get; }

    public Result(int id, string name)
    {

        Name = name;
        ID = id;
        Data = new List<int[]>();
    }
}
