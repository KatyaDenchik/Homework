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

void ReadFromFile(std::string&, MyClass&);

ostream& operator << (ostream& os, MyClass& myClass)
{
	auto combinedData = myClass.GetCombinedData();

	int size = myClass.FirstDataSize + myClass.SecondDataSize;

	for (size_t i = 0; i < size; i++)
	{
		double data = combinedData[i];
		os << data << "\n";
	}
	return os;
}
istream& operator >> (istream& in, MyClass& myClass)
{
	MyClass newClass(7,9);
	int count = 0;
	string line;
	vector<string> lines;

	while (getline(in, line))
	{
		lines.push_back(line);
		count++;

		if (count == 2)
		{
			break;
		}
	}

	for (size_t i = 0; i < 2; i++)
	{
		double temp;
		for (auto letter: lines[i])
		{
			try
			{

			}
			catch (const std::exception&)
			{

			}
		}
		
	}
	for (size_t i = 0; i < newClass.FirstDataSize; i++)
	{
		
			//newClass.FirstData[i];
	}

	for (size_t i = 0; i < newClass.SecondDataSize; i++)
	{
		in >> newClass.SecondData[i];
	}

	myClass = newClass;
	return in;
}

int main()
{
	Setup();
	MyClass myClass;

	string answer;
	cout << "Оберіть джерело інформації:" << endl;
	cout << "1: Консоль;" << endl;
	cout << "2: Файл." << endl;
	cin >> answer;

	if (answer == "1" || answer == "Консоль")
	{
		cout << "Введіть массиви:" << endl;
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
	cout << myClass;
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

