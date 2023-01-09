using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Utils;

namespace Chloride.RA2.MapExt.Data;

public class Infantry : FootObject
{
    public int SubCell = 0;
    public override string Type { get; set; } = "E1";
    public bool OnBridge = false;

    public Infantry() {}

    public static Infantry FromValue(string[] val) {
        var ret = GenericObjectUtil.NewObject<Infantry>(val);
        ret.SubCell = int.Parse(val[5]);
        ret.Mission = val[6];
        ret.Facing = int.Parse(val[7]);
        ret.Tag = val[8];
        ret.Veteran = int.Parse(val[9]);
        ret.Group = int.Parse(val[10]);
        ret.OnBridge = val[11] == "1";
        ret.AutoCreateNo = val[12] == "1";
        ret.AutoCreateYes = val[13] == "1";
        return ret;
    }

    public override IniValue Join() => IniValue.Join(
        Owner, Type, Health.ToString(), Coord.ToString(),
        SubCell.ToString(), Mission, Facing.ToString(),
        Tag, Veteran.ToString(), Group.ToString(),
        Convert.ToInt32(OnBridge).ToString(),
        Convert.ToInt32(AutoCreateNo).ToString(),
        Convert.ToInt32(AutoCreateYes).ToString()
    );
}