namespace Library;

public class Axe : IObject
{
    public int Attack { get; }
    public int Defense { get; } = 0;
    public bool IsMagical { get; } = false;

    public Axe() : this(0) { }

    public Axe(int attack)
    {
        Attack = attack;
    }
}