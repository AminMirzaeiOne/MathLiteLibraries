using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MathLiteCs
{
    public static class MathLite
    {
        public enum RootMethod
        {
            Newton, Binary
        }
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

        public static double Sqrt(double x)
        {
            if (x < 0)
            {
                throw new System.ArgumentException("Cannot calculate square root of a negative number.");
            }

            double y = x / 2;
            double epsilon = 1e-15;

            while (MathLite.Abs(y * y - x) > epsilon)
            {
                y = (y + x / y) / 2;
            }

            return y;
        }

        public static double Sqrt(double x, MathLiteCs.MathLite.RootMethod method)
        {
            double get = 0;
            if (method == RootMethod.Newton)
            {
                get = MathLiteCs.MathLite.Sqrt(x);
            }
            else
            {
                if (x < 0)
                {
                    throw new System.ArgumentException("Cannot calculate square root of a negative number.");
                }

                double left = 0, right = x;
                double epsilon = 1e-15;

                while (right - left > epsilon)
                {
                    double mid = (left + right) / 2;
                    if (mid * mid > x)
                    {
                        right = mid;
                    }
                    else
                    {
                        left = mid;
                    }
                }

                get = left;

            }

            return get;

        }

        public static double Root(double number, double n)
        {
            if (number < 0 && n % 2 == 0)
            {
                throw new System.ArgumentException("Cannot calculate even root of a negative number.");
            }

            return Math.Pow(number, 1.0 / n);
        }


        public static double Abs(double value)
        {
            return value < 0 ? -value : value;
        }

        public static long Round(double value)
        {
            ulong signMask = 0x8000000000000000;

            int sign = (int)((ulong)value & signMask) >> 63;

            int integral = (int)value;
            double fractional = value - integral;
            if (fractional >= 0.5)
            {
                integral += 1;
            }
            return integral - sign;
        }

        public static long Ceiling(double value)
        {
            long integralPart = (long)value;
            double fractionalPart = value - integralPart;

            if (fractionalPart > 0)
            {
                return integralPart + 1;
            }
            else
            {
                return integralPart;
            }
        }

        public static long Floor(double value)
        {
            if (value >= 0)
            {
                return (long)value;
            }
            else
            {
                return (long)value - 1;
            }
        }
    }
}
