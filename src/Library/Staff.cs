using System;

namespace Library;

/// <summary>
/// Representa un bastón que puede ser utilizado por un personaje.
/// Aporta valores de ataque y defensa.
/// </summary>
public class Staff
{
    /// <summary>
    /// Valor de ataque del bastón.
    /// </summary>
    public int Attack { get; }

    /// <summary>
    /// Valor de defensa del bastón.
    /// </summary>
    public int Defense { get; }

    /// <summary>
    /// Inicializa una nueva instancia de un bastón con valores por defecto.
    /// </summary>
    public Staff() : this(0, 0)
    {
    }
    
    /// <summary>
    /// Inicializa una nueva instancia de un bastón con ataque y defensa.
    /// Se utiliza Math.Max para asegurar que los valores de ataque
    /// y defensa no sean negativos.
    /// </summary>
    /// <param name="attack">Valor de ataque del bastón.</param>
    /// <param name="defense">Valor de defensa del bastón.</param>
    public Staff(int attack, int defense)
    {
        Attack = Math.Max(0, attack);
        Defense = Math.Max(0, defense);
    }
}