using System.Collections;
using System.Collections.Generic;
using Managers;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameManagerTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Pause()
        {
            GameManager.Instance.Pause(true);

            Assert.AreEqual(0, Time.timeScale);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GameManagerTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(5f);
            GameManager.Instance.Pause(true);

            Assert.AreEqual(0, Time.timeScale);

        }
    }
}
