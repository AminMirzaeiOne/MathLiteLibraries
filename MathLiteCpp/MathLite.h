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


	};
}