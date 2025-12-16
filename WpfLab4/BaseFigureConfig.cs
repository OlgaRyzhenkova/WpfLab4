using System;
using System.Windows.Controls;

namespace WpfLab4
{
    public abstract class BaseFigureConfig : UserControl
    {
        public abstract Figure CreateFigure();
        // Метод, щоб встановити координати з головного вікна
        public abstract void SetDefaultCoords(double x, double y);

        protected double GetDouble(string text)
        {
            try 
            { 
                return Convert.ToDouble(text); 
            } 
            catch 
            { 
                return 0; 
            }
        }
    }
}