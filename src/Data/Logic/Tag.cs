using Chloride.RA2.MapExt.Interfaces;
namespace Chloride.RA2.MapExt.Data;

public enum RepeatOption {
    OneTimeOr = 0,
    RepeatingOr = 1,
    OneTimeAnd = 2
    // no RepeatingAnd in game.
}

public class Tag : IComponent
{
    public string RegName { get; set; } = string.Empty;
    public RepeatOption Repeat = RepeatOption.OneTimeOr;
    public string Description { get; set; } = string.Empty;
    public string Trigger = string.Empty;

    public override string ToString() => $"Tag {RegName}: {Repeat}";
}
