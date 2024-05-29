namespace dataspace;

using demand;
using utils;

public class DataSpace
{
    private List<Demand> Data = new List<Demand>();

    public List<int> GetDemand(int id)
    {
        var demand = Data.Find(item => item.ID == id);

        if (demand == null)
            demand = new Demand();

        var data = demand.Data;

        if (data == null)
            data = "";

        return Parser.DataToIntList(data);
    }

    public void AddDemand(Demand demand)
    {
        Data.Add(demand);
    }
}
