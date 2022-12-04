#pragma once
#include<Windows.h>
#include <string>
#include "Product.h"
using namespace std;

class Lemon : public Product
{
public:
	int VitaminCPerGram;

	Lemon(int vitaminCPerGram, int caloriesPer100Grams, int weight) : Product (caloriesPer100Grams, weight)
	{
		this->VitaminCPerGram = vitaminCPerGram;
	}

	string ToString()
	{
		return this->Product::ToString()+"\nКількість вітаміна С в продукті: " + to_string(VitaminCPerGram);
	}

	int VitaminCPerProduct()
	{
		return VitaminCPerGram * Weight;
	}
};

