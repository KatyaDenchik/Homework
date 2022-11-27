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
    string value;
    in >> value;

    MyClass newClass(value.size());

    for (size_t i = 0; i < value.size(); i++)
    {
        newClass.Data[i] = value[i];
    }

    myClass = newClass;

    return in;
}

int main()
{
    Setup();
    MyClass myClass;

    cout << "Введите двоичное число: ";
    cin >> myClass;

    long n = 0;
    long multiplier = 1, divisor = 1; 
    for (size_t i = 0; i < myClass.Size; i++)
    {
        if (myClass.Data[i] == '.')
        {
            divisor = multiplier;
        }
        else
        {
            n += (myClass.Data[i] - '0') * multiplier;
            multiplier *= 2;
        }
    }

    double res = double(n) / double(divisor);

    cout << "Десятичное число: " << res << endl;


    cout << endl;
    system("pause");
}

