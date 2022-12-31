using Chloride.RA2.IniExt;

namespace Chloride.RA2.MapExt.Components;

public class TaskForce : ICompSection
{
    public string SectionName { get; private set; }
    public string Description { get; set; }
    internal (int count, string item)[] Formation;

    public TaskForce() {
        SectionName = string.Empty;
        Description = "New TaskForce";
        Formation = new (int, string)[6];
    }

    public TaskForce(string name) : this() {
        SectionName = name;
    }

    public TaskForce(IniSection isect) : this() {
        SectionName = isect.Name;
        Description = (string)isect["Name"];
        isect.Remove("Name");
        foreach (var i in isect.Items) {
            var _ = i.Value.TrySplit();
            Formation[int.Parse(i.Key)] = (int.Parse(_[0]), _[1]);
        }
    }

    public (int count, string item) this[int idx] { get => Formation[idx]; }
    public override string ToString() => $"TaskForce {SectionName}";
}