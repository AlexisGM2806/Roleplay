namespace MiddleEarth;

public class Spell
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public Spell(string name, int attack, int defense)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Spell other) return false;
        return Name == other.Name && Attack == other.Attack && Defense == other.Defense;
    }

    public override int GetHashCode() => HashCode.Combine(Name, Attack, Defense);
}