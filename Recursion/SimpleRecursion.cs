using System;
using System.Diagnostics;
public class SimpleRecursion
{
    Stopwatch timer;
    public long counter { get; set; }
    public SimpleRecursion(){
        timer  = new Stopwatch();
    }
    public string Start(long n){
        counter = 0;
        timer.Restart();

        long rez = L(n);

        timer.Stop();
        return $"{n, -14} {rez,-14} {counter, -14} {timer.ElapsedMilliseconds, -12}";
    }
    //L(n)=L(n/15)+L(n/10)+2L(n/6)+root(n)
    private long L(long n){
        counter++;
        if(n >= 1){
            int i;
            for (i = 0; i < (Int64)Math.Sqrt(n)-1; i++);
            return L(n/15) + L(n/10) + L(n/6) + L(n/6) + i;
        }
        else{
            return 0;
        }
    }
}
