#include <list>
#include <iostream>
#include <iterator>
#include <Windows.h>

using namespace std;

void Setup()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
}

template<typename T>
bool operator==(const T a, const T b) 
{
	return a == b;
}

template<typename T>
bool operator!=(const T a, const T b)
{
	return a != b;
}
template<typename T>
ostream& operator << (ostream& os, T& a) {
	return os << a;
}

template<typename T>
class Node
{
public:
	T data;
	Node* next;
	Node* prev;
	Node(T val) : data(val), next(nullptr), prev(nullptr) {}
	Node() : data(nullptr), next(nullptr), prev(nullptr) {}

	
};

template<typename T>
class DoublyLinkedList
{

public:
	Node<T>* head, * tail;
	DoublyLinkedList() : head(nullptr), tail(nullptr) {}

	~DoublyLinkedList()
	{
		Node<T>* tmp = nullptr;
		while (head)
		{
			tmp = head;
			head = head->next;
			delete tmp;
		}
		head = nullptr;
	}

	DoublyLinkedList(const DoublyLinkedList<T>& dll) = delete;
	DoublyLinkedList& operator=(DoublyLinkedList const&) = delete;

	void insertFront(T val)
	{
		Node<T>* node = new Node<T>(val);
		Node<T>* tmp = head;
		if (head == nullptr)
		{
			head = node;
			tail = node;
		}
		else
		{
			node->next = head;
			head = node;
			node->next->prev = node;
		}
	}

	void insertBack(T val)
	{
		Node<T>* node = new Node<T>(val);
		if (tail == nullptr)
		{
			head = node;
			tail = node;
		}
		if (tail->next == nullptr)
		{
			tail->next = node;
		}
	}


	void deleteVal(T val)
	{
		Node<T>* find = findVal(val);
		Node<T>* tmp = head;

		if (tmp == find)
		{
			head = tmp->next;
		}
		else
		{
			while (find != nullptr)
			{
				if (tmp->next == find)
				{
					tmp->next = find->next;
					find->next->prev = tmp;
					delete find;
					return;
				}
				tmp = tmp->next;
			}
		}
	}

	template <class U>
	friend std::ostream& operator<<(std::ostream& os, const DoublyLinkedList<U>& dll) {
		dll.display(os);
		return os;
	}

private:

	Node<T>* findVal(T n) 
	{
		Node<T>* node = head;
		while (node != nullptr)
		{
			if (node->data == n)
				return node;

			node = node->next;
		}
		return NULL;
	}

	void display(std::ostream& out = std::cout) const
	{
		Node<T>* node = head;
		while (node != nullptr)
		{
			out << node->data << " ";
			node = node->next;
		}
	}
};

class Carriage
{
public:
	int numberOfPleases;
	Carriage(int numberOfPleases)
	{
		this->numberOfPleases = numberOfPleases;
	};
};

class Train
{
public:
	DoublyLinkedList<Carriage> Carriages;

	void Add_carriage(Carriage carriage)
	{
		Carriages.insertFront(carriage);
	}
	void Del_carriage(Carriage carriage)
	{
		Carriages.deleteVal(carriage);
	}
	int Calc_places()
	{
		int sumAllPleases =0;
		Carriage current(0);

		for (auto node = Carriages.head; node != NULL; node = node->next)
		{
			sumAllPleases += node->data.numberOfPleases;
		}
		return sumAllPleases;
	}

};

int main()
{
	Setup();
	Train train;
	train.Add_carriage(Carriage(15));
	train.Add_carriage(Carriage(10));
	train.Add_carriage(Carriage(1));
	cout << train.Calc_places() << endl;
	

}

