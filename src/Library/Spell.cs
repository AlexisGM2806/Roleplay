using System;

namespace Library;

/// <summary>
/// Representa un hechizo que puede formar parte de un libro de hechizos.
/// Cada hechizo aporta valores de ataque y defensa.
/// </summary>
public class Spell
{
    /// <summary>
    /// Valor de ataque del hechizo.
    /// </summary>
    public int Attack { get; }

    /// <summary>
    /// Valor de defensa del hechizo.
    /// </summary>
    public int Defense { get; }

    /// <summary>
    /// Nombre del hechizo.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Inicializa una nueva instancia de un hechizo con nombre,ataque y defensa.
    /// Se utiliza Math.Max para asegurar que los valores de ataque y defensa no sean negativos.
    /// </summary>
    /// <param name="name">Nombre del hechizo.</param>
    /// <param name="attack">Valor de ataque del hechizo.</param>
    /// <param name="defense">Valor de defensa del hechizo.</param>
    public Spell(string name, int attack, int defense)
    {
        Name = name;
        Attack = Math.Max(0, attack);
        Defense = Math.Max(0, defense);
    }
    
    /// <summary>
    /// Se utiliza override de Equals porque la comparación por defecto de objetos en C#
    /// se basa en la referencia (memoria) y no en el contenido. 
    /// En este caso se redefine para que dos hechizos se consideren iguales si
    /// tienen el mismo nombre, ataque y defensa, lo cual permite evitar duplicados
    /// lógicos en el Spellbook al usar Contains o Remove.
    /// </summary>
    public override bool Equals(object obj)
    {
        return this.Name.Equals(((Spell)obj).Name) && this.Attack==((Spell)obj).Attack && this.Defense==((Spell)obj).Defense;
    }
    /// <summary>
    /// Complemento obligatorio de Equals. 
    /// Se redefine para mantener consistencia con la comparación por contenido.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Attack, Defense);
    }
}