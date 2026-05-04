using System;

namespace Library;

/// <summary>
/// Representa un mago dentro del juego.
/// Los magos utilizan un bastón y un libro de hechizos para atacar y defenderse.
/// Se aplica encapsulamiento para proteger el estado interno del personaje.
/// Cada ítem es responsable de sus propios valores, manteniendo separación de
/// responsabilidades.
/// </summary>
public class Wizard : ICharacter
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
    /// Objeto equipado por el mago (por ejemplo, un bastón).
    /// Se modela mediante la interfaz IObject para permitir flexibilidad.
    /// </summary>
    private IObject staff { get; set; }

    /// <summary>
    /// Vida actual del mago.
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    /// Vida máxima del mago.
    /// </summary>
    public int MaxHealth { get; private set; }

    /// <summary>
    /// Permite cambiar el objeto equipado del mago.
    /// </summary>
    /// <param name="newStaff">Nuevo staff a equipar.</param>
    public void SetStaff(IObject newStaff)
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
    /// Recibe un ataque de otro personaje, reduciendo la vida del mago
    /// en función del ataque del atacante y su defensa total.
    /// Se utiliza Math.Max para asegurar que:
    /// - El daño nunca sea negativo.
    /// - La vida nunca baje de 0.
    /// </summary>
    /// <param name="attacker">Personaje que realiza el ataque.</param>
    public void ReceiveAttack(ICharacter attacker)
    {
        if (attacker == null)
        {
            return;
        }

        int damage = Math.Max(0, attacker.GetAttack() - GetDefense());
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
    /// Inicializa una nueva instancia del mago con su nombre y vida máxima además de sus ítems.
    /// Se inicializan valores por defecto para evitar referencias nulas.
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