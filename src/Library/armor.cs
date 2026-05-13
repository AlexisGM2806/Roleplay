namespace Library;

public class Armor : IDefenseItem
{
    public int Defense { get; }
    public bool IsMagical { get; } = false;

    public Armor() : this(0) { }

    public Armor(int defense)
    {
        Defense = defense;
    }
}