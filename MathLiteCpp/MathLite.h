#include <iostream>
#include <climits>
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

		   int max(int* numbers, int size) {
			   if (numbers == nullptr || size == 0) {
				   throw std::invalid_argument("Array cannot be null or empty.");
			   }

			   int max_value = INT_MIN;
			   for (int i = 0; i < size; ++i) {
				   if (numbers[i] > max_value) {
					   max_value = numbers[i];
				   }
			   }
			   return max_value;
		   }



	};
}