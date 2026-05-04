using System;

namespace Library;

/// <summary>
/// Representa un personaje del juego.
/// Maneja vida, puede atacar, defenderse, curarse y equipar objetos.
/// </summary>
public interface ICharacter
{
    /// <summary>
    /// Vida actual del personaje.
    /// </summary>
    int Health { get; }

    /// <summary>
    /// Vida máxima del personaje.
    /// </summary>
    int MaxHealth { get; }

    /// <summary>
    /// Obtiene el valor total de ataque del personaje.
    /// </summary>
    int GetAttack();

    /// <summary>
    /// Obtiene el valor total de defensa del personaje.
    /// </summary>
    int GetDefense();

    /// <summary>
    /// Recibe un ataque proveniente de otro personaje.
    /// </summary>
    /// <param name="attacker">Personaje atacante.</param>
    void ReceiveAttack(ICharacter attacker);

    /// <summary>
    /// Restaura la vida del personaje a su valor máximo.
    /// </summary>
    void Heal();
}