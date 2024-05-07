namespace heaterobj;

public class HeaterObj
{
    public static int ids { get; set; }

    public int id { get; set; }
    public string? name { get; set; }
    public string? ip { get; set; }

    public HeaterObj(string name, string ip)
    {
        this.id = ids;
        this.name = name;
        this.ip = ip;

        ids++;
    }
}
