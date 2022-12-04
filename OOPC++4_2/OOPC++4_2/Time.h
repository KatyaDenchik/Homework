#pragma once
#include<Windows.h>
#include <string>
#include <iostream>

using namespace std;

class Time
{
public:
	int hours;
	int minutes;
	int seconds;

	Time(int hours, int minutes, int seconds)
	{
		this->hours = hours;
		this->minutes = minutes;
		this->seconds = seconds;
	}

	Time() : Time(0,0,0)
	{
		
	}

	~Time()
	{
		cout << "Об'єкт 'Time' знищено\n";
	}

	int GetSeconds() 
	{
		return seconds + (minutes * 60) + (hours * 3600);
	}

	void IncreaseeTime()
	{
		int temp = (seconds + 5)%60;
		if (temp > 0)
		{
			seconds = temp;
			minutes++;
		}
	}

	string ToString()
	{
		return "\n\nГодини: " + to_string(hours)
			+ "\nХвилини: " + to_string(minutes)
			+ "\nСекунди: " + to_string(seconds);
	}
};

