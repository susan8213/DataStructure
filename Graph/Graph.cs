
using System.Text;

namespace DSGraph.Graph {
 
    class Graph {

        private Dictionary<int, SortedSet<int>> adjacentList = new Dictionary<int, SortedSet<int>>();

        public void AddVertex(int node) {
            adjacentList.Add(node, new SortedSet<int>());
        }

        public void AddEdge(int node1, int node2) {
            if (adjacentList.ContainsKey(node1) && adjacentList.ContainsKey(node2)) {
                adjacentList[node1].Add(node2);
                adjacentList[node2].Add(node1);
            }
        }

        public void showConnections()
        {
            foreach(var item in adjacentList) {
                SortedSet<int> nodeConnections = adjacentList[item.Key];
                StringBuilder connections = new StringBuilder();
                foreach(int edge in nodeConnections) {
                    connections.Append(edge).Append(" ");
                }
                Console.WriteLine(item.Key + "-->" + connections);
            }
        }
        
    }

    class Program {
        static void Main(string[] args){

            Graph graph = new Graph();
            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddEdge(3, 1);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 2);
            graph.AddEdge(4, 5);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 0);
            graph.AddEdge(0, 2);
            graph.AddEdge(6, 5);
            graph.showConnections();
            
            
        }
        
    }

}
