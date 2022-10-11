using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Msagl.Core.Geometry;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Layout.Layered;
using static AVLTree.MainForm.AVL;

namespace AVLTree
{
    public partial class MainForm : Form
    {
        //Определим объект, который будет хранить данные для графического представления дерева
        static public GeometryGraph AVLTree;
        //private List<int> massAVL = new List<int>() { 1, 2, 3 };
        //public List<int> massAVL = new List<int>();
        static private AVL ClassAVLTree = new AVL();
        static private AVL ClassAVLTreeFotCheck = new AVL();

        static Panel PanelRef = new Panel();


        //Инициализируем объект, хранящий данные для графического представления дерева
        static public GeometryGraph Tree = new GeometryGraph();
        static private double radius = 10;

        public MainForm()
        {
            InitializeComponent();
            ClassAVLTree.Add(7);
            ClassAVLTree.Add(5);
            ClassAVLTree.Add(9);
            ClassAVLTree.Add(10);
            PanelRef = panelDrawTree;
            
            DisplayTreeDraw();
            

            AVLTree = CreateAndLayoutGraph(Tree);
            //panelDrawTree.CreateGraphics();
            //panelDrawTree.Refresh();
        }

        private void buttonAddNode_Click(object sender, EventArgs e)
        {
            //DrawHelpers.ClearNode(Tree);
            Tree.Edges.Clear();
            Tree.Nodes.Clear();

            if (textBoxAddNode.Text != "")
            {
                ClassAVLTree.Add(int.Parse(textBoxAddNode.Text));
            }
            DisplayTreeDraw();
            //DrawRoot11(ClassAVLTree.root);
            AVLTree = null;
            //Очистим панель с графическим представлением дерева
            panelDrawTree.CreateGraphics();
            //Вызовем вспомогательную функцию для графического представления дерева
            AVLTree = CreateAndLayoutGraph(Tree);
            textBoxAddNode.Text = "";   
        }
        //Вспомогательная функция создания макета и наполнения данных для графического представления дерева
        public GeometryGraph CreateAndLayoutGraph(GeometryGraph tree)
        {
            //Зададим основные настройки макета
            var settings = new SugiyamaLayoutSettings
            {
                //Установим стиль отображения рёбер
                EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.StraightLine }
            };
            //Создадим макет с заданными настройками из данных объекта
            var layout = new LayeredLayout(tree, settings);
            layout.Run();
            AVLTree = tree;
            
            //Перерисуем панель, где отображается дерево
            panelDrawTree.Refresh();
            return Tree;
        }
        private void DrawRoot11(NodeTree current)
        {
            if (current != null)
            {
                if (current.left != null)
                {
                    Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(current.left.data.ToString()), Tree.FindNodeByUserData(current.data.ToString())));
                }
            }
            AVLTree = CreateAndLayoutGraph(Tree);
        }
        private void DisplayTreeDraw()
        {
            if (ClassAVLTree.root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            DrawNode(ClassAVLTree.root);
            DrawNodeConnections(ClassAVLTree.root);
        }
        private void DrawNode(NodeTree current)
        {
            if (current != null)
            {
                DrawNode(current.right);
                DrawNode(current.left);
                Console.Write("({0}) ", current.data);
                DrawHelpers.AddNode(current.data.ToString(), Tree, radius);
            }
        }
        private void DrawNodeConnections(NodeTree current)
        {
            if (current != null)
            {
                //System.Threading.Thread.Sleep(1);
                //AVLTree = CreateAndLayoutGraph(Tree);
                DrawNodeConnections(current.left);
                DrawNodeConnections(current.right);
                if (current.left != null)
                {
                    Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(current.left.data.ToString()), Tree.FindNodeByUserData(current.data.ToString())));
                }

            }
            if (current != null)
            {
                DrawNodeConnections(current.left);
                DrawNodeConnections(current.right);
                if (current.right != null)
                {
                    Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(current.right.data.ToString()), Tree.FindNodeByUserData(current.data.ToString())));
                }

            }
        }

        private void DrawRoot(NodeTree current)
        {
            if (current.left != null)
            {
                Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(current.left.data.ToString()), Tree.FindNodeByUserData(current.data.ToString())));
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Tree.Edges.Clear();
            DrawHelpers.ClearNode(Tree);
            if (textBoxDeleteNode.Text != "")
            {
                ClassAVLTree.Delete(int.Parse(textBoxDeleteNode.Text));
            }
            //ClassAVLTree.DisplayTree();
            AVLTree = null;
            //Очистим панель с графическим представлением дерева
            panelDrawTree.CreateGraphics();
            //Вызовем вспомогательную функцию для графического представления дерева
            AVLTree = CreateAndLayoutGraph(Tree);
            textBoxDeleteNode.Text = "";
            //Перерисуем панель, где отображается дерево
            panelDrawTree.Refresh();
        }

        private void panelDrawTree_Paint(object sender, PaintEventArgs e)
        {
            //При каждой отрисовке панели также отобразим на ней дерево
            if (AVLTree != null) DrawHelpers.DrawFromGraph(panelDrawTree.ClientRectangle, AVLTree, e.Graphics);
        }

        private void panelDrawTree_SizeChanged(object sender, EventArgs e)
        {
            //Перерисуем дерево, если размер панели визуального представления изменился
            panelDrawTree.Invalidate();
        }

        ///////////////////////////////////////////////////////

        public class AVL
        {
            public class NodeTree
            {
                public int data;
                public NodeTree left;
                public NodeTree right;
                public NodeTree(int data)
                {
                    this.data = data;
                }
            }
            public NodeTree root;
            

            public AVL()
            {
            }
            public void Add(int data)
            {
                NodeTree newItem = new NodeTree(data);
                if (root == null)
                {
                    root = newItem;
                }
                else
                {
                    root = RecursiveInsert(root, newItem);
                }
            }
            private NodeTree RecursiveInsert(NodeTree current, NodeTree n)
            {
                if (current == null)
                {
                    current = n;
                    return current;
                }
                else if (n.data < current.data)
                {
                    current.left = RecursiveInsert(current.left, n);
                    current = balance_tree(current);
                }
                else if (n.data > current.data)
                {
                    current.right = RecursiveInsert(current.right, n);
                    current = balance_tree(current);
                }
                return current;
            }
            private NodeTree balance_tree(NodeTree current)
            {
                int b_factor = balance_factor(current);
                if (b_factor > 1)
                {
                    if (balance_factor(current.left) > 0)
                    {
                        current = RotateLL(current);
                    }
                    else
                    {
                        current = RotateLR(current);
                    }
                }
                else if (b_factor < -1)
                {
                    if (balance_factor(current.right) > 0)
                    {
                        current = RotateRL(current);
                    }
                    else
                    {

                        current = RotateRR(current);
                    }
                }
                return current;
            }
            public void Delete(int target)
            {//and here
                root = Delete(root, target);
            }
            private NodeTree Delete(NodeTree current, int target)
            {
                NodeTree parent;
                if (current == null)
                { return null; }
                else
                {
                    //left subtree
                    if (target < current.data)
                    {
                        current.left = Delete(current.left, target);
                        if (balance_factor(current) == -2)//here
                        {
                            if (balance_factor(current.right) <= 0)
                            {
                                current = RotateRR(current);
                            }
                            else
                            {
                                current = RotateRL(current);
                            }
                        }
                    }
                    //right subtree
                    else if (target > current.data)
                    {
                        current.right = Delete(current.right, target);
                        if (balance_factor(current) == 2)
                        {
                            if (balance_factor(current.left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else
                            {
                                current = RotateLR(current);
                            }
                        }
                    }
                    //if target is found
                    else
                    {
                        if (current.right != null)
                        {
                            //delete its inorder successor
                            parent = current.right;
                            while (parent.left != null)
                            {
                                parent = parent.left;
                            }
                            current.data = parent.data;
                            current.right = Delete(current.right, parent.data);
                            if (balance_factor(current) == 2)//rebalancing
                            {
                                if (balance_factor(current.left) >= 0)
                                {
                                    current = RotateLL(current);
                                }
                                else { current = RotateLR(current); }
                            }
                        }
                        else
                        {   //if current.left != null
                            return current.left;
                        }
                    }
                }
                return current;
            }
            public void Find(int key)
            {
                if (Find(key, root).data == key)
                {
                    Console.WriteLine("{0} was found!", key);
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
            private NodeTree Find(int target, NodeTree current)
            {

                if (target < current.data)
                {
                    if (target == current.data)
                    {
                        return current;
                    }
                    else
                        return Find(target, current.left);
                }
                else
                {
                    if (target == current.data)
                    {
                        return current;
                    }
                    else
                        return Find(target, current.right);
                }

            }
            private int max(int l, int r)
            {
                return l > r ? l : r;
            }
            private int getHeight(NodeTree current)
            {
                int height = 0;
                if (current != null)
                {
                    int l = getHeight(current.left);
                    int r = getHeight(current.right);
                    int m = max(l, r);
                    height = m + 1;
                }
                return height;
            }
            private int balance_factor(NodeTree current)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int b_factor = l - r;
                return b_factor;
            }
            private NodeTree RotateRR(NodeTree parent)
            {
                
                NodeTree pivot = parent.right;
                parent.right = pivot.left;
                pivot.left = parent;
                Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(parent.data.ToString()), Tree.FindNodeByUserData(pivot.data.ToString())));
                //Перерисуем панель, где отображается дерево
                System.Threading.Thread.Sleep(1000);
                PanelRef.Refresh();
                ///////////////////////////////////////////
                return pivot;
            }
            private NodeTree RotateLL(NodeTree parent)
            {

                NodeTree pivot = parent.left;
                parent.left = pivot.right;
                pivot.right = parent;
                return pivot;
            }
            private NodeTree RotateLR(NodeTree parent)
            {

                NodeTree pivot = parent.left;
                parent.left = RotateRR(pivot);
                return RotateLL(parent);
            }
            private NodeTree RotateRL(NodeTree parent)
            {

                NodeTree pivot = parent.right;
                parent.right = RotateLL(pivot);
                return RotateRR(parent);
            }
        }
    }

}