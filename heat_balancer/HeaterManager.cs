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

    public String getStatus()
    {
        String ret = "";
        foreach (var item in heaters)
        {
            ret += "Name: " + item.Name + " ID: " + item.ID + " IP: " + item.IP + "\n";
        }
        return ret;
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
