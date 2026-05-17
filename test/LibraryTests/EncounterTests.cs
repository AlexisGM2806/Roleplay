using Library;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class EncounterTests
    {
        private Encounter encounter;

        private Wizard wizard;
        private Berserker berserker;

        private Orc orc;
        private Bastard bastard;

        [SetUp]
        public void Setup()
        {
            encounter = new Encounter();

            wizard = new Wizard("Gandalf");
            berserker = new Berserker("Conan");

            orc = new Orc("Azog");
            bastard = new Bastard("Lurtz");
        }

        [Test]
        public void AddHero_AddsHeroToEncounter()
        {
            encounter.AddHero(wizard);

            Assert.That(encounter.Heroes.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddEnemy_AddsEnemyToEncounter()
        {
            encounter.AddEnemy(orc);

            Assert.That(encounter.Enemies.Count, Is.EqualTo(1));
        }

        [Test]
        public void DoEncounter_EnemiesAttackHeroes_HeroesReceiveDamage()
        {
            orc.SetAxe(new Axe(50));

            encounter.AddHero(wizard);
            encounter.AddHero(berserker);

            encounter.AddEnemy(orc);

            encounter.DoEncounter();

            Assert.That(
                wizard.Health < wizard.MaxHealth ||
                berserker.Health < berserker.MaxHealth,
                Is.True
            );
        }

        [Test]
        public void DoEncounter_HeroesAttackEnemies_EnemiesReceiveDamage()
        {
            wizard.SetStaff(new Staff(80, 0));

            encounter.AddHero(wizard);

            encounter.AddEnemy(orc);

            encounter.DoEncounter();

            Assert.That(orc.Health, Is.LessThan(orc.MaxHealth));
        }

        [Test]
        public void DoEncounter_DeadEnemyIsRemoved()
        {
            wizard.SetStaff(new Staff(300, 0));

            encounter.AddHero(wizard);

            encounter.AddEnemy(orc);

            encounter.DoEncounter();

            Assert.That(encounter.Enemies.Contains(orc), Is.False);
        }

        [Test]
        public void DoEncounter_DeadHeroIsRemoved()
        {
            orc.SetAxe(new Axe(500));

            encounter.AddHero(wizard);

            encounter.AddEnemy(orc);

            encounter.DoEncounter();

            Assert.That(encounter.Heroes.Contains(wizard), Is.False);
        }

        [Test]
        public void DoEncounter_HeroGainsVictoryPointsAfterKillingEnemy()
        {
            wizard.SetStaff(new Staff(300, 0));

            encounter.AddHero(wizard);

            encounter.AddEnemy(orc);

            encounter.DoEncounter();

            Assert.That(wizard.TotalVP, Is.EqualTo(2));
        }

        [Test]
        public void DoEncounter_HeroHealsAfterReachingFiveVictoryPoints()
        {
            wizard.ReceiveAttack(orc);

            wizard.SetStaff(new Staff(500, 0));

            Orc orc1 = new Orc("Orc1");
            Orc orc2 = new Orc("Orc2");
            Bastard bastard1 = new Bastard("Bastard1");

            encounter.AddHero(wizard);

            encounter.AddEnemy(orc1);
            encounter.AddEnemy(orc2);
            encounter.AddEnemy(bastard1);

            encounter.DoEncounter();

            Assert.That(wizard.TotalVP, Is.GreaterThanOrEqualTo(5));
            Assert.That(wizard.Health, Is.EqualTo(wizard.MaxHealth));
        }

        [Test]
        public void DoEncounter_MultipleHeroesCanFightTogether()
        {
            wizard.SetStaff(new Staff(80, 0));
            berserker.SetAxe(new Axe(80));

            encounter.AddHero(wizard);
            encounter.AddHero(berserker);

            encounter.AddEnemy(orc);
            encounter.AddEnemy(bastard);

            encounter.DoEncounter();

            Assert.That(
                orc.IsDead || bastard.IsDead ||
                orc.Health < orc.MaxHealth ||
                bastard.Health < bastard.MaxHealth,
                Is.True
            );
        }
    }
}