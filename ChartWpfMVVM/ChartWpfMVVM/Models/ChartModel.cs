using ChartWpfMVVM.WpfLibrary;
using ChartWpfMVVM.WpfLibrary.Interpolators;
using System.Windows;
using System.Windows.Media;

namespace ChartWpfMVVM.Models
{
    public class ChartModel : ICanvasChartDrawer
    {
        public enum xChartType
        {
            None, Analog, Discret
        };

        public xChartType ChartType { get; set; }
        public ICanvasChartComponent ChartComponent { get; set; }
        public CanvasChartSettings Settings { get; set; }
        public ICanvasChartInterpolator XAxisInterpolator { get; set; }
        public ICanvasChartInterpolator YAxisInterpolator { get; set; }
        public Brush Brush { get; set; }
        public Pen Pen { get; set; }

        public List<Point> PointsListAnalog1 = new List<Point>();
        public List<Point> PointsListAnalog2 = new List<Point>();

        public ChartModel()
        {
            ChartType = xChartType.None;

            Settings = new CanvasChartSettings();

            Settings.CoordYSteps = 1;
            //Settings.CoordXSteps = 1;

            Settings.MaxXZoomStep = 200.0f;
            Settings.MaxYZoomStep = 200.0f;

            Settings.HandleSizeChanged = false;
            Settings.FontSize = 4;

            Settings.PenForAxis = new Pen(new BrushConverter().ConvertFromString("#66000000") as Brush, 0.3);
            Settings.PenForGrid = new Pen(new BrushConverter().ConvertFromString("#CC000000") as Brush, 0.5);

            XAxisInterpolator = new CanvasChartIntInterpolator();
            YAxisInterpolator = new CanvasChartIntInterpolator();

            Brush = Brushes.Blue;
            Pen = new Pen(Brush, 1);

            Brush.Freeze();
            Pen.Freeze();

            ChartComponent = new CanvasChartComponent();
            ChartComponent.Init(((MainWindow)Application.Current.MainWindow).AnalogCanvas,
                ((MainWindow)Application.Current.MainWindow).HorizScroll,
                ((MainWindow)Application.Current.MainWindow).VertScroll,
                this, Settings, XAxisInterpolator, YAxisInterpolator);
            ChartComponent.SetMinMax(-1, 1, -1, 1);
            ChartComponent.DrawChart();
        }

        public void Draw(DrawingContext ctx)
        {
            switch (ChartType)
            {
                case xChartType.Analog:
                    DrawAnalog(ctx);
                    break;
                case xChartType.Discret:
                    DrawDiscret(ctx);
                    break;
                default:
                    // do nothing
                    break;
            }
        }

        public void OnChartMouseDown(double x, double y)
        {

        }

        public void OnChartMouseOver(double x, double y)
        {

        }

        private void DrawAnalog(DrawingContext ctx)
        {
            //Слелать не только для pointsListAnalog1
            //if (PointsListAnalog1.Count != 0)
            //{
            //    DrawAnalog(PointsListAnalog1, ctx);
            //}
            //if (PointsListAnalog2.Count != 0)
            //{
            //    DrawAnalog(PointsListAnalog2, ctx);
            //}
            if (PointsListAnalog1.Count != 0)
            {
                Point start1 = ChartComponent.Point2ChartPoint(PointsListAnalog1[0]);
                for (int i = 1; i < PointsListAnalog1.Count; i++)
                {
                    Point end1 = ChartComponent.Point2ChartPoint(PointsListAnalog1[i]);
                    ctx.DrawLine(Pen, start1, end1);
                    start1 = end1;
                }
            }
            if (PointsListAnalog2.Count != 0)
            {
                Point start2 = ChartComponent.Point2ChartPoint(PointsListAnalog2[0]);
                for (int i = 1; i < PointsListAnalog2.Count; i++)
                {
                    Point end2 = ChartComponent.Point2ChartPoint(PointsListAnalog2[i]);
                    ctx.DrawLine(Pen, start2, end2);
                    start2 = end2;
                }
            }
        }
        private void DrawAnalog(List<Point> pointsList, DrawingContext ctx)
        {

            Point start = ChartComponent.Point2ChartPoint(pointsList[0]);
            for (int i = 1; i < pointsList.Count; i++)
            {
                Point end = ChartComponent.Point2ChartPoint(pointsList[i]);
                ctx.DrawLine(Pen, start, end);
                start = end;
            }

        }
        //private void DrawAnalog2(List<Point> pointsList, DrawingContext ctx)
        //{

        //    Point start1 = ChartComponent.Point2ChartPoint(pointsList[0]);
        //    for (int i = 1; i < PointsListAnalog1.Count; i++)
        //    {
        //        Point end1 = ChartComponent.Point2ChartPoint(pointsList[i]);
        //        ctx.DrawLine(Pen, start1, end1);
        //        start1 = end1;
        //    }

        //}


        private void DrawDiscret(DrawingContext ctx)
        {

        }
    }
}
