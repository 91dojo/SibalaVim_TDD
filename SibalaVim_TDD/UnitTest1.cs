using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SibalaVim_TDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OneColor()
        {
            var dice = new Dice(1, 1, 1, 1);
            Assert.AreEqual("One Color", dice.Output);
        }
    }

    public class Dice
    {
        public Dice(int i, int i1, int i2, int i3)
        {
            throw new NotImplementedException();
        }

        public string Output { get; set; }
    }
}
