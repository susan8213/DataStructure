// Given two arrays that are sorted.
// Can you merge these two arrays into one big one that's still sorted.

namespace DSArray.MergeTwoSortedArray {

    class Program {

        // Time: O(m+n), Space: O(m+n)
        static int[] MergeTwoSortedArray(int[] arr1, int[] arr2) {

            int[] result = new int[arr1.Length + arr2.Length];
            int idx1 = 0, idx2 = 0;
            int count = 0;
            while (idx1 < arr1.Length && idx2 < arr2.Length) {

                if ( arr1[idx1] < arr2[idx2] )
                    result[count++] = arr1[idx1++];
                else
                    result[count++] = arr2[idx2++];
            }

            while( idx1 < arr1.Length) {
                result[count++] = arr1[idx1++];
            }

            while (idx2 < arr2.Length) {
                result[count++] = arr2[idx2++];
            }

            return result;
        }

        // built-in
        static int[] MergeTwoSortedArray2(int[] arr1, int[] arr2) {

            int[] newArray = new int[arr1.Length + arr2.Length];
            Array.Copy(arr1, newArray, arr1.Length);
            Array.Copy(arr2, 0, newArray, arr1.Length, arr2.Length);

            Array.Sort(newArray);
            return newArray;
        }

        static void Main(string[] args){
            
            // int[] result = MergeTwoSortedArray([0,3,4,31], [3,4,6,30]);
            int[] result = MergeTwoSortedArray2([0,3,4,31], [3,4,6,30]);
            foreach (var item in result) {
                Console.WriteLine(item);
            }

            
        }
    }
}
