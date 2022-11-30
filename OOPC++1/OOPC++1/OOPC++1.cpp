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
double ToDecimal(const MyClass&);

void ReadFromFile(std::string&, MyClass&);

ostream& operator << (ostream& os, MyClass& myClass)
{
	for (size_t i = 0; i < myClass.Size; i++)
	{
		os << myClass.Data[i] << endl;
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
	string pathToFile = "C:\\Users\\User\\Desktop\\Homework\\OOPC++1\\test.txt";

	string answer;
	cout << "Оберіть джерело інформації:" << endl;
	cout << "1: Консоль;" << endl;
	cout << "2: Файл." << endl;
	cin >> answer;

	if (answer == "1" || answer == "Консоль")
	{
		cout << "Вкажіть двоічне число:" << endl;
		cin >> myClass;
	}
	else if (answer == "2" || answer == "Файл")
	{

		cout << "Вкажіть шлях до файлу:" << endl;
		string pathToFile;
		cin >> pathToFile;
		ReadFromFile(pathToFile, myClass);
	}
	else
	{
		cout << "Невідома команда, спробуйте ще раз" << endl;
		main();
	}

	double value = ToDecimal(myClass);
	cout << "Десятичне число: " << value << endl;
}

void ReadFromFile(std::string& pathToFile, MyClass& myClass)
{
	fstream in(pathToFile);
	if (!in.is_open())
	{
		cout << "Не вдалось відкрити файл";
	}
	else
	{
		in >> myClass;
	}
}

double ToDecimal(const MyClass& myClass)
{
	long n = 0;
	long multiplier = 1, divisor = 1;
	for (size_t i = 0; i < myClass.Size; i++)
	{
		if (myClass.Data[i] == '.')
		{
			divisor = 1;
		}
		else
		{
			auto digit = int(myClass.Data[i] - '0');

			n = n * 2 + digit;
			divisor *= 2;
		}
	}

	double res = double(n) / double(divisor);
	return res;
}


