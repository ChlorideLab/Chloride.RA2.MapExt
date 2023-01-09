using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Interfaces;

namespace Chloride.RA2.MapExt.Data;

public class Waypoint : IObject {
    public Cell Coord { get; set; }
    public int ID = 0;

    public override string ToString() => $"WP {ID}: ({Coord.X}, {Coord.Y})";

    public IniEntry ToPair() => new(ID.ToString(), Cell.Join(Coord));
}