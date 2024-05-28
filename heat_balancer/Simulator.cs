namespace simulator;

using dataspace;
using heatermanager;
using state;

public class Simulator
{
    private DataSpace? DS { get; set; }
    private HeaterManager? HM { get; set; }

    public Simulator(DataSpace ds, HeaterManager hm)
    {
        DS = ds;
        HM = hm;
    }


    public async Task<List<List<int[]>>> Start(Simulation mode)
    {
        var result = new List<List<int[]>>();
        var tasks = new List<Task<List<int[]>>>();
        var ids = HM.GetHeaterIds();

        foreach (var id in ids)
        {

            tasks.Add(Task.Run(() =>
            {
                return HM.Run(id, DS.GetDemand(id));
            }));
        }

        foreach (var task in tasks)
        {
            result.Add(await task);
        }

        return result;
    }
}
