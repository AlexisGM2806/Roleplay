using System;

namespace Library;

/// <summary>
/// Representa un machete utilizado para atacar.
/// Es un item ofensivo no mágico.
/// </summary>
public class Machete : IAttackItem
{
    /// <summary>
    /// Valor de ataque del machete.
    /// </summary>
    public int Attack { get; }

    /// <summary>
    /// Indica si el item es mágico.
    /// </summary>
    public bool IsMagical { get; } = false;

    /// <summary>
    /// Inicializa un machete con ataque por defecto.
    /// </summary>
    public Machete() : this(0)
    {
    }

    /// <summary>
    /// Inicializa un machete con un valor de ataque específico.
    /// </summary>
    /// <param name="attack">Valor de ataque.</param>
    public Machete(int attack)
    {
        Attack = Math.Max(0, attack);
    }
}