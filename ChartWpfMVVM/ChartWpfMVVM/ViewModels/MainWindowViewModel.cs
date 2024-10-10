using ChartWpfMVVM.Commands;
using ChartWpfMVVM.ViewModels.Base;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ChartWpfMVVM.WpfLibrary;
using ChartWpfMVVM.WpfLibrary.Interpolators;
using ChartWpfMVVM.Models;

namespace ChartWpfMVVM.ViewModels
{

    public class MainWindowViewModel : ViewModelBase//, ICanvasChartDrawer
    {
        enum ChartType
        {
            None, Analog, Discret
        };

        //private ICanvasChartComponent? cc1 = null; //
        //private Pen pen1 = new Pen(Brushes.Red, 1);
        //private Brush brush1 = Brushes.Red;
        //private CanvasChartSettings settings1; //
        //private ChartType chartType = ChartType.None;
        //private ICanvasChartInterpolator xAxisInterpolator1;
        //private ICanvasChartInterpolator yAxisInterpolator1;
        //
        //private ICanvasChartComponent? cc2 = null; //
        //private Pen pen2 = new Pen(Brushes.Blue, 1);
        //private Brush brush2 = Brushes.Blue;
        //private CanvasChartSettings settings2; //
        //private ICanvasChartInterpolator xAxisInterpolator2;
        //private ICanvasChartInterpolator yAxisInterpolator2;

        private List<Point> pointsListAnalog1 = new List<Point>(); //
        private List<Point> pointsListAnalog2 = new List<Point>(); //
        private List<Point> pointsListAnalog3 = new List<Point>(); //

        private Point currentMin = new Point(-1,-1);
        private Point currentMax = new Point(1,1);


        private ChartModel chartAnalog1;
        private ChartModel chartAnalog2;

        public MainWindowViewModel()
        {
            textValueAnalog1 = "value:";

            chartAnalog2 = new ChartModel();
            chartAnalog1 = new ChartModel();


            

            //settings1 = new CanvasChartSettings();
            //settings1.CoordYSteps = 1;
            //settings1.MaxXZoomStep = 200.0f;
            //settings1.MaxYZoomStep = 200.0f;
            //pen1.Freeze();
            //brush1.Freeze();
            //settings1.HandleSizeChanged = false;
            //settings1.FontSize = 4;
            //settings1.PenForGrid = new Pen((Brush)new BrushConverter().ConvertFromString("#66000000"), 0.3);
            //settings1.PenForAxis = new Pen((Brush)new BrushConverter().ConvertFromString("#CC000000"), 0.5);
            //xAxisInterpolator1 = new CanvasChartIntInterpolator();
            //yAxisInterpolator1 = new CanvasChartFloatInterpolator();
            //cc1 = new CanvasChartComponent();
            //cc1.Init(((MainWindow)Application.Current.MainWindow).AnalogCanvas,
            //    ((MainWindow)Application.Current.MainWindow).HorizScroll,
            //    ((MainWindow)Application.Current.MainWindow).VertScroll,
            //    this, settings1, xAxisInterpolator1, yAxisInterpolator1);
            //cc1.SetMinMax(-1, 1, -1, 1);
            //cc1.DrawChart();
            //
            //settings2 = new CanvasChartSettings();
            //settings2.CoordYSteps = 1;
            //settings2.MaxXZoomStep = 200.0f;
            //settings2.MaxYZoomStep = 200.0f;
            //pen2.Freeze();
            //brush2.Freeze();
            //settings2.HandleSizeChanged = false;
            //settings2.FontSize = 4;
            //settings2.PenForGrid = new Pen((Brush)new BrushConverter().ConvertFromString("#66000000"), 0.3);
            //settings2.PenForAxis = new Pen((Brush)new BrushConverter().ConvertFromString("#CC000000"), 0.5);
            //xAxisInterpolator2 = new CanvasChartIntInterpolator();
            //yAxisInterpolator2 = new CanvasChartFloatInterpolator();
            //cc2 = new CanvasChartComponent();
            //cc2.Init(((MainWindow)Application.Current.MainWindow).AnalogCanvas,
            //    ((MainWindow)Application.Current.MainWindow).HorizScroll,
            //    ((MainWindow)Application.Current.MainWindow).VertScroll,
            //    this, settings2, xAxisInterpolator1, yAxisInterpolator1);
            //cc2.SetMinMax(-1, 1, -1, 1);
            //cc2.DrawChart();
        }

        //public void Draw(DrawingContext ctx)
        //{
        //    switch (chartType)
        //    {
        //        case ChartType.Analog:
        //            DrawAnalog(ctx);
        //            break;
        //        case ChartType.Discret:
        //            DrawDiscret(ctx);
        //            break;
        //        default:
        //            // do nothing
        //            break;
        //    }
        //}
        //private void DrawAnalog(DrawingContext ctx)
        //{
        //    //Слелать не только для pointsListAnalog1
        //    if (pointsListAnalog1.Count != 0)
        //    {
        //        Point start1 = cc1.Point2ChartPoint(pointsListAnalog1[0]);
        //        for (int i = 1; i < pointsListAnalog1.Count; i++)
        //        {
        //            Point end1 = cc1.Point2ChartPoint(pointsListAnalog1[i]);
        //            ctx.DrawLine(pen1, start1, end1);
        //            start1 = end1;
        //        }
        //    }
        //    if (pointsListAnalog2.Count != 0)
        //    {
        //        Point start2 = cc2.Point2ChartPoint(pointsListAnalog2[0]);
        //        for (int i = 1; i < pointsListAnalog2.Count; i++)
        //        {
        //            Point end2 = cc2.Point2ChartPoint(pointsListAnalog2[i]);
        //            ctx.DrawLine(pen2, start2, end2);
        //            start2 = end2;
        //        }
        //    }
        //}
        private void DrawDiscret(DrawingContext ctx)
        {

        }

        public void OnChartMouseDown(double x, double y)
        {

        }

        public void OnChartMouseOver(double x, double y)
        {
            
        }

        private void MinMaxChanged(List<Point> listPoint)
        {
            Point min = listPoint[0];
            Point max = listPoint[0];

            foreach (var point in listPoint)
            {
                min.X = Math.Min(min.X, point.X); // time = -1
                max.X = Math.Max(max.X, point.X);
                min.Y = Math.Min(min.Y, point.Y);
                max.Y = Math.Max(max.Y, point.Y);
            }

            if (min.X < currentMin.X)
            {
                currentMin.X = min.X;
                currentMin.X = currentMin.X - 1;
            }
            if (max.X > currentMax.X)
            {
                currentMax.X = max.X;
                currentMax.X = currentMax.X + 1;
            }
            if (min.Y < currentMin.Y)
            {
                currentMin.Y = min.Y;
                currentMin.Y = currentMin.Y - 1;
            }
            if (max.Y > currentMax.Y)
            {
                currentMax.Y = max.Y;
                currentMax.Y = currentMax.Y + 1;
            }

            //cc1?.SetMinMax(currentMin.X, currentMax.X, currentMin.Y, currentMax.Y);
            //cc2?.SetMinMax(currentMin.X, currentMax.X, currentMin.Y, currentMax.Y);
            chartAnalog1.ChartComponent?.SetMinMax(currentMin.X, currentMax.X, currentMin.Y, currentMax.Y);
            chartAnalog2.ChartComponent?.SetMinMax(currentMin.X, currentMax.X, currentMin.Y, currentMax.Y);
        }
        private void Refresh()
        {
            //cc1?.DrawChart();
            //cc2?.DrawChart();

            chartAnalog2.ChartComponent?.DrawChart();
            chartAnalog1.ChartComponent?.DrawChart();
        }

        #region textValueAnalog1 : string? - значение Analog1
        /// <summary>Fields - значение Analog1</summary>
        private string? textValueAnalog1;
        /// <summary>Properties - значение Analog1</summary>
        public string? TextValueAnalog1 { get => textValueAnalog1; set => Set(ref textValueAnalog1, value); }
        #endregion

        #region Command - AnalogChart1Command

        /// <summary>AnalogChart1Command</summary>
        private LambdaCommand? _AnalogChart1Command;

        /// <summary>AnalogChart1Command</summary>
        public ICommand AnalogChart1Command => _AnalogChart1Command ??= new(OnAnalogChart1CommandExecuted);
        
        /// <summary>Логика выполнения - AnalogChart1Command</summary>        
        private void OnAnalogChart1CommandExecuted(object? p)
        {
            chartAnalog1.Settings.CoordYSteps = 1;
            chartAnalog1.ChartType = ChartModel.xChartType.Analog;

            chartAnalog1.Brush = Brushes.Brown;
            chartAnalog1.Pen = new Pen(chartAnalog1.Brush, 1);

            chartAnalog1.PointsListAnalog1.Clear();

            int count = 10; // размер массива данных

            for (int i = 0; i < count; ++i)
            {
                chartAnalog1.PointsListAnalog1.Add(new Point(ArrayValueRPM.arrayTime[i], ArrayValueRPM.arrayAnalog1[i]));
            }

            MinMaxChanged(chartAnalog1.PointsListAnalog1);
            Refresh();

            //settings1.CoordYSteps = 1;
            //chartType = ChartType.Analog;

            //brush1 = Brushes.Brown;
            //pen1 = new Pen(brush1, 1);

            //pointsListAnalog1.Clear();

            //int count = 10; // размер массива данных

            //for (int i = 0; i < count; ++i)
            //{
            //    pointsListAnalog1.Add(new Point(ArrayValueRPM.arrayTime[i], ArrayValueRPM.arrayAnalog1[i]));
            //}

            //MinMaxChanged(pointsListAnalog1);
            //Refresh();
        }

        #endregion

        #region Command - AnalogChart2Command

        /// <summary>AnalogChart2Command</summary>
        private LambdaCommand? _AnalogChart2Command;

        /// <summary>AnalogChart2Command</summary>
        public ICommand AnalogChart2Command => _AnalogChart2Command ??= new(OnAnalogChart2CommandExecuted);

        
        /// <summary>
        /// Логика выполнения - AnalogChart2Command
        /// </summary>
        private void OnAnalogChart2CommandExecuted(object? p)
        {
            chartAnalog2.Settings.CoordYSteps = 1;
            chartAnalog2.ChartType = ChartModel.xChartType.Analog;

            chartAnalog2.Brush = Brushes.Aquamarine;
            chartAnalog2.Pen = new Pen(chartAnalog2.Brush, 1);

            chartAnalog2.PointsListAnalog2.Clear();

            int count = 10; // размер массива данных

            for (int i = 0; i < count; ++i)
            {
                chartAnalog2.PointsListAnalog2.Add(new Point(ArrayValueRPM.arrayTime[i], ArrayValueRPM.arrayAnalog2[i]));
            }

            MinMaxChanged(chartAnalog2.PointsListAnalog2);
            Refresh();

            //brush1 = Brushes.Transparent;
            //pen1 = new Pen(brush1, 1);

            //settings2.CoordYSteps = 1;
            //chartType = ChartType.Analog;

            //brush2 = Brushes.Aquamarine;
            //pen2 = new Pen(brush2, 1);

            //pointsListAnalog2.Clear();

            //int count = 10; // размер массива данных

            //for (int i = 0; i < count; ++i)
            //{
            //    pointsListAnalog2.Add(new Point(ArrayValueRPM.arrayTime[i], ArrayValueRPM.arrayAnalog2[i]));
            //}

            //MinMaxChanged(pointsListAnalog2);
            //Refresh();
            
        }

        #endregion

        #region Command - AnalogChart3Command

        /// <summary>AnalogChart3Command</summary>
        private LambdaCommand? _AnalogChart3Command;

        /// <summary>AnalogChart3Command</summary>
        public ICommand AnalogChart3Command => _AnalogChart3Command ??= new(OnAnalogChart3CommandExecuted);

        /// <summary>Логика выполнения - AnalogChart3Command</summary>
        private void OnAnalogChart3CommandExecuted(object? p)
        {

        }

        #endregion
    }
}
