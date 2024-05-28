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

        return Parser.DataToIntList(demand.Data);
    }

    public void AddDemand(Demand demand)
    {
        Data.Add(demand);
    }
}
