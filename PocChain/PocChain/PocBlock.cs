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
        public uint Nonce { get; private set; }
        public char[] PreviousHash { get; set; }
        public char[] Hash { get; set; }

        public PocBlock(long index, object data, char[] previousHash)
        {
            Index = index;
            TimeStamp = DateTime.UtcNow;
            Data = data;
            PreviousHash = previousHash;
            Hash = CalculateHash();
        }

        public char[] CalculateHash()
        {
            var hashString = new SHA256Managed();
            var input = Encoding.UTF8.GetBytes(Index + TimeStamp.ToString() + Data + PreviousHash + Nonce.ToString());
            var result = hashString.ComputeHash(input);
            return Encoding.UTF8.GetString(result).ToCharArray();
        }

        public void MineBlock(uint difficulty)
        {
            var difficultyList = new char[difficulty];
            for (int i = 0; i < difficulty; i++)
            {
                difficultyList[i] = '0';
            }

            while(Hash.GetValue(0, (int)difficulty) != difficultyList)
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
}
