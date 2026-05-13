namespace Library;

public class Axe : IAttackItem
{
    public int Attack { get; }
    public bool IsMagical { get; } = false;

    public Axe() : this(0) { }

    public Axe(int attack)
    {
        Attack = attack;
    }
}