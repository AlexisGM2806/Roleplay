using MiddleEarth;
using Xunit;

namespace MiddleEarth.Tests;

public class WizardTests
{

    [Fact]
    public void GetAttack_WithNoItems_ReturnsZero()
    {
        var wizard = new Wizard("Gandalf");
        Assert.Equal(0, wizard.GetAttack());
    }


    [Fact]
    public void GetAttack_WithStaffAndSpells_ReturnsCombinedAttack()
    {
        var wizard = new Wizard("Gandalf");
        wizard.SetStaff(new Staff(attack: 10, defense: 5));
        wizard.GetSpellbook().AddSpell(new Spell("Fireball", attack: 20, defense: 0));
        wizard.GetSpellbook().AddSpell(new Spell("Lightning", attack: 15, defense: 0));

        Assert.Equal(45, wizard.GetAttack()); // 10 + 20 + 15
    }

    [Fact]
    public void GetDefense_WithStaffAndSpells_ReturnsCombinedDefense()
    {
        var wizard = new Wizard("Gandalf");
        wizard.SetStaff(new Staff(attack: 10, defense: 5));
        wizard.GetSpellbook().AddSpell(new Spell("Shield", attack: 0, defense: 10));

        Assert.Equal(15, wizard.GetDefense()); // 5 + 10
    }

    [Fact]
    public void ReceiveAttack_WithSufficientDefense_TakesNoDamage()
    {
        var wizard = new Wizard("Gandalf");
        wizard.SetStaff(new Staff(attack: 0, defense: 50));

        wizard.ReceiveAttack(30);

        Assert.Equal(100, wizard.Health);
    }

    [Fact]
    public void ReceiveAttack_WithInsufficientDefense_ReducesHealth()
    {
        var wizard = new Wizard("Gandalf");
        wizard.SetStaff(new Staff(attack: 0, defense: 10));

        wizard.ReceiveAttack(40); // daño neto = 30

        Assert.Equal(70, wizard.Health);
    }

    [Fact]
    public void ReceiveAttack_HealthNeverGoesBelowZero()
    {
        var wizard = new Wizard("Saruman");
        wizard.ReceiveAttack(9999);

        Assert.Equal(0, wizard.Health);
    }

    [Fact]
    public void Heal_AfterTakingDamage_RestoresFullHealth()
    {
        var wizard = new Wizard("Gandalf");
        wizard.ReceiveAttack(50);
        wizard.Heal();

        Assert.Equal(wizard.MaxHealth, wizard.Health);
    }

    [Fact]
    public void SetStaff_WithNewStaff_UpdatesAttackValue()
    {
        var wizard = new Wizard("Gandalf");
        wizard.SetStaff(new Staff(attack: 10, defense: 5));
        wizard.SetStaff(new Staff(attack: 30, defense: 10));

        Assert.Equal(30, wizard.GetAttack());
    }

    [Fact]
    public void SetStaff_WithNull_RemovesStaffContribution()
    {
        var wizard = new Wizard("Gandalf");
        wizard.SetStaff(new Staff(attack: 10, defense: 5));
        wizard.SetStaff(null);

        Assert.Equal(0, wizard.GetAttack());
    }
}

public class SpellbookTests
{
    [Fact]
    public void AddSpell_SingleSpell_IncreasesAttackAndDefense()
    {
        var book = new Spellbook();
        book.AddSpell(new Spell("Fireball", attack: 20, defense: 5));

        Assert.Equal(20, book.Attack);
        Assert.Equal(5, book.Defense);
    }

    [Fact]
    public void RemoveSpell_ExistingSpell_DecreasesValues()
    {
        var book = new Spellbook();
        var spell = new Spell("Fireball", attack: 20, defense: 5);
        book.AddSpell(spell);
        book.RemoveSpell(spell);

        Assert.Equal(0, book.Attack);
        Assert.Equal(0, book.Defense);
    }

    [Fact]
    public void AddSpell_MultipleSpells_SumsAllValues()
    {
        var book = new Spellbook();
        book.AddSpell(new Spell("Fire", attack: 10, defense: 0));
        book.AddSpell(new Spell("Ice", attack: 5, defense: 8));
        book.AddSpell(new Spell("Shield", attack: 0, defense: 12));

        Assert.Equal(15, book.Attack);
        Assert.Equal(20, book.Defense);
    }
}

public class ElfTests
{
    [Fact]
    public void GetAttack_WithBow_ReturnsAttackValue()
    {
        var elf = new Elf("Legolas");
        elf.SetBow(new Bow(attack: 25));

        Assert.Equal(25, elf.GetAttack());
    }

    [Fact]
    public void GetDefense_WithHelmet_ReturnsDefenseValue()
    {
        var elf = new Elf("Legolas");
        elf.SetHelmet(new Helmet(defense: 15));

        Assert.Equal(15, elf.GetDefense());
    }

    [Fact]
    public void ReceiveAttack_ReducesHealthByNetDamage()
    {
        var elf = new Elf("Legolas");
        elf.SetHelmet(new Helmet(defense: 10));
        elf.ReceiveAttack(30); // daño neto = 20

        Assert.Equal(80, elf.Health);
    }

    [Fact]
    public void Heal_RestoresHealthToMax()
    {
        var elf = new Elf("Legolas");
        elf.ReceiveAttack(40);
        elf.Heal();

        Assert.Equal(elf.MaxHealth, elf.Health);
    }
}

public class DwarfTests
{
    [Fact]
    public void GetAttack_WithSword_ReturnsAttackValue()
    {
        var dwarf = new Dwarf("Gimli");
        dwarf.SetSword(new Sword(attack: 30));

        Assert.Equal(30, dwarf.GetAttack());
    }

    [Fact]
    public void GetDefense_WithShield_ReturnsDefenseValue()
    {
        var dwarf = new Dwarf("Gimli");
        dwarf.SetShield(new Shield(defense: 20));

        Assert.Equal(20, dwarf.GetDefense());
    }

    [Fact]
    public void ReceiveAttack_WithNoShield_TakesFullDamage()
    {
        var dwarf = new Dwarf("Gimli");
        dwarf.ReceiveAttack(30);

        Assert.Equal(90, dwarf.Health); // MaxHealth=120, daño=30
    }
}

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