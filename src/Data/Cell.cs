namespace Chloride.RA2.MapExt.Data;

public struct Cell
{
    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString() => $"{X},{Y}";

    public static Cell Split(string coord)
    {
        var ret = new Cell { X = int.Parse(coord) % 1000 };
        ret.Y = int.Parse(coord.Substring(0, coord.LastIndexOf($"{ret.X:D3}")));
        return ret;
    }

    public static string Join(Cell p2d) => $"{1000 * p2d.Y + p2d.X}";
}