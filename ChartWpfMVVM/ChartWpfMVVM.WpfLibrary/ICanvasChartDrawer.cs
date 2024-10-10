using System.Windows.Media;

namespace ChartWpfMVVM.WpfLibrary
{
    public interface ICanvasChartDrawer
    {
        void Draw(DrawingContext ctx);
        void OnChartMouseDown(double x, double y);
        void OnChartMouseOver(double x, double y);
    }
}
