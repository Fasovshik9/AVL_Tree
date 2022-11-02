using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Msagl.Core.Geometry;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Layout.Layered;
using static AVLTree.MainForm;
using static AVLTree.MainForm.AVL;

namespace AVLTree
{
    public partial class MainForm : Form
    {
        static public List<int> numberFromFile = new List<int>();
        //ALL
        //static public int[] aaraytestCase = new int[] { 4, 5, 51, 52, 1, 0, 6, 7, 8, 9 };
        //LR
        //static public int[] aaraytestCase = new int[] {50, 4, 5 };
        //RL
        //static public int[] aaraytestCase = new int[] {50, 60, 55};
        //RR
        //static public int[] aaraytestCase = new int[] {50, 55, 60 };
        //LL
        static public int[] aaraytestCase = new int[] {50, 40, 45  };
   

        static private double radius = 10;
        static public int speedDraw = 1000;
        static public int firstNumber = 50;
        static public bool firstStart = true;


        static public List<GeometryGraph> MainTree =  new List<GeometryGraph>();
        static public List<AVL> listClassAVLTree = new List<AVL>();
        static public GeometryGraph MainTreeFirst = new GeometryGraph();


        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddNode_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxAddNode.Text, out int val))
            {
                if ((firstStart == false) && (Find(val, listClassAVLTree[0])))
                {
                    MessageBox.Show("Данное значение уже есть в дереве!", "Error");
                    textBoxAddNode.Text = "";
                }
                else
                {
                    MainTree.Add(new GeometryGraph());
                    listClassAVLTree.Add(new AVL());
                    ConnectTreeAndDraw(listClassAVLTree[0], MainTreeFirst);

                    GeometryGraph MainTreeMain = MainTree[0];
                    AVL listClassAVLTreeMain = listClassAVLTree[0];

                    MainTree = new List<GeometryGraph>();
                    listClassAVLTree = new List<AVL>();

                    MainTree.Add(new GeometryGraph());
                    listClassAVLTree.Add(new AVL());

                    listClassAVLTree[0] = listClassAVLTreeMain;
                    MainTree[0] = MainTreeMain;


                    Add(val, listClassAVLTree[0]);
                    ConnectTreeAndDraw(listClassAVLTree[0], MainTree[0]);

                    panelDrawTree1.Visible = true;

                    textBoxAddNode.Text = "";
                    panelDrawTree1.Refresh();
                    firstStart = false;
                }

            }
            else
            {
                MessageBox.Show("Вы ввели неверное значение","Error");
                textBoxAddNode.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxDeleteNode.Text, out int val))
            {
                if ((firstStart == false) && (Find(val, listClassAVLTree[0])))
                {
                    
                    MainTree.Add(new GeometryGraph());
                    listClassAVLTree.Add(new AVL());

                    if (firstStart == false)
                    {
                        ConnectTreeAndDraw(listClassAVLTree[0], MainTreeFirst);
                    }

                    GeometryGraph MainTreeMain = MainTree[0];
                    AVL listClassAVLTreeMain = listClassAVLTree[0];

                    MainTree = new List<GeometryGraph>();
                    listClassAVLTree = new List<AVL>();

                    MainTree.Add(new GeometryGraph());
                    listClassAVLTree.Add(new AVL());

                    listClassAVLTree[0] = listClassAVLTreeMain;
                    MainTree[0] = MainTreeMain;


                    Delete(val, listClassAVLTree[0]);
                    ConnectTreeAndDraw(listClassAVLTree[0], MainTree[0]);

                    panelDrawTree1.Visible = true;

                    textBoxDeleteNode.Text = "";
                    panelDrawTree1.Refresh();
                    firstStart = false;
                }
                else
                {
                    MessageBox.Show("Данного значения нет в дереве!", "Error");
                    textBoxAddNode.Text = "";
                }
                
            }
            else
            {
                MessageBox.Show("Вы ввели неверное значение", "Error");
                textBoxDeleteNode.Text = "";
            }
        }

        private void ConnectTreeAndDraw(AVL ClassTree, GeometryGraph Tree)
        {
            Tree.Edges.Clear();
            Tree.Nodes.Clear();

            if (ClassTree.root == null)
            {
                return;
            }
            DrawNode(ClassTree.root, Tree);
            DrawNodeConnections(ClassTree.root, Tree);
            //Зададим основные настройки макета
            var settings = new SugiyamaLayoutSettings
            {
                //Установим стиль отображения рёбер
                EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.StraightLine }
            };
            //Создадим макет с заданными настройками из данных объекта
            var layout = new LayeredLayout(Tree, settings);
            layout.Run();
        }

        private void DrawNode(NodeTree current, GeometryGraph treeA)
        {
            if (current != null)
            {
                DrawNode(current.right, treeA);
                DrawNode(current.left, treeA);
                MainDraw.AddNode(current.data.ToString(), treeA, radius);
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
       



        private void panelDrawTree_SizeChanged(object sender, EventArgs e)
        {
            //Перерисуем дерево, если размер панели визуального представления изменился
            panelDrawTree1.Invalidate();
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
        public bool Find(int key, AVL avltree)
        {
            if (Find(key, avltree.root) != null)
            {
                if (Find(key, avltree.root).data == key)
                {
                    Console.WriteLine("{0} was found!", key);
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Nothing found!");
                return false;
            }
            return false;
        }
        private NodeTree Find(int target, NodeTree current)
        {
            if (current == null)
            {
                return current;
            }

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
                {
                    return Find(target, current.right);
                }
                    
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
            MainTree.Add(new GeometryGraph());
            listClassAVLTree.Add(new AVL());
            listClassAVLTree[listClassAVLTree.Count - 1] = listClassAVLTree[0];
            ConnectTreeAndDraw(listClassAVLTree[listClassAVLTree.Count - 1], MainTree[listClassAVLTree.Count - 1]);


            Console.WriteLine("--------------RotateRR--------------");
            NodeTree pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;

            return pivot;
        }
        private NodeTree RotateLL(NodeTree parent)
        {

            MainTree.Add(new GeometryGraph());
            listClassAVLTree.Add(new AVL());
            listClassAVLTree[listClassAVLTree.Count - 1] = listClassAVLTree[0];
            ConnectTreeAndDraw(listClassAVLTree[listClassAVLTree.Count - 1], MainTree[listClassAVLTree.Count - 1]);

            Console.WriteLine("--------------RotateLL--------------");
            NodeTree pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;

            return pivot;
        }
        private NodeTree RotateLR(NodeTree parent)
        {

            MainTree.Add(new GeometryGraph());
            listClassAVLTree.Add(new AVL());
            MainTree.Add(new GeometryGraph());
            listClassAVLTree.Add(new AVL());


            listClassAVLTree[listClassAVLTree.Count - 1] = listClassAVLTree[0];
            ConnectTreeAndDraw(listClassAVLTree[listClassAVLTree.Count - 1], MainTree[listClassAVLTree.Count - 1]);


            Console.WriteLine("--------------RotateLR--------------");
            NodeTree pivot = parent.left;

            //parent.left = RotateRR(pivot);
            NodeTree pivot2 = pivot.right;
            pivot.right = pivot2.left;
            pivot2.left = pivot;
            parent.left = pivot2;


            listClassAVLTree[listClassAVLTree.Count - 2] = listClassAVLTree[0];
            ConnectTreeAndDraw(listClassAVLTree[listClassAVLTree.Count - 2], MainTree[listClassAVLTree.Count - 2]);

            //return RotateLL(parent);
            NodeTree pivot3 = parent.left;
            parent.left = pivot3.right;
            pivot3.right = parent;

            return pivot3;

        }
        private NodeTree RotateRL(NodeTree parent)
        {

            MainTree.Add(new GeometryGraph());
            listClassAVLTree.Add(new AVL());
            MainTree.Add(new GeometryGraph());
            listClassAVLTree.Add(new AVL());

            listClassAVLTree[listClassAVLTree.Count - 1] = listClassAVLTree[0];
            ConnectTreeAndDraw(listClassAVLTree[listClassAVLTree.Count - 1], MainTree[listClassAVLTree.Count - 1]);

            Console.WriteLine("--------------RotateRL--------------");
            NodeTree pivot = parent.right;

            //parent.right = RotateLL(pivot);
            NodeTree pivot2 = pivot.left;
            pivot.left = pivot2.right;
            pivot2.right = pivot;
            parent.right = pivot2;

            listClassAVLTree[listClassAVLTree.Count - 2] = listClassAVLTree[0];
            ConnectTreeAndDraw(listClassAVLTree[listClassAVLTree.Count - 2], MainTree[listClassAVLTree.Count - 2]);

            //return RotateRR(parent);
            NodeTree pivot3 = parent.right;
            parent.right = pivot3.left;
            pivot3.left = parent;
            return pivot3;
        }
        ///////////////////////////////////////////////////////

        public class AVL
        {
            public class NodeTree           //узел АВЛ-дерева
            {
                public int data;            //данные хранящиеся а узле
                public NodeTree left;       //левый сосед узла
                public NodeTree right;      //правый сосед узла
                public NodeTree(int data)
                {
                    this.data = data;
                }
            }
            public NodeTree root;           //корень


            public AVL()
            {
            }


        }
        private void panelDrawTree_Paint(object sender, PaintEventArgs e)
        {

            if (firstStart == false)
            {
                e.Graphics.DrawRectangle(new Pen(Color.White, this.Height / 1), 0, 1, this.Width, this.Height / 1);
                if (MainTreeFirst != null) MainDraw.DrawFromTree(panelDrawTree1.ClientRectangle, MainTreeFirst, e.Graphics);
                System.Threading.Thread.Sleep(speedDraw);
            }

            //При каждой отрисовке панели также отобразим на ней дерево  
            for (int i = listClassAVLTree.Count - 1; i > -1; i--)
            {
                e.Graphics.DrawRectangle(new Pen(Color.White, this.Height / 1), 0, 1, this.Width, this.Height / 1);
                if (MainTree[i] != null) MainDraw.DrawFromTree(panelDrawTree1.ClientRectangle, MainTree[i], e.Graphics);
                System.Threading.Thread.Sleep(speedDraw);
            }

        }

        private void buttonTestCase_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < aaraytestCase.Length; i++)
            //{
            //    textBoxAddNode.Text = (aaraytestCase[i]).ToString();
            //    buttonAddNode_Click(null, null);
            //    textBoxAddNode.Text = "";
            //}

            using (StreamReader sr = new StreamReader("file.txt"))  //считываем данные из файла
            {
                string numbers = sr.ReadLine();     //присваевываем построчно данные из файла в переменную
                foreach (var number in numbers.Split()) //разделяем числа по пробелам
                {
                    if (int.TryParse(number, out int val))  //проверяем число ли данное значение
                    {
                        numberFromFile.Add(int.Parse(number));  //добавляем число в список
                    }

                }
            }
            foreach (var number in numberFromFile)  //проходим весь список с элементами
            {
                Console.WriteLine(number);
                textBoxAddNode.Text = (number).ToString();  //записываем каждое число в поле для вставки элемента
                buttonAddNode_Click(null, null);      //нажимаем кнопку для вставки элемента
                textBoxAddNode.Text = "";   //очищаем поле для вставки
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelDrawTree1.Refresh();
        }

        private void radioButtonSpeed1_CheckedChanged(object sender, EventArgs e)
        {
            speedDraw = 100;
        }

        private void radioButtonSpeed2_CheckedChanged(object sender, EventArgs e)
        {
            speedDraw = 1000;
        }

        private void radioButtonSpeed3_CheckedChanged(object sender, EventArgs e)
        {
            speedDraw = 2000;
        }


    }
}