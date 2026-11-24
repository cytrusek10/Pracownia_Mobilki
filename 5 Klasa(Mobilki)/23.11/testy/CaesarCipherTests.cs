using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaesarCipherApp;

namespace CaesarCipherApp.Tests
{
    [TestClass]
    public class CaesarCipherTests
    {
        [TestMethod]
        public void Encrypt_PositiveKeySmallerThanAlphabet_ShiftsLetters()
        {
            Assert.AreEqual("def", CaesarCipher.Encrypt("abc", 3));
        }

        [TestMethod]
        public void Encrypt_LettersAndKeyExceedAlphabet_WrapsAround()
        {
            Assert.AreEqual("abc", CaesarCipher.Encrypt("xyz", 3));
        }

        [TestMethod]
        public void Encrypt_NegativeKey_Decrypts()
        {
            Assert.AreEqual("abc", CaesarCipher.Encrypt("def", -3));
        }

        [TestMethod]
        public void Encrypt_KeyGreaterThanAlphabetLength_ReducesKey()
        {
            Assert.AreEqual("def", CaesarCipher.Encrypt("abc", 29));
        }

        [TestMethod]
        public void Encrypt_TextWithSpace_KeepsSpace()
        {
            Assert.AreEqual("cd ef", CaesarCipher.Encrypt("ab cd", 2));
        }
    }
}
