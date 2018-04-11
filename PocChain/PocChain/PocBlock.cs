using System;
using System.Security.Cryptography;
using System.Text;

namespace PocChain
{
    public class PocBlock
    {
        private long Index { get; set; }
        private DateTime TimeStamp { get; set; }
        private object Data { get; set; }
        private string PreviousHash { get; set; }
        private string Hash { get; set; }

        public PocBlock(long index, DateTime timeStamp, object data, string previousHash)
        {
            Index = index;
            TimeStamp = timeStamp;
            Data = data;
            PreviousHash = previousHash;
            Hash = CalculateHash();
        }

        private string CalculateHash()
        {
            var hashString = new SHA256Managed();
            var input = Encoding.ASCII.GetBytes(Index + TimeStamp.ToString() + Data + PreviousHash);
            var result = hashString.ComputeHash(input);
            return result.ToString();
        }
    }
}
