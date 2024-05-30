using heaterobj;

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

    public async Task<List<int[]>> Run(int id, List<int> demands, int time)
    {
        var output = new List<int[]>();

        var url = heaters.Find(item => item.ID == id)?.IP;

        foreach (int demand in demands)
        {
            var values = new Dictionary<string, string>
            {
                { "stfff", ""+demand},
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(url + "/start/?demand=" + demand, content);
            var responesString = await response.Content.ReadAsStringAsync();

            output.Add([demand, int.Parse(responesString)]);

            Thread.Sleep(time);
        }

        var cont = new FormUrlEncodedContent(new Dictionary<string, string>());
        var res = await client.PostAsync(url + "/stop", cont);

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
