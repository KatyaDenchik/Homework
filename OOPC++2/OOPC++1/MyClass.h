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
	int* FirstData;
public:
	int FirstDataSize;

public:
	int* SecondData;
public:
	int SecondDataSize;

public:
	MyClass(char firstDataSize, char secondDataSize)
	{
		this->FirstDataSize = firstDataSize;
		this->FirstData = new int[firstDataSize];
		this->SecondDataSize = secondDataSize;
		this->SecondData = new int[secondDataSize];
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
	void Print() 
	{
		int size = FirstDataSize + SecondDataSize;
		int* combinedData = new int[size];

		Sort(FirstData, FirstDataSize);
		Sort(SecondData, SecondDataSize);

		for (size_t i = 0; i < size; i++)
		{
			if (size <= FirstDataSize)
			{
				combinedData[i] = FirstData[i];
			}
			else
			{
				combinedData[i] = SecondData[i- FirstDataSize];
			}
		}
	}

	void Sort(int* x, int size, int dir = 1)
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



