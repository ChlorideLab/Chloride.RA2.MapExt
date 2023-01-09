namespace Chloride.RA2.MapExt.Data;

public class LocalVar {
    // just like in C++:
    //   bool casheen_burnt = 1; // without Phobos
    //   int homo = 114514; // with Phobos
    // however script actions only allow AN INT16 parameter.

    public string Name = string.Empty;
    // To support Phobos trigger actions, which is int32.
    public int Value = default;

    public override string ToString() => $"{Name}: {Value}";
}