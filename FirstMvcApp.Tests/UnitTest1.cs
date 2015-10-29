using System;
using System.Text;
using System.Collections.Generic;
using FirstMvcApp.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstMvcApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        // Arrange
        PinkFloydsTime myTime = new PinkFloydsTime(new DateTime(2015, 10, 5, 10, 10, 10), new DateTime(2015, 11, 5, 10, 10, 10));

        PinkFloydsTime sameTime = new PinkFloydsTime(new DateTime(2015, 10, 5, 10, 10, 10), new DateTime(2015, 11, 5, 10, 10, 10));

        PinkFloydsTime someOtherTimeWithStartInTheMiddle = new PinkFloydsTime(new DateTime(2015, 10, 29, 10, 10, 10), new DateTime(2015, 12, 31, 10, 10, 10));

        PinkFloydsTime someOtherTimeWithEndInTheMiddle = new PinkFloydsTime(new DateTime(2015, 1, 29, 10, 10, 10), new DateTime(2015, 12, 6, 10, 10, 10));

        PinkFloydsTime someOtherTimeOutside = new PinkFloydsTime(new DateTime(2015, 10, 4, 10, 10, 10), new DateTime(2015, 11, 6, 10, 10, 10));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Start time is later or equals to end time")]
        public void TestIllegalTime1()
        {
            PinkFloydsTime myIllegalTime1 = new PinkFloydsTime(new DateTime(2015, 10, 5, 10, 10, 10), new DateTime(2015, 9, 5, 10, 10, 10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Start time is later or equals to end time")]
        public void TestIllegalTime2()
        {
            PinkFloydsTime myIllegalTime2 = new PinkFloydsTime(new DateTime(2015, 10, 5, 10, 10, 10), new DateTime(2015, 9, 5, 10, 10, 10));
        }

        [TestMethod]
        public void TestSomeOtherTimeWithStartInTheMiddle()
        {
            // should return true
            Assert.IsTrue(myTime.IsOverlapped(someOtherTimeWithStartInTheMiddle));
        }

        [TestMethod]
        public void TestSomeOtherTimeWithEndInTheMiddle()
        {
            // should return true
            Assert.IsTrue(myTime.IsOverlapped(someOtherTimeWithEndInTheMiddle));
        }

        [TestMethod]
        public void TestSomeOtherTimeoutside()
        {
            // should return true
            Assert.IsTrue(myTime.IsOverlapped(someOtherTimeOutside));
        }

        [TestMethod]
        public void TestSameTime()
        {
            // should return true
            Assert.IsTrue(myTime.IsOverlapped(sameTime));
        }

        [TestMethod]
        public void TestExplosion()
        {
            // should explode
            Assert.IsTrue(someOtherTimeWithStartInTheMiddle.IsOverlapped(someOtherTimeWithEndInTheMiddle));
        }
    }
}
