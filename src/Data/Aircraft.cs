using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Utils;

namespace Chloride.RA2.MapExt.Data;

public class Aircraft : FootObject
{
    public override string Type { get; set; } = "ORCA";

    public static Aircraft FromValue(string[] val) {
        var ret = GenericObjectUtil.NewUnit<Aircraft>(val);
        ret.AutoCreateNo = val[10] == "1";
        ret.AutoCreateYes = val[11] == "1";
        return ret;
    }

    public override IniValue Join() => IniValue.Join(
        Owner, Type, Health.ToString(),
        Coord.ToString(), Facing.ToString(),
        Mission, Tag, Veteran.ToString(), Group.ToString(),
        Convert.ToInt32(AutoCreateNo).ToString(),
        Convert.ToInt32(AutoCreateYes).ToString()
    );
}