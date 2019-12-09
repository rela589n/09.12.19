#pragma once

template <class L>
class StackContainer
{
public:
	StackContainer();
	~StackContainer();

	void push(L data);
	L pop();
	void clear();
	bool empty();
	L& top();

	size_t size();

private:
	template <class T>
	class Node {
	public:
		T data;
		Node* next;

		Node(T data = T(), Node* next = nullptr) {
			this->data = data;
			this->next = next;
		};
	};

	Node<L>* head;
	size_t stackSize;

};
