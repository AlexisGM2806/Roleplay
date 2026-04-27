using berserker;
using Xunit;

namespace berserker.Tests;
public class BerserkerTests
{
    [Fact]
    public void GetAttack_WithAxe_ReturnsAttackValue()
    {
        var berserker = new Berserker("Bolg");
        berserker.SetAxe(new Axe(attack: 40));

        Assert.Equal(40, berserker.GetAttack());
    }

    [Fact]
    public void GetDefense_WithArmor_ReturnsDefenseValue()
    {
        var berserker = new Berserker("Bolg");
        berserker.SetArmor(new Armor(defense: 25));

        Assert.Equal(25, berserker.GetDefense());
    }

    [Fact]
    public void Heal_AfterMassiveDamage_RestoresFullHealth()
    {
        var berserker = new Berserker("Bolg");
        berserker.ReceiveAttack(9999);
        berserker.Heal();

        Assert.Equal(150, berserker.Health);
    }
}

public class SpellTests
{
    [Fact]
    public void Equals_TwoSpellsWithSameValues_ReturnsTrue()
    {
        var a = new Spell("Fireball", 20, 5);
        var b = new Spell("Fireball", 20, 5);

        Assert.Equal(a, b);
    }

    [Fact]
    public void Equals_TwoSpellsWithDifferentValues_ReturnsFalse()
    {
        var a = new Spell("Fireball", 20, 5);
        var b = new Spell("Ice", 10, 0);

        Assert.NotEqual(a, b);
    }
}