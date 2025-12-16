using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace WpfLab4
{
    public abstract class Figure
    {
        public double CenterX;
        public double CenterY;

        // Картинка фігури (для Canvas)
        public UIElement WpfShape;

        public abstract void DrawBlack();
        public abstract void HideDrawingBackGround();
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
            HideDrawingBackGround();
            CenterX += dx;        
            CenterY += dy;         
            UpdatePosition();      
            DrawBlack();            
        }
    }
}
