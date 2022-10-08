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
        private GeometryGraph gGraph;
        private int[] massAVL = {1,2,3};
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddNode_Click(object sender, EventArgs e)
        {
            
            var numberNode = textBoxAddNode.Text;
            gGraph = null;
            //Очистим панель с графическим представлением дерева
            panelDrawTree.CreateGraphics();
            //Вызовем вспомогательную функцию для графического представления дерева
            gGraph = CreateAndLayoutGraph();
            textBoxAddNode.Text = "";
            //Перерисуем панель, где отображается дерево
            panelDrawTree.Refresh();
        }
        //Вспомогательная функция создания макета и наполнения данных для графического представления дерева
        private GeometryGraph CreateAndLayoutGraph()
        {
            //Инициализируем объект, хранящий данные для графического представления дерева
            GeometryGraph graph = new GeometryGraph();
            //Установим радиус вершин
            double radius = 10;
            //Добавим в объект каждую вершину из списка смежности
            foreach (var itam in massAVL)
            {
                DrawHelpers.AddNode(itam.ToString(), graph, radius);
            }

            //Добавим в объект каждое ребро из списка смежности
            //foreach (var item in massAVL)
            //{
            //    graph.Edges.Add(new Edge(graph.FindNodeByUserData(massAVL[0].ToString()), graph.FindNodeByUserData(massAVL[1].ToString())));
            //    graph.Edges.Add(new Edge(graph.FindNodeByUserData(massAVL[0].ToString()), graph.FindNodeByUserData(massAVL[2].ToString())));
            //}
            //Зададим основные настройки макета
            var settings = new SugiyamaLayoutSettings
            {
                //Повернём макет на 180 градусов, чтобы дерево строилось сверху вниз
                Transformation = PlaneTransformation.Rotation(Math.PI),
                //Установим стиль отображения рёбер
                EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.StraightLine }
            };
            //Создадим макет с заданными настройками из данных объекта
            var layout = new LayeredLayout(graph, settings);
            layout.Run();

            return graph;
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panelDrawTree_Paint(object sender, PaintEventArgs e)
        {
            //При каждой отрисовке панели также отобразим на ней дерево
            if (gGraph != null) DrawHelpers.DrawFromGraph(panelDrawTree.ClientRectangle, gGraph, e.Graphics);
        }

        private void panelDrawTree_SizeChanged(object sender, EventArgs e)
        {
            //Перерисуем дерево, если размер панели визуального представления изменился
            panelDrawTree.Invalidate();
        }
    }
}
