using System;
using System.Collections.Generic;

namespace Library;

/// <summary>
/// Representa un libro de hechizos que contiene múltiples hechizos.
/// Su poder depende de la suma de los valores de los hechizos que contiene.
/// </summary>
public class Spellbook
{
    /// <summary>
    /// Lista de hechizos contenidos en el libro.
    /// </summary>
    private List<Spell> spells = new List<Spell>();

    /// <summary>
    /// Obtiene el valor total de ataque del libro de hechizos.
    /// 
    /// Este valor se calcula dinámicamente sumando el ataque
    /// de todos los hechizos contenidos.
    /// </summary>
    public int Attack
    {
        get
        {
            int total = 0;
            foreach (Spell spell in spells)
            {
                total += spell.Attack;
            }
            return total;
        }
    }

    /// <summary>
    /// Obtiene el valor total de defensa del libro de hechizos.
    /// 
    /// Este valor se calcula dinámicamente sumando la defensa
    /// de todos los hechizos contenidos.
    /// </summary>
    public int Defense
    {
        get
        {
            int total = 0;
            foreach (Spell spell in spells)
            {
                total += spell.Defense;
            }
            return total;
        }
    }

    /// <summary>
    /// Agrega un hechizo al libro de hechizos.
    /// Solo se agrega si:
    /// - El hechizo no es nulo.
    /// - No existe ya en la lista.
    /// Se utiliza Contains para evitar duplicados. Esta verificación compara referencias, por lo que impide agregar el mismo objeto
    /// más de una vez.
    /// </summary>
    /// <param name="spell">Hechizo a agregar.</param>
    public void AddSpell(Spell spell)
    {
        if (spell != null && !spells.Contains(spell))
        {
            spells.Add(spell);
        }
    }

    /// <summary>
    /// Elimina un hechizo del libro de hechizos.
    /// No realiza ninguna acción si el hechizo es nulo.
    /// </summary>
    /// <param name="spell">Hechizo a eliminar.</param>
    public void RemoveSpell(Spell spell)
    {
        if (spell != null)
        {
            spells.Remove(spell);
        }
    }
}