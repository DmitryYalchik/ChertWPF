using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using ChartWpfMVVM.WpfLibrary.Interpolators;

namespace ChartWpfMVVM.WpfLibrary
{
    public interface ICanvasChartComponent : IDisposable
    {
        void Init(Canvas canvas, ScrollBar horizScrollBar, ScrollBar vertScrollBar, ICanvasChartDrawer drawer,
            CanvasChartSettings settings, ICanvasChartInterpolator xAxisInterpolator, ICanvasChartInterpolator yAxisInterpolator);
        void SetMinMax(double minX, double maxX, double minY, double maxY);
        void DrawChart();
        Point Point2ChartPoint(Point p);
        Point ChartPoint2Point(Point p);
    }
}
