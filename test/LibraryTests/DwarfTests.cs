using Library;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class DwarfTests
    {
        private Dwarf dwarf;

        private Sword swordWeak;
        private Sword swordStrong;

        private Shield shieldWeak;
        private Shield shieldStrong;

        [SetUp]
        public void Setup()
        {
            dwarf = new Dwarf("Gimli");

            swordWeak = new Sword(0);
            swordStrong = new Sword(10);

            shieldWeak = new Shield(0);
            shieldStrong = new Shield(5);
        }

        [Test]
        public void GetAttack_EquippedItems_ReturnsSumOfAttack()
        {
            dwarf.SetSword(swordWeak);

            Assert.That(dwarf.GetAttack(), Is.EqualTo(0));
        }

        [Test]
        public void GetDefense_EquippedItems_ReturnsSumOfDefense()
        {
            dwarf.SetShield(shieldWeak);

            Assert.That(dwarf.GetDefense(), Is.EqualTo(0));
        }

        [Test]
        public void ReceiveAttack_HigherDefenseThanAttack_ReducesNoHealth()
        {
            dwarf.SetShield(shieldStrong); // defensa 5
            Dwarf attacker = new Dwarf("Attacker");
            attacker.SetSword(new Sword(4)); // ataca 4, menor que defensa 5
            dwarf.ReceiveAttack(attacker);

            Assert.That(dwarf.Health, Is.EqualTo(100));
        }

        [Test]
        public void ReceiveAttack_LethalDamage_HealthNeverBelowZero()
        {
            Dwarf attacker = new Dwarf("Attacker");
            attacker.SetSword(new Sword(120));
            dwarf.ReceiveAttack(attacker);

            Assert.That(dwarf.Health, Is.EqualTo(0));
        }

        [Test]
        public void Heal_AfterDamage_RestoresMaxHealth()
        {
            Dwarf attacker = new Dwarf("Attacker");
            attacker.SetSword(new Sword(120));
            dwarf.ReceiveAttack(attacker);
            dwarf.Heal();

            Assert.That(dwarf.Health, Is.EqualTo(100));
        }

        [Test]
        public void SetSword_NewSword_ReplacesPreviousSword()
        {
            dwarf.SetSword(swordWeak);
            int attack1 = dwarf.GetAttack();

            dwarf.SetSword(swordStrong);
            int attack2 = dwarf.GetAttack();

            Assert.That(attack1, Is.EqualTo(0));
            Assert.That(attack2, Is.EqualTo(10));
        }

        [Test]
        public void SetShield_NewShield_ReplacesPreviousShield()
        {
            dwarf.SetShield(shieldWeak);
            int defense1 = dwarf.GetDefense();

            dwarf.SetShield(shieldStrong);
            int defense2 = dwarf.GetDefense();

            Assert.That(defense1, Is.EqualTo(0));
            Assert.That(defense2, Is.EqualTo(5));
        }

        [Test]
        public void Dwarf_EquipShield_ChangesDefenseValues()
        {
            dwarf.SetShield(shieldWeak);
            int defense1 = dwarf.GetDefense();

            dwarf.SetShield(shieldStrong);
            int defense2 = dwarf.GetDefense();

            Assert.That(defense1, Is.EqualTo(0));
            Assert.That(defense2, Is.EqualTo(5));
        }
    }
}