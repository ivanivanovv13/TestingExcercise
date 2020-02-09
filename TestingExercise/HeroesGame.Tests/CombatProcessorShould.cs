using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
using HeroesGame.Implementation.Monster;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesGame.Tests
{
    public class CombatProcessorShould
    {
        private CombatProcessor _cp;

        [SetUp]
        public void Setup()
        {
            _cp = new CombatProcessor(new Hunter());
        }

        [Test]
        public void InitializeCorrectly()
        {
            Assert.That(_cp.Hero, Is.Not.Null);
            Assert.That(_cp.Logger, Is.Not.Null);
            Assert.That(_cp.Logger, Is.Empty);
        }

        [Test]
        public void FightCorrectlyAndRepeatedly_StrongEnemy()
        {
            IMonster monster = new MedusaTheGorgon(50);

            _cp.Fight(monster);
            var logger = _cp.Logger;

            Assert.That(logger, Has.Count.EqualTo(12));
            Assert.That(logger, Does.Contain("The hero dies on level 1 after 4 fights."));
        }
    }
}
