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