namespace Chloride.RA2.MapExt.Data;

public class BaseNode {
    public string RegName = string.Empty;
    public int Y = 0;
    public int X = 0;
    public BaseNode() {}
    public override string ToString() => $"{RegName},{Y},{X}";
}