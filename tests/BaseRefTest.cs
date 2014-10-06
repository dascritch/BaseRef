using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseRef
{
    [TestClass]
    public class BaseRefTest
    {
        [TestMethod]
        public void BaseRef_IsValid_Empty()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_0()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("0");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_9()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("9");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_A()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("A");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_X()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("X");
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void BaseRef_IsValid_underscore_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("_");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_B_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("B");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_G_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("G");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_I_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("I");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_L_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("L");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_O_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("O");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_S_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("S");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_Y_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("Y");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_Z_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("Z");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_String1_Valid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("5FF90");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BaseRef_IsValid_String2_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid("4QZ0");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test1()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(0);
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test2()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(1);
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test3()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(9);
            Assert.AreEqual("9", result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test4()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(10);
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test5()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(27);
            Assert.AreEqual("X", result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test6()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(28);
            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test7()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(55);
            Assert.AreEqual("1X", result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test8()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(56);
            Assert.AreEqual("20", result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test9()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(783);
            Assert.AreEqual("XX", result);
        }

        [TestMethod]
        public void BaseRef_Encode_Test10()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(784);
            Assert.AreEqual("100", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BaseRef_Encode_Test11()
        {
            BaseRef tested = new BaseRef();
            string result = tested.Encode(-14);
            Assert.Inconclusive();
        }

        [TestMethod]
        public void BaseRef_Decode_Test1()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("0");
            Assert.AreEqual(00, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test2()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("9");
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test3()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("A");
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test4()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("X");
            Assert.AreEqual(27, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test5()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("10");
            Assert.AreEqual(28, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test6()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("1X");
            Assert.AreEqual(55, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test7()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("20");
            Assert.AreEqual(56, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test8()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("XX");
            Assert.AreEqual(783, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test9()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("100");
            Assert.AreEqual(784, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test10()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("a");
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void BaseRef_Decode_Test11()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("xx");
            Assert.AreEqual(783, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BaseRef_Decode_Test12()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("L");
            Assert.Inconclusive();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BaseRef_Decode_Test13()
        {
            BaseRef tested = new BaseRef();
            int result = tested.Decode("-AX");
            Assert.Inconclusive();
        }
        
        [TestMethod]
        public void BaseRef_IsValid_StringWithDefault_NotValid()
        {
            BaseRef tested = new BaseRef();
            var result = tested.IsValid(default(char) + "$$");
            Assert.IsFalse(result);
        }
    }
}
