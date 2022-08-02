using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    public class Tests
    {
        [Test]
        public void TheWeapenShouldLoseDurabilityAfterEachAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }
        [Test]
        public void AttackWithBrokenWeaponShouldBeInposible()
        {
            Assert.That(() =>
            {
                Axe axe = new Axe(10, 0);
                Dummy dummy = new Dummy(10, 10);

                axe.Attack(dummy);
            },
            Throws.Exception.TypeOf<InvalidOperationException>(), ("Axe is broken.")
            );
        }
    }
}