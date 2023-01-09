using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Utils;

namespace Chloride.RA2.MapExt.Data;

public enum SpotlightOption {
    None = 0,
    CurveTowardFacing = 1,
    Circle = 2
}

public class Building : GenericObject
{
    public override string Type { get; set; } = "GAPOWR";
    public bool AISellable = false;
    public bool AIRebuildable = false; // obsolete, as base node implemented.
    public bool Powered = true;
    public int UpgradeCount => Upgrades.Count(i => i != "None");
    public string[] Upgrades = { "None", "None", "None" };
    public SpotlightOption Spotlight = SpotlightOption.None;
    public bool AIRepair = true;
    public bool Norminal = false; // EnemyUIName doesn't work until Ares 0.b.

    // only record the top cell.
    // for actual placement u should also consider the foundation,
    // which is too complex for a scripting lib.
    public override string ToString() => $"{Type} Top({Coord.X}, {Coord.Y})";

    public static Building FromValue(string[] val) {
        var ret = GenericObjectUtil.NewObject<Building>(val);
        ret.Facing = int.Parse(val[5]);
        ret.Tag = val[6];
        ret.AISellable = val[7] == "1";
        ret.AIRebuildable = val[8] == "1";
        ret.Powered = val[9] == "1";
        ret.Upgrades = val[12..15];
        ret.Spotlight = (SpotlightOption)(int.Parse(val[11]));
        ret.AIRepair = val[15] == "1";
        ret.Norminal = val[16] == "1";
        return ret;
    }

    public override IniValue Join() => IniValue.Join(
        Owner, Type, Health.ToString(), Coord.ToString(),
        Facing.ToString(), Tag,
        Convert.ToInt32(AISellable).ToString(),
        Convert.ToInt32(AIRebuildable).ToString(),
        Convert.ToInt32(Powered).ToString(),
        UpgradeCount.ToString(), ((int)Spotlight).ToString(),
        string.Join(',', Upgrades),
        Convert.ToInt32(AIRepair).ToString(),
        Convert.ToInt32(Norminal).ToString()
    );
}