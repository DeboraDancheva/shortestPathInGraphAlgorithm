using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortestPathInGraphAlgorithm
{
   public class Graph
    {
        public Node Root;
        public Node EndNode;
        public List<Node> AllNodes { get; set; } = new List<Node>();
        public List<Arc> AllArcs { get; set; } = new List<Arc>();
        public Node SelectRoot(int index)
        {
            Root = AllNodes.Where(x => x.Index == index).Single();
                return Root;
        }
        public Node SelectEndNode(int index)
        {
            EndNode = AllNodes.Where(x => x.Index == index).Single();
                return EndNode;
        }

        public Node CreateNode(int index,Point location)
        {
            var n = new Node(index,location);
            AllNodes.Add(n);
            return n;
        }
        
        public int[,] CreateAdjMatrix()
        {
            int[,] adj = new int[AllNodes.Count, AllNodes.Count];

            for (int i = 0; i < AllNodes.Count; i++)
            {
                Node n1 = AllNodes[i];

                for (int j = 0; j < AllNodes.Count; j++)
                {
                    Node n2 = AllNodes[j];

                    var arc = n1.Arcs.FirstOrDefault(a => a.Child == n2);

                    if (arc != null)
                    {
                        adj[i, j] = arc.Weigth;
                    }
                }
            }
            return adj;
        }
        public bool CheckIfArcЕxists(List<Node> nodes)
        {
            if (this.AllArcs.Any(x => x.Parent == nodes[0] && x.Child == nodes[1]) || this.AllArcs.Any(x => x.Parent == nodes[1] && x.Child == nodes[0]))
                return true;
            return false;
        }
        public bool CheckIfAllNodesAreConected()
        {
            foreach( var node in this.AllNodes)
            {
                if (node.Arcs.Count == 0)
                    return false;               
            }
            return true;
        }
    }
}
