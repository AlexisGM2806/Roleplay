using System;

namespace Library;

/// <summary>
/// Representa un mago dentro del juego.
/// Los magos son héroes capaces de utilizar
/// items mágicos y libros de hechizos.
/// </summary>
public class Wizard : Hero
{
    /// <summary>
    /// Libro de hechizos equipado por el mago.
    /// </summary>
    private Spellbook spellbook;

    /// <summary>
    /// Bastón equipado por el mago.
    /// </summary>
    private IItem staff;

    /// <summary>
    /// Inicializa una nueva instancia del mago
    /// con valores por defecto.
    /// </summary>
    /// <param name="name">Nombre del mago.</param>
    public Wizard(string name)
        : base(name, 100)
    {
        spellbook = new Spellbook();

        staff = new Staff();

        AddItem(staff);
    }

    /// <summary>
    /// Los magos pueden equipar cualquier item,
    /// incluyendo items mágicos.
    /// </summary>
    /// <param name="item">Item a equipar.</param>
    public override void AddItem(IItem item)
    {
        if (item != null && !items.Contains(item))
        {
            items.Add(item);
        }
    }

    /// <summary>
    /// Equipa un nuevo bastón al mago.
    /// </summary>
    /// <param name="newStaff">Nuevo bastón.</param>
    public void SetStaff(IItem newStaff)
    {
        if (newStaff == null)
        {
            return;
        }

        RemoveItem(staff);

        staff = newStaff;

        AddItem(staff);
    }

    /// <summary>
    /// Equipa un nuevo libro de hechizos.
    /// </summary>
    /// <param name="newSpellbook">Nuevo libro de hechizos.</param>
    public void SetSpellbook(Spellbook newSpellbook)
    {
        if (newSpellbook != null)
        {
            spellbook = newSpellbook;
        }
    }

    /// <summary>
    /// Obtiene el ataque total del mago,
    /// incluyendo hechizos y items ofensivos.
    /// </summary>
    /// <returns>Valor total de ataque.</returns>
    public override int GetAttack()
    {
        return base.GetAttack() + spellbook.Attack;
    }

    /// <summary>
    /// Obtiene la defensa total del mago,
    /// incluyendo hechizos y items defensivos.
    /// </summary>
    /// <returns>Valor total de defensa.</returns>
    public override int GetDefense()
    {
        return base.GetDefense() + spellbook.Defense;
    }
}