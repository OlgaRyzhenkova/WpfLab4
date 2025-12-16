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
        // Кожна фігура сама скаже, скільки місця вона займає від центру до краю
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
            // 1. Отримуємо доступ до Canvas (полотна), щоб знати його розміри
            var canvas = WpfShape.Parent as FrameworkElement;
            if (canvas == null) return; // Якщо фігури ще немає на екрані - не рухаємо

            // 2. Рахуємо, де фігура БУДЕ, якщо ми її посунемо
            double nextX = CenterX + dx;
            double nextY = CenterY + dy;

            // 3. Дізнаємося розміри фігури (через поліморфізм)
            double hw = GetHalfWidth();  // Половина ширини
            double hh = GetHalfHeight(); // Половина висоти

            // 4. ПЕРЕВІРКА МЕЖ (Collision Detection)

            // Якщо лівий край виходить за 0 -> заборонити
            if (nextX - hw < 0) return;

            // Якщо верхній край виходить за 0 -> заборонити
            if (nextY - hh < 0) return;

            // Якщо правий край виходить за ширину екрану -> заборонити
            if (nextX + hw > canvas.ActualWidth) return;

            // Якщо нижній край виходить за висоту екрану -> заборонити
            if (nextY + hh > canvas.ActualHeight) return;

            // 5. Якщо все ок - виконуємо рух
            HideDrawingBackGround();
            CenterX = nextX;
            CenterY = nextY;
            UpdatePosition();
            DrawBlack();
        }
    }
}
