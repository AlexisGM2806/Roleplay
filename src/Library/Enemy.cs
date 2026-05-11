using System;

namespace Library;

public abstract class Enemy : Character
{
    public int PVs {get; private set;}

    protected Enemy (string name, int maxHealth) : base (name, maxHealth)
    {
    }
}
