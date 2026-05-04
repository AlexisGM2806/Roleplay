using System;

namespace Library;

/// <summary>
/// Representa un berserker dentro del juego.
/// Los berserkers utilizan un hacha para atacar y una armadura para defenderse.
/// Se aplica encapsulamiento para proteger el estado interno del personaje.
/// Cada ítem es responsable de sus propios valores, manteniendo separación de
/// responsabilidades.
/// </summary>
public class Berserker : ICharacter
{
    /// <summary>
    /// Hacha del berserker.
    /// </summary>
    private IObject axe { get; set; }

    /// <summary>
    /// Armadura del berserker.
    /// </summary>
    private IObject armor { get; set; }

    /// <summary>
    /// Nombre del berserker.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Vida actual del berserker.
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    /// Vida máxima del berserker.
    /// </summary>
    public int MaxHealth { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia del berserker con su nombre y vida máxima además de sus ítems.
    /// Se inicializan valores por defecto para evitar referencias nulas.
    /// </summary>
    /// <param name="name">Nombre del berserker.</param>
    public Berserker(string name)
    {
        Name = name;
        MaxHealth = 150;
        Health = MaxHealth;
        axe = new Axe();
        armor = new Armor();
    }

    /// <summary>
    /// Obtiene el valor total de ataque del berserker según su hacha equipada.
    /// </summary>
    /// <returns>Valor total de ataque.</returns>
    public int GetAttack()
    {
        return axe.Attack;
    }

    /// <summary>
    /// Obtiene el valor total de defensa del berserker según su armadura equipada.
    /// </summary>
    /// <returns>Valor total de defensa.</returns>
    public int GetDefense()
    {
        return armor.Defense;
    }

    /// <summary>
    /// Recibe un ataque de otro personaje, reduciendo la vida del berserker
    /// en función del ataque del atacante y su defensa total.
    /// Se utiliza Math.Max para asegurar que:
    /// - El daño nunca sea negativo.
    /// - La vida nunca baje de 0.
    /// </summary>
    /// <param name="attacker">Personaje que realiza el ataque.</param>
    public void ReceiveAttack(ICharacter attacker)
    {
        if (attacker == null) return;
        int damage = Math.Max(0, attacker.GetAttack() - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    /// <summary>
    /// Restaura la vida del berserker a su valor máximo.
    /// </summary>
    public void Heal()
    {
        Health = MaxHealth;
    }

    /// <summary>
    /// Permite cambiar el hacha del berserker por otra.
    /// </summary>
    /// <param name="newAxe">Nueva hacha a equipar.</param>
    public void SetAxe(IObject newAxe)
    {
        if (newAxe != null)
        {
            axe = newAxe;
        }
    }

    /// <summary>
    /// Permite cambiar la armadura del berserker por otra.
    /// </summary>
    /// <param name="newArmor">Nueva armadura a equipar.</param>
    public void SetArmor(IObject newArmor)
    {
        if (newArmor != null)
        {
            armor = newArmor;
        }
    }
}