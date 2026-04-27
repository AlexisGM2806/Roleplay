namespace MiddleEarth;

public class Spellbook
{
    private List<Spell> spells = new();
    public int Attack => spells.Sum(s => s.Attack);
    
    public int Defense => spells.Sum(s => s.Defense);

    public void AddSpell(Spell spell) => spells.Add(spell);

    public void RemoveSpell(Spell spell) => spells.Remove(spell);

    public IReadOnlyList<Spell> GetSpells() => spells.AsReadOnly();
}