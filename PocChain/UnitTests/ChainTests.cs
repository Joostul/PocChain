using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocChain;

namespace UnitTests
{
    [TestClass]
    public class ChainTests
    {
        [TestMethod]
        public void CreateValidChain()
        {
            // Arrange
            var chain = new Chain();

            // Act
            var firstBlock = new PocBlock("test");
            chain.AddBlock(firstBlock);

            var secondBlock = new PocBlock("test2");
            chain.AddBlock(secondBlock);

            // Assert
            Assert.IsTrue(chain.IsChainValid());
        }

        [TestMethod]
        public void GetLatestBlock_GetsLatestBlock()
        {
            // Arrange
            var chain = new Chain();

            // Act
            var firstBlock = new PocBlock("test");
            chain.AddBlock(firstBlock);

            var secondBlock = new PocBlock("test2");
            chain.AddBlock(secondBlock);

            // Assert
            Assert.IsTrue(chain.IsChainValid());
            Assert.AreEqual(secondBlock, chain.GetLatestBlock());
        }

        [TestMethod]
        public void TemperCreatesInvalidChain()
        {
            // Arrange
            var chain = new Chain();

            // Act
            var firstBlock = new PocBlock("test");
            chain.AddBlock(firstBlock);

            var secondBlock = new PocBlock("test2");
            chain.AddBlock(secondBlock);

            var thirdBlock = new PocBlock("test3");
            chain.AddBlock(thirdBlock);

            chain.Blocks[0] = thirdBlock;

            // Assert
            Assert.IsFalse(chain.IsChainValid());
        }
    }
}
