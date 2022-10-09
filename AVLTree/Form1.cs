using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Layout.Layered;

namespace AVLTree
{
    public partial class MainForm : Form
    {
        //Определим объект, который будет хранить данные для графического представления дерева
        private GeometryGraph AVLTree;
        private List<int> massAVL = new List<int>() { 1, 2, 3 };
        //public List<int> massAVL = new List<int>();
        static private AVL ClassAVLTree = new AVL();



        //Инициализируем объект, хранящий данные для графического представления дерева
        static private GeometryGraph Tree = new GeometryGraph();
        static private double radius = 10;

        public MainForm()
        {
            InitializeComponent();
            ClassAVLTree.Add(1);
            ClassAVLTree.Add(2);
            ClassAVLTree.Add(3);
            ClassAVLTree.Add(4);
            ClassAVLTree.Add(5);
            ClassAVLTree.DisplayTree();
        }

        private void buttonAddNode_Click(object sender, EventArgs e)
        {
            Tree.Edges.Clear();
            if (textBoxAddNode.Text != "")
            {
                ClassAVLTree.Add(int.Parse(textBoxAddNode.Text));
            }
            ClassAVLTree.DisplayTree();
            AVLTree = null;
            //Очистим панель с графическим представлением дерева
            panelDrawTree.CreateGraphics();
            //Вызовем вспомогательную функцию для графического представления дерева
            AVLTree = CreateAndLayoutGraph();
            textBoxAddNode.Text = "";
            //Перерисуем панель, где отображается дерево
            panelDrawTree.Refresh();
            
        }
        //Вспомогательная функция создания макета и наполнения данных для графического представления дерева
        private GeometryGraph CreateAndLayoutGraph()
        {

            //Установим радиус вершин

            //Добавим в объект каждую вершину из списка смежности
            //foreach (var itam in massAVL)
            {
                //DrawHelpers.AddNode(itam.ToString(), Tree, radius);
            }
            //Добавим в объект каждое ребро из списка смежности
            //foreach (var item in massAVL)
            //{
            //    Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(massAVL[0].ToString()), Tree.FindNodeByUserData(massAVL[1].ToString())));
            //    draw(Tree);
            //    Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(massAVL[0].ToString()), Tree.FindNodeByUserData(massAVL[2].ToString())));
            //    draw(Tree);
            //}
            draw(Tree);
            return Tree;
        }
        private void draw(GeometryGraph tree)
        {
            //Зададим основные настройки макета
            var settings = new SugiyamaLayoutSettings
            {
                //Повернём макет на 180 градусов, чтобы дерево строилось сверху вниз
                //Transformation = PlaneTransformation.Rotation(Math.PI),
                //Установим стиль отображения рёбер
                EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.StraightLine }
            };
            //Создадим макет с заданными настройками из данных объекта
            var layout = new LayeredLayout(tree, settings);
            layout.Run();
            AVLTree = tree;
            System.Threading.Thread.Sleep(100);
            panelDrawTree.Refresh();
        }


        private void button2_Click(object sender, EventArgs e)
        {

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

        ////////////////////////////////////////////////////
        ///
        class AVL
        {
            class Node
            {
                public int data;
                public Node left;
                public Node right;
                public Node(int data)
                {
                    this.data = data;
                }
            }
            Node root;
            public AVL()
            {
            }
            public void Add(int data)
            {
                Node newItem = new Node(data);
                if (root == null)
                {
                    root = newItem;
                }
                else
                {
                    root = RecursiveInsert(root, newItem);
                }
            }
            private Node RecursiveInsert(Node current, Node n)
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
            private Node balance_tree(Node current)
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
            private Node Delete(Node current, int target)
            {
                Node parent;
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
            private Node Find(int target, Node current)
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
            public void DisplayTree()
            {
                if (root == null)
                {
                    Console.WriteLine("Tree is empty");
                    return;
                }
                InOrderDisplayTree(root);
                DisplayTree1(root);
                DisplayTree2(root);
                Console.WriteLine();
            }
            private void DisplayTree1(Node current)
            {
                if (current != null)
                {
                    DisplayTree1(current.left);
                    DisplayTree1(current.right);
                    if (current.left != null)
                    {
                        Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(current.left.data.ToString()), Tree.FindNodeByUserData(current.data.ToString())));
                    }
                }
            }
            private void DisplayTree2(Node current)
            {
                if (current != null)
                {
                    DisplayTree2(current.left);
                    DisplayTree2(current.right);
                    if (current.right != null)
                    {
                        Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(current.right.data.ToString()), Tree.FindNodeByUserData(current.data.ToString())));
                    }
                    
                }
            }
            private void InOrderDisplayTree(Node current)
            {
                if (current != null)
                {
                    InOrderDisplayTree(current.left);
                    InOrderDisplayTree(current.right);

                    Console.Write("({0}) ", current.data);
                    //if ((current.left != null) && (current != null))
                    //{
                    //    Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(current.left.data.ToString()), Tree.FindNodeByUserData(current.data.ToString())));
                    //}
                    //if ((current.right != null) && (current != null))
                    //{
                    //    Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(current.data.ToString()), Tree.FindNodeByUserData(current.right.data.ToString())));
                    //}

                    DrawHelpers.AddNode(current.data.ToString(), Tree, radius);
                }
            }
            private int max(int l, int r)
            {
                return l > r ? l : r;
            }
            private int getHeight(Node current)
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
            private int balance_factor(Node current)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int b_factor = l - r;
                return b_factor;
            }
            private Node RotateRR(Node parent)
            {
                Node pivot = parent.right;
                parent.right = pivot.left;
                pivot.left = parent;
                return pivot;
            }
            private Node RotateLL(Node parent)
            {
                Node pivot = parent.left;
                parent.left = pivot.right;
                pivot.right = parent;
                return pivot;
            }
            private Node RotateLR(Node parent)
            {
                Node pivot = parent.left;
                parent.left = RotateRR(pivot);
                return RotateLL(parent);
            }
            private Node RotateRL(Node parent)
            {
                Node pivot = parent.right;
                parent.right = RotateLL(pivot);
                return RotateRR(parent);
            }
        }
    }

}