using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ArtProject.Classes
{
    public class PaintField
    {
        public Canvas Canvas { get; set; }
        public List<Figure> Figures = new List<Figure>();
        public List<LineClass> Lines = new List<LineClass>();

        public void CreateNewFigure(Figure newFigure, Point position)
        {
            newFigure.Create(Canvas, (int)position.X, (int)position.Y);
            Figures.Add(newFigure);            
        }

        public void CreateNewLine(LineClass newLine, int beginIndex)
        {
            var xPosition = (int)Figures[beginIndex].Rectangle.Margin.Left + Figures[beginIndex].XSize / 2;
            var yPosition = (int)Figures[beginIndex].Rectangle.Margin.Top + Figures[beginIndex].YSize / 2; ;
            newLine.Create(Canvas, beginIndex, xPosition, yPosition);
            Lines.Add(newLine);
        }

        public int? RectangleClick(Point position)
        {
            foreach (var item in Figures)
            {
                if (position.X > item.Rectangle.Margin.Left && position.X < item.Rectangle.Margin.Left + item.XSize &&
                    position.Y > item.Rectangle.Margin.Top && position.Y < item.Rectangle.Margin.Top + item.YSize)
                {
                    return Figures.IndexOf(item);
                }               
            }
            return null;
        }

        public void ChangeRectanglePosition(int itemIndex, Point position)
        {
            Figures[itemIndex].ChangePosition((int)position.X, (int)position.Y);
            foreach (var item in Lines)
            {
                if (item.BeginPointIndex == itemIndex)
                {
                    item.ChangeBeginPosition((int)position.X, (int)position.Y);
                }
                if (item.EndPointIndex == itemIndex)
                {
                    item.ChangeEndPosition((int)position.X, (int)position.Y);
                }
            }
        }

        public void SetLineEndPoint(int itemIndex, int endPointIndex)
        {
            Lines[itemIndex].EndPointIndex = endPointIndex;
            var xPosition = (int)Figures[endPointIndex].Rectangle.Margin.Left + (int)Figures[endPointIndex].XSize / 2;
            var yPosition = (int)Figures[endPointIndex].Rectangle.Margin.Top + (int)Figures[endPointIndex].YSize / 2;
            Lines[itemIndex].ChangeEndPosition(xPosition, yPosition);
        }
    }
}
