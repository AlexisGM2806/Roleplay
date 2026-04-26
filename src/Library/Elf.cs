using System;

namespace Library;

/// <summary>
/// Representa un elfo dentro del juego.
/// Los elfos utilizan un arco para atacar y un casco para defenderse.
/// </summary>
public class Elf
{
    /// <summary>
    /// Nombre del elfo.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Arco del elfo.
    /// </summary>
    private Bow bow { get; set; }

    /// <summary>
    /// Casco del elfo.
    /// </summary>
    private Helmet helmet { get; set; }

    /// <summary>
    /// Vida actual del elfo.
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    /// Vida máxima del elfo.
    /// </summary>
    public int MaxHealth { get; private set; }

    /// <summary>
    /// Permite cambiar el arco del elfo por otro.
    /// </summary>
    /// <param name="newBow">Nuevo arco a equipar.</param>
    public void SetBow(Bow newBow)
    {
        if (newBow != null)
        {
            bow = newBow;
        }
    }

    /// <summary>
    /// Permite cambiar el casco del elfo por otro.
    /// </summary>
    /// <param name="newHelmet">Nuevo casco a equipar.</param>
    public void SetHelmet(Helmet newHelmet)
    {
        if (newHelmet != null)
        {
            helmet = newHelmet;
        }
    }

    /// <summary>
    /// Recibe un ataque, reduciendo la vida del elfo en función del ataque recibido
    /// y su defensa total.
    /// </summary>
    /// <param name="attack_power">Valor de ataque recibido.</param>
    public void ReceiveAttack(int attack_power)
    {
        int damage = Math.Max(0, attack_power - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    /// <summary>
    /// Obtiene el valor total de ataque del elfo, sumando los valores de sus ítems.
    /// </summary>
    /// <returns>Valor total de ataque.</returns>
    public int GetAttack()
    {
        return bow.Attack;
    }

    /// <summary>
    /// Obtiene el valor total de defensa del elfo, sumando los valores de sus ítems.
    /// </summary>
    /// <returns>Valor total de defensa.</returns>
    public int GetDefense()
    {
        return helmet.Defense;
    }

    /// <summary>
    /// Restaura la vida del elfo a su valor máximo.
    /// </summary>
    public void Heal()
    {
        Health = MaxHealth;
    }

    /// <summary>
    /// Inicializa una nueva instancia del elfo con su nombre y vida máxima.
    /// </summary>
    /// <param name="name">Nombre del elfo.</param>
    public Elf(string name)
    {
        MaxHealth = 100;
        Health = MaxHealth;
        Name = name;

        bow = new Bow();
        helmet = new Helmet();
    }
}
