using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Interfaces;

namespace Chloride.RA2.MapExt.Data;

public class CellTag : IObject
{
    public Cell Coord { get; set; }
    public string Tag { get; set; } = string.Empty;

    public override string ToString() => $"{Tag}: ({Coord.X}, {Coord.Y})";

    public IniEntry ToPair() => new(Cell.Join(Coord), Tag);
}