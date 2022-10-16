using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        static public int[] aaraytestCase = new int[] { 4, 5, 51, 52, 1, 0, 6, 7, 8, 9 };
        static private double radius = 10;
        static public int speedDraw = 1000;
        static public int firstNumber = 50;

        //Инициализируем объект, хранящий данные для графического представления дерева
        //static public GeometryGraph ClassActualTree = new GeometryGraph();
        //static public GeometryGraph Tree1 = new GeometryGraph();
        //static public GeometryGraph Tree2 = new GeometryGraph();
        //static public GeometryGraph Tree3 = new GeometryGraph();
        //static public GeometryGraph Tree4 = new GeometryGraph();
        //static public GeometryGraph Tree5 = new GeometryGraph();
        //static public GeometryGraph Tree6 = new GeometryGraph();
        //static public GeometryGraph[] treeNode = new GeometryGraph[5];


        //static private AVL ClassAVLTreeActual = new AVL();
        //static private AVL ClassAVLTree1 = new AVL();
        //static private AVL ClassAVLTree2 = new AVL();
        //static private AVL ClassAVLTree3 = new AVL();
        //static private AVL ClassAVLTree4 = new AVL();
        //static private AVL ClassAVLTree5 = new AVL();
        //static private AVL ClassAVLTree6 = new AVL();


        static public List<GeometryGraph> MainTree = new List<GeometryGraph>();
        static public List<AVL> listClassAVLTree = new List<AVL>();

        public MainForm()
        {
            InitializeComponent();

            MainTree.Add(new GeometryGraph());
            listClassAVLTree.Add(new AVL());

            //for (int i = 0; i < listClassAVLTree.Count; i++)
            {
                Add(firstNumber, listClassAVLTree[0]);
                ConnectTreeAndDraw(listClassAVLTree[0], MainTree[0]);
            }
        }

        private void buttonAddNode_Click(object sender, EventArgs e)
        {


            if (textBoxAddNode.Text != "")
            {
                for (int i = 0; i < listClassAVLTree.Count; i++)
                {
                    Add(firstNumber, listClassAVLTree[i]);
                    ConnectTreeAndDraw(listClassAVLTree[i], MainTree[i]);
                }
                Add(int.Parse(textBoxAddNode.Text), listClassAVLTree[0]);
            }
            textBoxAddNode.Text = "";
            ConnectTreeAndDraw(listClassAVLTree[0], MainTree[0]);

            panelDrawTree1.Refresh();

        }

        private void ConnectTreeAndDraw(AVL ClassTree, GeometryGraph Tree)
        {
            Tree.Edges.Clear();
            Tree.Nodes.Clear();

            if (ClassTree.root == null)
            {
                //Console.WriteLine("Tree is empty");
                return;
            }
            DrawNode(ClassTree.root, Tree);
            DrawNodeConnections(ClassTree.root, Tree);
            //Tree = null;
            //Зададим основные настройки макета
            var settings = new SugiyamaLayoutSettings
            {
                //Установим стиль отображения рёбер
                EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.StraightLine }
            };
            //Создадим макет с заданными настройками из данных объекта
            var layout = new LayeredLayout(Tree, settings);
            layout.Run();
            //Tree1 = Tree;
            //Tree2 = Tree;
            //Перерисуем панель, где отображается дерево
            //panel.Refresh();
        }

        private void DrawNode(NodeTree current, GeometryGraph treeA)
        {
            if (current != null)
            {
                DrawNode(current.right, treeA);
                DrawNode(current.left, treeA);
                //Console.Write("({0}) ", current.data);
                DrawHelpers.AddNode(current.data.ToString(), treeA, radius);
            }
        }
        private void DrawNodeConnections(NodeTree current, GeometryGraph treeA)
        {
            if (current != null)
            {
                DrawNodeConnections(current.left, treeA);
                DrawNodeConnections(current.right, treeA);
                if (current.left != null)
                {
                    treeA.Edges.Add(new Edge(treeA.FindNodeByUserData(current.left.data.ToString()), treeA.FindNodeByUserData(current.data.ToString())));
                }

            }
            if (current != null)
            {
                DrawNodeConnections(current.left, treeA);
                DrawNodeConnections(current.right, treeA);
                if (current.right != null)
                {
                    treeA.Edges.Add(new Edge(treeA.FindNodeByUserData(current.right.data.ToString()), treeA.FindNodeByUserData(current.data.ToString())));
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Tree1.Edges.Clear();
            //DrawHelpers.ClearNode(Tree1);
            //if (textBoxDeleteNode.Text != "")
            //{
            //    Delete(int.Parse(textBoxDeleteNode.Text), ClassAVLTree1);
            //    Delete(int.Parse(textBoxDeleteNode.Text), ClassAVLTree2);
            //    Delete(int.Parse(textBoxDeleteNode.Text), ClassAVLTree3);
            //}
            ////ClassAVLTree.DisplayTree();
            ////AVLTree = null;
            ////Очистим панель с графическим представлением дерева
            //panelDrawTree1.CreateGraphics();
            //textBoxDeleteNode.Text = "";
            ////Перерисуем панель, где отображается дерево
            //DisplayTreeDraw(ClassAVLTree1, panelDrawTree1, Tree1);
            //panelDrawTree1.Refresh();
        }



        private void panelDrawTree_SizeChanged(object sender, EventArgs e)
        {
            //Перерисуем дерево, если размер панели визуального представления изменился
            //panelDrawTree1.Invalidate();
            //panelDrawTree2.Invalidate();
        }
        ////////////////////////////////////////////////////////////////////////
        public void Add(int data, AVL avltree)
        {
            NodeTree newItem = new NodeTree(data);
            if (avltree.root == null)
            {
                avltree.root = newItem;
            }
            else
            {
                avltree.root = RecursiveInsert(avltree.root, newItem);
                //DisplayTreeDraw(ClassAVLTree3, Tree3);
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
        public void Delete(int target, AVL avltree)
        {//and here
            avltree.root = Delete(avltree.root, target);
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
        public void Find(int key, AVL avltree)
        {
            if (Find(key, avltree.root).data == key)
            {
                //Console.WriteLine("{0} was found!", key);
            }
            else
            {
                //Console.WriteLine("Nothing found!");
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
            Console.WriteLine("--------------RotateRR--------------");
            NodeTree pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;

            return pivot;
        }
        private NodeTree RotateLL(NodeTree parent)
        {
            Console.WriteLine("--------------RotateLL--------------");
            NodeTree pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;

            return pivot;
        }
        private NodeTree RotateLR(NodeTree parent)
        {
            Console.WriteLine("--------------RotateLR--------------");
            NodeTree pivot = parent.left;


            //parent.left = RotateRR(pivot);
            NodeTree pivot2 = pivot.right;
            pivot.right = pivot2.left;
            pivot2.left = pivot;
            parent.left = pivot2;

            MainTree.Add(new GeometryGraph());
            listClassAVLTree.Add(new AVL());
            listClassAVLTree[listClassAVLTree.Count - 1] = listClassAVLTree[0];
            ConnectTreeAndDraw(listClassAVLTree[listClassAVLTree.Count - 1], MainTree[listClassAVLTree.Count - 1]);

            //return RotateLL(parent);
            NodeTree pivot3 = parent.left;
            parent.left = pivot3.right;
            pivot3.right = parent;

            //MainTree.Add(new GeometryGraph());
            //listClassAVLTree.Add(new AVL());
            //listClassAVLTree[listClassAVLTree.Count - 1] = listClassAVLTree[0];
            //ConnectTreeAndDraw(listClassAVLTree[listClassAVLTree.Count - 1], MainTree[listClassAVLTree.Count - 1]);

            return pivot3;

        }
        private NodeTree RotateRL(NodeTree parent)
        {
            Console.WriteLine("--------------RotateRL--------------");
            NodeTree pivot = parent.right;

            //parent.right = RotateLL(pivot);
            NodeTree pivot2 = pivot.left;
            pivot.left = pivot2.right;
            pivot2.right = pivot;
            parent.right = pivot2;

            MainTree.Add(new GeometryGraph());
            listClassAVLTree.Add(new AVL());
            listClassAVLTree[listClassAVLTree.Count - 1] = listClassAVLTree[0];
            ConnectTreeAndDraw(listClassAVLTree[listClassAVLTree.Count - 1], MainTree[listClassAVLTree.Count - 1]);

            //return RotateRR(parent);
            NodeTree pivot3 = parent.right;
            parent.right = pivot3.left;
            pivot3.left = parent;
            return pivot3;
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


        }
        private void panelDrawTree_Paint(object sender, PaintEventArgs e)
        {
            //При каждой отрисовке панели также отобразим на ней дерево  
            for (int i = listClassAVLTree.Count-1; i > -1 ; i--)
            {
                e.Graphics.DrawRectangle(new Pen(Color.White, this.Height / 1), 0, 1, this.Width, this.Height / 1);
                if (MainTree[i] != null) DrawHelpers.DrawFromGraph(panelDrawTree1.ClientRectangle, MainTree[i], e.Graphics);
                System.Threading.Thread.Sleep(speedDraw);
            }

        }

        private void buttonTestCase_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < aaraytestCase.Length; j++)
                {
                    Add(aaraytestCase[j], listClassAVLTree[i]);
                }
                ConnectTreeAndDraw(listClassAVLTree[i], MainTree[i]);
            }
            panelDrawTree1.Refresh();
        }
    }
}