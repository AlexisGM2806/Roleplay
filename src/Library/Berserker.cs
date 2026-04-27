using System;

namespace Library;

/// <summary>
/// Representa un berserker dentro del juego.
/// Los berserkers utilizan un hacha para atacar y una armadura para defenderse.
/// </summary>
public class Berserker
{
    /// <summary>
    /// Hacha del berserker.
    /// </summary>
    private Axe axe { get; set; }

    /// <summary>
    /// Armadura del berserker.
    /// </summary>
    private Armor armor { get; set; }

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
    /// Inicializa una nueva instancia del berserker con su nombre y vida máxima.
    /// </summary>
    /// <param name="name">Nombre del berserker.</param>
    public Berserker(string name)
    {
        Name = name;
        MaxHealth = 150;
        Health = MaxHealth;
    }

    /// <summary>
    /// Obtiene el valor total de ataque del berserker según su hacha equipada.
    /// Retorna 0 si no tiene hacha equipada.
    /// </summary>
    /// <returns>Valor total de ataque.</returns>
    public int GetAttack()
    {
        return axe.Attack;
    }

    /// <summary>
    /// Obtiene el valor total de defensa del berserker según su armadura equipada.
    /// Retorna 0 si no tiene armadura equipada.
    /// </summary>
    /// <returns>Valor total de defensa.</returns>
    public int GetDefense()
    {
        return armor.Defense;
    }

    /// <summary>
    /// Recibe un ataque, reduciendo la vida del berserker en función del ataque recibido
    /// y su defensa total.
    /// </summary>
    /// <param name="attack_power">Valor de ataque recibido.</param>
    public void ReceiveAttack(int attack_power)
    {
        int damage = Math.Max(0, attack_power - GetDefense());
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
    /// <param name="newAxe">Nueva hacha a equipar. Puede ser null para desequipar.</param>
    public void SetAxe(Axe newAxe)
    {
        if (newAxe != null)
        {
            Axe = newAxe;
        }
    }

    /// <summary>
    /// Permite cambiar la armadura del berserker por otra.
    /// </summary>
    /// <param name="newArmor">Nueva armadura a equipar. Puede ser null para desequipar.</param>
    public void SetArmor(Armor newArmor)
    {
        if (newArmor != null)
        {
            Armor = newArmor;
        }
    }
}