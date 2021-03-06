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
            testCas.close();
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
            testCas.armed = true;
            Assert.IsFalse(testCas.flash);
            Assert.IsFalse(testCas.sound);
        }

        [Test]
        public void CAS_IsArmedAndThenUnlocked_ExpectArmedFalse()
        {
            testCas.armed = true;
            testCas.unlock();
            Assert.IsFalse(testCas.armed);
        }

        [Test]
        public void CAS_CASIsLocked_ExpectOpenedFalse()
        {
            Assert.IsFalse(testCas.opened);
        }

        [Test]
        public void CAS_IsUnlocked()
        {
            testCas.unlock();

            Assert.IsFalse(testCas.armed);
            Assert.IsFalse(testCas.locked);
            Assert.IsTrue(testCas.unlocked);
        }


        [Test]
        public void CAS_IsLockedWhileClosed()
        {
            testCas.close();
            testCas.lockcar();

            Assert.IsTrue(testCas.locked);
            Assert.IsFalse(testCas.unlocked);
            Assert.IsTrue(testCas.armed);
        }


        [Test]
        public void CAS_IsLockedWhileNotClosed()
        {
            testCas.lockcar();

            Assert.IsTrue(testCas.locked);
            Assert.IsFalse(testCas.unlocked);
        }

        [Test]
        public void CAS_IsClosedWhileLocked()
        {
            testCas.lockcar();
            testCas.close();

            Assert.IsTrue(testCas.closed);
            Assert.IsFalse(testCas.opened);
            Assert.IsTrue(testCas.armed);
        }

        [Test]
        public void CAS_IsClosedWhileNotLocked()
        {
            testCas.unlock();
            testCas.close();

            Assert.IsTrue(testCas.closed);
            Assert.IsFalse(testCas.opened);
            Assert.IsFalse(testCas.armed);
        }

        [Test]
        public void CAS_IsOpened()
        {
            testCas.unlock();
            testCas.open();

            Assert.IsTrue(testCas.opened);
            Assert.IsTrue(testCas.unlocked);
            Assert.IsFalse(testCas.closed);
            Assert.IsFalse(testCas.sound);
            Assert.IsFalse(testCas.flash);
            Assert.IsFalse(testCas.armed);
            Assert.IsFalse(testCas.locked);
        }

        [Test]
        public void CAS_IsFlashing_Unlocked()
        {
            Assert.IsFalse(testCas.flash);
        }

        [Test]
        public void CAS_IsOpenedWhileFlashAndSound()
        {
            testCas.armed = false;
            testCas.flash = true;
            testCas.sound = true;
            testCas.open();

            Assert.IsTrue(testCas.opened);
            Assert.IsFalse(testCas.closed);
            Assert.IsTrue(testCas.sound);
            Assert.IsTrue(testCas.flash);
        }


        [Test]
        public void CAS_FlashAlarm_SoundFlashFalse()
        {
            testCas.FlashAlarm();

            Assert.IsFalse(testCas.sound);
            Assert.IsFalse(testCas.flash);
        }

        [Test]
        public void CAS_IsOpenedWhileArmedAndUnlocked()
        {
            testCas.armed = true;
            testCas.unlocked = true;
            testCas.open();

            Assert.IsTrue(testCas.opened);
            Assert.IsFalse(testCas.closed);
            Assert.IsTrue(testCas.sound);
            Assert.IsTrue(testCas.flash);
        }

        [Test]
        public void CAS_IsOpenedWhileArmedAndNotUnlocked()
        {
            testCas.armed = true;
            testCas.unlocked = false;
            testCas.open();

            Assert.IsTrue(testCas.opened);
            Assert.IsFalse(testCas.closed);
            Assert.IsFalse(testCas.sound);
            Assert.IsFalse(testCas.flash);
        }
    }
}