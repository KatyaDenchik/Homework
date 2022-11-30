#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <list>

using namespace std;


class MyClass
{
public:
	double* FirstData;
public:
	int FirstDataSize;

public:
	double* SecondData;
public:
	int SecondDataSize;

public:
	MyClass(char firstDataSize, char secondDataSize)
	{
		this->FirstDataSize = firstDataSize;
		this->FirstData = new double[firstDataSize];
		this->SecondDataSize = secondDataSize;
		this->SecondData = new double[secondDataSize];
	}

public:
	MyClass()
	{

	}

public:
	MyClass(const MyClass& other)
	{
		this->FirstDataSize = other.FirstDataSize;
		this->FirstData = other.FirstData;
		this->SecondDataSize = other.SecondDataSize;
		this->SecondData = other.SecondData;
	}

public:
	double* GetCombinedData()
	{
		int size = FirstDataSize + SecondDataSize;
		double* combinedData = new double[size];

		Sort(FirstData, FirstDataSize);
		Sort(SecondData, SecondDataSize);

		for (size_t i = 0; i < size; i++)
		{
			if (i < FirstDataSize)
			{
				combinedData[i] = FirstData[i];
			}
			else
			{
				combinedData[i] = SecondData[i- FirstDataSize];
			}
		}
		return combinedData;
	}

	void Sort(double* x, int size, int dir = 1)
	{
		for (int i = 1; i < size; ++i)
			for (int j = size - 1; j >= i; --j)
				if (dir == 1 ? x[j - 1] < x[j] : x[j - 1] > x[j])
				{
					int tmp = x[j - 1];
					x[j - 1] = x[j];
					x[j] = tmp;
				}
	}
};



