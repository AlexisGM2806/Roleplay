using System;
using System.Collections.Generic;

namespace Library;

public abstract class Character
{
    /// <summary>
    /// Vida máxima del personaje.
    /// </summary>
    public int MaxHealth { get; private set; }

    /// <summary>
    /// Vida actual del personaje.
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    /// Nombre del personaje.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Indica si el personaje ha muerto.
    /// </summary>
    public bool IsDead
    {
        get
        {
            return Health == 0;
        }
    }

    /// <summary>
    /// Lista de items equipados por el personaje.
    /// </summary>
    protected readonly List<IItem> items = new List<IItem>();

    /// <summary>
    /// Agrega un item al personaje.
    /// Los personajes normales no pueden equipar items mágicos.
    /// </summary>
    /// <param name="item">Item a equipar.</param>
    public virtual void AddItem(IItem item)
    {
        if (item != null && !item.IsMagical && !items.Contains(item))
        {
            items.Add(item);
        }
    }

    /// <summary>
    /// Remueve un item del personaje.
    /// </summary>
    /// <param name="item">Item a remover.</param>
    public virtual void RemoveItem(IItem item)
    {
        if (item != null)
        {
            items.Remove(item);
        }
    }

    /// <summary>
    /// Obtiene el ataque total del personaje
    /// sumando todos los items ofensivos equipados.
    /// </summary>
    /// <returns>Valor total de ataque.</returns>
    public virtual int GetAttack()
    {
        int attack = 0;

        foreach (IItem item in items)
        {
            if (item is IAttackItem attackItem)
            {
                attack += attackItem.Attack;
            }
        }

        return attack;
    }

    /// <summary>
    /// Obtiene la defensa total del personaje
    /// sumando todos los items defensivos equipados.
    /// </summary>
    /// <returns>Valor total de defensa.</returns>
    public virtual int GetDefense()
    {
        int defense = 0;

        foreach (IItem item in items)
        {
            if (item is IDefenseItem defenseItem)
            {
                defense += defenseItem.Defense;
            }
        }

        return defense;
    }

    /// <summary>
    /// Recibe un ataque de otro personaje,
    /// reduciendo la vida según el daño recibido.
    /// </summary>
    /// <param name="attacker">Personaje atacante.</param>
    public virtual void ReceiveAttack(Character attacker)
    {
        if (attacker == null)
        {
            return;
        }

        int damage = Math.Max(0, attacker.GetAttack() - GetDefense());

        Health = Math.Max(0, Health - damage);
    }

    /// <summary>
    /// Restaura la vida del personaje a su valor máximo.
    /// </summary>
    public virtual void Heal()
    {
        Health = MaxHealth;
    }

    /// <summary>
    /// Inicializa un nuevo personaje con nombre y vida máxima.
    /// </summary>
    /// <param name="name">Nombre del personaje.</param>
    /// <param name="maxHealth">Vida máxima del personaje.</param>
    protected Character(string name, int maxHealth)
    {
        Name = name;
        MaxHealth = Math.Max(1, maxHealth);
        Health = MaxHealth;
    }
}