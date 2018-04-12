using System;
using System.Security.Cryptography;
using System.Text;
using Scrypt;

namespace PocChain
{
    public class PocBlock
    {
        public long Index { get; }
        public DateTime TimeStamp { get; }
        public object Data { get; }
        public uint Nonce { get; private set; }
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
            var hasher = new SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(Index + TimeStamp.ToString() + Data + PreviousHash + Nonce.ToString());
            
            var hash = hasher.ComputeHash(bytes);
            string result = string.Empty;
            foreach (var b in hash)
            {
                result += String.Format("{0:x2}", b);
            }
            return result;
        }

        public void MineBlock(uint difficulty)
        {
            var difficultyList = new char[difficulty];
            for (int i = 0; i < difficulty; i++)
            {
                difficultyList[i] = '0';
            }

            while(Hash.Substring(0, (int)difficulty) != new string(difficultyList))
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
}
