using System;

namespace Library;

public abstract class Enemy : Character
{
    /// <summary>
    /// Cantidad de puntos de victoria que otorga este enemigo al ser derrotado.
    /// </summary>
    public int VP { get; private set; }

    /// <summary>
    /// Inicializa un nuevo enemigo con nombre, vida máxima y puntos de victoria.
    /// </summary>
    /// <param name="name">Nombre del enemigo.</param>
    /// <param name="maxHealth">Vida máxima del enemigo.</param>
    /// <param name="vp">Puntos de victoria otorgados al derrotarlo.</param>
    protected Enemy(string name, int maxHealth, int vp)
        : base(name, maxHealth)
    {
        VP = Math.Max(0, vp);
    }
}