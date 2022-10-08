using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Point = Microsoft.Msagl.Core.Geometry.Point;

namespace AVLTree
{
    class DrawHelpers
    {
        //Отрисовка графа в пределах размеров области clientRectangle элемента управления
        //на основе данных из объекта geometryGraph MSAGL на поверхности рисования graphics элемента управления
        public static void DrawFromGraph(Rectangle clientRectangle, GeometryGraph geometryGraph, Graphics graphics)
        {
            //Подготовка трансформации графа под область для отрисовки
            SetGraphTransform(geometryGraph, clientRectangle, graphics);
            //Инициализируем инструмент рисования
            var pen = new Pen(Brushes.Black);
            //Нарисуем вершины графа
            DrawNodes(geometryGraph, pen, graphics);
            //Нарисуем рёбра графа
            DrawEdges(geometryGraph, pen, graphics);
        }

        public static void SetGraphTransform(GeometryGraph geometryGraph, Rectangle rectangle, Graphics graphics)
        {
            RectangleF clientRectangle = rectangle;
            var gr = geometryGraph.BoundingBox;
            if (clientRectangle.Height > 1 && clientRectangle.Width > 1)
            {
                var scale = Math.Min(clientRectangle.Width * 0.9 / gr.Width, clientRectangle.Height * 0.9 / gr.Height);
                var g0 = (gr.Left + gr.Right) / 2;
                var g1 = (gr.Top + gr.Bottom) / 2;

                var c0 = (clientRectangle.Left + clientRectangle.Right) / 2;
                var c1 = (clientRectangle.Top + clientRectangle.Bottom) / 2;
                var dx = c0 - scale * g0;
                var dy = c1 - scale * g1;

                graphics.Transform = new Matrix((float)scale, 0, 0, (float)scale, (float)dx, (float)dy);
            }
        }

        public static void DrawNodes(GeometryGraph geometryGraph, Pen pen, Graphics graphics)
        {
            foreach (Node n in geometryGraph.Nodes)
                DrawNode(n, pen, graphics);
        }

        static void DrawEdges(GeometryGraph geometryGraph, Pen pen, Graphics graphics)
        {
            foreach (Edge e in geometryGraph.Edges)
                DrawEdge(e, pen, graphics);
        }

        public static void DrawNode(Node n, Pen pen, Graphics graphics)
        {
            ICurve curve = n.BoundaryCurve;
            Ellipse el = curve as Ellipse;
            if (el != null)
            {
                graphics.DrawEllipse(pen, new RectangleF((float)el.BoundingBox.Left, (float)el.BoundingBox.Bottom,
                    (float)el.BoundingBox.Width, (float)el.BoundingBox.Height));
                graphics.DrawString(n.UserData.ToString(), new Font(FontFamily.GenericSansSerif, (float)9), Brushes.Black, new PointF((float)(el.Center.X - 2 - el.BoundingBox.Width / 4), (float)(el.Center.Y - el.BoundingBox.Height / 3)));
            }
            else
                graphics.DrawPath(pen, CreateGraphicsPath(curve));
        }

        static void DrawEdge(Edge e, Pen pen, Graphics graphics)
        {
            graphics.DrawPath(pen, CreateGraphicsPath(e.Curve));
        }

        internal static GraphicsPath CreateGraphicsPath(ICurve iCurve)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            if (iCurve == null)
                return null;
            Curve c = iCurve as Curve;
            if (c != null)
            {
                foreach (ICurve seg in c.Segments)
                {
                    CubicBezierSegment cubic = seg as CubicBezierSegment;
                    if (cubic != null)
                        graphicsPath.AddBezier(PointF(cubic.B(0)), PointF(cubic.B(1)), PointF(cubic.B(2)), PointF(cubic.B(3)));
                    else
                    {
                        LineSegment ls = seg as LineSegment;
                        if (ls != null)
                            graphicsPath.AddLine(PointF(ls.Start), PointF(ls.End));

                        else
                        {
                            Ellipse el = seg as Ellipse;
                            if (el != null)
                            {
                                graphicsPath.AddArc((float)(el.Center.X - el.AxisA.X), (float)(el.Center.Y - el.AxisB.Y), (float)(el.AxisA.X * 2), Math.Abs((float)el.AxisB.Y * 2), EllipseStartAngle(el), EllipseSweepAngle(el));

                            }
                        }
                    }
                }
            }
            else
            {
                var ls = iCurve as LineSegment;
                if (ls != null)
                    graphicsPath.AddLine(PointF(ls.Start), PointF(ls.End));
            }

            return graphicsPath;
        }

        static PointF PointF(Point point)
        {
            return new PointF((float)point.X, (float)point.Y);
        }

        public static float EllipseSweepAngle(Ellipse el)
        {
            return (float)((el.ParEnd - el.ParStart) / Math.PI * 180);
        }

        public static float EllipseStartAngle(Ellipse el)
        {
            return (float)(el.ParStart / Math.PI * 180);
        }

        public static void AddNode(string id, GeometryGraph graph, double radius)
        {
            if (graph.FindNodeByUserData(id) == null)
                graph.Nodes.Add(new Node(CreateCurve(radius), id));
        }

        public static ICurve CreateCurve(double radius)
        {
            return CurveFactory.CreateCircle(radius, new Point());
        }
    }
}
