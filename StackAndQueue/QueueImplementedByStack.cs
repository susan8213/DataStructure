
namespace DSStackAndQueue.QueueImplementedByStack {
 
    /// <summary>
    /// enQueue(q,  x)
    /// 1) Push x to stack1 (assuming size of stacks is unlimited).
    ///    Here time complexity will be O(1)
    ///
    /// deQueue(q)
    /// 1) If both stacks are empty then error.
    /// 2) If stack2 is empty
    ///    While stack1 is not empty, push everything from stack1 to stack2.
    /// 3) Pop the element from stack2 and return it.
    /// Here time complexity will be O(n)
    /// </summary>

    class Queue {

        Stack<int> _inStack = new Stack<int>();
        Stack<int> _outStack = new Stack<int>();
        private int _size = 0;

        public int Peek() {
            if (IsEmpty()) 
                throw new NullReferenceException();

            if (_outStack.Count == 0)
                MoveItemFromInStacktoOutStack();

            return _outStack.Peek();
        }

        public void Enqueue(int item) {
            _inStack.Push(item);
            _size++;
        }

        public int Dequeue() {
            if (IsEmpty()) 
                throw new NullReferenceException();

            if (_outStack.Count == 0)
                MoveItemFromInStacktoOutStack();

            int item = _outStack.Pop();
            _size--;

            return item;
        }

        private bool IsEmpty() {
            return (_inStack.Count + _outStack.Count) == 0;
        }

        private void MoveItemFromInStacktoOutStack() {
            while (_inStack.Count > 0) {
                _outStack.Push(_inStack.Pop());
            }
        }

        public override string ToString() {
            string output = String.Empty;
            foreach (var item in _outStack)
            {
                output += item + " ";
            } 
            for (int i = _inStack.Count - 1; i >= 0; i--) {
                output += _inStack.ElementAt(i) + " ";
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
