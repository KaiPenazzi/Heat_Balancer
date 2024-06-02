using result;

namespace resultmanager;

public class ResultManager
{
    private List<Result>? _data { get; set; }
    public List<Result> Data
    {
        get
        {
            if (_data == null)
            {
                return new List<Result>();
            }
            return _data;
        }
        set
        {
            _data = value;
        }
    }

    public List<Result> GetResults()
    {
        return Data;
    }
}
