#pragma once
#include <iostream>
#include "Sort.h"

using namespace std;

class Application
{
private:
	list<int> arr;
	list< pair<string, int> > arr2;

	void init()
	{
		arr = { 2401, 935, 7, 49, 8615, 911 };
		arr2 = {
			{"Clean Code", 2009},
			{"Python Crash Course", 2010},
			{"Code", 2019},
			{"Learning Python", 2029},
			{"The Pragmatic Programmer", 2000},
			{"The Hidden Language of Computer Hardware and Software", 2008},
			{"Programming Pearls", 1999},
			{"The C Programming Language", 1800},
			{"The Mythical Man-Month", 2020},
		};
		//arr = { 802, 630, 20, 745, 52, 300, 612, 932, 78, 187 };
	}

	void printArr()
	{
		cout << "First array:\n";
		for (auto el : arr) {
			cout << el << endl;
		}
	}

	void printArr2() {
		cout << "Second array:\n";
		for (auto el : arr2) {
			cout << el.first << " : " << el.second << endl;
		}
	}

public:

	void run()
	{	
		init();
		Sort<int>::radixSort(arr, [](const int& el) { return el; });
		Sort< pair<string, int> >::radixSort(
			arr2,
			[](const pair<string, int>& el) { 
				return el.second; 
			}
		);

		printArr();
		cout << endl;
		printArr2();
	}
};