using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace EditModeTests
{
    public class SpeedBoostTest
    {
        [Test]
        public void SpeedBoostBasic()
        {
            // Act
            float finalSpeed = PlayerSpeedBonus.CalculateSpeedBoost(2.5f, 2f);

            // Assert
            Assert.AreEqual(5f, finalSpeed);
        }

        [Test]
        public void SpeedBoostMax()
        {
            // Act
            float finalSpeed = PlayerSpeedBonus.CalculateSpeedBoost(2.5f, 100f);

            // Assert
            Assert.AreEqual(50f, finalSpeed);
        }
    }
}
