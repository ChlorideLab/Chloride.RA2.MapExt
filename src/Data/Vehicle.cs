using System.Data;
using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Utils;

namespace Chloride.RA2.MapExt.Data;

public class Vehicle : FootObject
{
    public override string Type { get; set; } = "AMCV";
    public bool OnBridge = false;
    public int FollowID = -1;

    public static Vehicle FromValue(string[] val) {
        var ret = GenericObjectUtil.NewUnit<Vehicle>(val);
        ret.OnBridge = val[10] == "1";
        ret.FollowID = int.Parse(val[11]);
        ret.AutoCreateNo = val[12] == "1";
        ret.AutoCreateYes = val[13] == "1";
        return ret;
    }

    public override IniValue Join() => IniValue.Join(
        Owner, Type, Health.ToString(), Coord.ToString(),
        Facing.ToString(), Mission, Tag, Veteran.ToString(),
        Group.ToString(), Convert.ToInt32(OnBridge).ToString(),
        FollowID.ToString(),
        Convert.ToInt32(AutoCreateNo).ToString(),
        Convert.ToInt32(AutoCreateYes).ToString()
    );
}