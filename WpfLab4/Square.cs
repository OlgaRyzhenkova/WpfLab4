using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace WpfLab4
{
    public class Square : Figure
    {
        public double SideLength;
        public Square(double x, double y, double side)
        {
            CenterX = x;
            CenterY = y;
            SideLength = side;

            Rectangle rect = new Rectangle();
            rect.Width = side;
            rect.Height = side;
            rect.StrokeThickness = 2;

            WpfShape = new Rectangle { Width = side, Height = side, StrokeThickness = 2 };
            UpdatePosition();
        }
        public override void UpdatePosition()
        {
            Canvas.SetLeft(WpfShape, CenterX - SideLength / 2);
            Canvas.SetTop(WpfShape, CenterY - SideLength / 2);
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
        public override double GetHalfWidth() { return SideLength / 2; }
        public override double GetHalfHeight() { return SideLength / 2; }
    }
}
