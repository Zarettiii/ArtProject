using System.Linq;
using System.Windows;
using System.Windows.Input;
using ArtProject.Classes;

namespace ArtProject
{
    public partial class MainWindow : Window
    {
        private PaintField _paintField = new PaintField();
        private DragDetector _drag = new DragDetector();
        private LineDetector _makeLine = new LineDetector();

        public MainWindow()
        {
            InitializeComponent();
            _paintField.Canvas = cnvPaintPanel;
            cbElement.Items.Add("Прямоугольник");
            cbElement.Items.Add("Прямоугольник (пунктир)");
            cbElement.Items.Add("Соединительная линия");
        }

        private void cnvPaintPanel_MouseMove(object sender, MouseEventArgs e)
        {
            var position = new Point(e.GetPosition(cnvPaintPanel).X, e.GetPosition(cnvPaintPanel).Y);

            if (_makeLine.IsActive)
            {
                if (_makeLine.ItemIndex != null)
                    _paintField.Lines[(int)_makeLine.ItemIndex].ChangeEndPosition((int)position.X, (int)position.Y);
                return;
            }
            if (_drag.IsActive)
            {
                if (_drag.ItemIndex != null)
                    _paintField.ChangeRectanglePosition((int)_drag.ItemIndex, position);
            }
        }

        private void cnvPaintPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var position = new Point(e.GetPosition(cnvPaintPanel).X, e.GetPosition(cnvPaintPanel).Y);

            if (cbElement.Text == "Соединительная линия")
            {
                var newLine = new SolidLine();
                var beginIndex = (int)_paintField.RectangleClick(position);
                _paintField.CreateNewLine(newLine, beginIndex);
                _makeLine.IsActive = true;
                _makeLine.ItemIndex = _paintField.Lines.Count() - 1;
            }
            else
            {
                if (_paintField.RectangleClick(position) != null)
                {
                    _drag.ItemIndex = _paintField.RectangleClick(position);
                    _drag.IsActive = true;
                    return;
                }

                if (cbElement.Text == "Прямоугольник")
                {
                    var newRectangle = new SolidRectangle();
                    _paintField.CreateNewFigure(newRectangle, position);
                }
                if (cbElement.Text == "Прямоугольник (пунктир)")
                {
                    var newRectangle = new DottedLineRectangle();
                    _paintField.CreateNewFigure(newRectangle, position);
                }
            }          
        }

        private void cnvPaintPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var position = new Point(e.GetPosition(cnvPaintPanel).X, e.GetPosition(cnvPaintPanel).Y);

            _drag.IsActive = false;

            if (_makeLine.IsActive)
            {
                if (_paintField.RectangleClick(position) != null)
                {
                    if (_makeLine.ItemIndex != null)
                        _paintField.SetLineEndPoint((int)_makeLine.ItemIndex, (int)_paintField.RectangleClick(position));
                }
                else
                {
                    cnvPaintPanel.Children.Remove(_paintField.Lines[(int)_makeLine.ItemIndex].line);            
                    _paintField.Lines.RemoveAt((int)_makeLine.ItemIndex);
                }
                _makeLine.IsActive = false;
            }
        }
    }
}
