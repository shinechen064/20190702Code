using MetalSaleSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestMetalSaleSystem
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ReadJsonData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string argFile = AppDomain.CurrentDomain.BaseDirectory+"\\sample_command.json";

            // Act
            var result = Program.ReadJsonData(
                argFile);

            // Assert
            if (!result)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UnpackOrderData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string argContext = "{\"orderId\":\"0000001\",\"memberId\":\"6236609999\",\"createTime\":\"2019-07-0215:00:00\",\"items\":[{\"product\":\"001001\",\"amount\":2},{\"product\":\"001002\",\"amount\":3},{\"product\":\"002002\",\"amount\":1},{\"product\":\"002003\",\"amount\":5}],\"payments\":[{\"type\":\"”‡∂Ó÷ß∏∂\",\"amount\":9860.00}],\"discountCards\":[\"9’€»Ø\"]}";
            // Act
            var result = Program.UnpackOrderData(argContext);

            // Assert
            if (!result)
            {
                Assert.Fail();
            }
        }
    }
}
