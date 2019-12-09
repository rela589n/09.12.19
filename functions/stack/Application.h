#pragma once
#include <iostream>
#include "StackContainer.cpp"

using namespace std;

class Application
{
private:
	StackContainer<int> setContainer;

	void interactive()
	{
		printMenu();
		int choise;
		cin >> choise;
		
		switch (choise) {
		case 1:
			put();
			break;
		case 2:
			pop();
			break;
		case 3:
			emptyCheck();
			break;
		case 4:
			printSize();
			break;
		case 5:
			return;
		default:
			cout << "Wrong input! retry!\n";
		}

		interactive();
	}

	void printSize()
	{
		cout << "Stack size: " << this->setContainer.size() << endl;
	}
	
	void emptyCheck() 
	{
		if (this->setContainer.empty()) {
			cout << "Container is empty!\n";
		}
		else {
			cout << "Container is not empty\n";
		}	
	}

	void printMenu()
	{
		cout << "  Menu:\n";
		cout << "1 - push element\n";
		cout << "2 - pop element\n";
		cout << "3 - check for emptiness\n";
		cout << "4 - print stack size\n";
		cout << "5 - exit\n";
	}

	void input()
	{
		cout << "Enter element's count: ";
		int n;
		cin >> n;

		cout << "Enter " << n << " element's:\n";
		for (int i = 0; i < n; ++i) {
			int num;
			cin >> num;

			setContainer.push(num);
		}
	}

	void pop() 
	{
		if (this->setContainer.empty()) {
			cout << "Stack is already empty!\n";
			return;
		}
		cout << "Removed element: " << this->setContainer.pop() << endl;
	}

	void put()
	{
		int el;
		cout << "Eter element to put: ";
		cin >> el;
		this->setContainer.push(el);
	}

public:

	void run()
	{
		input();
		interactive();
	}
};