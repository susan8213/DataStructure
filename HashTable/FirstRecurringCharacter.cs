
using System.Collections;
using DSHashTable.HashTableImplementation;

namespace DSHashTable.FirstRecurringCharacter {
 
    
    class Program {

        // Time: O(n^2), Space: O(1)
        private static int FindFirstRecurringChar(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++) {
                for(int j = i+1; j< arr.Length; j++) {
                    if (arr[i] == arr[j])
                        return arr[i];
                }
            }

            return 0;
        }

        // Time: O(n), Space: O(n)
        private static int FindFirstRecurringChar2(int[] arr)
        {
            HashTable hashTable = new HashTable(10);
            foreach( int item in arr ) {
                if( hashTable.Get(item.ToString()) > 0)
                    return item;

                hashTable.Set(item.ToString(), item);
            }

            return 0;
        }

        static void Main(string[] args){

            int[] arr = { 1, 5, 8, 5, 1, 8, 8, 7, 4, 4, 10 };
            Console.WriteLine(FindFirstRecurringChar(arr));

            Console.WriteLine(FindFirstRecurringChar2(arr));
        }

    }

}
