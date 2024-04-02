
namespace DSStackAndQueue.QueueImplementedByLinkedList {
 
    class Queue {

        LinkedList<int> _list = new LinkedList<int>();
        private int _size = 0;

        public int Peek() {
            if (IsEmpty()) 
                throw new NullReferenceException();

            return _list.First();
        }

        public void Enqueue(int item) {
            _list.AddLast(item);
            _size++;
        }

        public int Dequeue() {
            if (IsEmpty()) 
                throw new NullReferenceException();

            int item = _list.First();
            _list.RemoveFirst();
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

            Queue s = new Queue();
            s.Enqueue(10);
            s.Enqueue(16);
            s.Enqueue(100);
            Console.WriteLine(s);
            Console.WriteLine(s.Dequeue());
            Console.WriteLine(s.Peek());
            Console.WriteLine(s);
            
        }
        
    }

}
