#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;


class MyClass
{
public:
	int* Data;
public:
	int Size;

public:
	MyClass(int size)
	{
		this->Size = size;
		this->Data = new int[size];

	}

public:
	MyClass()
	{

	}

public:
	MyClass(const MyClass& other)
	{
		this->Size = other.Size;
		this->Data = new int[other.Size];
	}

};



