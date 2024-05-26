namespace heater;

public class Heater
{
    private static Heater? _instance;
    public static Heater Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Heater();
            }

            return _instance;
        }
    }

    private int _heating;
    private int Heating
    {
        get
        {
            return _heating;
        }

        set
        {
            if (value >= 0)
            {
                _heating = value;
            }
            if (value > 4000)
            {
                _heating = 4000;
            }
        }
    }

    private Heater()
    {
        Heating = 0;
    }

    public void start(int demand)
    {
        Heating = demand;
    }

    public void stop()
    {
        Heating = 0;
    }

    public int state()
    {
        return Heating;
    }
}
