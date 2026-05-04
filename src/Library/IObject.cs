using System;

namespace Library;

/// <summary>
/// Representa un objeto que puede ser utilizado por un personaje.
/// Puede aportar valores de ataque y/o defensa, y puede ser mágico o no.
/// </summary>
public interface IObject
{
    /// <summary>
    /// Valor de ataque que aporta el objeto.
    /// </summary>
    int Attack { get; }

    /// <summary>
    /// Valor de defensa que aporta el objeto.
    /// </summary>
    int Defense { get; }

    /// <summary>
    /// Indica si el objeto es mágico.
    /// Solo los magos pueden utilizar objetos mágicos.
    /// </summary>
    bool IsMagical { get; }
}