namespace MiddleEarth;

public class Wizard
{
    private Spellbook spellbook;
    private Staff? staff;

    public string Name { get; set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public Wizard(string name)
    {
        Name = name;
        MaxHealth = 100;
        Health = MaxHealth;
        spellbook = new Spellbook();
    }

    public int GetAttack() => spellbook.Attack + (staff?.Attack ?? 0);

    public int GetDefense() => spellbook.Defense + (staff?.Defense ?? 0);
    public void ReceiveAttack(int attack_power)
    {
        int damage = Math.Max(0, attack_power - GetDefense());
        Health = Math.Max(0, Health - damage);
    }
    public void Heal() => Health = MaxHealth;

    public void SetStaff(Staff? newStaff) => staff = newStaff;
    public void SetSpellbook(Spellbook newSpellbook) => spellbook = newSpellbook;

    public Spellbook GetSpellbook() => spellbook;
}