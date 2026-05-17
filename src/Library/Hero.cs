using System;

namespace Library;

public abstract class Hero : Character
{
    /// <summary>
    /// Cantidad total de puntos de victoria acumulados.
    /// </summary>
    public int TotalVP { get; private set; }

    /// <summary>
    /// Agrega puntos de victoria al héroe.
    /// Cada vez que el héroe supera un nuevo bloque
    /// de 5 VP acumulados, recupera toda su vida.
    /// </summary>
    /// <param name="vp">Cantidad de VP a agregar.</param>
    public void AddVP(int vp)
    {
        if (vp <= 0)
        {
            return;
        }

        int previousLevel = TotalVP / 5;

        TotalVP += vp;

        int currentLevel = TotalVP / 5;

        if (currentLevel > previousLevel)
        {
            Heal();
        }
    }

    /// <summary>
    /// Inicializa un nuevo héroe con nombre y vida máxima.
    /// </summary>
    /// <param name="name">Nombre del héroe.</param>
    /// <param name="maxHealth">Vida máxima del héroe.</param>
    protected Hero(string name, int maxHealth)
        : base(name, maxHealth)
    {
    }
}