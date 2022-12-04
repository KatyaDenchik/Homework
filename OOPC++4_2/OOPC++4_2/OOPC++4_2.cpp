
#include <Windows.h>
#include <iostream>
#include "Time.h"
#include "TrainTimetable.h"

using namespace std;

void Setup()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
}

int main()
{
	Setup();
	Time* Time1 = new Time(13, 20, 45);
	cout << Time1->ToString();
	TrainTimetable* trainTimetable = new TrainTimetable(3, "Êè¿â - Õàðê³â", 9, 45, 0);
	cout << trainTimetable->ToString();
}


