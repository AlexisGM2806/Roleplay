namespace MiddleEarth;

public class Dwarf
{
    private Sword? sword;
    private Shield? shield;

    public string Name { get; set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public Dwarf(string name)
    {
        Name = name;
        MaxHealth = 120; 
        Health = MaxHealth;
    }

    public int GetAttack() => sword?.Attack ?? 0;

    public int GetDefense() => shield?.Defense ?? 0;

    public void ReceiveAttack(int attack_power)
    {
        int damage = Math.Max(0, attack_power - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    public void Heal() => Health = MaxHealth;

    public void SetSword(Sword? newSword) => sword = newSword;
    public void SetShield(Shield? newShield) => shield = newShield;
}