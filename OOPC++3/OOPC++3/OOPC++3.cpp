#pragma once
#include <Windows.h>
#include <iostream>
#include <fstream>
#include <vector>
#include "Car.h"
#include "OOPC++3.h"
#include "SalesInformation.h"
#include <chrono>
#include <ctime>  
#define _CRT_SECURE_NO_DEPRECATE
#pragma warning(disable:4996)

using namespace std;

void IncreasePrice(vector<SalesInformation*>);
void CleanExpensiveCars(vector<SalesInformation*>);
void PrintCars(vector<SalesInformation*>);
void PrintSoldCar(vector<SalesInformation*>);

void Setup()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
}

ostream& operator << (ostream& os, Car& car)
{
	os << "ІД машини: " << car.ID_car << endl
		<< "Назва машини: " << car.name_car << endl
		<< "Ціна машини: " << car.price << endl
		<< "Кількість машини: " << car.number << endl;

	return os;
}

istream& operator >> (istream& in, Car& car)
{
	in >> car.ID_car >> car.name_car >> car.price >> car.number;
	return in;
}

ostream& operator << (ostream& os, SalesInformation& info)
{
	os  << "Номер контракту: " << info.contractNumber << endl
		<< "Дата продажу: " << info.data.tm_mday <<"." << info.data.tm_mon << "." << info.data.tm_year << endl
		<< "Знижка: " << info.discount << endl
		<< "Спосіб оплати: " << info.formOfPayment << endl
		<< "Інформація про машину машину: " << endl << *info.car << endl;

	return os;
}

istream& operator >> (istream& in, SalesInformation& info)
{
	in >> info.contractNumber >> info.data.tm_mday>> info.data.tm_mon >> info.data.tm_year >> info.discount >> info.formOfPayment >> *info.car;
	return in;
}


bool operator == (const Car& car1, const Car& car2)
{
	return car1.ID_car == car2.ID_car;
}

int main()
{
	Setup();
	auto BMW = new Car(1, "BMW", 150000, 15);
	auto BMWsaleTime = new tm();
	BMWsaleTime->tm_mday = 15;
	BMWsaleTime->tm_mon = 9;
	BMWsaleTime->tm_year = 2022;

	auto Tesla = new Car(2, "Tesla", 300000, 25);
	auto TeslSsaleTime = new tm();
	TeslSsaleTime->tm_mday = 22;
	TeslSsaleTime->tm_mon = 11;
	TeslSsaleTime->tm_year = 2022;

	auto Ford = new Car(3, "Ford", 200000, 25);
	auto FordsaleTime = new tm();
	FordsaleTime->tm_mday = 1;
	FordsaleTime->tm_mon = 12;
	FordsaleTime->tm_year = 2022;

	vector<SalesInformation*> SalesInformations
	{
		new SalesInformation(21, new Client(), BMW, *BMWsaleTime, 10, "налл"),
		new SalesInformation(22, new Client(), Tesla, *FordsaleTime, 10, "карта"),
		new SalesInformation(23, new Client(), Ford, *BMWsaleTime, 10, "натура")
	};

	PrintCars(SalesInformations);
	IncreasePrice(SalesInformations);
	CleanExpensiveCars(SalesInformations);
	PrintSoldCar(SalesInformations);

}

void PrintSoldCar(vector<SalesInformation*> SalesInformations)
{
	time_t rawtime;
	struct tm* info;
	time(&rawtime);
	tm* ltm = localtime(&rawtime);

	cout << "Машини, які були продані за останній місяць:" << endl << endl;
	for (auto SalesInformation : SalesInformations)
	{
		if ((SalesInformation->data.tm_mon - ltm->tm_mon)<1)
		{
			cout << *SalesInformation->car << endl;
		}
	}
}

void CleanExpensiveCars(vector<SalesInformation*> SalesInformations)
{
	for (auto SalesInformation : SalesInformations)
	{
		if (SalesInformation->car->price > 200000)
		{
			auto index = find(SalesInformations.begin(), SalesInformations.end(), SalesInformation);
			SalesInformations.erase(index);
		}
	}
	PrintCars(SalesInformations);

}

void IncreasePrice(vector<SalesInformation*> SalesInformations)
{
	string answer;
	int IDAnswer;
	cout << "Введіть ІД машини для збільшення ціни вдвічі: \n";
	cin >> answer;
	try
	{
		IDAnswer = atoi(answer.c_str());
	}
	catch (const std::exception&)
	{
		cout << "Введіть числом ІД машини";
		IncreasePrice(SalesInformations);
	}

	SalesInformation* foundCar = nullptr;
	for (auto SalesInformation : SalesInformations)
	{
		if (IDAnswer == SalesInformation->car->ID_car)
		{
			foundCar = SalesInformation;
			foundCar->car->price *= 2;

			cout << "Оновлена інформація" << endl << *SalesInformation->car << endl;
		}
	}
	if (foundCar == nullptr)
	{
		cout << "Введіть коректний ІД машини" << endl;
		IncreasePrice(SalesInformations);
	}

}

void PrintCars(vector<SalesInformation*> info)
{
	for (auto item : info)
	{
		cout << *item->car << endl;
	}
}


