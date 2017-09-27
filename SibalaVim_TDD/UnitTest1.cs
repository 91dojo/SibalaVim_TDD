﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SibalaVim_TDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OneColor()
        {
            DiceOutputShouldBe("One Color", 1, 1, 1, 1);
        }

        private static void DiceOutputShouldBe(string expected, int i0, int i1, int i2, int i3)
        {
            var dice = new Dice(i0, i1, i2, i3);
            Assert.AreEqual(expected, dice.Output);
        }
    }

    public class Dice
    {
        private List<int> _dices;

        public Dice(int i0, int i1, int i2, int i3)
        {
            this._dices = new List<int> { i0, i1, i2, i3 };
        }

        public string Output
        {
            get
            {
                return "One Color";
            }
        }
    }
}