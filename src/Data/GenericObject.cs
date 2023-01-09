using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Interfaces;

namespace Chloride.RA2.MapExt.Data;

public abstract class GenericObject : IObject
{
    public virtual string Owner { get; set; } = "Neutral House";
    public virtual string Type { get; set; } = string.Empty;
    public virtual int Health { get; set; } = 256;
    public virtual Cell Coord { get; set; } = default;
    public virtual int Facing { get; set; } = 0;
    public virtual string Tag { get; set; } = "None";

    public abstract IniValue Join();
    public override string ToString() => $"{Type} ({Coord.X}, {Coord.Y})";
}