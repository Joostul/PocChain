using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocChain;

namespace UnitTests
{
    [TestClass]
    public class BlockTests
    {
        private int index = 1;
        private object data = "{ \"address\": \"Joost\", \"value:\", \"42\" }";
        private string previousHash = "0";

        [TestMethod]
        public void CreateValidBlock()
        {
            // Arrange

            // Act
            var block = new PocBlock(index, data, previousHash);

            // Assert
            Assert.IsNotNull(block);
            Assert.AreEqual(index, block.Index);
            Assert.AreEqual(data, block.Data);
            Assert.AreEqual(previousHash, block.PreviousHash);
        }

        [TestMethod]
        public void CreateAndMineBlock()
        {
            // Arrange
            var block = new PocBlock(index, data, previousHash);

            // Act
            block.MineBlock(4);

            // Assert
            Assert.IsNotNull(block);
            Assert.IsNotNull(block.Nonce);
            Assert.AreEqual(index, block.Index);
            Assert.AreEqual(data, block.Data);
            Assert.AreEqual(previousHash, block.PreviousHash);
        }
    }
}
