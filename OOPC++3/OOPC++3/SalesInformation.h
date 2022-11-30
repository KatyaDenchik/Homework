#pragma once
#include <string>
#include "Client.h"
#include "Car.h"
#include <ctime>

using namespace std;

class SalesInformation
{
public:
	int contractNumber;
	Client client;
	Car car;
	tm data;
	double discount;
	string formOfPayment;
};

