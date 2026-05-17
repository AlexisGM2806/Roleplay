using System;
using System.Collections.Generic;

namespace Library;

public class Encounter
{
    public List<Hero> heroes = new List<Hero>();
    public List<Enemy> enemies = new List<Enemy>();

    /// <summary>
    /// Agrega un héroe al encuentro.
    /// </summary>
    /// <param name="hero">Héroe a agregar.</param>
    public void AddHero(Hero hero)
    {
        if (hero != null)
        {
            heroes.Add(hero);
        }
    }

    /// <summary>
    /// Agrega un enemigo al encuentro.
    /// </summary>
    /// <param name="enemy">Enemigo a agregar.</param>
    public void AddEnemy(Enemy enemy)
    {
        if (enemy != null)
        {
            enemies.Add(enemy);
        }
    }

    /// <summary>
    /// Ejecuta el encuentro hasta que todos los héroes
    /// o todos los enemigos hayan sido derrotados.
    /// </summary>
    public void DoEncounter()
    {
        while (heroes.Count > 0 && enemies.Count > 0)
        {
            EnemiesAttack();

            heroes.RemoveAll(hero => hero.IsDead);

            if (heroes.Count == 0)
            {
                break;
            }

            HeroesAttack();

            heroes.RemoveAll(hero => hero.IsDead);
        }
    }

    /// <summary>
    /// Los enemigos atacan a los héroes siguiendo
    /// el orden definido por la consigna.
    /// </summary>
    private void EnemiesAttack()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Hero target = heroes[i % heroes.Count];

            target.ReceiveAttack(enemies[i]);
        }
    }

    /// <summary>
    /// Todos los héroes vivos atacan a todos los enemigos vivos.
    /// Si un enemigo muere, el héroe gana sus VP.
    /// </summary>
    private void HeroesAttack()
    {
        List<Enemy> defeatedEnemies = new List<Enemy>();

        foreach (Hero hero in heroes)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsDead)
                {
                    continue;
                }

                enemy.ReceiveAttack(hero);

                if (enemy.IsDead)
                {
                    hero.AddVP(enemy.VP);
                    defeatedEnemies.Add(enemy);
                }
            }
        }

        foreach (Enemy enemy in defeatedEnemies)
        {
            enemies.Remove(enemy);
        }
    }
}