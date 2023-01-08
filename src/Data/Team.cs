using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Interfaces;

namespace Chloride.RA2.MapExt.Data;

public class Team : IComponent
{
    public string RegName { get; private set; }
    public string Description { get; set; }
    public Team() {
        RegName = string.Empty;
        Description = "New TeamType";
    }
    public Team(string name) : this() {
        RegName = name;
    }
    public Team(IniSection isect) {
        RegName = isect.Name;
        Description = isect["Name"].ToString();
        isect.Remove("Name");
        foreach (var i in isect.Keys){
            var prop = this.GetType().GetProperty(i);
            var type = prop!.PropertyType;
            prop.SetValue(this, Convert.ChangeType(isect[i], type));
        }
    }

    public int Max = 5;
    public int Group = -1;
    public string House = "<none>";
    public string Script = "<none>";
    public string TaskForce = "<none>";
    public int Priority = 5;
    public int Waypoint = 0;
    public int TechLevel = 0;
    public int VeteranLevel = 1; // 1-3
    public int MindControlDecision = 0; // 0-5
    public bool AreTeamMembersRecruitable = true;
    public bool Full = false;
    public bool Whiner = false;
    public bool Droppod = false;
    public bool Suicide = false;
    public bool Loadable = false;
    public bool Prebuild = false;
    public bool Annoyance = false;
    public bool IonImmune = false;
    public bool Recruiter = false;
    public bool Reinforce = false;
    public bool Aggressive = false;
    public bool Autocreate = false;
    public bool GuardSlower = false;
    public bool OnTransOnly = false;
    public bool AvoidThreats = false;
    public bool LooseRecruit = false;
    public bool IsBaseDefense = false;
    public bool UseTransportOrigin = false;
    public bool OnlyTargetHouseEnemy = false;
    public bool TransportsReturnOnUnload = false;

    public override string ToString() => $"Team {RegName}";
}