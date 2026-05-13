using System;

namespace Library;

/// <summary>
/// Representa un bastardo dentro del juego.
/// Los bastardos utilizan un machete para atacar y una armadura para defenderse.
/// </summary>
public class Bastardo : Enemy
{
    /// <summary>
    /// Hacha del bastardo.
    /// </summary>
    private IObject machete { get; set; }
   
    /// <summary>
    /// Armadura del bastardo.
    /// </summary>
    private IObject layer { get; set; }

    /// <summary>
    /// Nombre del bastardo.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Vida actual del bastardo.
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    /// Vida máxima del bastardo.
    /// </summary>
    public int MaxHealth { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia del berserker con su nombre y vida máxima además de sus ítems.
    /// Se inicializan valores por defecto para evitar referencias nulas.
    /// </summary>
    /// <param name="name">Nombre del bastardo.</param>
    public Bastardo(string name)
    {
        Name = name;
        MaxHealth = 150;
        Health = MaxHealth;
        machete = new Machete();
        layer = new Layer();
    }

    /// <summary>
    /// Obtiene el valor total de ataque del bastardo según su machete equipado.
    /// </summary>
    /// <returns>Valor total de ataque.</returns>
    public int GetAttack()
    {
        return machete.Attack;
    }

    /// <summary>
    /// Obtiene el valor total de defensa del bastardo según su armadura equipada.
    /// </summary>
    /// <returns>Valor total de defensa.</returns>
    public int GetDefense()
    {
        return layer.Defense;
    }

    /// <summary>
    /// Recibe un ataque de otro personaje, reduciendo la vida del bastardo
    /// en función del ataque del atacante y su defensa total.
    /// Se utiliza Math.Max para asegurar que:
    /// - El daño nunca sea negativo.
    /// - La vida nunca baje de 0.
    /// </summary>
    /// <param name="attacker">Personaje que realiza el ataque.</param>
    public void ReceiveAttack(ICharacter attacker)
    {
        if (attacker == null) return;
        int damage = Math.Max(0, attacker.GetAttack() - GetDefense());
        Health = Math.Max(0, Health - damage);
    }

    /// <summary>
    /// Restaura la vida del bastardo a su valor máximo.
    /// </summary>
    public void Heal()
    {
        Health = MaxHealth;
    }

    /// <summary>
    /// Permite cambiar el machete del bastardo por otro.
    /// </summary>
    /// <param name="newMachete">Nuevo machete a equipar.</param>
    public void SetMachete(IObject newMachete)
    {
        if (newMachete != null)
        {
            machete = newMachete;
        }
    }

    /// <summary>
    /// Permite cambiar la armadura del bastardo por otra.
    /// </summary>
    /// <param name="newLayer">Nueva armadura a equipar.</param>
    public void SetLayer(IObject newLayer)
    {
        if (newLayer != null)
        {
            layer = newLayer;
        }
    }
}