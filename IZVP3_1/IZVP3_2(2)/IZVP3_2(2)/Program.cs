using System;

//2x + 3y = 7
//x - y = 3
var solution2x2 = Solver.SolveTwoLinearEquations(2, 3, 7, 1, -1, 3);
Console.WriteLine("x: " + solution2x2.Item1);
Console.WriteLine("y: " + solution2x2.Item2);

//2x + 3y + z = 7
//x - y + z = 3
//3x + 2y - z = 5
var solution3x3 = Solver.SolveThreeLinearEquations(2, 3, 1, 7, 1, -1, 1, 3, 3, 2, -1, 5);
Console.WriteLine("x: " + solution3x3.Item1);
Console.WriteLine("y: " + solution3x3.Item2);
Console.WriteLine("z: " + solution3x3.Item3);

Console.ReadLine();

public class Solver
{

    public static (double, double) SolveTwoLinearEquations(double a1, double b1, double c1, double a2, double b2, double c2)
    {
        double determinant = a1 * b2 - a2 * b1;
        if (determinant == 0)
        {
            throw new Exception("The system has no unique solution.");
        }
        double x = (c1 * b2 - c2 * b1) / determinant;
        double y = (a1 * c2 - a2 * c1) / determinant;
        return (x, y);
    }


    public static (double, double, double) SolveThreeLinearEquations(double a1, double b1, double c1, double d1, double a2, double b2, double c2, double d2, double a3, double b3, double c3, double d3)
    {
        double determinant = a1 * (b2 * c3 - b3 * c2) - b1 * (a2 * c3 - a3 * c2) + c1 * (a2 * b3 - a3 * b2);
        if (determinant == 0)
        {
            throw new Exception("The system has no unique solution.");
        }
        double x = (d1 * (b2 * c3 - b3 * c2) - b1 * (d2 * c3 - d3 * c2) + c1 * (d2 * b3 - d3 * b2)) / determinant;
        double y = (a1 * (d2 * c3 - d3 * c2) - d1 * (a2 * c3 - a3 * c2) + c1 * (a2 * d3 - a3 * d2)) / determinant;
        double z = (a1 * (b2 * d3 - b3 * d2) - b1 * (a2 * d3 - a3 * d2) + d1 * (a2 * b3 - a3 * b2)) / determinant;
        return (x, y, z);
    }
}



