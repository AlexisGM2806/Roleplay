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
}