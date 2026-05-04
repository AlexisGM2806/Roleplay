using System;

namespace Library;

/// <summary>
/// Representa una espada usada por el enano para atacar.
/// </summary>
public class Sword : IObject
{
    /// <summary>
    /// Valor de ataque de la espada.
    /// </summary>
    public int Attack { get; }

    /// <summary>
    /// Valor de defensa de la espada (no defiende).
    /// </summary>
    public int Defense { get; } = 0;

    /// <summary>
    /// La espada no es mágica.
    /// </summary>
    public bool IsMagical { get; } = false;

    /// <summary>
    /// Inicializa una nueva instancia de una espada con valores por defecto.
    /// </summary>
    public Sword() : this(0)
    {
    }

    /// <summary>
    /// Inicializa una nueva instancia de una espada con ataque definido.
    /// </summary>
    /// <param name="attack">Valor de ataque de la espada.</param>
    public Sword(int attack)
    {
        Attack = Math.Max(0, attack);
    }
}