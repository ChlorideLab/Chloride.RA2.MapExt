using Chloride.RA2.IniExt;

namespace Chloride.RA2.MapExt.Components;

public class TaskForce : IComponent
{
    public string RegName { get; private set; }
    public string Description { get; set; }
    internal (int count, string item)[] Formation;

    public TaskForce() {
        RegName = string.Empty;
        Description = "New TaskForce";
        Formation = new (int, string)[6];
    }

    public TaskForce(string name) : this() {
        RegName = name;
    }

    public TaskForce(IniSection isect) : this() {
        RegName = isect.Name;
        Description = isect["Name"].ToString();
        isect.Remove("Name");
        foreach (var i in isect.Items) {
            var _ = i.Value.Split();
            Formation[int.Parse(i.Key)] = (int.Parse(_[0]), _[1]);
        }
    }

    public (int count, string item) this[int idx] { get => Formation[idx]; }
    public override string ToString() => $"TaskForce {RegName}";
}