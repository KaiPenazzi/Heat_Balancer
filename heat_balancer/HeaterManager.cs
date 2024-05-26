using heaterobj;

namespace heatermanager;

public class HeatManager
{
    private static HeatManager? _instance;
    public static HeatManager? Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new HeatManager();
            }
            return _instance;
        }
    }

    private List<HeaterObj> heaters = new List<HeaterObj>();

    //add a new Heater to the heaters list
    public int add(HeaterObj heater)
    {
        heaters.Add(heater);
        return heater.ID;
    }

    public void remove(int ID) {
        foreach (var item in heaters)
        {
            if(item.ID == ID)
            {
                heaters.Remove(item);
                break;
            }
        }
    }

    public String getStatus() {
        String ret = "";
        foreach (var item in heaters)
        {
            ret += "Name: " + item.Name + " ID: " + item.ID + " IP: " + item.IP + "\n";            
        }
        return ret;    
    }
}
