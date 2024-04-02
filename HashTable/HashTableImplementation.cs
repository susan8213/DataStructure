
using System.Collections;

namespace DSHashTable.HashTableImplementation {
 
    class Pair {
        public string Key { get; set; }
        public int Value { get; set; }
        public Pair? Next { get; set; } // Implementing Linked List to handle hash collision

        public override string ToString()
        {
            return ("{" + nameof(Key) + ": " + Key + ", " + nameof(Value) + ": " + Value + "}");
        }
    }

    class HashTable {

        private int _length;
        private Pair[] _data;

        public HashTable(int size) {
            _data = new Pair[size];
        } 

        private int Hash(string key)
        {
            int hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hash = (hash + (int)key[i] * i) % _data.Length;
            }
            return hash;
        }

        public int Get(string key) {
            
            int index = Hash(key);
            Pair? currentPair = _data[index];
            // loop the linked list inside the same hash index bucket
            while (currentPair != null) {
                if (currentPair.Key == key)
                    return currentPair.Value;
                
                currentPair = currentPair.Next;
            }

            return 0;
        }

        public void Set(string key, int val) {
            
            int index = Hash(key);
            if (_data[index] == null) { // bucket is empty
                _data[index] = new Pair() {Key = key, Value = val};
                _length++;
            }
            else {                      // bucket is not empty
                Pair currentPair = _data[index];
                while (true) {
                    if (currentPair.Key == key) {   // update value when key is existed
                        currentPair.Value = val;
                        return;
                    }

                    if (currentPair.Next != null)   // handle collision, add pair to bucket
                       currentPair = currentPair.Next;
                    else {
                        currentPair.Next = new Pair() {Key = key, Value = val};
                        _length++;
                        return;
                    }
                }

                
            }
        }

        public string[] Keys() {

            string[] output = new string[_length];
            int count = 0;
            foreach (var item in _data)
            {
                Pair? currentPair = item;
                while (currentPair != null) {
                    output[count++] = currentPair.Key;
                    currentPair = currentPair.Next;
                }
            }

            return output;
        }

        public override string ToString()
        {
            string output = String.Empty;
            foreach (var item in _data)
            {
                Pair? currentPair = item;
                while (currentPair != null) {
                    output += currentPair.ToString();
                    output += ", ";
                
                    currentPair = currentPair.Next;
                }
            }
            return output;
        }
    }

    class Program {
        static void Main(string[] args){

            HashTable hashTable = new HashTable(1);
            hashTable.Set("Hello", 134);
            hashTable.Set("World!", 550000);
            hashTable.Set("Hello", 77);
            Console.WriteLine(hashTable);

            int result;
            result = hashTable.Get("Iam");
            Console.WriteLine(result);
            result = hashTable.Get("World!");
            Console.WriteLine(result);
            
            string[] keys = hashTable.Keys();
            Console.WriteLine(string.Join(", ", keys));
        }
        
    }

}
