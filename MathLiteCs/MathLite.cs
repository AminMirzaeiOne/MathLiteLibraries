using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLiteCs
{
    public static class MathLite
    {
        public static int Max(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new System.ArgumentException("Array cannot be null or empty.");
            }

            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        public static int Min(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new System.ArgumentException("Array cannot be null or empty.");
            }

            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;

        }
    }
}
