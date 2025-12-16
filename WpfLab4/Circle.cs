using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
namespace WpfLab4
{
    public class Circle : Figure
    {
        public double Radius;
        public Circle(double x, double y, double r)
        {
            CenterX = x;
            CenterY = y;
            Radius = r;

            Ellipse elips = new Ellipse();
            elips.Width = r * 2;
            elips.Height = r * 2;
            elips.StrokeThickness = 2;

            WpfShape = new Ellipse { Width = r * 2, Height = r * 2, StrokeThickness = 2 };
            UpdatePosition();
        }
        public override void UpdatePosition()
        {
            Canvas.SetLeft(WpfShape, CenterX - Radius);
            Canvas.SetTop(WpfShape, CenterY - Radius);
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
        // Для кола половина ширини і висоти - це Радіус
        public override double GetHalfWidth() { return Radius; }
        public override double GetHalfHeight() { return Radius; }
    }
}
