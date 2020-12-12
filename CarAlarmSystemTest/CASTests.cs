using NUnit.Framework;
using CAS;
using System;

namespace CarAlarmSystemTest
{
    public class CASTests
    {
        public CAS.CarAlarmSystem testCas = new CAS.CarAlarmSystem(false, true, true, false, false, false, false);

        [SetUp]
        public void Setup()
        {
            testCas.lockcar();
        }

        [Test]
        public void CAS_IsLockedAndClosed_ExpectArmedTrue()
        {
            testCas.unlock();
            testCas.lockcar();
            Assert.IsTrue(testCas.armed);
        }

        [Test]
        public void CAS_IsUnlocked_ExpectArmedFalse()
        {
            testCas.unlock();
            Assert.IsFalse(testCas.armed);
        }

        [Test]
        public void CAS_IsArmedAndClosed_ExpectNoFlashAndSilence()
        {
            testCas.close();
            Assert.IsFalse(testCas.flash);
            Assert.IsFalse(testCas.sound);
        }

        [Test]
        public void CAS_IsArmedAndThenUnlocked_ExpectArmedFalse()
        {
            testCas.unlock();
            Assert.IsFalse(testCas.armed);
        }
    }
}