using System.Collections.Generic;
using System.Collections;
using Chloride.RA2.IniExt;

namespace Chloride.RA2.MapExt.Components;

public class Script : IComponent
{
    public string RegName { get; private set; }
    public string Description { get; set; }

    internal ScriptAction[] Actions;

    public Script() {
        RegName = string.Empty;
        Description = "New Script";
        Actions = new ScriptAction[50];
    }

    public Script(string name) : this() {
        RegName = name;
    }

    public Script(IniSection isect) : this() {
        RegName = isect.Name;
        Description = isect["Name"] ?? string.Empty;
        isect.Remove("Name");
        foreach (var i in isect.Items) {
            var _ = i.Value?.Split(',');
            Actions[int.Parse(i.Key)] = new() {
                Id = int.Parse(_[0]),
                Param = int.Parse(_[1])
            };
        }
    }

    public ScriptAction this[int idx] { get => Actions[idx]; }
    public override string ToString() => $"Script {RegName}";
    // api tbc
}