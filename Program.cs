using System;
class Program
{
    static SimpleRecursion sRecursion;
    static DynamicRecursion dRecursion ;
    static void Main(string[] args)
    {
        sRecursion = new SimpleRecursion();
        dRecursion = new DynamicRecursion();

        Console.WriteLine("Manual(m) or Automatic(a) test?");
        string testType = "";
        while(!(testType.CompareTo("m") == 0 || testType.CompareTo("a") == 0)){
            testType = Console.ReadLine();
        }
        if(testType.CompareTo("m") == 0){//if manual
            manualTestRecursion();
        }
        else{//if automatic
            autoTestRecursion();
        }

        //hold console
        Console.ReadLine();
    }

    static void manualTestRecursion(){
        Console.WriteLine("Enter integer: ");
        long n = Int64.Parse(Console.ReadLine());

        printTestStart("Simple recursion");
        Console.WriteLine(sRecursion.Start(n));

        printTestStart("Dynamic recursion");
        Console.WriteLine(dRecursion.Start(n));
    }
    static void autoTestRecursion(){
        long[] inputs = {1000, 1000000, 1000000000, 10000000000, 100000000000, 1000000000000};
        printTestStart("Simple recursion");
        foreach (long item in inputs){
            Console.WriteLine(sRecursion.Start(item));
        }

        printTestStart("Dynamic recursion");
        foreach (long item in inputs){
            Console.WriteLine(dRecursion.Start(item));
        }
    }

    static void printTestStart(string testName){
        Console.WriteLine();
        Console.WriteLine(testName);
        Console.WriteLine($"{"input", -14} {"rezult",-14} {"steps made", -14} {"elapsed time", -12}");
    }
}