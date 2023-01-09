using Chloride.RA2.IniExt;

namespace Chloride.RA2.MapExt.Data;

public class House
{
    // This guy without "Name" tag is not a standard IComponent.
    public string RegName = " House";
    public int IQ = 0;
    public string Edge = "West";
    public string Color = "Gold";
    public List<string> Allies = new();
    public string Country = string.Empty;
    private int _credits = 0;
    public int Credits { get => _credits * 100; set => _credits = value / 100; }
    public List<BaseNode> Nodes = new();
    public int NodeCount => Nodes.Count;
    public int TechLevel = 10;
    public int PercentBuilt = 100;
    public bool PlayerControl = false;
    internal void LoadAllies(IniValue val) {
        Allies = val.Split().ToList();
    }
    internal void LoadNodes(IniSection house) {
        var nodes = house.Where(i => int.TryParse(i.Key, out _));
        int cnt = 0;
        foreach (var i in nodes) {
            if (i.Key != $"{cnt++:D3}")
                throw new FormatException("Nodes are not continuous, which will cause Fatal Error in game!");
            else {
                var node = i.Value.Split(',');
                Nodes.Add(new BaseNode
                {
                    RegName = node[0],
                    Y = int.Parse(node[1]),
                    X = int.Parse(node[2])
                });
            }
        }
    }
    public override string ToString() => RegName;
}