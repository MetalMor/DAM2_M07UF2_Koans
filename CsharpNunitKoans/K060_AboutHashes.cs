using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System;

namespace TheKoans
{
	[TestFixture]
	public class K060_AboutHashes : KoanHelper
	{
		[Test]
		public void CreatingHashes ()
		{
			var hash = new Hashtable ();
            Assert.AreEqual(typeof(Hashtable), hash.GetType());
            //Assert.Equals (FILL_ME_IN, hash.Count);
            Assert.AreEqual(0, hash.Count);
        }

		[Test]
		public void HashLiterals ()
		{
			// Hi ha diverses maneres d'obtenir estils similars a Ruby en C#
			// Obriu el blog de Haacked's aquí mateix: http://haacked.com/archive/2008/01/06/collection-initializers.aspx
			// Aquesta és una manera:
			var hash = new Hashtable () { { "one", "uno" }, { "two", "dos" } };
            //Assert.Equals (FILL_ME_IN, hash.Count);
            Assert.AreEqual(2, hash.Count);
        }

		[Test]
		public void AccessingHashes ()
		{
			var hash = new Hashtable () { { "one", "uno" }, { "two", "dos" } };
            //Assert.Equals (FILL_ME_IN, hash ["one"]);
            Assert.AreEqual("uno", hash["one"]);
            //Assert.Equals (FILL_ME_IN, hash ["two"]);
            Assert.AreEqual("dos", hash["two"]);
            //Assert.Equals (FILL_ME_IN, hash ["doesntExist"]);
            Assert.AreEqual(null, hash["doesntExist"]);
        }

        [Test]
		public void ChangingHashes ()
		{
			var hash = new Hashtable () { { "one", "uno" }, { "two", "dos" } };
			hash ["one"] = "eins";

            //var expected = new Hashtable () { { "one", FILL_ME_IN }, { "two", "dos" } };
            var expected = new Hashtable() { { "one", "eins" }, { "two", "dos" } };
            Assert.AreEqual(expected, hash);
		}

		[Test]
		public void HashIsUnordered ()
		{
			var hash1 = new Hashtable () { { "one", "uno" }, { "two", "dos" } };
			var hash2 = new Hashtable () { { "two", "dos" }, { "one", "uno" } };
			Assert.AreEqual(hash1, hash2);
            // OK
		}

		[Test]
		public void HashKeysAndValues ()
		{
			var hash = new Hashtable () { { "one", "uno" }, { "two", "dos" } };

			// Alerta: Sintaxi no familiar a dalt. Perquè les hashtable keys
			// només retornen un ICollection, no hi ha una bona manera de preguntar
			// si coincideix, o conté els valors. Així doncs, utilitzem el 'truc' des
			// des LINQ per a fer-hi un cast. Noteu que el cast no és important en
            // aquesta càpsula de C#, sinó el valor de les claus el que ens interessa.

			var expectedKeys = new List<string> () { "one", "two" };
			expectedKeys.Sort ();
			var actualKeys = hash.Keys.Cast<string> ().ToList ();
			actualKeys.Sort ();

			Assert.AreEqual(expectedKeys, actualKeys);

            //var expectedValues = new List<string> () { FILL_ME_IN.ToString (), FILL_ME_IN.ToString () };
            var expectedValues = new List<string>() { "uno", "dos" };
            expectedValues.Sort ();
			var actualValues = hash.Values.Cast<string> ().ToList ();
			actualValues.Sort ();

			Assert.AreEqual(expectedValues, actualValues);
		}
		// Codi original agafat del mètode CombiningHashes() de sota.
		// No podem afegir la mateixa clau:
		// Assert.Throws(typeof(FILL_ME_IN), delegate() { hash.Add("jim", 54); });
		// ...a un mètode separat i que entengueu l'excepció que es llença.
		
		[Test]
        // No us preocupeu si a priori no enteneu aquest atribut de MSTest de sota. 
        // Bàsicmament, estem dient que esperem que es llenci una excepció del tipus indicat.
        // No us conformeu amb posar la classe genèrica Exception; 
        // investigueu quina excepció específica us convé.
        //[ExpectedException (typeof(FILL_ME_IN))]
		public void CannotAddSameKeyInHashtable ()
		{
			var hash = new Hashtable () { { "jim", 53 }, { "amy", 20 }, { "dan", 23 } };

            // No podem afegir la mateixa clau:
            try { hash.Add("jim", 54); }
            catch(Exception ex) { Console.Write(ex.Message); }
		}

		[Test]
		public void CombiningHashes ()
		{
			var hash = new Hashtable () { { "jim", 53 }, { "amy", 20 }, { "dan", 23 } };

            // No podem afegir la mateixa clau:

            // Convertit el codi original: 
            //Assert.Throws(typeof(FILL_ME_IN), delegate () { hash.Add("jim", 54); });
            Assert.Throws(typeof(ArgumentException), delegate() { hash.Add("jim", 54); });
			// ...al mètode CannotAddSameKeyInHashtable() de dalt.

			// Però ara imaginem que volíem fusionar dues Hashtables? 
			// Tenim el següent:
			var newHash = new Hashtable () { { "jim", 54 }, { "jenny", 26 } };

			// i volem fusionar això en la el nostre primer hashtable. 
            // Això farà el fet...
			foreach (DictionaryEntry item in newHash) {
				hash [item.Key] = item.Value;
			}

			Assert.AreEqual (54, hash ["jim"]);
			Assert.AreEqual(26, hash ["jenny"]);
			Assert.AreEqual(20, hash ["amy"]);

		}
	}
}