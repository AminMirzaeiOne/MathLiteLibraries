// TestMath.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include "/Projects/Solution/Libraries/MathLiteLibraries/MathLiteCpp/MathLite.h"
#include <iostream>

int main()
{
	std::cout << "Hello World!\n";
	int arr[] = { 3, 7, 2, 9, 0 };
	int size = sizeof(arr) / sizeof(arr[0]);
	std::cout << MathLiteCpp::MathLite::Min(arr,size) << std::endl;
	getchar();

}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
