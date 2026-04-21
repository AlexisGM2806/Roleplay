using System;

namespace Library;

/// <summary>
/// Representa un mago dentro del juego.
/// Los magos utilizan un bastón y un libro de hechizos para atacar y defenderse.
/// </summary>
public class Wizard
{
    /// <summary>
    /// Nombre del mago.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Libro de hechizos del mago.
    /// </summary>
    private Spellbook spellbook { get; set; }

    /// <summary>
    /// Bastón del mago.
    /// </summary>
    private Staff staff { get;set; }

    /// <summary>
    /// Vida actual del mago.
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    /// Vida máxima del mago.
    /// </summary>
    public int MaxHealth { get; private set; }

    /// <summary>
    /// Permite cambiar el bastón del mago por otro.
    /// </summary>
    /// <param name="newStaff">Nuevo bastón a equipar.</param>
    public void SetStaff(Staff newStaff)
    {
        if (newStaff != null)
        {
            staff = newStaff;
        }
    }

    /// <summary>
    /// Permite cambiar el libro de hechizos del mago por otro.
    /// </summary>
    /// <param name="newSpellbook">Nuevo libro de hechizos a equipar.</param>
    public void SetSpellbook(Spellbook newSpellbook)
    {
        if (newSpellbook != null)
        {
            spellbook = newSpellbook;
        }
    }

    /// <summary>
    /// Recibe un ataque, reduciendo la vida del mago en función del ataque recibido
    /// y su defensa total.
    /// Se utiliza Math.Max para asegurar que:
    /// - El daño nunca sea negativo (si la defensa es mayor al ataque).
    /// - La vida nunca baje de 0.
    /// </summary>
    /// <param name="attack_power">Valor de ataque recibido.</param>
    public void ReceiveAttack(int attack_power)
    {
        int damage = Math.Max(0, attack_power - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    /// <summary>
    /// Obtiene el valor total de ataque del mago, sumando los valores de sus ítems.
    /// </summary>
    /// <returns>Valor total de ataque.</returns>
    public int GetAttack()
    {
        return staff.Attack + spellbook.Attack;
    }

    /// <summary>
    /// Obtiene el valor total de defensa del mago, sumando los valores de sus ítems.
    /// </summary>
    /// <returns>Valor total de defensa.</returns>
    public int GetDefense()
    {
        return staff.Defense + spellbook.Defense;
    }

    /// <summary>
    /// Restaura la vida del mago a su valor máximo.
    /// </summary>
    public void Heal()
    {
        Health = MaxHealth;
    }

    /// <summary>
    /// Inicializa una nueva instancia del mago con su nombre y vida máxima.
    /// </summary>
    /// <param name="name">Nombre del mago.</param>
    public Wizard(string name)
    {
        MaxHealth = 100;
        Health = MaxHealth;
        Name = name;
        
        spellbook = new Spellbook();
        staff = new Staff();
    }
}