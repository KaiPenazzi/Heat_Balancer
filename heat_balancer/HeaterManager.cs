using heaterobj;
using dataspace;
using state;

namespace heatermanager;

public class HeatManager
{
    private DataSpace? Data;
    private List<HeaterObj> heaters = new List<HeaterObj>();

    public HeatManager(DataSpace ds)
    {
        Data = ds;
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

    public void Start(Simulation mode)
    {
    }
}
