
using System.Collections;
using System.Data;

namespace DSLinkedList.DoublyLinkedList {
 
    class Node {
        public int Value { get; set; }
        public Node? Next { get; set; }
        public Node? Previous {get; set; }

        public override string ToString()
        {
            string output = Value.ToString();
            if (Previous != null) {
                output = Previous.ToString() + " <> " + output;
            }
            return output;
        }
    }

    class DoublyLinkedList {

        private int _length;
        private Node _head;
        private Node _tail;

        public int Length {
            get => _length;
        }

        public DoublyLinkedList(int item) {
            
            Node node = new Node() {Value = item};
            _head = node;
            _tail = node;
            _length = 1;
        }

        public void Append(int item) {
            if (_tail == null)
                throw new NullReferenceException();

            Node node = new Node(){Value = item};
            _tail.Next = node;
            node.Previous = _tail; //+
            _tail = _tail.Next;
            _length++;
        }

        public void Prepend(int item) {
            if (_head == null)
                throw new NullReferenceException();

            Node node = new Node(){Value = item};
            node.Next = _head;
            _head.Previous = node; //+
            _head = node;
            _length++;
        }

        public void Insert(int index, int item) {
            if (index < 0 || index > _length)
                throw new IndexOutOfRangeException();

            if (index == 0) {
                Prepend(item);
                return;
            }
            else if (index == _length) {
                Append(item);
                return;
            }
                
            Node newNode = new Node(){Value=item};
            Node previousNode = TraverseToNodeByIndex(index - 1);
            Node nextNode = previousNode.Next;
            newNode.Next = nextNode;
            newNode.Previous = previousNode; //+
            previousNode.Next = newNode;
            nextNode.Previous = newNode; //+
            _length++;
        }

        public void Remove(int index) {
            if (index < 0 || index >= _length )
                throw new IndexOutOfRangeException();

            // Cannot remove the ONLY-ONE node.
            if (_length == 1)
                throw new NoNullAllowedException();
            
            // Scenario: remove head node
            if (index == 0) {
                _head = _head.Next;
                _head.Previous = null; //+
                _length--;
                return;
            }
            
            Node previousNode = TraverseToNodeByIndex(index - 1);
            Node NodeToRemove = previousNode.Next;
            // Scenario: remove tail node
            if (NodeToRemove == _tail) {
                previousNode.Next = null;
                _tail = previousNode;
            }
            else { // Scenario: others
                Node nextNode = NodeToRemove.Next;
                previousNode.Next = nextNode;
                nextNode.Previous = previousNode; //+
            }
            _length--;
        }

        public void Reverse() {
            if (_head == _tail) return;

            Node previousNode = _head;
            Node currentNode = previousNode.Next;
            _head.Next = null;
            _head.Previous = currentNode; //+
            while (currentNode != null) {
                Node? nextNode = currentNode.Next;
                currentNode.Next = previousNode;
                currentNode.Previous = nextNode; //+

                previousNode = currentNode;
                currentNode = nextNode;
            }
            
            _tail = _head;
            _head = previousNode;
        }

        private Node TraverseToNodeByIndex(int index) {
            int count = 0;
            Node currentNode = _head;
            while (count < index) {
                currentNode = currentNode.Next;
                count++;
            }

            return currentNode;
        }

        public override string ToString()
        {
            return _tail.ToString();
        }
    }

    class Program {
        static void Main(string[] args){

            DoublyLinkedList linkedList = new DoublyLinkedList(1);
            linkedList.Append(10);
            linkedList.Prepend(20);
            Console.WriteLine(linkedList);

            // // linkedList.Insert(5, 50); // Error: Index Out of bound
            linkedList.Insert(1, 30); // insert to middle
            linkedList.Insert(4, 40); // insert to tail
            linkedList.Insert(0, 50); // insert to head
            Console.WriteLine(linkedList);

            linkedList.Remove(1);
            linkedList.Remove(4); // remove tail
            linkedList.Remove(0); // remove head
            // linkedList.Remove(1);
            // linkedList.Remove(1);
            // // linkedList.Remove(0); // Error: Not allow to remove the only one row.
            Console.WriteLine(linkedList);

            linkedList.Reverse();
            Console.WriteLine(linkedList);
            linkedList.Append(99);
            linkedList.Prepend(999);
            Console.WriteLine(linkedList);
            
        }
        
    }

}
