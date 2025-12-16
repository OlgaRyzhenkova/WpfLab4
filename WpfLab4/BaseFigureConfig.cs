using System;
using System.Windows.Controls;

namespace WpfLab4
{
    public abstract class BaseFigureConfig : UserControl
    {
        public abstract Figure CreateFigure();

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