using System;

namespace Library;

/// <summary>
/// Representa un escudo usado por el enano para defenderse.
/// </summary>
public class Shield : IObject
{
    /// <summary>
    /// Valor de ataque del escudo (no ataca).
    /// </summary>
    public int Attack { get; } = 0;

    /// <summary>
    /// Valor de defensa del escudo.
    /// </summary>
    public int Defense { get; }

    /// <summary>
    /// El escudo no es mágico.
    /// </summary>
    public bool IsMagical { get; } = false;

    /// <summary>
    /// Inicializa una nueva instancia de un escudo con valores por defecto.
    /// </summary>
    public Shield() : this(0)
    {
    }

    /// <summary>
    /// Inicializa una nueva instancia de un escudo con defensa definida.
    /// </summary>
    /// <param name="defense">Valor de defensa del escudo.</param>
    public Shield(int defense)
    {
        Defense = Math.Max(0, defense);
    }
}