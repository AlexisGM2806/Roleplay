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
    /// Cada vez que alcanza un múltiplo de 5 VP,
    /// el héroe recupera toda su vida.
    /// </summary>
    /// <param name="vp">Cantidad de VP a agregar.</param>
    public void AddVP(int vp)
    {
        if (vp <= 0)
        {
            return;
        }

        TotalVP += vp;

        if (TotalVP % 5 == 0)
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