using System;
using System.Collections.Generic;

namespace ToyStore.DataGenerator
{
    public class RNG
    {
        private const string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static readonly RNG rng = new RNG();
        
        private Random rand;

        private RNG()
        {
            this.rand = new Random();
        }

        public static RNG GetInstance()
        {
            return rng;
        }

        public int GenerateNumber(int min, int max)
        {
            return rand.Next(min, max + 1);
        }

        public string GenerateString(int min, int max)
        {
            int len = GenerateNumber(min, max);
            var randomString = new char[len];

            for (int i = 0; i < len; i++)
            {
                randomString[i] = alpha[GenerateNumber(0, alpha.Length - 1)];
            }

            return new String(randomString);
        }
    }
}
