using System;
using System.Security.Cryptography;
using System.Text;

namespace PocChain
{
    public class PocBlock
    {
        internal long Index { get; }
        internal DateTime TimeStamp { get; }
        internal object Data { get; }
        internal string PreviousHash { get; set; }
        internal string Hash { get; set; }

        public PocBlock(long index, object data, string previousHash)
        {
            Index = index;
            TimeStamp = DateTime.UtcNow;
            Data = data;
            PreviousHash = previousHash;
            Hash = CalculateHash();
        }

        internal string CalculateHash()
        {
            var hashString = new SHA256Managed();
            var input = Encoding.ASCII.GetBytes(Index + TimeStamp.ToString() + Data + PreviousHash);
            var result = hashString.ComputeHash(input);
            return result.ToString();
        }
    }
}
