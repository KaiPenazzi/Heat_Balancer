using stateheater;

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

    private StateHeater State { get; set; }

    private Heater()
    {
        State = StateHeater.waiting;
    }

    public void start()
    {
        State = StateHeater.running;
    }

    public void stop()
    {
        State = StateHeater.waiting;
    }

    public StateHeater state()
    {
        return State;
    }
}
