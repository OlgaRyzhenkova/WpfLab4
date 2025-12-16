using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLab4
{
    public partial class RhombConfig : BaseFigureConfig
    {
        public RhombConfig() { InitializeComponent(); }

        public override Figure CreateFigure()
        {
            return new Rhomb(GetDouble(tbX.Text), GetDouble(tbY.Text),
                             GetDouble(tbH.Text), GetDouble(tbV.Text));
        }
        public override void SetDefaultCoords(double x, double y)
        {
            tbX.Text = x.ToString();
            tbY.Text = y.ToString();
        }
    }
}
