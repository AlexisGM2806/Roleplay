using System;

namespace Library;

/// <summary>
/// Representa un bastardo dentro del juego.
/// Los bastardos utilizan un machete para atacar
/// y una armadura para defenderse.
/// </summary>
public class Bastard : Enemy
{
    /// <summary>
    /// Machete equipado por el bastardo.
    /// </summary>
    private Machete machete;

    /// <summary>
    /// Armadura equipada por el bastardo.
    /// </summary>
    private Layer layer;

    /// <summary>
    /// Inicializa una nueva instancia del bastardo
    /// con valores por defecto.
    /// </summary>
    /// <param name="name">Nombre del bastardo.</param>
    public Bastard(string name)
        : base(name, 150, 3)
    {
        machete = new Machete();
        layer = new Layer();

        AddItem(machete);
        AddItem(layer);
    }

    /// <summary>
    /// Permite cambiar el machete del bastardo.
    /// </summary>
    /// <param name="newMachete">Nuevo machete a equipar.</param>
    public void SetMachete(Machete newMachete)
    {
        if (newMachete == null)
        {
            return;
        }

        RemoveItem(machete);

        machete = newMachete;

        AddItem(machete);
    }

    /// <summary>
    /// Permite cambiar la armadura del bastardo.
    /// </summary>
    /// <param name="newLayer">Nueva armadura a equipar.</param>
    public void SetLayer(Layer newLayer)
    {
        if (newLayer == null)
        {
            return;
        }

        RemoveItem(layer);

        layer = newLayer;

        AddItem(layer);
    }
}