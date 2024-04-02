

namespace AlgoSearching.SearchingTree {

    enum DFSType {
        PreOrder,
        InOrder,
        PostOrder
    }

    class Node {
        public int Value { get; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(int n) {
            Value = n;
        }
    }

    class BinaryTree {

        internal Node root;

        public int[] BFS() {

            List<int> traverseResult = new List<int>();
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            
            while(q.Count > 0) {
                Node currentNode = q.Dequeue();
                traverseResult.Add(currentNode.Value);

                if (currentNode.Left != null)
                    q.Enqueue(currentNode.Left);
                if (currentNode.Right != null)
                    q.Enqueue(currentNode.Right);
            }

            return traverseResult.ToArray();
        }

        

        public int[] DFS(DFSType dfsType) {

            List<int> result = new List<int>();
            switch (dfsType)
            {
                case DFSType.PreOrder:
                    PreOrderTraverse(root, result);
                    break;
                case DFSType.InOrder:
                    InOrderTraverse(root, result);
                    break;
                case DFSType.PostOrder:
                    PostOrderTraverse(root, result);
                    break;
                default:
                    break;
            }

            return result.ToArray();
        }

        private void PreOrderTraverse(Node node, List<int> result) {

            if (node == null) return;

            result.Add(node.Value);
            PreOrderTraverse(node.Left, result);
            PreOrderTraverse(node.Right, result);
        }

        private void InOrderTraverse(Node node, List<int> result) {

            if (node == null) return;

            InOrderTraverse(node.Left, result);
            result.Add(node.Value);
            InOrderTraverse(node.Right, result);
        }

        private void PostOrderTraverse(Node node, List<int> result) {

            if (node == null) return;

            PostOrderTraverse(node.Left, result);
            PostOrderTraverse(node.Right, result);
            result.Add(node.Value);
        }

    }

    class Program {
        static void Main(string[] args){
            
            // Creating a binary search tree
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(10);
            tree.root.Left = new Node(6);
            tree.root.Right = new Node(15);
            tree.root.Left.Left = new Node(3);
            tree.root.Left.Right = new Node(8);
            tree.root.Right.Right = new Node(20);

            Console.Write("BFS Traversal:           ");
            PrintResult(tree.BFS());
            
            Console.Write("DFS PreOrder Traversal:  ");
            PrintResult(tree.DFS(DFSType.PreOrder));
            Console.Write("DFS InOrder Traversal:   ");
            PrintResult(tree.DFS(DFSType.InOrder));
            Console.Write("DFS PostOrder Traversal: ");
            PrintResult(tree.DFS(DFSType.PostOrder));
            

            
        }

        static void PrintResult(int[] result) {
            foreach (int item in result)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }
        
    }

}
