#pragma once
#include<Windows.h>
#include <string>
#include <iostream>
#include "Time.h"
#define _CRT_SECURE_NO_DEPRECATE
#pragma warning(disable:4996)

using namespace std;

class TrainTimetable : public Time
{
public:
	int numberTrain;
	string trainDirection;
	
	TrainTimetable(int numberTrain, string trainDirection, int hours, int minutes, int seconds): Time(hours, minutes, seconds)
	{
		this->numberTrain = numberTrain;
		this->trainDirection = trainDirection;
	}

	int GetNumberOfMinutesBeforeDeparture() 
	{
		time_t rawtime;
		struct tm* info;
		time(&rawtime);
		tm* ltm = localtime(&rawtime);
		int totalMinutes = hours * 60 + minutes;
		return totalMinutes - (ltm->tm_hour*60 + ltm->tm_min);
	}

	string ToString()
	{
		return "\n\nНомер поїзду: " + to_string(numberTrain)
			+ "\n\nНапрямок поїзду: " + trainDirection
			+ "\n\nЧас відправлення: " + this->Time::ToString();
			
	}
};

