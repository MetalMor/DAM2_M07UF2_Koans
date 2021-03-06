﻿using System;
using NUnit.Framework;

namespace TheKoans
{
	[TestFixture]
	public class K010_AboutAsserts : KoanHelper
	{
		private static readonly Int32 FILL_ME_IN = new Int32 ();
		private static readonly bool FILL_ME__IN;

		[Test]
		public void AssertTruth ()
		{
            //Assert.IsTrue(false);
            Assert.IsTrue(true);
            //El teu llarg trajecte comença amb una simple passa. Busquem el que és cert, ajudan's a trobar-ho.
        }

		[Test]
		public void AssertsShouldHaveMessages ()
		{
            //Assert.IsTrue(FILL_ME__IN, "Aquest missatge t'hauria d'ajudar a entendre què ha fallat. Si us plau, ajudan's a trobar la veritat.");
            Assert.IsTrue(true, "Aquest missatge t'hauria d'ajudar a entendre què ha fallat. Si us plau, ajudan's a trobar la veritat.");
        }

        [Test]
		public void AssertFalse ()
		{
            //Assert.IsFalse(true, "La veritat es presenta en diverses formes. Aquí el que és cert hauria de ser fals.");
            Assert.IsFalse(false, "La veritat es presenta en diverses formes. Aquí el que és cert hauria de ser fals.");
        }

        [Test]
		public void AssertEquality ()
		{
            //Assert.IsTrue(1 == FILL_ME_IN, "La veritat pot ser descoberta en expressions booleanes, quan són certes.");
            Assert.IsTrue(1 == 1, "La veritat pot ser descoberta en expressions booleanes, quan són certes.");
        }

        [Test]
		public void AssertEqualityTheBetterWay ()
		{
            //var expectedValue = FILL_ME__IN;
            var expectedValue = 2;
            var actualValue = 1 + 1;

			Assert.AreEqual (expectedValue, actualValue, "Quan el teu karma es trenca és més útil saber què s'esperava i què realment és.");
		}

		[Test]
		public void AssertFail ()
		{
            //bool thePathToEnlightment = FILL_ME__IN;
            bool thePathToEnlightment = true;
            if (!thePathToEnlightment) {
				Assert.Fail ("Prendre un camí (path) desafortunat trenca el teu karma. Canvia els camins cap a la veritat.");
			}
            
			Assert.IsTrue (thePathToEnlightment, "El camí ha estat trobat.");
		}
	}
}