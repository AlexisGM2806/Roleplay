using Library;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class SpellTests
    {
        private Spell spell1;
        private Spell spellSameValues;
        private Spell spellDifferent;

        [SetUp]
        public void SetUp()
        {
            spell1 = new Spell("Fireball", 10, 5);


            spellSameValues = new Spell("Fireball", 10, 5);

            spellDifferent = new Spell("IceSpike", 5, 5);
        }

        [Test]
        public void Equals_SameValues_ReturnsTrue()
        {
            bool resultado = spell1.Equals(spellSameValues);

            Assert.That(resultado, Is.EqualTo(true));
        }

        [Test]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            bool resultado = spell1.Equals(spellDifferent);

            Assert.That(resultado, Is.EqualTo(false));
        }

        [Test]
        public void GetHashCode_SameValues_ReturnsSameHash()
        {
            int hash1 = spell1.GetHashCode();
            int hash2 = spellSameValues.GetHashCode();

            Assert.That(hash1, Is.EqualTo(hash2));
        }
    }
}