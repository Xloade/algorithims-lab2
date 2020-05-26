using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
class CustomData
{
    public int[] array;
    public int m;
    public int stopBefore;
    public int startFrom;
    public List<int> result;

    public CustomData(int[] array ,int m, int stopBefore, int startFrom){
        this.array = array;
        this.m = m;
        this.stopBefore = stopBefore;
        this.startFrom = startFrom;
    }
}
class Project{
    Stopwatch timer;
    List<int> result;
    public Project(){
        timer = new Stopwatch();
    }
    public String start(int[] array, int m, int countCPU){
        Task[] tasks = new Task[countCPU];
        result = new List<int>();
        timer.Restart();

        for (int i = 0; i < tasks.Length; i++){
            tasks[i] = Task.Factory.StartNew(
                (Object p)=>
                {
                    CustomData data = p as CustomData;
                    data.result = T(data.array, data.m, data.stopBefore, data.startFrom);
                },
                new CustomData(array, m, (int)((double)array.Length/countCPU*(i+1)), (int)((double)array.Length/countCPU*i))
            );
        }
        Task.WaitAll(tasks);

        foreach (Task task in tasks){
            result.AddRange((task.AsyncState as CustomData).result);
        }
        timer.Stop();
        return $"{array.Length, -14} {m,-14} {timer.ElapsedMilliseconds, -12}";
    }

    public String startSingleCore(int[] array, int m){
        timer.Restart();
        result = T(array, m ,array.Length, 0);
        timer.Stop();
        return $"{array.Length, -14} {m,-14} {timer.ElapsedMilliseconds, -12}";
    }

    public String Result(){
        StringBuilder builder = new StringBuilder();
        foreach(int item in result)
        {
            builder.Append(item.ToString());
            builder.Append(" ");
        }
        return builder.ToString();
    }

    public List<int> T(int[] array ,int m, int stopBefore, int currentNum){
        if(currentNum < stopBefore){
            int greaterThenCurrent = 0; //how many numbers are greater then currentNum
            for (int i = 0; i < array.Length; i++)
            {
                if(array[currentNum] < array[i]){
                    greaterThenCurrent++;
                }
            } 
            List<int> res = T(array ,m, stopBefore, currentNum + 1);
            if(greaterThenCurrent < m){
                res.Add(array[currentNum]);
            }
            return res;
        }
        else{
            return new List<int>();
        }
    }
}