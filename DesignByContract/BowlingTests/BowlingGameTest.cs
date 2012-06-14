using NUnit.Framework;
using BowlingByContract.Game;

namespace BowlingByContract.Tests
{
    [TestFixture]
    public class BowlingGameTest
    {
        [Test]
        public void Rolling_a_negative_number_is_invalid()
        {
            var bg = new BowlingGame();
            bg.Bowl(-1);
            Assert.AreEqual(-1, bg.Score);
        }

        [Test]
        public void Legacy_Rolling_a_negative_number_is_invalid()
        {
            // Demonstrates a one way to avoid re-writing legacy assertions. Better to re-write.
            var bg = new BowlingGame();
            bg.LegacyBowl(-1);
            Assert.AreEqual(-1, bg.Score);
        }


    }
}
