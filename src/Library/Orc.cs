using System;

namespace Library;

/// <summary>
/// Representa un orco enemigo dentro del juego.
/// Los orcos utilizan armas físicas y armaduras,
/// pero no pueden utilizar items mágicos.
/// </summary>
public class Orc : Enemy
{
    /// <summary>
    /// Hacha equipada por el orco.
    /// </summary>
    private Axe axe;

    /// <summary>
    /// Armadura equipada por el orco.
    /// </summary>
    private Armor armor;

    /// <summary>
    /// Inicializa un nuevo orco con valores por defecto.
    /// </summary>
    /// <param name="name">Nombre del orco.</param>
    public Orc(string name)
        : base(name, 130, 2)
    {
        axe = new Axe(15);
        armor = new Armor(10);

        AddItem(axe);
        AddItem(armor);
    }

    /// <summary>
    /// Equipa una nueva hacha al orco.
    /// </summary>
    /// <param name="newAxe">Nueva hacha.</param>
    public void SetAxe(Axe newAxe)
    {
        if (newAxe == null)
        {
            return;
        }

        RemoveItem(axe);

        axe = newAxe;

        AddItem(axe);
    }

    /// <summary>
    /// Equipa una nueva armadura al orco.
    /// </summary>
    /// <param name="newArmor">Nueva armadura.</param>
    public void SetArmor(Armor newArmor)
    {
        if (newArmor == null)
        {
            return;
        }

        RemoveItem(armor);

        armor = newArmor;

        AddItem(armor);
    }
}