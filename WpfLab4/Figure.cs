using System.Windows;
using System.Windows.Controls;

namespace WpfLab4
{
    public abstract class Figure
    {
        public double CenterX;
        public double CenterY;
        public UIElement WpfShape;

        public abstract void DrawBlack();
        public abstract void HideDrawingBackGround();

        //  методи для отримання розмірів
        public abstract double GetHalfWidth();
        public abstract double GetHalfHeight();

        public virtual void UpdatePosition()
        {
            if (WpfShape != null)
            {
                Canvas.SetLeft(WpfShape, CenterX);
                Canvas.SetTop(WpfShape, CenterY);
            }
        }

        public void Move(double dx, double dy)
        {
            var shape = WpfShape as FrameworkElement;
            var canvas = shape?.Parent as FrameworkElement;

            if (canvas == null) return; 

            double nextX = CenterX + dx;
            double nextY = CenterY + dy;

            double hw = GetHalfWidth();
            double hh = GetHalfHeight();

            if (nextX - hw < 0) return; 
            if (nextY - hh < 0) return; 
            if (nextX + hw > canvas.ActualWidth) return; 
            if (nextY + hh > canvas.ActualHeight) return; 

            HideDrawingBackGround();
            CenterX = nextX;
            CenterY = nextY;
            UpdatePosition();
            DrawBlack();
        }
    }
}