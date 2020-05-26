using System;
using System.Collections.Generic;
using System.Diagnostics;
public class DynamicRecursion
{
    Dictionary<long,long> memory;
    Stopwatch timer;
    public long counter { get; set; }
    public DynamicRecursion(){
        memory = new Dictionary<long,long>();
        timer = new Stopwatch();
    }
    public string Start(long n){
        memory.Clear();
        counter = 0;
        timer.Restart();

        long rez = L(n);

        timer.Stop();
        return $"{n, -14} {rez, -14} {counter, -14} {timer.ElapsedMilliseconds, -12}";
    }
    //L(n)=L(n/15)+L(n/10)+2L(n/6)+root(n)
    private long L(long n){
        counter++;
        if(n >= 1){
            return getL(n/15) + getL(n/10) + getL(n/6) + getL(n/6) + (Int64)Math.Sqrt(n);
        }
        else{
            return 0;
        }
    }
    private long getL(long n){
        long rez;
        if(!memory.TryGetValue(n,out rez)){
            rez = L(n);
            memory.Add(n, rez);
        }
        return rez;
    }
}