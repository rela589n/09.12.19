#include "StackContainer.h"

template <class L>
StackContainer<L>::StackContainer()
{
	head = nullptr;
	stackSize = 0;
}

template <class L>
StackContainer<L>::~StackContainer()
{
	clear();
}

template<class L>
void StackContainer<L>::push(L data)
{
	head = new Node<L>(data, head);
	++stackSize;
}

template<class L>
L StackContainer<L>::pop()
{
	Node<L>* tmp = head;
	
	head = head->next;
	L ans = tmp->data;
	
	delete tmp;
	--stackSize;
	
	return ans;
}
template <class L>
void StackContainer<L>::clear() {
	while (stackSize) {
		pop();
	}
}

template<class L>
bool StackContainer<L>::empty()
{
	return !stackSize;
}

template<class L>
L& StackContainer<L>::top()
{
	return head->data;
}

template<class L>
size_t StackContainer<L>::size()
{
	return stackSize;
}
