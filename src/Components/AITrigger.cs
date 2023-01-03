using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Utils;

namespace Chloride.RA2.MapExt.Components;

public enum AITriggerCond {
    Any = -1,
    EnemyOwn = 0,
    FriendlyOwn = 1,
    EnemyPowerYellow = 2,
    EnemyPowerRed = 3,
    EnemyCredits = 4,
    FriendlyIron = 5,
    FriendlyChrono = 6,
    NeutralOwn = 7
}

public enum AITriggerCalc {
    Less = 0,
    LessOrEqual = 1,
    Equal = 2,
    GreaterOrEqual = 3,
    Greater = 4,
    NotEqual = 5
}

public class AITrigger : IComponent
{
    public string RegName { get; private set; }
    public string Description { get; set; }

    public AITrigger() {
        RegName = string.Empty;
        Description = "New AITrigger";
    }

    public AITrigger(string name) : this() {
        RegName = name;
    }

    // according to latest AI tutorial.
    public AITrigger(IniEntry entry) {
        RegName = entry.Key;
        var _ = entry.Value!.Split(',');
        Description = _[0];
        TeamA = _[1];
        Owner = _[2];
        TechLevel = int.Parse(_[3]);
        Condition = (AITriggerCond)(int.Parse(_[4]));
        ConditionOwn = _[5];
        ConditionCount = HexUtil.Hex2Int(_[6][0..8]);
        ConditionCalculator = (AITriggerCalc)(int.Parse(_[6][9..11]));
        WeightBasic = float.Parse(_[7]);
        WeightMin = float.Parse(_[8]);
        WeightMax = float.Parse(_[9]);
        Multiplay = _[10] == "1";
        Side = int.Parse(_[12]);
        TeamB = _[14];
        AIEasyEnable = _[15] == "1";
        AIMidEnable = _[16] == "1";
        AIHardEnable = _[17] == "1";
    }

    public string TeamA = "<none>"; // main team
    public string Owner = "<all>";
    public int TechLevel = 1;
    public AITriggerCond Condition = AITriggerCond.Any;
    /// <summary>
    /// When we mentioned sb. "owned" sth. in AITriggerCondition,
    /// the Prerequisite just means that "sth.".
    /// </summary>
    public string ConditionOwn = "<none>";
    public int ConditionCount = 0;
    public AITriggerCalc ConditionCalculator = AITriggerCalc.Less;
    public float WeightBasic = 500;
    public float WeightMin = 0;
    public float WeightMax = 500;
    public bool Multiplay = true;
    private short unknown_1 = 0;
    /// <summary>
    /// 0 for all, 1 and then for specific side.
    /// </summary>
    public int Side = 0;
    private short unknown_2 = 0;
    public string TeamB = "<none>";
    public bool AIEasyEnable = true;
    public bool AIMidEnable = true;
    public bool AIHardEnable = true;

    public override string ToString() => $"AITrigger {RegName}";
}