#include <Windows.h>
#include <iostream>
#include "MyClass.h"
#include <list>

using namespace std;

void Setup()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
}

ostream& operator << (ostream& os, MyClass& myClass)
{
    for (size_t i = 0; i < myClass.Size; i++)
    {
         os << myClass.Data[i]<< endl;
    }
    
    return os;
}
istream& operator >> (istream& in, MyClass& myClass)
{
    vector<int> temp; 
    int value;
    while ( in >> value && cin.get() != '\n')
    {
        temp.push_back(value);
    }

    MyClass newClass(temp.size());

    for (size_t i = 0; i < temp.size(); i++)
    {
        newClass.Data[i] = temp[i];
    }

    myClass = newClass;

    return in;
}

int main()
{
    Setup();
    MyClass myClass;

    cin >> myClass;
    cout << myClass;
}

