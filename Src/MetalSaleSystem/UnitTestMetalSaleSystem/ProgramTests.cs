using MetalSaleSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestMetalSaleSystem
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void UnpackJsonData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string argFile = "sample_command.json";

            // Act
            var result = Program.ReadJsonData(
                argFile);

            // Assert
            if (!result)
            {
                Assert.Fail();
            }
        }
    }
}
