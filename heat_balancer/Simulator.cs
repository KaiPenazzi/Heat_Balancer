namespace simulator;

using dataspace;
using heatermanager;

public class Simulator
{
    private DataSpace? DS { get; set; }
    private HeaterManager? HM { get; set; }

    public Simulator(DataSpace ds, HeaterManager hm)
    {
        DS = ds;
        HM = hm;
    }


    public async Task<List<List<int[]>>> Start(int time)
    {
        var result = new List<List<int[]>>();
        var tasks = new List<Task<List<int[]>>>();
        var ids = HM?.GetHeaterIds();

        if (ids == null)
            return result;

        foreach (var id in ids)
        {

            tasks.Add(Task.Run(async () =>
            {
                List<int[]> res = new List<int[]>();
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
