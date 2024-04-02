
namespace AlgoRecursion.Factorial {

    class Program {

        // O(n)
        static int FactorialIterative(int num) {
            int result = 1;
            for (int i = num; i >= 1; i--) {
                result *= i;
            }

            return result;
        }

        // O(n)
        static int FactorialRecursive(int num) {
            
            if (num == 1) return num;
            return num * FactorialRecursive(num - 1);
        }
        static void Main(string[] args){
            
            Console.WriteLine(FactorialIterative(2));
            Console.WriteLine(FactorialRecursive(2));
        }
        
    }

}
