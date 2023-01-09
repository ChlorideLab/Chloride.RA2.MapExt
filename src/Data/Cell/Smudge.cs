using Chloride.RA2.IniExt;
using Chloride.RA2.MapExt.Interfaces;

namespace Chloride.RA2.MapExt.Data;

public class Smudge : IObject
{
    public Cell Coord { get; set; }
    public string Type { get; set; } = string.Empty;
    public bool Ignored = false;

    public IniValue Join() => IniValue.Join(
        Type,
        Coord.ToString(),
        Convert.ToInt32(Ignored).ToString()
    );
}