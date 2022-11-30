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
	MyClass newClass(9, 7);
	double temp;
	int count = 0;
	while (in >> temp)
	{
		newClass.FirstData[count] = temp;

		count++;
		if (count == newClass.FirstDataSize)
		{
			count = 0;
			break;
		}
	}

	while (in >> temp)
	{
		newClass.SecondData[count] = temp;

		count++;
		if (count == newClass.SecondDataSize)
		{
			count = 0;
			break;
		}
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
		return;
	}
	MyClass newClass(9, 7);
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
		string digit;
		int count = 0;
		for (size_t j = 0; j <= lines[i].size(); j++)
		{
			auto letter = lines[i][j];
			if (letter == '.' || ('0' <= letter && letter <= '9'))
			{
				digit.push_back(letter);
			}
			else
			{
				try
				{
					double temp = stod(digit);
					if (i == 0)
					{
						newClass.FirstData[count] = temp;
						count++;
					}
					else
					{
						newClass.SecondData[count] = temp;
						count++;
					}
				}
				catch (const std::exception&)
				{

				}
				digit = "";
			}
		}
		count = 0;
	}

	myClass = newClass;
}

