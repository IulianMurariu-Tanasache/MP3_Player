using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FormHelpers;

namespace UnitTestFormHelper
{
    [TestClass]
    public class UnitTestFormHelper
    {

        [TestMethod]
        public void TestConvertTime()
        {
            int timeInSeconds = 90;
            Assert.AreEqual("01:30", FormHelper.ConvertTime(timeInSeconds));
        }

        [TestMethod]
        public void TestAddWithoutDuplicates()
        {
            List<string> newItems = new List<string> { "item1", "item2" };
            List<string> mainList = new List<string> { "item1", "item3" };
            List<string> newFiltered = FormHelper.AddWithoutDuplicates(newItems, mainList);

            Assert.AreEqual(1, newFiltered.Count);
            Assert.AreEqual("item2", newFiltered[0]);
        }
    }
}
