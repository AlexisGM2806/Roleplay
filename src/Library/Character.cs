using System;
using System.Collections.Generic;

namespace Library;

public abstract class Character
{
    public int MaxHealth { get; private set;}

    public int Health { get; private set;}

    public string Name { get; }

    private List<IObject> Objetos = new List<IObject>();

    public int GetAttack()
    {
        int ataque = 0;
        foreach (IObject objeto in Objetos)
        {
            ataque += objeto.Attack;
        }
        return ataque;
    }

        public int GetDefense()
    {
        int defensa = 0;
        foreach (IObject objeto in Objetos)
        {
            defensa += objeto.Defense;
        }
        return defensa;
    }

    public void ReceiveAttack(Character attacker)
    {
        if (attacker == null)
        {
            return;
        }

        int damage = Math.Max(0, attacker.GetAttack() - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    public void Heal()
    {
        Health = MaxHealth;
    }
    
    protected Character (string name, int maxHealth)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
    }
}
