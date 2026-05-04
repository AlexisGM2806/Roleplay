using Library;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class BerserkerTests
    {
        private Berserker berserker;

        private Axe axeWeak;
        private Axe axeStrong;

        private Armor armorWeak;
        private Armor armorStrong;

        [SetUp]
        public void Setup()
        {
            berserker = new Berserker("Bolg");

            axeWeak = new Axe(0);
            axeStrong = new Axe(40);

            armorWeak = new Armor(0);
            armorStrong = new Armor(25);
        }

        [Test]
        public void GetAttack_EquippedAxe_ReturnsAxeAttack()
        {
            berserker.SetAxe(axeWeak);

            Assert.That(berserker.GetAttack(), Is.EqualTo(0));
        }

        [Test]
        public void GetDefense_EquippedArmor_ReturnsArmorDefense()
        {
            berserker.SetArmor(armorWeak);

            Assert.That(berserker.GetDefense(), Is.EqualTo(0));
        }

        [Test]
        public void ReceiveAttack_HigherDefenseThanAttack_ReducesNoHealth()
        {
            Berserker attacker = new Berserker("Attacker");
            attacker.SetAxe(new Axe(10));

            berserker.SetArmor(armorStrong); // defensa 25 > ataque 10

            berserker.ReceiveAttack(attacker);

            Assert.That(berserker.Health, Is.EqualTo(150));
        }

        [Test]
        public void ReceiveAttack_LethalDamage_HealthNeverBelowZero()
        {
            Berserker attacker = new Berserker("Attacker");
            attacker.SetAxe(new Axe(9999));

            berserker.ReceiveAttack(attacker);

            Assert.That(berserker.Health, Is.EqualTo(0));
        }

        [Test]
        public void Heal_AfterDamage_RestoresMaxHealth()
        {
            Berserker attacker = new Berserker("Attacker");
            attacker.SetAxe(new Axe(9999));

            berserker.ReceiveAttack(attacker);
            berserker.Heal();

            Assert.That(berserker.Health, Is.EqualTo(150));
        }

        [Test]
        public void SetAxe_NewAxe_ReplacesPreviousAxe()
        {
            berserker.SetAxe(axeWeak);
            int attack1 = berserker.GetAttack();

            berserker.SetAxe(axeStrong);
            int attack2 = berserker.GetAttack();

            Assert.That(attack1, Is.EqualTo(0));
            Assert.That(attack2, Is.EqualTo(40));
        }

        [Test]
        public void SetArmor_NewArmor_ReplacesPreviousArmor()
        {
            berserker.SetArmor(armorWeak);
            int defense1 = berserker.GetDefense();

            berserker.SetArmor(armorStrong);
            int defense2 = berserker.GetDefense();

            Assert.That(defense1, Is.EqualTo(0));
            Assert.That(defense2, Is.EqualTo(25));
        }
    }
}