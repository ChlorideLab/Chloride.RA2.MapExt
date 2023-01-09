using Chloride.RA2.MapExt.Data;

namespace Chloride.RA2.MapExt.Utils;

public static class GenericObjectUtil {
    public static T NewObject<T>(string[] val) where T : GenericObject, new() => new T
    {
        Owner = val[0],
        Type = val[1],
        Health = int.Parse(val[2]),
        Coord = new()
        {
            X = int.Parse(val[3]),
            Y = int.Parse(val[4])
        }
    };

    public static T NewUnit<T>(string[] val) where T : FootObject, new() {
        var ret = GenericObjectUtil.NewObject<T>(val);
        ret.Facing = int.Parse(val[5]);
        ret.Mission = val[6];
        ret.Tag = val[7];
        ret.Veteran = int.Parse(val[8]);
        ret.Group = int.Parse(val[9]);
        return ret;
    }
}