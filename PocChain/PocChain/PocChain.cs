using System.Collections.Generic;

namespace PocChain
{
    public class Chain
    {
        public List<PocBlock> Blocks { get; private set; }
        private uint Difficulty { get; set; }

        public Chain(uint difficulty = 4)
        {
            Blocks = new List<PocBlock>
            {
                CreateGenesisBlock()
            };
            Difficulty = difficulty;
        }

        private PocBlock CreateGenesisBlock()
        {
            return new PocBlock("Genisis Block");
        }

        public PocBlock GetLatestBlock()
        {
            return Blocks[Blocks.Count-1];
        }

        public void AddBlock(PocBlock newBlock)
        {
            newBlock.PreviousHash = GetLatestBlock().Hash;
            newBlock.Index = Blocks.Count;
            newBlock.MineBlock(Difficulty);
            Blocks.Add(newBlock);
        }

        public bool IsChainValid()
        {
            for (int i = 1; i < Blocks.Count; i++)
            {
                var currentBlock = Blocks[i];
                var previousBlock = Blocks[i - 1];

                if(currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if(currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
