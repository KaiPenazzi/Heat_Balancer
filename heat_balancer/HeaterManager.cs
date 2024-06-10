using heaterobj;
using exceptions;
using result;

namespace heatermanager;

public class HeaterManager
{
    private List<HeaterObj> heaters = new List<HeaterObj>();
    private HttpClient client = new HttpClient();

    public HeaterManager()
    {
    }

    //add a new Heater to the heaters list
    public int add(HeaterObj heater)
    {
        try
        {
            var resTask = client.GetAsync(heater.IP + "/ok");
            resTask.Wait();
            var res = resTask.Result;
        }
        catch (Exception e)
        {
            Console.Write("ip is wrong\n" + e);
            throw new IpException("cant connect to ip");
        }

        heaters.Add(heater);
        return heater.ID;
    }

    public void remove(int ID)
    {
        foreach (var item in heaters)
        {
            if (item.ID == ID)
            {
                heaters.Remove(item);
                break;
            }
        }
    }

    public List<HeaterObj> getStatus()
    {
        GetDemands();
        return heaters;
    }

    private async void GetDemands()
    {
        foreach (var heater in heaters)
        {
            var response = await client.GetAsync(heater.IP + "/state");
            var respnseString = await response.Content.ReadAsStringAsync();

            heater.demand = int.Parse(respnseString);
        }
    }

    public async Task<Result> Run(int id, List<int> demands, int time)
    {
        var output = new Result(id, "not found");

        var heater = heaters.Find(item => item.ID == id);

        if (heater != null)
        {
            output = new Result(id, heater?.Name);

            foreach (int demand in demands)
            {
                var values = new Dictionary<string, string>();
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(heater.IP + "/start/?demand=" + demand, content);
                var responesString = await response.Content.ReadAsStringAsync();

                output.Data.Add([demand, int.Parse(responesString)]);

                Thread.Sleep(time);
            }

            var cont = new FormUrlEncodedContent(new Dictionary<string, string>());
            var res = await client.PostAsync(heater.IP + "/stop", cont);
        }

        return output;
    }

    public List<int> GetHeaterIds()
    {
        var ids = new List<int>();
        foreach (var item in heaters)
        {
            ids.Add(item.ID);
        }

        return ids;
    }
}

