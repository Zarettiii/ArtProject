using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ArtProject.Classes
{
    public abstract class LineClass
    {
        public Line line = new Line();   

        public int BeginPointIndex;
        public int? EndPointIndex = null;

        public abstract void Create(Canvas canvas, int beginIndex, int xPosition, int yPosition);

        public void ChangeBeginPosition(int xPosition, int yPosition)
        {
            line.X1 = xPosition;
            line.Y1 = yPosition;
        }

        public void ChangeEndPosition(int xPosition, int yPosition)
        {
            line.X2 = xPosition;
            line.Y2 = yPosition;
        }     
    }

    public class SolidLine : LineClass
    {
        public override void Create(Canvas canvas, int beginIndex, int xPosition, int yPosition)
        {
            BeginPointIndex = beginIndex;
            line.Stroke = Brushes.Black;
            line.X1 = xPosition;
            line.Y1 = yPosition;
            line.X2 = xPosition;
            line.Y2 = yPosition;
            canvas.Children.Add(line);
        }
    }
}
