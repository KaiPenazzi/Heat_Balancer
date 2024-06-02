namespace simulator;

using dataspace;
using heatermanager;
using result;

public class Simulator
{
    private DataSpace? DS { get; set; }
    private HeaterManager? HM { get; set; }

    public Simulator(DataSpace ds, HeaterManager hm)
    {
        DS = ds;
        HM = hm;
    }


    public async Task<List<Result>> Start(int time)
    {
        var result = new List<Result>();
        var tasks = new List<Task<Result>>();
        var ids = HM?.GetHeaterIds();

        if (ids == null)
            return result;

        foreach (var id in ids)
        {

            tasks.Add(Task.Run(async () =>
            {
                Result res = new Result(id);
                if (HM != null && DS != null)
                    res = await HM.Run(id, DS.GetDemand(id), time);
                return res;
            }));
        }

        foreach (var task in tasks)
        {
            result.Add(await task);
        }

        return result;
    }
}
