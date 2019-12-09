#pragma once
#include <list>
#include <vector>
#include <algorithm>

using namespace std;

template<class T>
class Sort
{
private:

	template<class Functor>
	static T& getMax(list<T>& arr, Functor f)
	{
		return *max_element(arr.begin(), arr.end(), [&](T const& first, T const& second) {
			return f(first) < f(second);
		});
	}

	static const int digitSize = 10;

	template<class Functor>
	static void countSortByDigit(list<T>& arr, int digit, Functor f) 
	{
		vector<T> ans = vector<T>(arr.size());

		int count[digitSize] = { 0 };

		for (auto& el : arr) {
			++count[(f(el) / digit) % digitSize];
		}

		for (int i = 1; i < digitSize; ++i) {
			count[i] += count[i - 1];
		}

		for (auto it = arr.rbegin(); it != arr.rend(); ++it) {
			auto el = *it;
			int inx = (f(el) / digit) % digitSize;

			ans[count[inx] - 1] = el;
			--count[inx];
		}

		arr.assign(ans.begin(), ans.end());
	}

public:

	template<class Functor>
	static void radixSort(list<T>& arr, Functor f)
	{
		T m = getMax(arr, f);

		for (int digit = 1; f(m) / digit > 0; digit *= digitSize) {
			countSortByDigit(arr, digit, f);
		}
	}
};
