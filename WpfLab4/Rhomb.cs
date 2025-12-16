using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace WpfLab4
{
    public class Rhomb : Figure
    {
        public double HorDiagLen;
        public double VertDiagLen;

        public Rhomb(double x, double y, double h, double v)
        {
            CenterX = x;
            CenterY = y;
            HorDiagLen = h;
            VertDiagLen = v;

            Polygon poly = new Polygon();
            poly.StrokeThickness = 2;

            WpfShape = poly;
            UpdatePosition();
        }

        public override void UpdatePosition()
        {
            if (WpfShape is Polygon poly)
            {
                PointCollection points = new PointCollection();

                points.Add(new Point(CenterX, CenterY - VertDiagLen / 2));
                points.Add(new Point(CenterX + HorDiagLen / 2, CenterY));
                points.Add(new Point(CenterX, CenterY + VertDiagLen / 2));
                points.Add(new Point(CenterX - HorDiagLen / 2, CenterY));

                poly.Points = points;
            }
        }

        public override void DrawBlack()
        {
            ((Shape)WpfShape).Stroke = Brushes.Black;
            ((Shape)WpfShape).Fill = Brushes.Black;
        }

        public override void HideDrawingBackGround()
        {
            ((Shape)WpfShape).Stroke = Brushes.Transparent;
            ((Shape)WpfShape).Fill = Brushes.Transparent;
        }
    }
}