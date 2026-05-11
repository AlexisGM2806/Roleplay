using System;

namespace Library;


public abstract class Hero : Character
{
    public int pvTotales {get; private set;}

    public void añadirPV (Enemy enemy)
    {
        pvTotales += enemy.PVs; 
    } 

    protected Hero (string name, int maxHealth) : base (name, maxHealth)
    {
    }
    
}