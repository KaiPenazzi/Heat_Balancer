namespace heaterobj;

public class HeaterObj
{
    private static int ids { get; set; }

    public int ID { get; }
    public string? Name { get; }
    public string? IP { get; }

    public HeaterObj(string name, string ip)
    {
        this.ID = ids;
        this.Name = name;
        this.IP = ip;

        ids++;
    }
}
