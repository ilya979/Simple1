using System.Diagnostics;
ulong N;

//Console.Write("Простые числа до N=");
//N = Convert.ToUInt64(Console.ReadLine());

for(ulong i=10; i<100_000_000; i*=10)
    FindSimpleNumb(i);

Console.WriteLine("Press any key...");
Console.ReadKey();

void FindSimpleNumb(ulong N)
{
    Stopwatch stopWatch = new Stopwatch();

    Console.WriteLine($"N = {N}");
    Console.Write("FindSimpleNumbI: ");
    stopWatch.Restart();
    Console.Write(FindSimpleNumbI(N));
    stopWatch.Stop();
    Console.WriteLine($" ({stopWatch.ElapsedMilliseconds} ms)");

    Console.Write("FindSimpleNumbE: ");
    stopWatch.Restart();
    Console.Write(FindSimpleNumbE(N));
    stopWatch.Stop();
    Console.WriteLine($" ({stopWatch.ElapsedMilliseconds} ms)");
}

ulong FindSimpleNumbI(ulong N)
{
    ulong res = 0;
    ulong nn;
    ulong maxN;
    // ищем до sqrt(N)
    for (ulong i = 1; i < N; i+=2)
    {

        maxN = (ulong)Math.Sqrt(i) + 1;
        nn = 0;
        for (ulong j = 2; j < maxN && nn==0; j++)
        {
            if(i%j==0) nn++;
        }
        if (nn == 0)
        {
            res++;
        }

    }
    return res;
}

ulong FindSimpleNumbE(ulong N)
{
    ulong res = 0;
    ulong NN = N + 1;
    ulong sqrt = (ulong)Math.Sqrt(N)+1;
    bool[] bools = new bool[NN];
    //bools[0] = false;
    //bools[1] = false;
    //for (ulong i=2; i<NN; i++)  bools[i] = true;
    for (ulong i=2; i<NN; i++)
    {
        if (!bools[i])
        {
            res++;
            for (ulong j = i * i; j < NN; j += i)
                bools[j] = true;
        }
    }
//    for(ulong i=2; i<NN; i++)
//        if (!bools[i])
//            res++;

    return res;
}