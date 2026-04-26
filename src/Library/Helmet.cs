using System;

namespace Library;

/// <summary>
/// Representa un casco que puede ser utilizado por un personaje.
/// Aporta valor de defensa.
/// </summary>
public class Helmet
{
    /// <summary>
    /// Valor de defensa del casco.
    /// </summary>
    public int Defense { get; }

    /// <summary>
    /// Inicializa una nueva instancia de un casco con valor por defecto.
    /// </summary>
    public Helmet() : this(0)
    {
    }

    /// <summary>
    /// Inicializa una nueva instancia de un casco con defensa.
    /// Se utiliza Math.Max para asegurar que el valor de defensa no sea negativo.
    /// </summary>
    /// <param name="defense">Valor de defensa del casco.</param>
    public Helmet(int defense)
    {
        Defense = Math.Max(0, defense);
    }
}
