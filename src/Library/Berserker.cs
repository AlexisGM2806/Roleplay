namespace MiddleEarth;

public class Berserker
{
    private Axe? axe;
    private Armor? armor;

    public string Name { get; set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public Berserker(string name)
    {
        Name = name;
        MaxHealth = 150; 
        Health = MaxHealth;
    }

    public int GetAttack() => axe?.Attack ?? 0;

    public int GetDefense() => armor?.Defense ?? 0;

    public void ReceiveAttack(int attack_power)
    {
        int damage = Math.Max(0, attack_power - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    public void Heal() => Health = MaxHealth;

    public void SetAxe(Axe? newAxe) => axe = newAxe;
    public void SetArmor(Armor? newArmor) => armor = newArmor;
}