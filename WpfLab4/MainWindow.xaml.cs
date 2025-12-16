using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfLab4
{
    public partial class MainWindow : Window
    {
        List<Figure> figureList = new List<Figure>();
        Figure selectedFigure = null;
        BaseFigureConfig currentConfig = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this);
            cbType_SelectionChanged(null, null);
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ConfigContainer == null || MyCanvas == null || cbType == null) return;

            if (cbType.SelectedItem == null) return;
            string tag = ((ComboBoxItem)cbType.SelectedItem).Tag.ToString();

            if (tag == "Circle") currentConfig = new CircleConfig();
            else if (tag == "Square") currentConfig = new SquareConfig();
            else if (tag == "Rhomb") currentConfig = new RhombConfig();

            double centerX = MyCanvas.ActualWidth / 2;
            double centerY = MyCanvas.ActualHeight / 2;

            if (centerX == 0) centerX = 250;
            if (centerY == 0) centerY = 200;

            if (currentConfig != null)
            {
                currentConfig.SetDefaultCoords(centerX, centerY);
            }

            ConfigContainer.Content = currentConfig;

            Keyboard.Focus(this);
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (currentConfig != null)
            {
                Figure newFig = currentConfig.CreateFigure();

                figureList.Add(newFig);
                MyCanvas.Children.Add(newFig.WpfShape);
                newFig.DrawBlack();

                SelectFigure(newFig);
            }
            Keyboard.Focus(this);
        }

        private void MyCanvas_Click(object sender, MouseButtonEventArgs e)
        {
            object clickedObject = e.OriginalSource;
            foreach (Figure f in figureList)
            {
                if (f.WpfShape == clickedObject)
                {
                    SelectFigure(f);
                    break;
                }
            }
            Keyboard.Focus(this);
        }

        private void SelectFigure(Figure fig)
        {
            if (selectedFigure != null)
                ((Shape)selectedFigure.WpfShape).Stroke = Brushes.Black;

            selectedFigure = fig;

            if (selectedFigure != null)
                ((Shape)selectedFigure.WpfShape).Stroke = Brushes.Blue;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedFigure != null)
            {
                MyCanvas.Children.Remove(selectedFigure.WpfShape);
                figureList.Remove(selectedFigure);
                selectedFigure = null;
            }
            Keyboard.Focus(this);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectedFigure == null) return;

            double step = 10;

            if (e.Key == Key.Left)
            {
                selectedFigure.Move(-step, 0);
                e.Handled = true;
            }
            else if (e.Key == Key.Right)
            {
                selectedFigure.Move(step, 0);
                e.Handled = true;
            }
            else if (e.Key == Key.Up)
            {
                selectedFigure.Move(0, -step);
                e.Handled = true;
            }
            else if (e.Key == Key.Down)
            {
                selectedFigure.Move(0, step);
                e.Handled = true;
            }
        }
    }
}