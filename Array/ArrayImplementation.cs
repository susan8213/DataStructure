
namespace DSArray.ArrayImplementation {
    public class MyArray {

        private Object[] _data;
        private int _length = 0;

        public int Length {
            get => _length;
        }

        public MyArray(int size) {
            _data = new Object [size];
        }

        public Object Get(int index) {
            return _data[index];
        }

        public void Push(Object item) {
            _data[_length] = item;
            _length ++;
        }

        public void Insert(int index, Object item) {
            if (index < 0 || index > _length)
                throw new IndexOutOfRangeException();

            for (int i = _length; i > index; i--) {
                _data[i] = _data[i - 1];
            }
            _data[index] = item;
            _length ++;

        }

        public Object Pop() {
            Object item = _data[_length - 1];
            _data[_length - 1] = null;
            _length --;
            
            return item;
        }

        public void Delete(int index) {
            if (index < 0 || index >= _length)
                throw new IndexOutOfRangeException();

            for (int i = index + 1; i < _length; i++) {
                _data[i - 1] = _data[i];
            }
            Pop();
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < _length; i++)
            {
                output += this.Get(i).ToString();
                output += " ";
            }
            return output;
        }

    }

    class Program {
        static void Main(string[] args){
            MyArray myArray = new MyArray(10);

            myArray.Push("Hello");
            myArray.Push("World");
            myArray.Push(123);
            Console.WriteLine(myArray);

            myArray.Pop();
            Console.WriteLine(myArray);

            myArray.Delete(0);
            Console.WriteLine(myArray);

            myArray.Insert(1, "Hello");
            myArray.Insert(0, 3.14);
            // myArray.Insert(5, "Error");
            Console.WriteLine(myArray);
            Console.WriteLine(myArray.Length);
        }
        
    }

}
