using ChartWpfMVVM.ClassLibrary.Interpolators;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace ChartWpfMVVM.ClassLibrary
{
    public interface ICanvasChartComponent : IDisposable
    {
        void Init(Canvas canvas, ScrollBar horizScrollBar, ScrollBar vertScrollBar, ICanvasChartDrawer drawer,
            WPFCanvasChartSettings settings, IWPFCanvasChartInterpolator xAxisInterpolator, IWPFCanvasChartInterpolator yAxisInterpolator);
        void SetMinMax(double minX, double maxX, double minY, double maxY);
        void DrawChart();
        Point Point2ChartPoint(Point p);
        Point ChartPoint2Point(Point p);
    }
}
