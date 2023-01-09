using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Interfaces;

namespace Chloride.RA2.MapExt.Data;

public class Terrain : IObject
{
    public Cell Coord { get; set; }
    public string Type { get; set; } = string.Empty;

    public override string ToString() => $"{Type}: ({Coord.X}, {Coord.Y})";

    public IniEntry ToPair() => new(Cell.Join(Coord), Type);
}