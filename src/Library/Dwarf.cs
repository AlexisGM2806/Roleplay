using System;

namespace Library;

/// <summary>
/// Representa un enano dentro del juego.
/// Los enanos utilizan una espada y un escudo para atacar y defenderse.
/// Se aplica encapsulamiento para proteger el estado interno del personaje.
/// Cada ítem es responsable de sus propios valores, manteniendo separación de
/// responsabilidades.
/// </summary>
public class Dwarf : ICharacter
{
    /// <summary>
    /// Nombre del enano.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Espada del enano.
    /// </summary>
    private IObject sword { get; set; }

    /// <summary>
    /// Escudo del enano.
    /// </summary>
    private IObject shield { get; set; }

    /// <summary>
    /// Vida actual del enano.
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    /// Vida máxima del enano.
    /// </summary>
    public int MaxHealth { get; private set; }

    /// <summary>
    /// Permite cambiar la espada del enano por otra.
    /// </summary>
    /// <param name="newSword">Nueva espada a equipar.</param>
    public void SetSword(IObject newSword)
    {
        if (newSword != null)
        {
            sword = newSword;
        }
    }

    /// <summary>
    /// Permite cambiar el escudo del enano por otro.
    /// </summary>
    /// <param name="newShield">Nuevo escudo a equipar.</param>
    public void SetShield(IObject newShield)
    {
        if (newShield != null)
        {
            shield = newShield;
        }
    }

    /// <summary>
    /// Recibe un ataque proveniente de otro personaje.
    /// </summary>
    /// <param name="attacker">Personaje atacante.</param>
    public void ReceiveAttack(ICharacter attacker)
    {
        int damage = Math.Max(0, attacker.GetAttack() - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    /// <summary>
    /// Obtiene el valor total de ataque del enano.
    /// </summary>
    /// <returns>Valor total de ataque.</returns>
    public int GetAttack()
    {
        return sword.Attack;
    }

    /// <summary>
    /// Obtiene el valor total de defensa del enano.
    /// </summary>
    /// <returns>Valor total de defensa.</returns>
    public int GetDefense()
    {
        return shield.Defense;
    }

    /// <summary>
    /// Restaura la vida del enano a su valor máximo.
    /// </summary>
    public void Heal()
    {
        Health = MaxHealth;
    }

    /// <summary>
    /// Inicializa una nueva instancia del enano con su nombre y vida máxima además de sus ítems.
    /// </summary>
    /// <param name="name">Nombre del enano.</param>
    public Dwarf(string name)
    {
        MaxHealth = 100;
        Health = MaxHealth;
        Name = name;

        sword = new Sword();
        shield = new Shield();
    }
}