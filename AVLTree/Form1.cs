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
        private int[] massAVL = { 1, 2, 3 };
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddNode_Click(object sender, EventArgs e)
        {
            //Подготовим данные перед вызовом формы заполнения матрицы смежности
            var size = textBoxAddNode.Text;
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
            //Инициализируем объект, хранящий данные для графического представления дерева
            GeometryGraph Tree = new GeometryGraph();
            //Установим радиус вершин
            double radius = 10;
            //Добавим в объект каждую вершину из списка смежности
            foreach (var itam in massAVL)
            {
                DrawHelpers.AddNode(itam.ToString(), Tree, radius);
            }

            

            //Добавим в объект каждое ребро из списка смежности
            foreach (var item in massAVL)
            {
                Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(massAVL[0].ToString()), Tree.FindNodeByUserData(massAVL[1].ToString())));
                draw(Tree);
                Tree.Edges.Add(new Edge(Tree.FindNodeByUserData(massAVL[0].ToString()), Tree.FindNodeByUserData(massAVL[2].ToString())));
                draw(Tree);
            }
            
            

            return Tree;
        }
        private void draw(GeometryGraph tree)
        {
            //Зададим основные настройки макета
            var settings = new SugiyamaLayoutSettings
            {
                //Повернём макет на 180 градусов, чтобы дерево строилось сверху вниз
                Transformation = PlaneTransformation.Rotation(Math.PI),
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
    }
}
