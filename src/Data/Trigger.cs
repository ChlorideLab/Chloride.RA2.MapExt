using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Interfaces;
namespace Chloride.RA2.MapExt.Data;

public class Trigger : IComponent {
    public class Event {
        public int ID = 0;
        public List<string> Params = new();
    }
    public class Action
    {
        public int ID = 0;
        public string[] Params = new string[6];
        public int Waypoint = 0;
    }
    public string RegName { get; set; } = string.Empty;
    public string Owner = string.Empty;
    public string AssociatedTo = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Disabled = false;
    public bool EasyEnable = true;
    public bool MidEnable = true;
    public bool HardEnable = true;
    public List<Event> Events = new();
    public List<Action> Actions = new();

    internal void LoadEvents(string[] val) {
        // todo
    }
    internal void LoadActions(string[] val) {
        // todo
    }
    public IniEntry ToPair() => new(
        RegName,
        string.Format(
            "{0},{1},{2},{3},{4},{5},{6},0",
            this.Owner,
            this.AssociatedTo,
            this.Description,
            Convert.ToInt32(Disabled),
            Convert.ToInt32(EasyEnable),
            Convert.ToInt32(MidEnable),
            Convert.ToInt32(HardEnable))
    );
    public IniValue ExportEvents() => new(); // todo
    public IniValue ExportActions() => new(); // todo
    public override string ToString() => $"Trigger {RegName}";
}