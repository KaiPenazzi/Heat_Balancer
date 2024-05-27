namespace dataspace;

using demand;

public class DataSpace
{
    private List<Demand> Data = new List<Demand>();

    public Demand GetDemand(int id)
    {
        var demand = Data.Find(item => item.ID == id);

        if (demand == null)
            demand = new Demand();

        return demand;
    }

    public void AddDemand(Demand demand)
    {
        Data.Add(demand);
    }
}
