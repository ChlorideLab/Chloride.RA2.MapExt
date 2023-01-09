using Chloride.RA2.MapExt.Interfaces;

namespace Chloride.RA2.MapExt.Data;
public class Country : IComponent
{
    public string RegName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Side = string.Empty;
    public string Color = "Gold";
    public char Prefix => Side == "GDI" ? 'G' : 'B';
    public string Suffix => Side == "GDI" ? "Allied" : "Soviet";
    public bool SmartAI = true;
    public string ParentCountry = string.Empty;

    // buffs below, according to RulesMD
    public double ArmorAircraftMult = 1;
    public double ArmorUnitsMult = 1;
    public double ArmorInfantryMult = 1;
    public double ArmorBuildingsMult = 1;
    public double ArmorDefensesMult = 1;

    public double IncomeMult = 1;

    public double CostAircraftMult = 1;
    public double CostUnitsMult = 1;
    public double CostInfantryMult = 1;
    public double CostBuildingsMult = 1;
    public double CostDefensesMult = 1;

    // Aircrafts take another movement system,
    // so multiplier doesn't affect.
    // As for buildings, they even can't move right?
    public double SpeedUnitsMult = 1;
    public double SpeedInfantryMult = 1;

    public double BuildTimeAircraftMult = 1;
    public double BuildTimeUnitsMult = 1;
    public double BuildTimeInfantryMult = 1;
    public double BuildTimeBuildingsMult = 1;
    public double BuildTimeDefensesMult = 1;
}