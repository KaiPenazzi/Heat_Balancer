namespace simulator;

using dataspace;
using heatermanager;
using result;
using resultmanager;

public class Simulator
{
    private DataSpace? DS { get; set; }
    private HeaterManager? HM { get; set; }
    private ResultManager? RM { get; set; }

    public Simulator(DataSpace ds, HeaterManager hm, ResultManager rm)
    {
        DS = ds;
        HM = hm;
        RM = rm;
    }


    public async Task Start(int time)
    {
        var result = new List<Result>();
        var tasks = new List<Task<Result>>();
        var ids = HM?.GetHeaterIds();

        if (ids == null)
            return;

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

        if (RM != null)
            RM.Data = result;
    }
}
