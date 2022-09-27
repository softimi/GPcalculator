// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using Internal;

int[] scores;
string[] courseCode;
int[] courseUnit;
string[] grade;
int[] gradeUnit;
int[] weightPoint;
string[] remark;
//MyClass.display();
//AcceptData.acceptInput();
//MyClass.display();
//Console.WriteLine(val);

/*
 * Table class
 * Calculations class
 * Table class
 * 
 * 
 * 
 * 
 * 
 * 
 */

Console.WriteLine("Welcome To Your GP calculator. Please enter the number of subjects");
int noOfCourse = Int32.Parse(Console.ReadLine());
scores = new int[noOfCourse];
courseCode = new string[noOfCourse];
courseUnit = new int[noOfCourse];
grade = new string[noOfCourse];
gradeUnit = new int[noOfCourse];
weightPoint = new int[noOfCourse];
remark = new string[noOfCourse];


// To ma
for (int i = 0; i < noOfCourse; i++)
{
    Console.WriteLine("Please enter course name and code");
    // Verify input, Ok? process operation : prompt user to input the right thing
    courseCode[i] = Console.ReadLine();


    Console.WriteLine("Please enter course unit");
    // Verify input, Ok? process operation : prompt user to input the right thing
    courseUnit[i] = Int32.Parse(Console.ReadLine());


    Console.WriteLine("Please enter course score");
    // Verify input, Ok? process operation : prompt user to input the right thing
    scores[i] = Int32.Parse(Console.ReadLine());

    // Grade unit
    GradeInUnit grader = new GradeInUnit();
    gradeUnit[i] = grader.gradeUnit(scores[i]);

    // Remark
    Remarks remarks = new Remarks();
    remark[i] = remarks.makeRemark(gradeUnit[i]);


    weightPoint[i] = courseUnit[i] * gradeUnit[i];
}


for (int i = 0; i < noOfCourse; i++)
{
    //Console.WriteLine("CoursCode: " + courseCode[i] + " | CourseUnit: " + courseUnit + " | CourseScore: " + scores);
    //Console.WriteLine("CoursCode: " + courseCode[i] + " | CourseUnit: " + courseUnit[i] );
    //| MTH101 | 5 | B | 4 | 20 | Very Good |
    MyClass.display(courseCode[i], courseUnit[i], scores[i], gradeUnit[i], remark[i]);
}


// Total Course Unit Registered
int tcuRegistered = courseUnit.Sum();
Console.WriteLine("Total Course Unit Registered is: " + tcuRegistered);



// Total Course Unit Passed
TcuPassed tcuP = new TcuPassed();
int tcuPassed = tcuP.calc(courseUnit, gradeUnit);
Console.WriteLine("Total Course Unit Passed is: " + tcuPassed);

// Total Weight point
int tWeightPoint = weightPoint.Sum();
Console.WriteLine("Total Weight Poin is: " + tWeightPoint);

double gpaCalc = tWeightPoint / courseUnit.Sum();
double _gpa = Math.Round(gpaCalc, 2);



Console.ReadLine();

class MyClass
{
    public static void display(string a, int b, int c, int d, string e)
    {
        //Console.WriteLine("Hello, World!");
        //string val = Console.ReadLine();
        //Console.WriteLine("CoursCode: " + a + " | CourseUnit: " + b + " | CourseScore: " + c);
        Console.WriteLine("|" + a + " | " + b + " | " + c + " | " + d + " | " + e + "  |");


    }
}

// Remarks ( Excellent - Fail)
class Remarks
{
    //I want to be able to input course name and code, course unit, course score; one after the other so that the calculator will calculate
    //the score grade and record it before the total result and GPA is displayed.
    public string makeRemark(int a)
    {

        //int intValue = Int32.Parse(a);
        string val = "";

        if (a == 5)
        {
            val = "Excellent";
        }
        else if (a == 4)
        {
            val = "Very Good";
        }
        else if (a == 3)
        {
            val = "Good";
        }
        else if (a == 2)
        {
            val = "Fair";
        }
        else if (a == 1)
        {
            val = "Pass";
        }
        else if (a == 0)
        {
            val = "Fail";
        }
        else
        {

        }

        return val;
    }
}

// Grading unit system { 0 - 5 }
class GradeInUnit
{
    public int gradeUnit(int a)
    {

        //int intValue = Int32.Parse(a);
        int val = 0;

        if (a >= 70)
        {
            val = 5;
        }
        else if (a >= 60)
        {
            val = 4;
        }
        else if (a >= 50)
        {
            val = 3;
        }
        else if (a >= 45)
        {
            val = 2;
        }
        else if (a >= 40)
        {
            val = 1;
        }
        else if (a >= 0)
        {
            val = 0;
        }
        else
        {

        }

        return val;
    }
}


class ConvertToInt
{
    public int acceptData(string a)
    {
        //Console.WriteLine("Welcome To Your GP calculator. Please enter the number of subjects");
        //Console.ReadLine();

        int intValue = Int32.Parse(a);

        return intValue;
    }
}

class TcuPassed
{
    public int calc(int[] arr, int[] ary)
    {
        // Where arr = CourseUnit; ary = GradeUnit
        int tcup = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (ary[i] > 0)
            {
                tcup += arr[i];
            }
        }

        return tcup;
    }
}

class AcceptData
{
    //I want to be able to input course name and code, course unit, course score; one after the other so that the calculator will calculate
    //the score grade and record it before the total result and GPA is displayed.
    public static void acceptInput()
    {
        Console.WriteLine("Welcome To Your GP calculator. Please enter the number of subjects");
        Console.ReadLine();
    }
}