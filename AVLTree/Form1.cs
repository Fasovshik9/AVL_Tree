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
        static private double radius = 10;
        static public int speedDraw = 10;

        //Инициализируем объект, хранящий данные для графического представления дерева
        static public GeometryGraph ClassActualTree = new GeometryGraph();
        static public GeometryGraph Tree1 = new GeometryGraph();
        static public GeometryGraph Tree2 = new GeometryGraph();
        static public GeometryGraph Tree3 = new GeometryGraph();
        static public GeometryGraph Tree4 = new GeometryGraph();
        static public GeometryGraph Tree5 = new GeometryGraph();
        static public GeometryGraph Tree6 = new GeometryGraph();


        static private AVL ClassAVLTreeActual = new AVL();
        static private AVL ClassAVLTree1 = new AVL();
        static private AVL ClassAVLTree2 = new AVL();
        static private AVL ClassAVLTree3 = new AVL();
        static private AVL ClassAVLTree4 = new AVL();
        static private AVL ClassAVLTree5 = new AVL();
        static private AVL ClassAVLTree6 = new AVL();

        public MainForm()
        {
            //GeometryGraph[] treeNode = new GeometryGraph[5];
            //for (int counter = 0; counter < 5; counter++)
            //{
            //    treeNode[counter] = new GeometryGraph();
            //}
            //AVL[] treeNodeAVL = new AVL[5];
            //for (int counter = 0; counter < 5; counter++)
            //{
            //    treeNode[counter] = new GeometryGraph();
            //}

            InitializeComponent();
            Add(5, ClassAVLTree1);
            Add(1, ClassAVLTree1);
            Add(8, ClassAVLTree1);
            Add(6, ClassAVLTree1);
            Add(10, ClassAVLTree1);

            
            Add(1, ClassAVLTree4);
            Add(2, ClassAVLTree4);
            Add(3, ClassAVLTree4);
            //ClassAVLTree2 = ClassAVLTree1;
            //ClassAVLTree3 = ClassAVLTree1;
            //ClassAVLTree4 = ClassAVLTree1;

            ConnectTreeAndDraw(ClassAVLTree1, Tree1);
            ConnectTreeAndDraw(ClassAVLTree2, Tree2);
            ConnectTreeAndDraw(ClassAVLTree3, Tree3);
            ConnectTreeAndDraw(ClassAVLTree4, Tree4);
        }

        private void buttonAddNode_Click(object sender, EventArgs e)
        {
            
            if (textBoxAddNode.Text != "")
            {
                Add(int.Parse(textBoxAddNode.Text), ClassAVLTree4);
            }
            textBoxAddNode.Text = "";
            ConnectTreeAndDraw(ClassAVLTree4, Tree4);
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

        //Вспомогательная функция создания макета и наполнения данных для графического представления дерева
        //public GeometryGraph CreateAndLayoutGraph(GeometryGraph Tree, Panel panel, GeometryGraph AVLTree)
        //{
        //    //Зададим основные настройки макета
        //    var settings = new SugiyamaLayoutSettings
        //    {
        //        //Установим стиль отображения рёбер
        //        EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.StraightLine }
        //    };
        //    //Создадим макет с заданными настройками из данных объекта
        //    var layout = new LayeredLayout(Tree, settings);
        //    layout.Run();
        //    AVLTree1 = Tree;
        //    AVLTree2 = Tree;
        //    //Перерисуем панель, где отображается дерево
        //    panel.Refresh();
        //    return Tree;
        //}
        //private void DrawRoot11(NodeTree current)
        //{
        //    if (current != null)
        //    {
        //        if (current.left != null)
        //        {
        //            Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(current.left.data.ToString()), Tree.FindNodeByUserData(current.data.ToString())));
        //        }
        //    }
        //    AVLTree = CreateAndLayoutGraph(Tree);
        //}

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
            //DisplayTreeDraw(ClassAVLTree2, Tree2);
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
            return pivot;

            //return RotateLL(parent);
            NodeTree pivot3 = parent.left;
            parent.left = pivot3.right;
            pivot3.right = parent;
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
            //if (Tree1 != null) DrawHelpers.DrawFromGraph(panelDrawTree1.ClientRectangle, Tree1, e.Graphics);
            //System.Threading.Thread.Sleep(speedDraw);
            //e.Graphics.DrawRectangle(new Pen(Color.White, this.Height / 1), 0, 1, this.Width, this.Height / 1);
            //if (Tree2 != null) DrawHelpers.DrawFromGraph(panelDrawTree1.ClientRectangle, Tree2, e.Graphics);
            //System.Threading.Thread.Sleep(speedDraw);
            //e.Graphics.DrawRectangle(new Pen(Color.White, this.Height / 1), 0, 1, this.Width, this.Height / 1);
            //if (Tree3 != null) DrawHelpers.DrawFromGraph(panelDrawTree1.ClientRectangle, Tree3, e.Graphics);
            //System.Threading.Thread.Sleep(speedDraw);
            //e.Graphics.DrawRectangle(new Pen(Color.White, this.Height / 1), 0, 1, this.Width, this.Height / 1);
            if (Tree4 != null) DrawHelpers.DrawFromGraph(panelDrawTree1.ClientRectangle, Tree4, e.Graphics);
        }



    }

}