namespace MiddleEarth;

public class Elf
{
    private Bow? bow;
    private Helmet? helmet;

    public string Name { get; set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public Elf(string name)
    {
        Name = name;
        MaxHealth = 100;
        Health = MaxHealth;
    }

    public int GetAttack() => bow?.Attack ?? 0;

    public int GetDefense() => helmet?.Defense ?? 0;

    public void ReceiveAttack(int attack_power)
    {
        int damage = Math.Max(0, attack_power - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    public void Heal() => Health = MaxHealth;

    public void SetBow(Bow? newBow) => bow = newBow;
    public void SetHelmet(Helmet? newHelmet) => helmet = newHelmet;
}