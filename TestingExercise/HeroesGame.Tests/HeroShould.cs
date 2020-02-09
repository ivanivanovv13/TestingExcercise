using HeroesGame.Constant;
using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesGame.Tests
{
    public class HeroShould
    {
        private IHero _hero;

        [SetUp]
        public void Setup()
        {
            this._hero = new Mage();
        }

        [Test]
        public void HaveCorrectInitialValues()
        {
            Assert.That(_hero.Level, Is.EqualTo(HeroConstants.InitialLevel), "Level not expected");
            Assert.That(_hero.Experience, Is.EqualTo(HeroConstants.InitialExperience));
            Assert.That(_hero.MaxHealth, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(_hero.Health, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(_hero.Armor, Is.EqualTo(HeroConstants.InitialArmor));
            Assert.That(_hero.Weapon, Is.Not.Null);
        }

        [Test]
        public void TakeHitCorrectly()
        {
            //Act
            var damage = 50;
            _hero.TakeHit(damage);

            //Assert
            Assert.That(_hero.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void TakeHitCorrectly_TestCase(int damage)
        {
            //Act
            _hero.TakeHit(damage);

            //Assert
            Assert.That(_hero.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        [Test]
        public void TakeHitCorrectly_Combinatorial([Values(40,50,60)] int damage)
        {
            //Act
            _hero.TakeHit(damage);

            //Assert
            Assert.That(_hero.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        [Test]
        public void TakeHitCorrectly_Range([Range(70, 100, 10)] int damage)
        {
            //Act
            _hero.TakeHit(damage);

            //Assert
            Assert.That(_hero.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        [Test]
        public void ThrowExceptionForNegativeTakeHitValue()
        {
            //Act
            var damage = -50;

            //Assert
            Assert.Throws<ArgumentException>(() => _hero.TakeHit(damage), "Damage value cannot be negative");
        }
    }
}
