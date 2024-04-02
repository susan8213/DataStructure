
using System.Globalization;

namespace AlgoSorting.Sorting {

    class Program {

        static void BubbleSort(int[] arr) {

            for (int i=0; i< arr.Length-1; i++) {
                for (int j=0; j< arr.Length-1; j++) {
                    if (arr[j+1] < arr[j]) {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                    }
                }
            }
        }

        static void SelectionSort(int[] arr) {

            for (int i=0; i<arr.Length; i++) {
                int minIndex = i;
                for (int j=i+1; j<arr.Length; j++) {
                    if (arr[j] < arr[minIndex]) {
                        minIndex = j;
                    }
                }

                if (minIndex != i) {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }
        }

        static void InsertionSort(int[] arr) {

            // Traverse through 1 to length of arr
            for (int i=1; i<arr.Length; i++) {
                int key = arr[i];  // Current element to be compared

                // Move elements of arr[0..i-1], that are greater than key,
                // to one position ahead of their current position
                int j = i-1;
                while (j >= 0 && key < arr[j]) {
                    arr[j+1] = arr[j];
                    j--;
                }
                // Insert key into its correct position
                arr[j+1] = key;
            }
        }

        static void MergeSort(int[] arr) {

            if (arr.Length > 1) {
                int mid = arr.Length / 2;   // Finding the middle of the array

                // Dividing the array elements into 2 halves
                int[] leftArr = arr.Take(mid).ToArray();    
                int[] rightArr = arr.Skip(mid).ToArray();
                MergeSort(leftArr);         // Sorting the first half
                MergeSort(rightArr);        // Sorting the second half

                // Merging the two halves
                int i = 0, j = 0, k = 0;
                while (i < leftArr.Length && j < rightArr.Length) {
                    if (leftArr[i] < rightArr[j]) {
                        arr[k++] = leftArr[i++];
                    }
                    else {
                        arr[k++] = rightArr[j++];
                    }
                }

                // Checking if any element was left
                while (i < leftArr.Length) {
                    arr[k++] = leftArr[i++];
                }
                while (j < rightArr.Length) {
                    arr[k++] = rightArr[j++];
                }
            }
        }

        private static int Partition(int[] arr, int lowIdx, int highIdx) {

            int pivot = arr[highIdx];   // Selecting the last element as pivot
            int pivotIdx = lowIdx;      // Index of smaller element

            for (int i = lowIdx; i < highIdx; i++) {

                // If current element is smaller than or equal to pivot
                if (arr[i] < pivot) {

                    // Swap arr[pivotIdx] and arr[i]
                    int temp = arr[i];
                    arr[i] = arr[pivotIdx];
                    arr[pivotIdx] = temp;

                    pivotIdx++;
                }
            }

            // Swap arr[pivotIdx] and arr[high]
            int temp2 = arr[pivotIdx];
            arr[pivotIdx] = pivot;
            arr[highIdx] = temp2;

            return pivotIdx;
        }

        static void QuickSort(int[] arr, int lowIdx, int highIdx) {
            
            // when lowIdx >= highIdx, means all of the elements in the arr are already sorted
            if (lowIdx < highIdx) {

                // pivotIdx is partitioning index, arr[pivotIdx] is now at right place
                int pivotIdx = Partition(arr, lowIdx, highIdx);

                // Separately sort elements before partition and after partition
                QuickSort(arr, lowIdx, pivotIdx-1);
                QuickSort(arr, pivotIdx+1, highIdx);

            }
        }

        static void Main(string[] args){
            
            int[] arr = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };
            //  arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            // arr = new int[] { 35, 33, 42, 10, 14, 19, 27, 44, 31};

            // BubbleSort(arr);
            // SelectionSort(arr);
            // InsertionSort(arr);
            // MergeSort(arr);
            QuickSort(arr, 0, arr.Length-1);

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        
    }

}




