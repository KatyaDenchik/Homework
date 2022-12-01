#pragma once
#include <string>
#include "Client.h"
#include <ctime>
#include "Car.h"

using namespace std;

class SalesInformation
{
public:
	int contractNumber;
	Client* client;
	Car* car;
	tm data;
	double discount;
	string formOfPayment;

	SalesInformation(int contractNumber,
				 	Client* client,
					Car* car,
					tm data,
					double discount,
					string formOfPayment)
	{
		this->contractNumber = contractNumber;
		this->client = client;
		this->car = car;
		this->data = data;
		this->discount = discount;
		this->formOfPayment = formOfPayment;
	}
};

