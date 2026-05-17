using System;

namespace Library;

/// <summary>
/// Representa un enano dentro del juego.
/// Los enanos utilizan espadas y escudos
/// para combatir.
/// </summary>
public class Dwarf : Hero
{
    /// <summary>
    /// Espada equipada por el enano.
    /// </summary>
    private Sword sword;

    /// <summary>
    /// Escudo equipado por el enano.
    /// </summary>
    private Shield shield;

    /// <summary>
    /// Inicializa una nueva instancia del enano
    /// con valores por defecto.
    /// </summary>
    /// <param name="name">Nombre del enano.</param>
    public Dwarf(string name)
        : base(name, 100)
    {
        sword = new Sword(15);
        shield = new Shield(10);

        AddItem(sword);
        AddItem(shield);
    }

    /// <summary>
    /// Permite cambiar la espada del enano.
    /// </summary>
    /// <param name="newSword">Nueva espada a equipar.</param>
    public void SetSword(Sword newSword)
    {
        if (newSword == null)
        {
            return;
        }

        RemoveItem(sword);

        sword = newSword;

        AddItem(sword);
    }

    /// <summary>
    /// Permite cambiar el escudo del enano.
    /// </summary>
    /// <param name="newShield">Nuevo escudo a equipar.</param>
    public void SetShield(Shield newShield)
    {
        if (newShield == null)
        {
            return;
        }

        RemoveItem(shield);

        shield = newShield;

        AddItem(shield);
    }
}