using System.Collections.Generic;

namespace PocChain
{
    public class PocChain
    {
        public List<PocBlock> Chain { get; set; }
        public uint Difficulty { get; set; }

        public PocChain()
        {
            Chain.Add(CreateGenesisBlock());
            Difficulty = 4;
        }

        private PocBlock CreateGenesisBlock()
        {
            return new PocBlock(0, "Genisis Block", new char[0]);
        }

        public PocBlock GetLatestBlock()
        {
            return Chain[Chain.Count-1];
        }

        public void AddBlock(PocBlock newBlock)
        {
            newBlock.PreviousHash = GetLatestBlock().Hash;
            newBlock.MineBlock(Difficulty);
            Chain.Add(newBlock);
        }

        public bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                var currentBlock = Chain[i];
                var previousBlock = Chain[i - 1];

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
