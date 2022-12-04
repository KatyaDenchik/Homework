#pragma once
#include<Windows.h>
#include <string>

using namespace std;

class Product
{
public:
	int CaloriesPer100Grams;
	int Weight;

	Product(int caloriesPer100Grams, int weight)
	{
		this->CaloriesPer100Grams = caloriesPer100Grams;
		this->Weight = weight;
	}

	int GetTotalCalories()
	{
		return (CaloriesPer100Grams * Weight) / 100;
	}

	string ToString()
	{
		return "\n\n���������� 100� ��������: " + to_string(CaloriesPer100Grams)
			 + "\n���� �������� � ������: " + to_string(Weight)
			 + "\n���������� ��������: " + to_string(GetTotalCalories());
	}
};

