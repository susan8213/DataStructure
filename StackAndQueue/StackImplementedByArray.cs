
using System.Collections;

namespace DSStackAndQueue.StackImplementedByArray {
 
    class Stack {

        ArrayList _arr = new ArrayList();
        private int _size = 0;

        public int Peek() {
            if (IsEmpty()) 
                throw new NullReferenceException();

            return (int)_arr[_size - 1];
        }

        public void Push(int item) {
            _arr.Add(item);
            _size++;
        }

        public int Pop() {
            if (IsEmpty()) 
                throw new NullReferenceException();

            int item = (int)_arr[_size - 1];
            _arr.RemoveAt(_size - 1);
            _size--;

            return item;
        }

        private bool IsEmpty() {
            return _size == 0;
        }

        public override string ToString()
        {
            string output = String.Empty;
            foreach (var item in _arr)
            {
                output += item + " ";
            }
            return output;
        }
    }

    class Program {
        static void Main(string[] args){

            Stack s = new Stack();
            s.Push(10);
            s.Push(16);
            s.Push(100);
            Console.WriteLine(s);
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Peek());
            Console.WriteLine(s);
            
        }
        
    }

}
