#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;


class MyClass
{
public:
	char* Data;
public:
	int Size;

public:
	MyClass(char size)
	{
		this->Size = size;
		this->Data = new char[size];

	}

public:
	MyClass()
	{

	}

public:
	MyClass(const MyClass& other)
	{
		this->Size = other.Size;
		this->Data = new char[other.Size];
	}

};



