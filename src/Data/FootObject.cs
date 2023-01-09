namespace Chloride.RA2.MapExt.Data;

public abstract class FootObject : GenericObject {
    public virtual string Mission { get; set; } = "Guard";
    public virtual int Veteran { get; set; } = 0;
    public virtual int Group { get; set; } = -1;
    public virtual bool AutoCreateNo { get; set; } = false;
    public virtual bool AutoCreateYes { get; set; } = true;
}