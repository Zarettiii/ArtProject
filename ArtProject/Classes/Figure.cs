using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ArtProject.Classes
{
    public abstract class Figure
    {
        public int XSize = 100;
        public int YSize = 50;                               

        public Rectangle Rectangle = new Rectangle();            

        public abstract void Create(Canvas canvas, int xPosition, int yPosition);

        public void ChangePosition(int xPosition, int yPosition)
        {
            var position = new Thickness
            {
                Left = xPosition - XSize/2,
                Top = yPosition - YSize/2
            };
            Rectangle.Margin = position;            
        }
    }

    public class SolidRectangle : Figure
    {
        public override void Create(Canvas canvas, int xPosition, int yPosition)
        {            
            var position = new Thickness();        
            Rectangle.Stroke = Brushes.Black;            
            Rectangle.Width = XSize;
            Rectangle.Height = YSize;
            position.Left = xPosition - XSize / 2;
            position.Top = yPosition - YSize / 2;
            Rectangle.Margin = position;
            canvas.Children.Add(Rectangle);          
        }
    }

    public class DottedLineRectangle : Figure
    {
        public override void Create(Canvas canvas, int xPosition, int yPosition)
        {            
            var position = new Thickness();
            Rectangle.Stroke = Brushes.DodgerBlue;
            Rectangle.Width = XSize;
            Rectangle.Height = YSize;
            position.Left = xPosition - XSize / 2;
            position.Top = yPosition - YSize / 2;
            Rectangle.Margin = position;
            canvas.Children.Add(Rectangle);
        }        
    }
}
