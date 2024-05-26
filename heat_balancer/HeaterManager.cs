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

}
