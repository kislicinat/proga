using System; 
 
class Program 
{ 
    static void Main() 
    { 
        int n = 1000000; 
        int mod = 1000000000; 
        long result = S(n, mod); 
        Console.WriteLine(result); 
    } 
    static long Sigma(int n) 
    { 
        long sum = 0; 
        for (int i = 1; i * i <= n; i++) 
        { 
            if (n % i == 0) 
            { 
                sum += (long)i * i; 
                if (i != n / i) 
                { 
                    sum += (long)(n / i) * (n / i); 
                } 
            } 
        } 
        return sum; 
    } 
 
    static long S(int n, int mod) 
    { 
        long sum = 0; 
        for (int i = 1; i <= n; i++) 
        { 
            sum = (sum + Sigma(i)) % mod; 
        } 
        return sum; 
    } 
}