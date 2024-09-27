#include <iostream>
#include <climits>
#include <vector>
#include <stdexcept>
#pragma once

namespace MathLiteCpp {
	static  class  MathLite
	{
		enum RootMethod
		{
			Newton, Binary
		};

		enum PowerMethod
		{
			Loop, Returned
		};

	private: static double _xValues[];
	private: static double _tanhValues[];
	private: static double _step;

	public:

		static int Max(int* numbers, int size) {
			if (numbers == nullptr || size == 0) {
				throw std::invalid_argument("Array cannot be null or empty.");
			}

			int max_value = numbers[0];
			for (int i = 0; i < size; ++i) {
				if (numbers[i] > max_value) {
					max_value = numbers[i];
				}
			}
			return max_value;
		}

		static int Min(int* numbers, int size) {
			if (numbers == nullptr || size == 0) {
				throw std::invalid_argument("Array cannot be null or empty.");
			}

			int min_value = numbers[0];
			for (int i = 0; i < size; ++i) {
				if (numbers[i] < min_value) {
					min_value = numbers[i];
				}
			}
			return min_value;
		}



	};
}