using System.Text;
using System.Globalization;

namespace Chloride.RA2.MapExt.Utils;

public static class HexUtil {
    // this util isn't only convert number between 2 expressions
    // to hex side, we also need to revert it (like 186A0 -> A08601).
    public static int Hex2Int(string hex) {
        // we know the hex would have 8 bit. so just cycle 4 times :P
        StringBuilder sb = new();
        for (int i = hex.Length - 2; i >= 0; i -= 2) {
            sb.Append(hex.Substring(i, 2));
        }
        return int.Parse(sb.ToString(), NumberStyles.HexNumber);
    }

    public static string Int2Hex(int num) {
        var ret = num.ToString("X8");
        StringBuilder sb = new();
        for (int i = ret.Length - 2; i >= 0; i -= 2) {
            sb.Append(ret.Substring(i, 2));
        }
        return sb.ToString();
    }
}