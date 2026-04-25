using Library;
using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class StaffTests
    {
        private Staff staffDefault;
        private Staff staffNegative;

        [SetUp]
        public void SetUp()
        {
            staffDefault = new Staff();

            staffNegative = new Staff(-10, -5);
        }

        [Test]
        public void Staff_DefaultConstructor_InitializesZeroValues()
        {
            int attack = staffDefault.Attack;
            int defense = staffDefault.Defense;

            Assert.That(attack, Is.EqualTo(0));
            Assert.That(defense, Is.EqualTo(0));
        }

        [Test]
        public void Staff_NegativeValues_ClampsToZero()
        {
            int attack = staffNegative.Attack;
            int defense = staffNegative.Defense;

            Assert.That(attack, Is.EqualTo(0));
            Assert.That(defense, Is.EqualTo(0));
        }
    }    
}
