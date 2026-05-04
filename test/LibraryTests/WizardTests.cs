using Library;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class WizardTests
    {
        private Wizard wizard;
        
        private Staff staffWeak;
        private Staff staffStrong;
        
        private Spellbook spellbookEmpty;
        private Spellbook spellbookWithSpells;

        private Spell fireball;
        private Spell magicMissile;
        private Spell magicArmor;

        [SetUp]
        public void Setup()
        {
            wizard = new Wizard("Elminster");

            staffWeak = new Staff(0, 0);
            staffStrong = new Staff(10, 5);

            fireball = new Spell("Fireball", 10, 0);
            magicMissile = new Spell("MagicMissile", 10, 0);

            spellbookEmpty = new Spellbook();

            spellbookWithSpells = new Spellbook();
            spellbookWithSpells.AddSpell(fireball);
            spellbookWithSpells.AddSpell(magicMissile);
        }

        [Test]
        public void GetAttack_EquippedItems_ReturnsSumOfAttack()
        {
            wizard.SetStaff(staffWeak);
            wizard.SetSpellbook(spellbookEmpty);
           
            Assert.That(wizard.GetAttack(), Is.EqualTo(0));
        }

        [Test]
        public void GetDefense_EquippedItems_ReturnsSumOfDefense()
        {
            wizard.SetStaff(staffWeak);
            wizard.SetSpellbook(spellbookEmpty);
           
            Assert.That(wizard.GetDefense(), Is.EqualTo(0));
        }

        [Test]
        public void ReceiveAttack_HigherDefenseThanAttack_ReducesNoHealth()
        {
            Wizard attacker = new Wizard("Attacker");
            attacker.SetStaff(new Staff(5, 0));

            wizard.SetStaff(staffStrong);
            wizard.ReceiveAttack(attacker);
            
            Assert.That(wizard.Health, Is.EqualTo(100));
        }

        [Test]
        public void ReceiveAttack_LethalDamage_HealthNeverBelowZero()
        {
            Wizard attacker = new Wizard("Attacker");
            attacker.SetStaff(new Staff(120, 0));

            wizard.ReceiveAttack(attacker);
           
            Assert.That(wizard.Health, Is.EqualTo(0));
        }

        [Test]
        public void Heal_AfterDamage_RestoresMaxHealth()
        {
            Wizard attacker = new Wizard("Attacker");
            attacker.SetStaff(new Staff(120, 0));

            wizard.ReceiveAttack(attacker);
            wizard.Heal();
           
            Assert.That(wizard.Health, Is.EqualTo(100));
        }

        [Test]
        public void SetStaff_NewStaff_ReplacesPreviousStaff()
        {
            wizard.SetStaff(staffWeak);
            int attack1 = wizard.GetAttack();
           
            wizard.SetStaff(staffStrong);
            int attack2 = wizard.GetAttack();
           
            Assert.That(attack1, Is.EqualTo(0));
            Assert.That(attack2, Is.EqualTo(10));
        }

        [Test]
        public void SetSpellbook_NewSpellbook_ReplacesPreviousSpellbook()
        {
            wizard.SetSpellbook(spellbookEmpty);
            int attack1 = wizard.GetAttack();
           
            wizard.SetSpellbook(spellbookWithSpells);
            int attack2 = wizard.GetAttack();
           
            Assert.That(attack1, Is.EqualTo(0));
            Assert.That(attack2, Is.EqualTo(20));
        }

        [Test]
        public void Wizard_EquipSpellbook_ChangesAttackAndDefense()
        {
            magicArmor = new Spell("MagicArmor", 0, 10);
            spellbookWithSpells.AddSpell(magicArmor);
            
            wizard.SetSpellbook(spellbookEmpty);
            int defense1 = wizard.GetDefense();
            int attack1 = wizard.GetAttack();
            
            wizard.SetSpellbook(spellbookWithSpells);
            int defense2 = wizard.GetDefense();
            int attack2 = wizard.GetAttack();

            Assert.That(defense1, Is.EqualTo(0));
            Assert.That(attack1, Is.EqualTo(0));
            Assert.That(defense2, Is.EqualTo(10));
            Assert.That(attack2, Is.EqualTo(20));
        }

        [Test]
        public void Wizard_EquipStaff_ChangesDefenseValues()
        {
            wizard.SetStaff(staffWeak);
            int defense1 = wizard.GetDefense();

            wizard.SetStaff(staffStrong);
            int defense2 = wizard.GetDefense();

            Assert.That(defense1, Is.EqualTo(0));
            Assert.That(defense2, Is.EqualTo(5));
        }
    }
}