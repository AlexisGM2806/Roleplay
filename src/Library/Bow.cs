using System;

namespace Library;

/// <summary>
/// Representa un arco que puede ser utilizado por un personaje.
/// Aporta valor de ataque.
/// </summary>
public class Bow
{
    /// <summary>
    /// Valor de ataque del arco.
    /// </summary>
    public int Attack { get; }

    /// <summary>
    /// Inicializa una nueva instancia de un arco con valor por defecto.
    /// </summary>
    public Bow() : this(0)
    {
    }

    /// <summary>
    /// Inicializa una nueva instancia de un arco con ataque.
    /// Se utiliza Math.Max para asegurar que el valor de ataque no sea negativo.
    /// </summary>
    /// <param name="attack">Valor de ataque del arco.</param>
    public Bow(int attack)
    {
        Attack = Math.Max(0, attack);
    }
}
