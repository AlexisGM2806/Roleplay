namespace MiddleEarth;

public class Staff
{
    public int Attack { get; set; }
    public int Defense { get; set; }

    public Staff(int attack, int defense)
    {
        Attack = attack;
        Defense = defense;
    }
}

public class Bow
{
    public int Attack { get; set; }

    public Bow(int attack)
    {
        Attack = attack;
    }
}

public class Helmet
{
    public int Defense { get; set; }

    public Helmet(int defense)
    {
        Defense = defense;
    }
}

public class Sword
{
    public int Attack { get; set; }

    public Sword(int attack)
    {
        Attack = attack;
    }
}

public class Shield
{
    public int Defense { get; set; }

    public Shield(int defense)
    {
        Defense = defense;
    }
}

public class Axe
{
    public int Attack { get; set; }

    public Axe(int attack)
    {
        Attack = attack;
    }
}

public class Armor
{
    public int Defense { get; set; }

    public Armor(int defense)
    {
        Defense = defense;
    }
}