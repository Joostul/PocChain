using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocChain;

namespace UnitTests
{
    [TestClass]
    public class BlockTests
    {
        private readonly object data = "{ \"address\": \"Joost\", \"value:\", \"42\" }";

        [TestMethod]
        public void CreateValidBlock()
        {
            // Arrange

            // Act
            var block = new PocBlock(data);

            // Assert
            Assert.IsNotNull(block);
            Assert.AreEqual(data, block.Data);
        }

        [TestMethod]
        public void CreateAndMineBlock()
        {
            // Arrange
            var block = new PocBlock(data);

            // Act
            block.MineBlock(4);

            // Assert
            Assert.IsNotNull(block);
            Assert.IsNotNull(block.Nonce);
            Assert.AreEqual(data, block.Data);
        }
    }
}
