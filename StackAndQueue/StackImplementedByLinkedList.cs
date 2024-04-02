
namespace DSStackAndQueue.StackImplementedByLinkedList {
 
    class Stack {

        LinkedList<int> _list = new LinkedList<int>();
        private int _size = 0;

        public int Peek() {
            if (IsEmpty()) 
                throw new NullReferenceException();

            return _list.LastOrDefault();
        }

        public void Push(int item) {
            _list.AddLast(item);
            _size++;
        }

        public int Pop() {
            if (IsEmpty()) 
                throw new NullReferenceException();

            int item = _list.LastOrDefault();
            _list.RemoveLast();
            _size--;

            return item;
        }

        private bool IsEmpty() {
            return _size == 0;
        }

        public override string ToString()
        {
            string output = String.Empty;
            foreach (var item in _list)
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
