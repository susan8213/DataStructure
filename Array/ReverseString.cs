

namespace DSArray.ReverseString {

    class Program {

        // Time: O(n), Space: O(1)
        // Assumption: without data type changed "string <-> char[]"
        static string Reverse(string str) {
            char[] arr = str.ToCharArray();
            for (int i = 0; i < (arr.Length / 2); i++) {
                char temp = arr[i];
                arr[i] = arr[(arr.Length - 1) - i];
                arr[(arr.Length - 1) - i] = temp;
            }
            return new string(arr);
        }

        // Time: O(n), Space: O(n)
        static string Reverse2(string str) {
            string result = string.Empty;
            for (int i = str.Length - 1 ; i >= 0; i--) {
                result += str[i];
            }
            return result;
        }

        // built-in
        static string Reverse3(string str) {
            char[]? result = str.ToCharArray();
            Array.Reverse(result);
            
            return new string(result);
        }

        static void Main(string[] args){
            string reversedString;
            reversedString = Reverse("Hello World!");
            Console.WriteLine(reversedString);

            reversedString = Reverse2("Hello World!");
            Console.WriteLine(reversedString);

            reversedString = Reverse3("Hello World!");
            Console.WriteLine(reversedString);
        }
    }
}
