using System;

namespace Library;

public class Wizard
{
    public string Name {get;}
    private Spellbook spellbook = new Spellbook();
    private Staff staff = new Staff();
    public int Health {get; private set;}
    public int MaxHealth {get;private set;}

    public void SetStaff(Staff newStaff)
    {
        if (newStaff != null)
        {
            staff = newStaff;
        }
    }

    public void SetSpellbook(Spellbook newSpellbook)
    {
        if (newSpellbook != null)
        {
            spellbook = newSpellbook;
        }
    }
    public void ReceiveAttack (int attack_power)
    {
        int damage = Math.Max(0, attack_power - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    public int GetAttack()
    {
        return staff.Attack + spellbook.Attack;
    }
    public int GetDefense()
    {
        return staff.Defense + spellbook.Defense;
    }

    public void Heal()
    {
        Health = MaxHealth;
    }

    public Wizard (string name)
    {
        MaxHealth = 100;
        Health = MaxHealth;
        Name = name;
    }
}
