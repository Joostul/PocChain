using System;
using System.Security.Cryptography;
using System.Text;

namespace PocChain
{
    public class PocBlock
    {
        public long Index { get; }
        public DateTime TimeStamp { get; }
        public object Data { get; }
        public int Nonce { get; private set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }

        public PocBlock(long index, object data, string previousHash)
        {
            Index = index;
            TimeStamp = DateTime.UtcNow;
            Data = data;
            PreviousHash = previousHash;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            var hashString = new SHA256Managed();
            var input = Encoding.ASCII.GetBytes(Index + TimeStamp.ToString() + Data + PreviousHash + Nonce.ToString());
            var result = hashString.ComputeHash(input);
            return result.ToString();
        }

        public void MineBlock(int difficulty)
        {
            var difficultyList = new char[difficulty + 1];
            for (int i = 0; i < difficulty + 1; i++)
            {
                difficultyList[i] = '0';
            }

            while(Hash.Substring(0, difficulty).ToCharArray() != difficultyList)
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
}
