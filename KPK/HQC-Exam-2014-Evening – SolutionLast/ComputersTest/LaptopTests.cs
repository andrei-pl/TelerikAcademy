namespace ComputersTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computers.UI.Console;
    
    [TestClass]
    public class LaptopTests
    {

        [TestMethod]
        public void ChargingBatteryWithPositiveValueMustReturnHundredWhenPercentageIsHundred()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 100;
            battery.Charge(1);

            Assert.AreEqual(100, battery.Percentage);
        }

        [TestMethod]
        public void ChargingBatteryWithNegativeValueMustReturnZeroWhenPercentageIsZero()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 0;
            battery.Charge(-1);

            Assert.AreEqual(0, battery.Percentage);
        }

         [TestMethod]
        public void ChargingBatteryWithNegativeValueMustReturnFourthyNineAfterNewBatteryIsCreated()
        {
            var battery = new LaptopBattery();
            battery.Charge(-1);

            Assert.AreEqual(49, battery.Percentage);
        }
    }
}
