
// Fibonacci sequence is the pattern that each value is the sum of the 2 previous values
// 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 ...

// Given a number N return the index value of the Fibonacci sequence

namespace AlgoRecursion.ReverseString {

    class Program {

        // O(n)
        static char[] ReverseStringIterative(char[] str) {
            
            for(int i = 0; i< (str.Length / 2); i++) {
                char temp = str[i];
                str[i] = str[(str.Length - 1) - i];
                str[(str.Length - 1) - i] = temp;
            }
            
            return str;
        }

        // O(2^n)
        static char[] ReverseStringRecursive(char[] str, int index=0) {
            
            if (str.Length <= 1) return str;
            if ( index >= (str.Length / 2)) return str;

            char temp = str[index];
            str[index] = str[(str.Length-1)-index];
            str[(str.Length-1)-index] = temp;


            return ReverseStringRecursive(str, index+1);
        }
        static void Main(string[] args){
            
            char[] input = "Hello World!".ToCharArray();
            Console.WriteLine(ReverseStringIterative(input));
            Console.WriteLine(ReverseStringRecursive(input));
        }
        
    }

}
