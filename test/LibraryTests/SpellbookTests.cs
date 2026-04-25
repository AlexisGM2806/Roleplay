using Library;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class SpellbookTests
    {
        private Spellbook spellbook;

        private Spell spell1;
        private Spell spell2;
        private Spell spell3;
        private Spell spell4;
        private Spell duplicateSpell;

        [SetUp]
        public void Setup()
        {
            spellbook = new Spellbook();

            spell1 = new Spell("Fireball", 10, 0);
            spell2 = new Spell("MagicMissile", 10, 0);
            spell3 = new Spell("MagicArmor", 0, 10); 
            spell4 = new Spell("MageArmor", 0, 5);

            duplicateSpell = new Spell("Fireball", 10, 0);
        }

        [Test]
        public void AddSpell_NewSpell_AddsToCollection()
        {
            int attack1 = spellbook.Attack;

            spellbook.AddSpell(spell1);
            int attack2 = spellbook.Attack;

            Assert.That(attack1, Is.EqualTo(0));
            Assert.That(attack2, Is.EqualTo(10));
        }

        [Test]
        public void AddSpell_DuplicateSpell_DoesNotAddAgain()
        {
            spellbook.AddSpell(spell1);
            int attack1 = spellbook.Attack;

            spellbook.AddSpell(duplicateSpell);
            int attack2 = spellbook.Attack;

            Assert.That(attack1, Is.EqualTo(10));
            Assert.That(attack2, Is.EqualTo(10));
            Assert.That(attack1, Is.EqualTo(attack2));
        }

        [Test]
        public void RemoveSpell_ExistingSpell_RemovesFromCollection()
        {
        spellbook.AddSpell(spell1);
        int attack1 = spellbook.Attack;

        spellbook.RemoveSpell(spell1);
        int attack2 = spellbook.Attack;

        Assert.That(attack1, Is.EqualTo(10));
        Assert.That(attack2, Is.EqualTo(0));
        Assert.That(attack1, Is.Not.EqualTo(attack2));
        }

        [Test]
        public void RemoveSpell_NonExistingSpell_NoChanges()
        {
            int attack1 = spellbook.Attack;
            spellbook.RemoveSpell(spell1);   
            int attack2 = spellbook.Attack;   

            Assert.That(attack1, Is.EqualTo(0));
            Assert.That(attack2, Is.EqualTo(0));
            Assert.That(attack1, Is.EqualTo(attack2));
        }

        [Test]
        public void Attack_WithSpells_ReturnsTotalAttack()
        {
            spellbook.AddSpell(spell1);
            spellbook.AddSpell(spell2);

            Assert.That(spellbook.Attack, Is.EqualTo(20));
        }

        [Test]
        public void Defense_WithSpells_ReturnsTotalDefense()
        {
            spellbook.AddSpell(spell3);
            spellbook.AddSpell(spell4);

            Assert.That(spellbook.Defense, Is.EqualTo(15));
        }
    }
}
