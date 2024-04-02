
namespace DSTree.BinarySearchTree {

    public class Node {
        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public override string ToString()
        {
            return "Value = " + Value.ToString();
        }
    }

    class BinarySearchTree {

        private Node _root;

        public void Insert(int item) {

            _root = InsertRecursion(_root, item);
        }

        private Node InsertRecursion(Node root, int item) {
            Node node = new Node(){Value = item};
            if (root == null) {
                root = node;
                return root;
            }

            if(item < root.Value) {
                root.Left = InsertRecursion(root.Left, item);
            }
            else if (item > root.Value) {
                root.Right = InsertRecursion(root.Right, item);
            }

            return root;
        }

        public Node? Lookup(int item) {

            return LookupRecursion(_root, item);
        }

        private Node? LookupRecursion(Node? root, int item) {
            // Base Cases: root is null or item is present at root
            if(root == null || root.Value == item) return root;
            
            // Item is greater than root's Value
            if(item < root.Value) {
                root = LookupRecursion(root.Left, item);
            }
            
            // Item is smaller than root's Value
            return LookupRecursion(root.Right, item);
        }

        public void Remove(int item) {
            RemoveRecursion(_root, item);
        }

        // https://www.geeksforgeeks.org/deletion-in-binary-search-tree/?ref=lbp
        private Node RemoveRecursion(Node? root, int item) {
            
            if(root == null) return root;

            if(item < root.Value) {
                root.Left = RemoveRecursion(root.Left, item);
                return root;
            }
            else if (item > root.Value) {
                root.Right = RemoveRecursion(root.Right, item);
                return root;
            }

            if (root.Left == null && root.Right == null) {
                root = null;
                return null;
            }
            if (root.Left == null) {
                Node replacedNode = root.Right;
                root = null;
                return replacedNode;
            }
            else if (root.Right == null) {
                Node replacedNode = root.Left;
                root = null;
                return replacedNode;
            }
            else { // TODO* still can't understand
                Node succParent = root;
 
                // Find successor
                Node succ = root.Right;
                while (succ.Left != null) {
                    succParent = succ;
                    succ = succ.Left;
                }
    
                // Delete successor.  Since successor
                // is always left child of its parent
                // we can safely make successor's right
                // right child as left of its parent.
                // If there is no succ, then assign
                // succ.right to succParent.right
                if (succParent != root)
                    succParent.Left = succ.Right;
                else
                    succParent.Right = succ.Right;
    
                // Copy Successor Data to root
                root.Value = succ.Value;
    
                // Delete Successor and return root
                succ = null;
                return root;

            }

            return root;
        }

        public void PrintTree() {
            _root.Print();
        }

        // This method mainly calls InorderRec()
       public void inorder() { inorderRec(_root); }

        // A utility function to
        // do inorder traversal of BST
        void inorderRec(Node root)
        {
            if (root != null) {
                inorderRec(root.Left);
                Console.Write(root.Value + " ");
                inorderRec(root.Right);
            }
        }

        
    }

    class Program {
        static void Main(string[] args){

            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(9);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(20);
            tree.Insert(170);
            tree.Insert(15);
            tree.Insert(1);
            //tree.PrintTree();
            tree.inorder();
            Console.WriteLine();

            bool result = tree.Lookup(20) != null;
            Console.WriteLine(result);
            result = tree.Lookup(111111) != null;
            Console.WriteLine(result);

            tree.Remove(4);
            tree.inorder();
        }
        
    }

}
