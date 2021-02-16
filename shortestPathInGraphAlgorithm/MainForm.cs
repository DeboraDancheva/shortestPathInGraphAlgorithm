using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shortestPathInGraphAlgorithm
{
    public partial class MainForm : Form
    {
        List<Node> selectedNodes = new List<Node>();
        List<Point> clickLocation = new List<Point>();
        List<Shape> elementsOfGraph = new List<Shape>();

        Graph graph = new Graph();
        int nodeNum = 1;

        bool buttonDrawNodeIsClicked = false;
        bool buttonDrawArcIsClicked = false;
        bool selectSource = false;
        bool selectEndNode = false;
        
        public MainForm()
        {
            InitializeComponent();
            textBoxCalculation.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            buttonSource.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            listViewNodes.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            buttonEndNode.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var element in elementsOfGraph)
            {
                element.Paint(e.Graphics);
            }
        }

        private void buttonDrawArc_Click(object sender, EventArgs e)
        {
            buttonDrawArcIsClicked = true;
            buttonDrawNodeIsClicked = false;
        }

        private void buttonDrawNode_Click(object sender, EventArgs e)
        {
            buttonDrawNodeIsClicked = true;
            buttonDrawArcIsClicked = false;
        }

        //Drawing Node 
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (buttonDrawNodeIsClicked && graph.AllNodes.Count<10)
            {
                Brush brush = new System.Drawing.SolidBrush(Color.Blue);
                Graphics gr = this.CreateGraphics();
                Node node = graph.CreateNode(nodeNum, new Point(e.X, e.Y));
                node.Paint(gr);
                elementsOfGraph.Add(node);
                nodeNum++;
            }
            else if(buttonDrawNodeIsClicked && graph.AllNodes.Count >= 10)
            {
                MessageBox.Show("The limit of nodes is 10!");
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Drawing arc if two clicks are executed
            if ((e.Button == System.Windows.Forms.MouseButtons.Right)
               && (CheckIfNodeIsSelected(e.Location))
               && buttonDrawArcIsClicked)
            {
                if (selectedNodes.Count > 1 && graph.CheckIfArcЕxists(selectedNodes))
                {
                    MessageBox.Show("Arc already exists!");
                    selectedNodes.Clear();
                    clickLocation.Clear();
                }

                else
                if (selectedNodes.Count == 2)
                {
                    using (Graphics gr = this.CreateGraphics())
                    {
                        Arc arc = null;
                        ArcWeightInputForm enterWeightForm = new ArcWeightInputForm();
                        enterWeightForm.ShowDialog();

                        if (enterWeightForm.DialogResult == DialogResult.OK)
                        {
                            arc = new Arc(selectedNodes[0], selectedNodes[1], Color.Yellow, clickLocation, enterWeightForm.Weight);
                            graph.AllArcs.Add(arc);
                            enterWeightForm.Close();
                        }

                        elementsOfGraph.Add(arc);
                        selectedNodes[0].AddArc(arc);
                        arc.Paint(gr);
                        selectedNodes.Clear();
                        clickLocation.Clear();
                    }
                }
            }
            //Select node as  Source
            else if ((e.Button == System.Windows.Forms.MouseButtons.Left) && (selectSource))
                CheckIfNodeIsSelected(e.Location);
            //Select node as  EndNode
            else if ((e.Button == System.Windows.Forms.MouseButtons.Left) && (selectEndNode))
                CheckIfNodeIsSelected(e.Location);
        }

        private bool CheckIfNodeIsSelected(Point point)
        {
            foreach (Node node in graph.AllNodes)
            {
                if (node.Contains(point) && !selectSource && !selectEndNode)
                {
                    selectedNodes.Add(node);
                    clickLocation.Add(point);
                    return true;
                }
                if (node.Contains(point) && selectSource && !selectEndNode)
                    graph.SelectRoot(node.Index);
                if (node.Contains(point) && !selectSource && selectEndNode)
                    graph.SelectEndNode(node.Index);
            }
            return false;
        }

        private void FillListView()
        {
            foreach (var node in graph.AllNodes)
            {
                string[] row = new string[3];
                row[0] = node.Index.ToString();

                if (node.ShortestPath != int.MaxValue)
                    row[1] = node.ShortestPath.ToString();
                else
                    row[1] = "∞";

                if (node.PreviousNode != null)
                    row[2] = node.PreviousNode.Index.ToString();
                else
                    row[2] = "-";

                var listViewItem = new ListViewItem(row);
                listViewNodes.Items.Add(listViewItem);
                listViewItem.Font = new System.Drawing.Font("Century Gothic", 12, System.Drawing.FontStyle.Bold);
            }
        }

        private void EditListView(Node node)
        {
            string[] row = new string[3];
            row[0] = node.Index.ToString();

            if (node.ShortestPath != int.MaxValue)
                listViewNodes.Items[node.Index - 1].SubItems[1].Text = node.ShortestPath.ToString();
            else
                row[1] = "∞";

            if (node.PreviousNode != null)
                listViewNodes.Items[node.Index - 1].SubItems[2].Text = node.PreviousNode.Index.ToString();
            else
                row[2] = "-";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (graph.Root != null && graph.EndNode != null && graph.AllNodes.Count <= 10 && graph.CheckIfAllNodesAreConected())
            {
                selectSource = false;
                selectEndNode = false;
                FillListView();
                Djikstra(graph, graph.CreateAdjMatrix(), graph.Root.Index);
            }
            else
            {
                MessageBox.Show("You need to finish graph");
                selectSource = false;
                selectEndNode = false;
            }
        }

        private void Djikstra(Graph graph, int[,] graphMatrix, int source)
        {
            Node[] nodes = graph.AllNodes.ToArray();

            bool[] finilizedNodes = new bool[graph.AllNodes.Count];

            //Initialize all paths as infiniti and all nodes as unvisited
            for (int i = 0; i < graph.AllNodes.Count; i++)
            {
                nodes[i].ShortestPath = int.MaxValue;
                finilizedNodes[i] = false;
            }

            nodes[source - 1].ShortestPath = 0;
            nodes[source - 1].PreviousNode = null;

            for (int count = 0; count < graph.AllNodes.Count - 1; count++)
            {
                int indexOfShortestPath = MinDistance(nodes, finilizedNodes);
                //Changing the color of the current Node that is being analized
                graph.AllNodes.ElementAt(indexOfShortestPath).IsChecked = true;
                Invalidate();
                Update();
                Thread.Sleep(1500);

                finilizedNodes[indexOfShortestPath] = true;

                for (int i = 0; i < graph.AllNodes.Count; i++)
                {
                    if (!finilizedNodes[i] &&
                        graphMatrix[indexOfShortestPath, i] != 0 &&
                        nodes[indexOfShortestPath].ShortestPath != int.MaxValue &&
                        nodes[indexOfShortestPath].ShortestPath + graphMatrix[indexOfShortestPath, i] < nodes[i].ShortestPath)
                    {
                        textBoxCalculation.Text = $" {nodes[indexOfShortestPath].ShortestPath} + {graphMatrix[indexOfShortestPath, i]} < {nodes[i].ShortestPath} ?";
                        nodes[i].ShortestPath = nodes[indexOfShortestPath].ShortestPath + graphMatrix[indexOfShortestPath, i];
                        nodes[i].PreviousNode = nodes[indexOfShortestPath];
                        EditListView(nodes[i]);
                        //Changing the color of the current Arc which is being analized
                        Node parent = graph.AllNodes.ElementAt(indexOfShortestPath);
                        Node child = graph.AllNodes.ElementAt(indexOfShortestPath).Arcs.Single(x => x.Child.Index == i + 1).Child;

                        if (graph.AllArcs.SingleOrDefault(x => x.Parent == parent && x.Child == child) != null)
                            graph.AllArcs.SingleOrDefault(x => x.Parent == parent && x.Child == child).IsChecked = true;
                        if (graph.AllArcs.SingleOrDefault(x => x.Parent == child && x.Child == parent) != null)
                            graph.AllArcs.SingleOrDefault(x => x.Parent == child && x.Child == parent).IsChecked = true;

                        textBoxCalculation.BackColor = Color.Green;
                        Invalidate();
                        Update();
                        Thread.Sleep(3000);
                        // Returning the color of the current Arc which was analized

                        if (graph.AllArcs.SingleOrDefault(x => x.Parent == parent && x.Child == child) != null)
                            graph.AllArcs.SingleOrDefault(x => x.Parent == parent && x.Child == child).IsChecked = false;

                        if (graph.AllArcs.SingleOrDefault(x => x.Parent == child && x.Child == parent) != null)
                            graph.AllArcs.SingleOrDefault(x => x.Parent == child && x.Child == parent).IsChecked = false;

                        textBoxCalculation.BackColor = Color.White;
                        textBoxCalculation.Text = String.Empty;
                        Invalidate();
                        Update();
                        Thread.Sleep(3000);
                    }

                    else if (!finilizedNodes[i] &&
                        graphMatrix[indexOfShortestPath, i] != 0 &&
                        nodes[indexOfShortestPath].ShortestPath != int.MaxValue &&
                        nodes[indexOfShortestPath].ShortestPath + graphMatrix[indexOfShortestPath, i] >= nodes[i].ShortestPath)
                    {
                        textBoxCalculation.Text = $" {nodes[indexOfShortestPath].ShortestPath} + {graphMatrix[indexOfShortestPath, i]} < {nodes[i].ShortestPath} ?";
                        Node parent = graph.AllNodes.ElementAt(indexOfShortestPath);
                        Node child = graph.AllNodes.ElementAt(indexOfShortestPath).Arcs.Single(x => x.Child.Index == i + 1).Child;
                        //Changing the color of the current Arc which is being analized
                        if (graph.AllArcs.SingleOrDefault(x => x.Parent == parent && x.Child == child) != null)
                            graph.AllArcs.Single(x => x.Parent == parent && x.Child == child).IsChecked = true;

                        if (graph.AllArcs.SingleOrDefault(x => x.Parent == child && x.Child == parent) != null)
                            graph.AllArcs.SingleOrDefault(x => x.Parent == child && x.Child == parent).IsChecked = true;

                        textBoxCalculation.BackColor = Color.Red;
                        Invalidate();
                        Update();
                        Thread.Sleep(3000);
                        //Returning the color of the current Arc which was analized

                        if (graph.AllArcs.SingleOrDefault(x => x.Parent == parent && x.Child == child) != null)
                            graph.AllArcs.SingleOrDefault(x => x.Parent == parent && x.Child == child).IsChecked = false;

                        if (graph.AllArcs.SingleOrDefault(x => x.Parent == child && x.Child == parent) != null)
                            graph.AllArcs.SingleOrDefault(x => x.Parent == child && x.Child == parent).IsChecked = false;

                        textBoxCalculation.BackColor = Color.White;
                        textBoxCalculation.Text = String.Empty;
                        Invalidate();
                        Update();
                        Thread.Sleep(3000);
                    }
                }
                //Marking Node as finilized
                graph.AllNodes.ElementAt(indexOfShortestPath).InnerFillColor = Color.Red;
                Invalidate();
                Update();
                Thread.Sleep(1000);
            }
            //nodes.Single(x => x.InnerFillColor != Color.Red).InnerFillColor = Color.Red;
            graph.AllNodes.SingleOrDefault(x => x.InnerFillColor != Color.Red).IsChecked = true;
            graph.AllNodes.SingleOrDefault(x => x.InnerFillColor != Color.Red).InnerFillColor = Color.Red;
            
            Invalidate();
            Update();
            Thread.Sleep(1000);
            //Drawing shortest path of required node
            Node curNode = nodes[graph.EndNode.Index - 1];
            do
            {
                if(graph.AllArcs.SingleOrDefault(x => x.Parent == curNode && x.Child == curNode.PreviousNode) != null)
                    graph.AllArcs.SingleOrDefault(x => x.Parent == curNode && x.Child == curNode.PreviousNode).IsChecked = true;
                
                if (graph.AllArcs.SingleOrDefault(x => x.Parent == curNode.PreviousNode && x.Child == curNode) != null)
                    graph.AllArcs.SingleOrDefault(x => x.Parent == curNode.PreviousNode && x.Child == curNode).IsChecked = true;
                
                curNode = curNode.PreviousNode;
            } while (curNode.PreviousNode != null);
            Invalidate();
            Update();
            Thread.Sleep(1000);
        }

        private int MinDistance(Node[] nodes, bool[] finilizedNodes)
        {
            int min = int.MaxValue, min_index = -1;

            for (int i = 0; i < graph.AllNodes.Count; i++)
            {
                if (finilizedNodes[i] == false && nodes[i].ShortestPath <= min)
                {
                    min = nodes[i].ShortestPath;
                    min_index = i;
                }
            }
            return min_index;
        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            buttonDrawArcIsClicked = false;
            buttonDrawNodeIsClicked = false;
            selectSource = true;
            selectEndNode = false;
        }

        private void buttonEndNode_Click(object sender, EventArgs e)
        {
            selectEndNode = true;
            selectSource = false;
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            elementsOfGraph.Clear();
            graph.AllNodes.Clear();
            graph.AllArcs.Clear();
            graph.Root = null;
            graph.EndNode = null;
            Invalidate();
            nodeNum = 1;
            listViewNodes.Items.Clear();

        }
    }

}