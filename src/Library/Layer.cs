using System;

namespace Library;

/// <summary>
/// Representa una armadura utilizada para defender.
/// Es un item defensivo no mágico.
/// </summary>
public class Layer : IDefenseItem
{
    /// <summary>
    /// Valor de defensa de la armadura.
    /// </summary>
    public int Defense { get; }

    /// <summary>
    /// Indica si el item es mágico.
    /// </summary>
    public bool IsMagical { get; } = false;

    /// <summary>
    /// Inicializa una armadura con defensa por defecto.
    /// </summary>
    public Layer() : this(0)
    {
    }

    /// <summary>
    /// Inicializa una armadura con un valor de defensa específico.
    /// </summary>
    /// <param name="defense">Valor de defensa.</param>
    public Layer(int defense)
    {
        Defense = Math.Max(0, defense);
    }
}