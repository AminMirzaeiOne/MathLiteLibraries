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

        public enum PowerMethod
        {
            Loop, Returned
        }

        private static double[] _xValues;
        private static double[] _tanhValues;
        private static double _step;


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

        public static short Abs(short value)
        {
            return System.Convert.ToInt16(value < 0 ? -value : value);
        }

        public static int Abs(int value)
        {
            return value < 0 ? -value : value;
        }

        public static long Abs(long value)
        {
            return value < 0 ? -value : value;
        }

        public static decimal Abs(decimal value)
        {
            return value < 0 ? -value : value;
        }

        public static float Abs(float value)
        {
            return value < 0 ? -value : value;
        }

        public static double Abs(double value)
        {
            return value < 0 ? -value : value;
        }

        public static sbyte Abs(sbyte value)
        {
            return System.Convert.ToSByte(value < 0 ? -value : value);
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

        public static double Pow(double baseNumber, double exponent)
        {
            double result = 1.0;
            if (exponent >= 0)
            {
                for (int i = 0; i < exponent; i++)
                {
                    result *= baseNumber;
                }
            }
            else
            {
                for (int i = 0; i > exponent; i--)
                {
                    result /= baseNumber;
                }
            }
            return result;
        }

        public static double Pow(double baseNumber, double exponent, MathLiteCs.MathLite.PowerMethod method)
        {
            double get = 0;
            if (method == PowerMethod.Loop)
            {
                get = MathLiteCs.MathLite.Pow(baseNumber, exponent);
            }
            else
            {
                if (exponent == 0)
                {
                    get = 1.0;
                }
                if (exponent < 0)
                {
                    get = 1.0 / MathLite.Pow(baseNumber, -exponent);
                }
                if (exponent % 2 == 0)
                {
                    double temp = MathLite.Pow(baseNumber, exponent / 2);
                    get = temp * temp;
                }
                else
                {
                    get = baseNumber * MathLite.Pow(baseNumber, exponent - 1);
                }
            }
            return get;
        }

        public static double Cos(double x)
        {
            
            double result = 1.0;
            double term = 1.0;
            int sign = -1;
            for (int i = 2; MathLite.Abs(term) > 1e-10; i += 2)
            {
                term *= sign * x * x / (i * (i - 1));
                sign = -sign;
                result += term;
            }
            return result;
        }

        public static double Sin(double x)
        {
            
            double result = x;
            double term = x;
            int sign = -1;
            for (int i = 3; MathLite.Abs(term) > 1e-10; i += 2)
            {
                term *= -x * x / ((i - 1) * i);
                result += term;
                sign *= -1;
            }
            return result;
        }

        public static double Acos(double x)
        {
            if (x < -1 || x > 1)
                throw new System.ArgumentOutOfRangeException("x must be between -1 and 1");

            double result = MathLiteCs.Constants.PI / 2 - 2 * MathLite.Atan(x / (1 + MathLite.Sqrt(1 - x * x)));
            return result;
        }

        public static double Atan(double x)
        {
            double result = x;
            double term = x;
            int sign = -1;
            for (int i = 3; MathLite.Abs(term) > 1e-10; i += 2)
            {
                term *= -x * x / (i - 1) * i;
                result += term;
                sign *= -1;
            }
            return result;
        }

        public static double Asin(double x)
        {
            
            if (x < -1 || x > 1)
                throw new System.ArgumentOutOfRangeException("x must be between -1 and 1");

            double result = 2 * MathLite.Atan(x / (1 + MathLite.Sqrt(1 - x * x)));
            return result;
        }

        public static double Cosh(double x)
        {
            return (MathLite.Exp(x) + MathLite.Exp(-x)) / 2;
        }

        public static double Exp(double x)
        {
            double result = 1.0;
            double term = 1.0;
            for (int i = 1; MathLite.Abs(term) > 1e-10; i++)
            {
                term *= x / i;
                result += term;
            }
            return result;
            
        }

        public static long BigMul(int a, int b)
        {
            long result = 0;
            int multiplier = 1;

            while (b != 0)
            {
                int lastDigit = b % 10;
                result += a * lastDigit * multiplier;
                b /= 10;
                multiplier *= 10;
            }
            
            return result;
        }

        public static double MyAtan2(double y, double x)
        {
            if (x == 0)
            {
                if (y > 0) return MathLiteCs.Constants.PI / 2;
                if (y < 0) return -MathLiteCs.Constants.PI / 2;
                return double.NaN;
            }

            double theta = MathLite.Atan(y / x);
            if (x < 0)
            {
                theta += MathLiteCs.Constants.PI;
            }
            else if (y < 0 && x > 0)
            {
                theta += 2 * MathLiteCs.Constants.PI;
            }
            
            return theta;
        }

        public static int Sign(int number)
        {
            if (number > 0)
            {
                return 1;
            }
            else if (number < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static double Tan(double angle)
        {
            return MathLite.Sin(angle) / MathLite.Cos(angle);
        }

        public static double Tanh(double x)
        {
            double exp_x = MathLite.Exp(x);
            double exp_neg_x = MathLite.Exp(-x);
            return (exp_x - exp_neg_x) / (exp_x + exp_neg_x);
        }


        public static double Tanh(double x, int terms)
        {
            double result = 0;
            double term = x;
            int sign = 1;
            for (int i = 1; i <= terms; i++)
            {
                result += term;
                sign *= -1;
                term *= x * x * (2 * i - 1) / (2 * i + 1);
            }
            return result;
        }

        public static void TanhLookupTable(double minX, double maxX, int numPoints)
        {
            MathLite._step = (maxX - minX) / (numPoints - 1);
            MathLite._xValues = new double[numPoints];
            MathLite._tanhValues = new double[numPoints];

            for (int i = 0; i < numPoints; i++)
            {
                _xValues[i] = minX + i * _step;
                _tanhValues[i] = MathLite.Tanh(_xValues[i]);
            }
        }

        public static double GetTanh(double x)
        {
            if (x < _xValues[0]) return MathLite.Tanh(x);
            if (x > _xValues[_xValues.Length - 1]) return MathLite.Tanh(x);

            int index = (int)((x - _xValues[0]) / _step);
            double t = (x - _xValues[index]) / _step;

            return (1 - t) * _tanhValues[index] + t * _tanhValues[index + 1];
        }




    }
}
