
// Fibonacci sequence is the pattern that each value is the sum of the 2 previous values
// 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 ...

// Given a number N return the index value of the Fibonacci sequence

namespace AlgoRecursion.Fibonacci {

    class Program {

        // O(n)
        static int FibonacciIterative(int n) {
            if (n == 0 || n == 1) return n;
            
            int p1 = 1, p2 = 0;
            int counter = 2;
            int result = 0;
            while (counter <= n) {
                result = p1 + p2;
                p2 = p1;
                p1 = result;
                counter++;
            }

            return result;
        }

        // O(2^n)
        static int FibonacciRecursive(int n) {
            
            if (n == 0 || n == 1) return n;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }
        static void Main(string[] args){
            
            Console.WriteLine(FibonacciIterative(9));
            Console.WriteLine(FibonacciRecursive(9));
        }
        
    }

}
