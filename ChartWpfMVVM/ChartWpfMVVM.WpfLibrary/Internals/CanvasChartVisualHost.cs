using System.Windows.Media;
using System.Windows;

namespace ChartWpfMVVM.WpfLibrary.Internals
{
    internal class CanvasChartVisualHost : FrameworkElement
    {
        private VisualCollection children;
        private DrawingVisual drawingVisual;

        public CanvasChartVisualHost()
        {
            this.ClipToBounds = true;
            drawingVisual = new DrawingVisual();
            children = new VisualCollection(this);
            children.Add(drawingVisual);
        }

        public DrawingVisual Drawing { get { return drawingVisual; } }

        protected override int VisualChildrenCount
        {
            get { return children.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= children.Count)
                throw new ArgumentOutOfRangeException();

            return children[index];
        }
    }
}
