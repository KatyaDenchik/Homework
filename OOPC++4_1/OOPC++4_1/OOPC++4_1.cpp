#include <Windows.h>
#include <iostream>
#include "Product.h"
#include"VitaminC.h"

void Setup()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
}

int main()
{
	Setup();
	Product* Chees = new Product(25, 500);
    cout << Chees->ToString();
	Lemon* lemon = new Lemon(2, 300, 500);
	cout << lemon->ToString();
}


