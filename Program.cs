using System;
using System.IO;
class Program
{
    static SimpleRecursion sRecursion;
    static DynamicRecursion dRecursion ;
    static Project project;
    static void Main(string[] args)
    {
        sRecursion = new SimpleRecursion();
        dRecursion = new DynamicRecursion();
        project = new Project();

        Console.WriteLine("Manual(m) or Automatic(a) test?");
        string testType = "";
        while(!(testType.Equals("m") || testType.Equals("a"))){
            testType = Console.ReadLine();
        }
        if(testType.Equals("m")){//if manual
            manualTestRecursion();
            Console.WriteLine("--------------------------------------------------------------");
            manualTestProject();
        }
        else{//if automatic
            //autoTestRecursion();
            Console.WriteLine("--------------------------------------------------------------");
            autoTestProject();
        }

        //hold console
        Console.ReadLine();
    }

    static void manualTestRecursion(){
        Console.WriteLine("Recursion test");
        Console.WriteLine("Enter integer: ");
        long n = Int64.Parse(Console.ReadLine());

        printRecTestStart("Simple recursion");
        Console.WriteLine(sRecursion.Start(n));

        printRecTestStart("Dynamic recursion");
        Console.WriteLine(dRecursion.Start(n));
    }
    static void autoTestRecursion(){
        long[] inputs = {1000000000, 1000, 1000000, 1000000000, 10000000000, 100000000000, 1000000000000};
        printRecTestStart("Simple recursion");
        foreach (long item in inputs){
            Console.WriteLine(sRecursion.Start(item));
        }

        printRecTestStart("Dynamic recursion");
        foreach (long item in inputs){
            Console.WriteLine(dRecursion.Start(item));
        }
    }

    static void printRecTestStart(string testName){
        Console.WriteLine();
        Console.WriteLine(testName);
        Console.WriteLine($"{"input", -14} {"rezult",-14} {"steps made", -14} {"elapsed time", -12}");
    }

    static void manualTestProject(){
        Console.WriteLine("Project test");
        Console.WriteLine("Enter m - number of prejects to be done:");
        int toBeDone = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter projects earnnings (seperate values with single space)");
        string data = Console.ReadLine();
        string[] splitData = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int[] convertedData = new int[splitData.Length];
        for (int i = 0; i < splitData.Length; i++){
            convertedData[i] = Int32.Parse(splitData[i]);
        }
        printProjTestStart("Single core test");
        Console.WriteLine(project.startSingleCore(convertedData, toBeDone));
        Console.WriteLine("Full answer:");
        Console.WriteLine(project.Result());
        Console.WriteLine();
        printProjTestStart("4 core test");
        Console.WriteLine(project.start(convertedData, toBeDone, 4));
        Console.WriteLine("Full answer:");
        Console.WriteLine(project.Result());
    }

    static void autoTestProject(){
        Random rand = new Random();
        int[] inputSizes = {1000, 100, 1000, 5000, 10000};
        int[][] inputs = new int[5][];
        
        printProjTestStart("Single core test");
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = new int[inputSizes[i]];
            for (int k = 0; k < inputs[i].Length; k++)
            {
                inputs[i][k] = rand.Next();
            }
        }
        for (int i = 0; i < inputs.Length; i++)
        {
            Console.WriteLine(project.startSingleCore(inputs[i], 10));
        }
        printProjTestStart("4 core test");
        for (int i = 0; i < inputs.Length; i++)
        {
            Console.WriteLine(project.start(inputs[i], 10, 4));
        }
    }
    static void printProjTestStart(string testName){
        Console.WriteLine();
        Console.WriteLine(testName);
        Console.WriteLine($"{"n", -14} {"m",-14} {"elapsed time", -12}");
    }
}