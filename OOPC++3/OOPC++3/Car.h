#pragma once
#include <string>

using namespace std;

class Car
{
public:
	int ID_car;
	string name_car;
	double price;
	int number;

	Car(int ID_car, string name_car, double price, int number) 
	{
		this->ID_car = ID_car;
		this->name_car = name_car;
		this->price = price;
		this->number = number;
	}
};


